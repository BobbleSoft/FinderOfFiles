<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblFilesToFind = New System.Windows.Forms.Label()
        Me.txtFileSpecs = New System.Windows.Forms.TextBox()
        Me.lblDatedCreated = New System.Windows.Forms.Label()
        Me.dtpCreatedFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateCreatedAnd = New System.Windows.Forms.Label()
        Me.dtpCreatedTo = New System.Windows.Forms.DateTimePicker()
        Me.dtpModifiedTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpModifiedFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDatedModified = New System.Windows.Forms.Label()
        Me.lblContents = New System.Windows.Forms.Label()
        Me.txtContents = New System.Windows.Forms.TextBox()
        Me.chkIgnorCase = New System.Windows.Forms.CheckBox()
        Me.chkDateCreated = New System.Windows.Forms.CheckBox()
        Me.chkDateModified = New System.Windows.Forms.CheckBox()
        Me.lblStartDir = New System.Windows.Forms.Label()
        Me.txtStartDir = New System.Windows.Forms.TextBox()
        Me.chkIncludeSubDirs = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.chkDateLastAccessed = New System.Windows.Forms.CheckBox()
        Me.dtpLastAccessedTo = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpLastAccessedFrom = New System.Windows.Forms.DateTimePicker()
        Me.lblDateAccessed = New System.Windows.Forms.Label()
        Me.btnBrowseForFolder = New System.Windows.Forms.Button()
        Me.lblCharacterCount = New System.Windows.Forms.Label()
        Me.lblStartDirExist = New System.Windows.Forms.Label()
        Me.lblFileSpecTip = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblFilesToFind
        '
        Me.lblFilesToFind.AutoSize = True
        Me.lblFilesToFind.Location = New System.Drawing.Point(12, 59)
        Me.lblFilesToFind.Name = "lblFilesToFind"
        Me.lblFilesToFind.Size = New System.Drawing.Size(89, 13)
        Me.lblFilesToFind.TabIndex = 0
        Me.lblFilesToFind.Text = "What files to find:"
        '
        'txtFileSpecs
        '
        Me.txtFileSpecs.Location = New System.Drawing.Point(143, 56)
        Me.txtFileSpecs.Name = "txtFileSpecs"
        Me.txtFileSpecs.Size = New System.Drawing.Size(200, 20)
        Me.txtFileSpecs.TabIndex = 3
        Me.txtFileSpecs.Text = "*.mp3;*.ogg;*.wav"
        '
        'lblDatedCreated
        '
        Me.lblDatedCreated.AutoSize = True
        Me.lblDatedCreated.Location = New System.Drawing.Point(11, 132)
        Me.lblDatedCreated.Name = "lblDatedCreated"
        Me.lblDatedCreated.Size = New System.Drawing.Size(116, 13)
        Me.lblDatedCreated.TabIndex = 3
        Me.lblDatedCreated.Text = "Date created between:"
        '
        'dtpCreatedFrom
        '
        Me.dtpCreatedFrom.Location = New System.Drawing.Point(143, 128)
        Me.dtpCreatedFrom.Name = "dtpCreatedFrom"
        Me.dtpCreatedFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpCreatedFrom.TabIndex = 6
        '
        'lblDateCreatedAnd
        '
        Me.lblDateCreatedAnd.Location = New System.Drawing.Point(349, 128)
        Me.lblDateCreatedAnd.Name = "lblDateCreatedAnd"
        Me.lblDateCreatedAnd.Size = New System.Drawing.Size(42, 20)
        Me.lblDateCreatedAnd.TabIndex = 5
        Me.lblDateCreatedAnd.Text = "and"
        Me.lblDateCreatedAnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpCreatedTo
        '
        Me.dtpCreatedTo.Location = New System.Drawing.Point(397, 128)
        Me.dtpCreatedTo.Name = "dtpCreatedTo"
        Me.dtpCreatedTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpCreatedTo.TabIndex = 7
        '
        'dtpModifiedTo
        '
        Me.dtpModifiedTo.Location = New System.Drawing.Point(397, 169)
        Me.dtpModifiedTo.Name = "dtpModifiedTo"
        Me.dtpModifiedTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpModifiedTo.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(349, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "and"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpModifiedFrom
        '
        Me.dtpModifiedFrom.Location = New System.Drawing.Point(143, 169)
        Me.dtpModifiedFrom.Name = "dtpModifiedFrom"
        Me.dtpModifiedFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpModifiedFrom.TabIndex = 9
        '
        'lblDatedModified
        '
        Me.lblDatedModified.AutoSize = True
        Me.lblDatedModified.Location = New System.Drawing.Point(12, 173)
        Me.lblDatedModified.Name = "lblDatedModified"
        Me.lblDatedModified.Size = New System.Drawing.Size(119, 13)
        Me.lblDatedModified.TabIndex = 7
        Me.lblDatedModified.Text = "Date modified between:"
        '
        'lblContents
        '
        Me.lblContents.AutoSize = True
        Me.lblContents.Location = New System.Drawing.Point(12, 95)
        Me.lblContents.Name = "lblContents"
        Me.lblContents.Size = New System.Drawing.Size(118, 13)
        Me.lblContents.TabIndex = 11
        Me.lblContents.Text = "Look inside the files for:"
        '
        'txtContents
        '
        Me.txtContents.Location = New System.Drawing.Point(143, 91)
        Me.txtContents.Name = "txtContents"
        Me.txtContents.Size = New System.Drawing.Size(200, 20)
        Me.txtContents.TabIndex = 4
        '
        'chkIgnorCase
        '
        Me.chkIgnorCase.AutoSize = True
        Me.chkIgnorCase.Location = New System.Drawing.Point(362, 91)
        Me.chkIgnorCase.Name = "chkIgnorCase"
        Me.chkIgnorCase.Size = New System.Drawing.Size(82, 17)
        Me.chkIgnorCase.TabIndex = 5
        Me.chkIgnorCase.Text = "Ignore case"
        Me.chkIgnorCase.UseVisualStyleBackColor = True
        '
        'chkDateCreated
        '
        Me.chkDateCreated.AutoSize = True
        Me.chkDateCreated.Location = New System.Drawing.Point(616, 131)
        Me.chkDateCreated.Name = "chkDateCreated"
        Me.chkDateCreated.Size = New System.Drawing.Size(103, 17)
        Me.chkDateCreated.TabIndex = 8
        Me.chkDateCreated.Text = "Use these dates"
        Me.chkDateCreated.UseVisualStyleBackColor = True
        '
        'chkDateModified
        '
        Me.chkDateModified.AutoSize = True
        Me.chkDateModified.Location = New System.Drawing.Point(616, 172)
        Me.chkDateModified.Name = "chkDateModified"
        Me.chkDateModified.Size = New System.Drawing.Size(103, 17)
        Me.chkDateModified.TabIndex = 11
        Me.chkDateModified.Text = "Use these dates"
        Me.chkDateModified.UseVisualStyleBackColor = True
        '
        'lblStartDir
        '
        Me.lblStartDir.AutoSize = True
        Me.lblStartDir.Location = New System.Drawing.Point(11, 20)
        Me.lblStartDir.Name = "lblStartDir"
        Me.lblStartDir.Size = New System.Drawing.Size(93, 13)
        Me.lblStartDir.TabIndex = 16
        Me.lblStartDir.Text = "Start searching at:"
        '
        'txtStartDir
        '
        Me.txtStartDir.Location = New System.Drawing.Point(143, 17)
        Me.txtStartDir.Name = "txtStartDir"
        Me.txtStartDir.Size = New System.Drawing.Size(200, 20)
        Me.txtStartDir.TabIndex = 1
        Me.txtStartDir.Text = "C:\Program Files"
        '
        'chkIncludeSubDirs
        '
        Me.chkIncludeSubDirs.AutoSize = True
        Me.chkIncludeSubDirs.Checked = True
        Me.chkIncludeSubDirs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIncludeSubDirs.Location = New System.Drawing.Point(397, 21)
        Me.chkIncludeSubDirs.Name = "chkIncludeSubDirs"
        Me.chkIncludeSubDirs.Size = New System.Drawing.Size(115, 17)
        Me.chkIncludeSubDirs.TabIndex = 2
        Me.chkIncludeSubDirs.Text = "Include sub-folders"
        Me.chkIncludeSubDirs.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(640, 12)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 15
        Me.btnOK.Text = "&Go!"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.Location = New System.Drawing.Point(640, 41)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(75, 23)
        Me.btnAbout.TabIndex = 17
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'chkDateLastAccessed
        '
        Me.chkDateLastAccessed.AutoSize = True
        Me.chkDateLastAccessed.Location = New System.Drawing.Point(616, 210)
        Me.chkDateLastAccessed.Name = "chkDateLastAccessed"
        Me.chkDateLastAccessed.Size = New System.Drawing.Size(103, 17)
        Me.chkDateLastAccessed.TabIndex = 14
        Me.chkDateLastAccessed.Text = "Use these dates"
        Me.chkDateLastAccessed.UseVisualStyleBackColor = True
        '
        'dtpLastAccessedTo
        '
        Me.dtpLastAccessedTo.Location = New System.Drawing.Point(397, 207)
        Me.dtpLastAccessedTo.Name = "dtpLastAccessedTo"
        Me.dtpLastAccessedTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpLastAccessedTo.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(349, 207)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "and"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'dtpLastAccessedFrom
        '
        Me.dtpLastAccessedFrom.Location = New System.Drawing.Point(143, 207)
        Me.dtpLastAccessedFrom.Name = "dtpLastAccessedFrom"
        Me.dtpLastAccessedFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpLastAccessedFrom.TabIndex = 12
        '
        'lblDateAccessed
        '
        Me.lblDateAccessed.AutoSize = True
        Me.lblDateAccessed.Location = New System.Drawing.Point(11, 211)
        Me.lblDateAccessed.Name = "lblDateAccessed"
        Me.lblDateAccessed.Size = New System.Drawing.Size(126, 13)
        Me.lblDateAccessed.TabIndex = 24
        Me.lblDateAccessed.Text = "Date accessed between:"
        '
        'btnBrowseForFolder
        '
        Me.btnBrowseForFolder.AutoSize = True
        Me.btnBrowseForFolder.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBrowseForFolder.Location = New System.Drawing.Point(349, 17)
        Me.btnBrowseForFolder.Name = "btnBrowseForFolder"
        Me.btnBrowseForFolder.Size = New System.Drawing.Size(26, 23)
        Me.btnBrowseForFolder.TabIndex = 27
        Me.btnBrowseForFolder.Text = "..."
        Me.btnBrowseForFolder.UseVisualStyleBackColor = True
        '
        'lblCharacterCount
        '
        Me.lblCharacterCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        Me.lblCharacterCount.Location = New System.Drawing.Point(143, 111)
        Me.lblCharacterCount.Name = "lblCharacterCount"
        Me.lblCharacterCount.Size = New System.Drawing.Size(196, 17)
        Me.lblCharacterCount.TabIndex = 28
        '
        'lblStartDirExist
        '
        Me.lblStartDirExist.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        Me.lblStartDirExist.Location = New System.Drawing.Point(143, 37)
        Me.lblStartDirExist.Name = "lblStartDirExist"
        Me.lblStartDirExist.Size = New System.Drawing.Size(194, 13)
        Me.lblStartDirExist.TabIndex = 29
        '
        'lblFileSpecTip
        '
        Me.lblFileSpecTip.AutoSize = True
        Me.lblFileSpecTip.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.5!)
        Me.lblFileSpecTip.Location = New System.Drawing.Point(143, 76)
        Me.lblFileSpecTip.Name = "lblFileSpecTip"
        Me.lblFileSpecTip.Size = New System.Drawing.Size(212, 12)
        Me.lblFileSpecTip.TabIndex = 30
        Me.lblFileSpecTip.Text = "(Seperate each file specification with a semi-colon)"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 240)
        Me.Controls.Add(Me.lblFileSpecTip)
        Me.Controls.Add(Me.lblStartDirExist)
        Me.Controls.Add(Me.lblCharacterCount)
        Me.Controls.Add(Me.btnBrowseForFolder)
        Me.Controls.Add(Me.chkDateLastAccessed)
        Me.Controls.Add(Me.dtpLastAccessedTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpLastAccessedFrom)
        Me.Controls.Add(Me.lblDateAccessed)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkIncludeSubDirs)
        Me.Controls.Add(Me.txtStartDir)
        Me.Controls.Add(Me.lblStartDir)
        Me.Controls.Add(Me.chkDateModified)
        Me.Controls.Add(Me.chkDateCreated)
        Me.Controls.Add(Me.chkIgnorCase)
        Me.Controls.Add(Me.txtContents)
        Me.Controls.Add(Me.lblContents)
        Me.Controls.Add(Me.dtpModifiedTo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpModifiedFrom)
        Me.Controls.Add(Me.lblDatedModified)
        Me.Controls.Add(Me.dtpCreatedTo)
        Me.Controls.Add(Me.lblDateCreatedAnd)
        Me.Controls.Add(Me.dtpCreatedFrom)
        Me.Controls.Add(Me.lblDatedCreated)
        Me.Controls.Add(Me.txtFileSpecs)
        Me.Controls.Add(Me.lblFilesToFind)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Finder of Files    :)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFilesToFind As Label
    Friend WithEvents txtFileSpecs As TextBox
    Friend WithEvents lblDatedCreated As Label
    Friend WithEvents dtpCreatedFrom As DateTimePicker
    Friend WithEvents lblDateCreatedAnd As Label
    Friend WithEvents dtpCreatedTo As DateTimePicker
    Friend WithEvents dtpModifiedTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpModifiedFrom As DateTimePicker
    Friend WithEvents lblDatedModified As Label
    Friend WithEvents lblContents As Label
    Friend WithEvents txtContents As TextBox
    Friend WithEvents chkIgnorCase As CheckBox
    Friend WithEvents chkDateCreated As CheckBox
    Friend WithEvents chkDateModified As CheckBox
    Friend WithEvents lblStartDir As Label
    Friend WithEvents txtStartDir As TextBox
    Friend WithEvents chkIncludeSubDirs As CheckBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents chkDateLastAccessed As CheckBox
    Friend WithEvents dtpLastAccessedTo As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpLastAccessedFrom As DateTimePicker
    Friend WithEvents lblDateAccessed As Label
    Friend WithEvents btnBrowseForFolder As Button
    Friend WithEvents lblCharacterCount As Label
    Friend WithEvents lblStartDirExist As Label
    Friend WithEvents lblFileSpecTip As Label
End Class
