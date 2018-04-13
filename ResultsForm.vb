Imports System.IO

''' <summary>
''' ToDo: https://support.microsoft.com/en-us/help/319399/how-to-sort-a-listview-control-by-a-column-in-visual-basic-net-or-in-v
''' </summary>
Public Class frmResults
    Private Const vbQuote As String = """"

    Private Enum FileInfoElement As Integer
        FullName = 0
        CreationDate = 1
        LastModifiedDate = 2
        LastAccessDate = 3
        Size = 4
    End Enum

    Private _sPathName As String = vbNullString
    Private _sFilespec() As String
    Private _bIncludeSubDirs As Boolean = False
    Private _sTextToFind As String = vbNullString
    Private _bIgnoreTextCase As Boolean
    Private _sDateCreatedFrom As String = vbNullString
    Private _sDateCreatedTo As String = vbNullString
    Private _sDateModifiedFrom As String = vbNullString
    Private _sDateModifiedTo As String = vbNullString
    Private _sDateLastAccessedFrom As String = vbNullString
    Private _sDateLastAccessedTo As String = vbNullString
    Private _bStopNow As Boolean = False
    Private _nFilesFound As Long = 0
    Private _dirDepth As Integer = 0
    Private _sFileList As New List(Of String)

    Private Sub form_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Not used per the compiler, but works anyway
        Me.CheckForIllegalCrossThreadCalls = False

        With Me.lstResults
            .Items.Clear()
            .View = System.Windows.Forms.View.Details
        End With
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        _bStopNow = True
        FinishUp()
    End Sub

    Private Sub FinishUp()
        UpdateStatus(vbNullString)
        btnStop.Enabled = False
        _sFileList.Clear()

        btnExport.Enabled = lstResults.Items.Count > 0
    End Sub

    Public Sub FindFiles()
        _bStopNow = False
        _nFilesFound = 0
        _dirDepth = 0
        Dim myThread As System.Threading.Thread

        myThread = New System.Threading.Thread(AddressOf DirSearch)
        myThread.Start()
    End Sub

    Public Sub Setup(
                    ByVal sPathName As String,
                    ByVal sFilespec As String,
                    ByVal bIncludeSubDirs As Boolean,
                    ByVal sTextToFind As String,
                    ByVal bIgnoreTextCase As Boolean,
                    ByVal sDateCreatedFrom As String,
                    ByVal sDateCreatedTo As String,
                    ByVal sDateModifiedFrom As String,
                    ByVal sDateModifiedTo As String,
                    ByVal sDateLastAccessedFrom As String,
                    ByVal sDateLastAccessedTo As String)

        With Me
            ._sPathName = sPathName
            ._bIncludeSubDirs = bIncludeSubDirs
            ._sTextToFind = sTextToFind
            ._bIgnoreTextCase = bIgnoreTextCase
            ._sDateCreatedFrom = sDateCreatedFrom + vbNullString
            ._sDateCreatedTo = sDateCreatedTo + vbNullString
            ._sDateModifiedFrom = sDateModifiedFrom + vbNullString
            ._sDateModifiedTo = sDateModifiedTo + vbNullString
            ._sDateLastAccessedFrom = sDateLastAccessedFrom + vbNullString
            ._sDateLastAccessedTo = sDateLastAccessedTo + vbNullString
            .Show()
        End With

        IdentifyFileSpecs(sFilespec)

    End Sub

    ''' <summary>
    ''' Searches through a directory for files matching a provided file
    ''' specification.
    ''' </summary>
    ''' <param name="sDir">The directory to search through.</param>
    Private Sub DirSearch(Optional ByVal sDir As String = vbNullString)
        If _bStopNow Then
            Exit Sub
        End If

        Dim f As String
        Dim fileInfo(5) As String

        ' To support multi-threading we could not always pass the
        ' directory to this routine.
        If sDir = vbNullString Then
            sDir = _sPathName
        End If

        _dirDepth += 1
        UpdateStatus("Searching " + sDir)

        Dim lvItem As ListViewItem
        For i As Integer = LBound(_sFilespec) To UBound(_sFilespec)
            For Each f In Directory.GetFiles(sDir, _sFilespec(i))
                If _bStopNow Then
                    GoTo ExitPoint
                End If
                Dim bGoodFile As Boolean = True

                ' Ensure this file is not already in our list
                bGoodFile = Not IsFileInList(f)

                If bGoodFile Then
                    fileInfo = GetTextForOutput(f)

                    If Len(_sDateCreatedFrom) > 0 And bGoodFile Then
                        bGoodFile = IsDateBetween(fileInfo(FileInfoElement.CreationDate),
                                                  _sDateCreatedFrom, _sDateCreatedTo)
                    End If
                    If Len(_sDateModifiedFrom) > 0 And bGoodFile Then
                        bGoodFile = IsDateBetween(fileInfo(FileInfoElement.LastModifiedDate),
                                                  _sDateModifiedFrom, _sDateModifiedTo)
                    End If
                    If Len(_sDateLastAccessedFrom) > 0 And bGoodFile Then
                        bGoodFile = IsDateBetween(fileInfo(FileInfoElement.LastAccessDate),
                                                  _sDateLastAccessedFrom, _sDateLastAccessedTo)
                    End If
                    If Len(_sTextToFind) > 0 Then
                        bGoodFile = FoundTextInFile(f)
                    End If
                    If bGoodFile Then
                        _nFilesFound += 1
                        lvItem = New ListViewItem(fileInfo)
                        lstResults.Items.Add(lvItem)
                        lstResults.Items(CInt(_nFilesFound - 1)).EnsureVisible()
                        _sFileList.Add(f)
                    End If
                End If
            Next
        Next

        Try
            If _bIncludeSubDirs Then
                Dim d As String
                For Each d In Directory.GetDirectories(sDir)
                    DirSearch(d)
                Next
            End If
        Catch ex As System.Exception
            ' We  may have a 'permission denied' message, so just
            ' ignore it and continue on. Or path too long. Or ...
            Debug.WriteLine(ex.Message)
        End Try

ExitPoint:
        _dirDepth -= 1

        If _dirDepth < 1 Then
            FinishUp()
        End If
    End Sub

    Private Function IsFileInList(ByVal sFile As String) As Boolean
        IsFileInList = False

        For Each sItem As String In _sFileList
            If _sFileList.Contains(sFile) Then
                IsFileInList = True
                Exit For
            End If
        Next
    End Function

    Private Function IsDateBetween(ByVal dtDate As Date, ByVal dtDateFrom As Date, ByVal dtDateTo As Date)
        If dtDate.CompareTo(dtDateFrom) >= 0 And dtDate.CompareTo(dtDateTo) <= 0 Then
            IsDateBetween = True
        Else
            IsDateBetween = False
        End If
    End Function

    Private Function FoundTextInFile(ByVal sFile As String) As Boolean
        FoundTextInFile = False

        Dim oStreamReader As StreamReader = Nothing
        Dim sLineText As String = vbNullString
        Dim sStatusText As String
        Dim sTextToFind As String
        Dim nLinesSearched As Long

        If _bIgnoreTextCase Then
            sTextToFind = _sTextToFind.ToLower
        Else
            sTextToFind = _sTextToFind
        End If

        nLinesSearched = 0
        Try
            oStreamReader = New StreamReader(sFile)
            ' Read the first line to support our Do loop
            sLineText = oStreamReader.ReadLine
            Do While Not sLineText Is Nothing
                If _bStopNow Then
                    Exit Do
                End If

                nLinesSearched += 1
                sStatusText = Format$(nLinesSearched, "000,000") +
                        " lines looked at so far in" + vbQuote + sFile + vbQuote
                UpdateStatus(sStatusText)

                If _bIgnoreTextCase Then
                    If sLineText.ToLower.Contains(sTextToFind) Then
                        FoundTextInFile = True
                        Exit Do
                    End If
                Else
                    If sLineText.Contains(sTextToFind) Then
                        FoundTextInFile = True
                        Exit Do
                    End If
                End If

                ' Read the next line.
                sLineText = oStreamReader.ReadLine
            Loop
        Catch ex As Exception
            Debug.WriteLine(ex)
        End Try

        Try
            If Not oStreamReader Is Nothing Then
                oStreamReader.Close()
            End If
        Catch ex As Exception
            ' do not care cause we're just trying to ensure the file is closed.
            Debug.WriteLine(ex)
        End Try

    End Function

    Private Sub IdentifyFileSpecs(ByVal sItem As String)
        If IsNothing(sItem) Or Len(sItem) < 1 Then
            ReDim _sFilespec(1)
            _sFilespec(0) = "*.*"
        Else
            _sFilespec = sItem.Split(";")
        End If

    End Sub

    Private Function GetTextForOutput(ByVal filePath As String) As String()
        ' Verify that the file exists.
        If My.Computer.FileSystem.FileExists(filePath) = False Then
            Throw New Exception("File Not Found: " & filePath)
        End If

        Dim str(5) As String

        ' Obtain file information.
        Dim thisFile As System.IO.FileInfo = My.Computer.FileSystem.GetFileInfo(filePath)

        ' Add file attributes.
        str(FileInfoElement.FullName) = thisFile.FullName
        str(FileInfoElement.CreationDate) = thisFile.CreationTime.ToString("yyyy-MM-dd")
        str(FileInfoElement.LastModifiedDate) = thisFile.LastWriteTime.ToString("yyyy-MM-dd")
        str(FileInfoElement.LastAccessDate) = thisFile.LastAccessTime.ToString("yyyy-MM-dd")
        str(FileInfoElement.Size) = thisFile.Length.ToString

        GetTextForOutput = str

    End Function

    Private Sub UpdateStatus(ByVal sText As String)
        lblCurrent.Text = sText
    End Sub

    Private Sub UpdateExportStatus(ByVal num As Long)
        If num < 0 Then
            lblCurrent.Text = "Export is complete."
        Else
            lblCurrent.Text = num.ToString
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToFile()
    End Sub

    Private Sub ExportToFile()
        btnExport.Enabled = False

        Using saveDlg As New SaveFileDialog
            saveDlg.DefaultExt = "csv"
            saveDlg.OverwritePrompt = True
            saveDlg.Filter = "txt files (*.csv;*.txt)|*.csv;*.txt|All files (*.*)|*.*"
            saveDlg.FilterIndex = 1
            saveDlg.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            If saveDlg.ShowDialog() = DialogResult.OK Then
                Dim objStreamWriter As StreamWriter
                Dim sLineText As String = vbNullString
                objStreamWriter = New StreamWriter(saveDlg.FileName)

                sLineText = "File" + vbTab + "Created" + vbTab + "Modified" + vbTab + "Last Accessed" + vbTab + "Size"
                objStreamWriter.WriteLine(sLineText)

                Dim listItemCount As Long = lstResults.Items.Count
                For Each lvItem As ListViewItem In lstResults.Items
                    'lvItem.Focused = True
                    'lvItem.Selected = True
                    UpdateStatus("Exporting - please wait -- " + Format("000", listItemCount))
                    listItemCount = listItemCount - 1
                    sLineText = vbNullString
                    For Each lvCell As ListViewItem.ListViewSubItem In lvItem.SubItems
                        sLineText = sLineText + lvCell.Text + vbTab
                    Next
                    sLineText = sLineText.Remove(sLineText.Length - vbTab.Length, vbTab.Length)      ' Remove the tab at the end of the line.
                    objStreamWriter.WriteLine(sLineText)
                Next
                objStreamWriter.Close()
                UpdateStatus("Export is complete!")
            End If
        End Using
        btnExport.Enabled = True
    End Sub

    Private Sub frmResults_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Const sMsgText As String = "Are you sure that you would like to close the results?"
        Dim sMsgCaption As String = Application.ProductName + " -- Results"
        Dim sMsgResult As DialogResult

        sMsgResult = MessageBox.Show(sMsgText, sMsgCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If (sMsgResult = DialogResult.No) Then
            ' cancel the closure of the form.
            e.Cancel = True
        End If
    End Sub
End Class
