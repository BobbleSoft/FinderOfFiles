<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmResults
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmResults))
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.lblCurrent = New System.Windows.Forms.Label()
        Me.lstResults = New System.Windows.Forms.ListView()
        Me.colFile = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDateCreated = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDateModified = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colDateAccessed = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSize = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'btnStop
        '
        Me.btnStop.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnStop.Location = New System.Drawing.Point(642, 12)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 0
        Me.btnStop.Text = "&Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Enabled = False
        Me.btnExport.Location = New System.Drawing.Point(642, 41)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(75, 23)
        Me.btnExport.TabIndex = 1
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'lblCurrent
        '
        Me.lblCurrent.AutoEllipsis = True
        Me.lblCurrent.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblCurrent.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrent.Location = New System.Drawing.Point(0, 189)
        Me.lblCurrent.Name = "lblCurrent"
        Me.lblCurrent.Size = New System.Drawing.Size(729, 15)
        Me.lblCurrent.TabIndex = 3
        Me.lblCurrent.Text = "Searching..."
        '
        'lstResults
        '
        Me.lstResults.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFile, Me.colDateCreated, Me.colDateModified, Me.colDateAccessed, Me.colSize})
        Me.lstResults.FullRowSelect = True
        Me.lstResults.GridLines = True
        Me.lstResults.Location = New System.Drawing.Point(13, 12)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(623, 174)
        Me.lstResults.TabIndex = 4
        Me.lstResults.UseCompatibleStateImageBehavior = False
        Me.lstResults.View = System.Windows.Forms.View.Details
        '
        'colFile
        '
        Me.colFile.Text = "File"
        Me.colFile.Width = 250
        '
        'colDateCreated
        '
        Me.colDateCreated.Text = "Created"
        Me.colDateCreated.Width = 90
        '
        'colDateModified
        '
        Me.colDateModified.Text = "Modified"
        Me.colDateModified.Width = 90
        '
        'colDateAccessed
        '
        Me.colDateAccessed.Text = "Last Accessed"
        Me.colDateAccessed.Width = 90
        '
        'colSize
        '
        Me.colSize.Text = "Size (bytes)"
        Me.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSize.Width = 75
        '
        'frmResults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnStop
        Me.ClientSize = New System.Drawing.Size(729, 204)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.lblCurrent)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnStop)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmResults"
        Me.Text = "FoF Results"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnStop As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents lblCurrent As Label
    Friend WithEvents lstResults As ListView
    Friend WithEvents colFile As ColumnHeader
    Friend WithEvents colDateCreated As ColumnHeader
    Friend WithEvents colDateModified As ColumnHeader
    Friend WithEvents colDateAccessed As ColumnHeader
    Friend WithEvents colSize As ColumnHeader
End Class
