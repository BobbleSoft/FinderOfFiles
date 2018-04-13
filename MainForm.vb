Public Class frmMain

    ''' <summary>
    ''' Called when the form is first loaded.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub form_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReadUserSettings()

        Me.Text = Application.ProductName + " v" + Application.ProductVersion
    End Sub

    Private Sub form_closing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        SaveUserSettings()
    End Sub

    Private Sub ReadUserSettings()
        Dim sVal As String
        Dim iValX As Integer
        Dim iValY As Integer

        ' Position the main form
        iValX = My.Settings.MainFormPositionX
        If iValX < 0 Then iValX = 100
        iValY = My.Settings.MainFormPositionY
        If iValY < 0 Then iValY = 100
        Me.Location = New Point(x:=iValX, y:=iValY)

        ' Set the Starting Folder
        sVal = My.Settings.StartingFolder
        If IsNothing(sVal) Or Len(sVal) < 1 Then
            ' Pre-fill the starting directory with the user's "MyDocuments" folder.
            txtStartDir.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        Else
            txtStartDir.Text = sVal
        End If

        ' File Specifications
        sVal = My.Settings.FileSpecsToFind
        If IsNothing(sVal) Or Len(sVal) < 1 Then
            txtFileSpecs.Text = "*.mp3;*.ogg;*.wav"
        Else
            txtFileSpecs.Text = sVal
        End If

        ' Text to Find
        txtContents.Text = My.Settings.TextToFind & vbNullString

        ' Ignore Case of text to find
        chkIgnorCase.Checked = My.Settings.IgnoreCase

        ' Include Subdirectories
        chkIncludeSubDirs.Checked = My.Settings.IncludeSubFolders

        ' Creation Date
        sVal = My.Settings.DateCreatedFrom
        If Not IsNothing(sVal) And Len(sVal) > 0 Then
            dtpCreatedFrom.Value = CDate(sVal)
        End If
        sVal = My.Settings.DateCreatedTo
        If Not IsNothing(sVal) And Len(sVal) > 0 Then
            dtpCreatedTo.Value = CDate(sVal)
        End If

        ' Modified Date
        sVal = My.Settings.DateModifiedFrom
        If Not IsNothing(sVal) And Len(sVal) > 0 Then
            dtpModifiedFrom.Value = CDate(sVal)
        End If
        sVal = My.Settings.DateModifiedTo
        If Not IsNothing(sVal) And Len(sVal) > 0 Then
            dtpModifiedTo.Value = CDate(sVal)
        End If

        ' Last Accessed Date
        sVal = My.Settings.DateLastAccessedFrom
        If Not IsNothing(sVal) And Len(sVal) > 0 Then
            dtpLastAccessedFrom.Value = CDate(sVal)
        End If
        sVal = My.Settings.DateLastAccessedTo
        If Not IsNothing(sVal) And Len(sVal) > 0 Then
            dtpLastAccessedTo.Value = CDate(sVal)
        End If
    End Sub

    Private Sub SaveUserSettings()
        With My.Settings
            .MainFormPositionX = Me.Location.X
            .MainFormPositionY = Me.Location.Y
            .StartingFolder = txtStartDir.Text
            .IncludeSubFolders = chkIncludeSubDirs.Checked
            .FileSpecsToFind = txtFileSpecs.Text
            .TextToFind = txtContents.Text
            .IgnoreCase = chkIgnorCase.Checked
            .DateCreatedFrom = Format("yyyy-MM-dd", dtpCreatedFrom.Value)
            .DateCreatedTo = Format("yyyy-MM-dd", dtpCreatedTo.Value)
            .DateModifiedFrom = Format("yyyy-MM-dd", dtpModifiedFrom.Value)
            .DateModifiedTo = Format("yyyy-MM-dd", dtpModifiedTo.Value)
            .DateLastAccessedFrom = Format("yyyy-MM-dd", dtpLastAccessedFrom.Value)
            .DateLastAccessedTo = Format("yyyy-MM-dd", dtpLastAccessedTo.Value)
        End With
    End Sub

    ''' <summary>
    ''' Displays an 'About' box describing this application.
    ''' </summary>
    Public Sub ShowAboutBox()
        'Display the About dialog box
        Using objAbout As New AboutBox
            objAbout.ShowDialog(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Determines if the form values are valid enough that processing can begin.
    ''' </summary>
    ''' <returns>True if the form values are valid, otherwise False.</returns>
    Private Function FormIsValid() As Boolean
        Dim sMsg As String = vbNullString

        If Len(txtStartDir.Text) < 1 Then
            sMsg = "The starting folder cannot be empty"
        ElseIf Not DirIsReadable(txtStartDir.Text) Then
            sMsg = "The folder you specified does not exist, cannot be read, or is invalid"
        ElseIf Len(txtFileSpecs.Text) < 1 Then
            sMsg = "The file specification must be provided."
        End If

        ' If we have any kind of message then some type of error occurred.
        If Len(sMsg) > 0 Then
            FormIsValid = False
            MessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            FormIsValid = True
        End If
    End Function

    ''' <summary>
    ''' Determines if the directory specified is reachable. If it is a valid directory
    ''' but we do not have permission, then we trap a "permission denied" exception. If
    ''' the directory format is invalid (e.g., C:\MYDIR\D:) then that is trapped also.
    ''' </summary>
    ''' <param name="sDir">The directory (folder) to check for validity.</param>
    ''' <returns>True if the directory is readable, otherwise False.</returns>
    Private Function DirIsReadable(ByVal sDir As String) As Boolean
        Try
            DirIsReadable = System.IO.Directory.Exists(sDir)
        Catch ex As Exception
            DirIsReadable = False
            Debug.WriteLine(ex)
        End Try
    End Function

    ''' <summary>
    ''' Launches the process to begin searching for the files requested.
    ''' </summary>
    Private Sub StartFinding()
        If FormIsValid() Then
            Dim sDateCreatedFrom As String = vbNullString
            Dim sDateCreatedTo As String = vbNullString
            Dim sDateModifiedFrom As String = vbNullString
            Dim sDateModifiedTo As String = vbNullString
            Dim sDateLastAccessedFrom As String = vbNullString
            Dim sDateLastAccessedTo As String = vbNullString
            Dim objResults As New frmResults

            With Me
                If .chkDateCreated.Checked Then
                    sDateCreatedFrom = dtpCreatedFrom.Value.ToShortDateString
                    sDateCreatedTo = dtpCreatedTo.Value.ToShortDateString
                End If
                If .chkDateModified.Checked Then
                    sDateModifiedFrom = dtpModifiedFrom.Value.ToShortDateString
                    sDateModifiedTo = dtpModifiedTo.Value.ToShortDateString
                End If
                If .chkDateLastAccessed.Checked Then
                    sDateLastAccessedFrom = dtpLastAccessedFrom.Value.ToShortDateString
                    sDateLastAccessedTo = .dtpLastAccessedTo.Value.ToShortDateString
                End If
            End With

            With Me
                objResults.Setup(
                    .txtStartDir.Text,
                    .txtFileSpecs.Text,
                    .chkIncludeSubDirs.Checked,
                    .txtContents.Text,
                    .chkIgnorCase.Checked,
                    sDateCreatedFrom,
                    sDateCreatedTo,
                    sDateModifiedFrom,
                    sDateModifiedTo,
                    sDateLastAccessedFrom,
                    sDateLastAccessedTo)
            End With

            objResults.FindFiles()
        End If
    End Sub

    ''' <summary>
    ''' Presents the 'Browse for Folder' dialog box to t he user and saves the result, if
    ''' any, to our "starting directory" textbox.
    ''' </summary>
    Private Sub GetFolder()
        Dim sPath As String = vbNullString

        ' Set up and show the 'Browse for Folder' dialog.
        Using objFolderDialog As New FolderBrowserDialog
            With objFolderDialog
                .ShowNewFolderButton = False
                .Description = "Please select the folder to start searching at"
                If .ShowDialog() = DialogResult.OK Then
                    sPath = .SelectedPath
                End If
            End With
        End Using

        ' If the user clicked [Cancel] then we'll not have a path.
        If Len(sPath) > 0 Then
            Me.txtStartDir.Text = sPath
        End If
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        ShowAboutBox()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        SaveUserSettings()
        StartFinding()
    End Sub

    Private Sub btnBrowseForFolder_Click(sender As Object, e As EventArgs) Handles btnBrowseForFolder.Click
        GetFolder()
    End Sub
    Private Sub SwapDates(ByRef dtDate1 As Date, ByRef dtDate2 As Date)
        Dim dtDateTemp As Date
        dtDateTemp = dtDate1
        dtDate1 = dtDate2
        dtDate2 = dtDateTemp
    End Sub

    Private Sub dtpCreatedFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpCreatedFrom.ValueChanged
        If dtpCreatedFrom.Value.CompareTo(dtpCreatedTo.Value) > 0 Then
            SwapDates(dtpCreatedFrom.Value, dtpCreatedTo.Value)
        End If
    End Sub

    Private Sub dtpCreatedTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpCreatedTo.ValueChanged
        If dtpCreatedTo.Value.CompareTo(dtpCreatedFrom.Value) < 0 Then
            SwapDates(dtpCreatedFrom.Value, dtpCreatedTo.Value)
        End If
    End Sub

    Private Sub dtpModifiedFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpModifiedFrom.ValueChanged
        If dtpModifiedFrom.Value.CompareTo(dtpModifiedTo.Value) > 0 Then
            SwapDates(dtpModifiedFrom.Value, dtpModifiedTo.Value)
        End If
    End Sub

    Private Sub dtpModifiedTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpModifiedTo.ValueChanged
        If dtpModifiedTo.Value.CompareTo(dtpModifiedFrom.Value) < 0 Then
            SwapDates(dtpModifiedFrom.Value, dtpModifiedTo.Value)
        End If
    End Sub

    Private Sub dtpLastAccessedFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpLastAccessedFrom.ValueChanged
        If dtpLastAccessedFrom.Value.CompareTo(dtpLastAccessedTo.Value) > 0 Then
            SwapDates(dtpLastAccessedFrom.Value, dtpLastAccessedTo.Value)
        End If
    End Sub

    Private Sub dtpLastAccessedTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpLastAccessedTo.ValueChanged
        If dtpLastAccessedTo.Value.CompareTo(dtpLastAccessedFrom.Value) < 0 Then
            SwapDates(dtpLastAccessedFrom.Value, dtpLastAccessedTo.Value)
        End If
    End Sub

    Private Sub txtContents_TextChanged(sender As Object, e As EventArgs) Handles txtContents.TextChanged
        Select Case Len(txtContents.Text)
            Case 0
                lblCharacterCount.Text = vbNullString
            Case 1
                lblCharacterCount.Text = "(1 character)"
            Case Else       ' > 1
                lblCharacterCount.Text = "(" + CStr(Len(txtContents.Text)) + " characters)"
        End Select
    End Sub

    Private Sub txtStartDir_TextChanged(sender As Object, e As EventArgs) Handles txtStartDir.TextChanged
        If DirIsReadable(txtStartDir.Text) Then
            lblStartDirExist.Text = vbNullString
        Else
            lblStartDirExist.Text = "(does not exist)"
        End If
    End Sub

End Class
