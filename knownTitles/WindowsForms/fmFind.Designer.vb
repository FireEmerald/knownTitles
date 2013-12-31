<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmFind
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmFind))
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbToFind = New System.Windows.Forms.TextBox()
        Me.btnCount = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.gbSearchMode = New System.Windows.Forms.GroupBox()
        Me.rbSearchMode_SQLSytax = New System.Windows.Forms.RadioButton()
        Me.rbSearchMode_Normal = New System.Windows.Forms.RadioButton()
        Me.ssFind = New System.Windows.Forms.StatusStrip()
        Me.tsStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsHelpLink = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbColumns = New System.Windows.Forms.GroupBox()
        Me.rbColumns_All = New System.Windows.Forms.RadioButton()
        Me.rbColumns_Specified = New System.Windows.Forms.RadioButton()
        Me.cbColumns_Specified = New System.Windows.Forms.ComboBox()
        Me.rbColumns_Normal = New System.Windows.Forms.RadioButton()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.cbTransparency = New System.Windows.Forms.CheckBox()
        Me.cbWildcraft = New System.Windows.Forms.CheckBox()
        Me.gbSearchMode.SuspendLayout()
        Me.ssFind.SuspendLayout()
        Me.gbColumns.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnFilter
        '
        Me.btnFilter.ForeColor = System.Drawing.Color.Navy
        Me.btnFilter.Location = New System.Drawing.Point(335, 12)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(112, 23)
        Me.btnFilter.TabIndex = 1
        Me.btnFilter.Text = "Find Text"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(27, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Find what:"
        '
        'tbToFind
        '
        Me.tbToFind.Location = New System.Drawing.Point(89, 14)
        Me.tbToFind.Name = "tbToFind"
        Me.tbToFind.Size = New System.Drawing.Size(240, 20)
        Me.tbToFind.TabIndex = 0
        '
        'btnCount
        '
        Me.btnCount.ForeColor = System.Drawing.Color.Navy
        Me.btnCount.Location = New System.Drawing.Point(335, 41)
        Me.btnCount.Name = "btnCount"
        Me.btnCount.Size = New System.Drawing.Size(112, 23)
        Me.btnCount.TabIndex = 2
        Me.btnCount.Text = "Count"
        Me.btnCount.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.ForeColor = System.Drawing.Color.Navy
        Me.btnClose.Location = New System.Drawing.Point(335, 99)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(112, 23)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'gbSearchMode
        '
        Me.gbSearchMode.Controls.Add(Me.rbSearchMode_SQLSytax)
        Me.gbSearchMode.Controls.Add(Me.rbSearchMode_Normal)
        Me.gbSearchMode.ForeColor = System.Drawing.Color.Navy
        Me.gbSearchMode.Location = New System.Drawing.Point(12, 133)
        Me.gbSearchMode.Name = "gbSearchMode"
        Me.gbSearchMode.Size = New System.Drawing.Size(106, 69)
        Me.gbSearchMode.TabIndex = 5
        Me.gbSearchMode.TabStop = False
        Me.gbSearchMode.Text = "Search mode"
        '
        'rbSearchMode_SQLSytax
        '
        Me.rbSearchMode_SQLSytax.AutoSize = True
        Me.rbSearchMode_SQLSytax.Location = New System.Drawing.Point(6, 42)
        Me.rbSearchMode_SQLSytax.Name = "rbSearchMode_SQLSytax"
        Me.rbSearchMode_SQLSytax.Size = New System.Drawing.Size(81, 17)
        Me.rbSearchMode_SQLSytax.TabIndex = 5
        Me.rbSearchMode_SQLSytax.Text = "SQL Syntax"
        Me.rbSearchMode_SQLSytax.UseVisualStyleBackColor = True
        '
        'rbSearchMode_Normal
        '
        Me.rbSearchMode_Normal.AutoSize = True
        Me.rbSearchMode_Normal.Location = New System.Drawing.Point(6, 19)
        Me.rbSearchMode_Normal.Name = "rbSearchMode_Normal"
        Me.rbSearchMode_Normal.Size = New System.Drawing.Size(58, 17)
        Me.rbSearchMode_Normal.TabIndex = 4
        Me.rbSearchMode_Normal.Text = "Normal"
        Me.rbSearchMode_Normal.UseVisualStyleBackColor = True
        '
        'ssFind
        '
        Me.ssFind.BackColor = System.Drawing.Color.White
        Me.ssFind.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsStatusLabel, Me.tsHelpLink})
        Me.ssFind.Location = New System.Drawing.Point(0, 205)
        Me.ssFind.Name = "ssFind"
        Me.ssFind.Size = New System.Drawing.Size(459, 22)
        Me.ssFind.TabIndex = 7
        Me.ssFind.Text = "StatusStrip1"
        '
        'tsStatusLabel
        '
        Me.tsStatusLabel.ForeColor = System.Drawing.Color.Blue
        Me.tsStatusLabel.Name = "tsStatusLabel"
        Me.tsStatusLabel.Size = New System.Drawing.Size(0, 17)
        '
        'tsHelpLink
        '
        Me.tsHelpLink.IsLink = True
        Me.tsHelpLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline
        Me.tsHelpLink.Name = "tsHelpLink"
        Me.tsHelpLink.Size = New System.Drawing.Size(40, 17)
        Me.tsHelpLink.Text = "[Help]"
        Me.tsHelpLink.Visible = False
        '
        'gbColumns
        '
        Me.gbColumns.Controls.Add(Me.rbColumns_All)
        Me.gbColumns.Controls.Add(Me.rbColumns_Specified)
        Me.gbColumns.Controls.Add(Me.cbColumns_Specified)
        Me.gbColumns.Controls.Add(Me.rbColumns_Normal)
        Me.gbColumns.ForeColor = System.Drawing.Color.Navy
        Me.gbColumns.Location = New System.Drawing.Point(124, 135)
        Me.gbColumns.Name = "gbColumns"
        Me.gbColumns.Size = New System.Drawing.Size(323, 67)
        Me.gbColumns.TabIndex = 8
        Me.gbColumns.TabStop = False
        Me.gbColumns.Text = "Columns"
        '
        'rbColumns_All
        '
        Me.rbColumns_All.AutoSize = True
        Me.rbColumns_All.Location = New System.Drawing.Point(6, 40)
        Me.rbColumns_All.Name = "rbColumns_All"
        Me.rbColumns_All.Size = New System.Drawing.Size(79, 17)
        Me.rbColumns_All.TabIndex = 7
        Me.rbColumns_All.Text = "All Columns"
        Me.rbColumns_All.UseVisualStyleBackColor = True
        '
        'rbColumns_Specified
        '
        Me.rbColumns_Specified.AutoSize = True
        Me.rbColumns_Specified.Location = New System.Drawing.Point(171, 17)
        Me.rbColumns_Specified.Name = "rbColumns_Specified"
        Me.rbColumns_Specified.Size = New System.Drawing.Size(110, 17)
        Me.rbColumns_Specified.TabIndex = 8
        Me.rbColumns_Specified.Text = "Specified Column:"
        Me.rbColumns_Specified.UseVisualStyleBackColor = True
        '
        'cbColumns_Specified
        '
        Me.cbColumns_Specified.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbColumns_Specified.FormattingEnabled = True
        Me.cbColumns_Specified.Location = New System.Drawing.Point(171, 40)
        Me.cbColumns_Specified.Name = "cbColumns_Specified"
        Me.cbColumns_Specified.Size = New System.Drawing.Size(146, 21)
        Me.cbColumns_Specified.TabIndex = 9
        '
        'rbColumns_Normal
        '
        Me.rbColumns_Normal.AutoSize = True
        Me.rbColumns_Normal.Location = New System.Drawing.Point(6, 17)
        Me.rbColumns_Normal.Name = "rbColumns_Normal"
        Me.rbColumns_Normal.Size = New System.Drawing.Size(156, 17)
        Me.rbColumns_Normal.TabIndex = 6
        Me.rbColumns_Normal.Text = "Normal (Male && FemaleTitle)"
        Me.rbColumns_Normal.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.ForeColor = System.Drawing.Color.Navy
        Me.btnReset.Location = New System.Drawing.Point(335, 70)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(112, 23)
        Me.btnReset.TabIndex = 9
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'cbTransparency
        '
        Me.cbTransparency.AutoSize = True
        Me.cbTransparency.ForeColor = System.Drawing.Color.Navy
        Me.cbTransparency.Location = New System.Drawing.Point(18, 103)
        Me.cbTransparency.Name = "cbTransparency"
        Me.cbTransparency.Size = New System.Drawing.Size(91, 17)
        Me.cbTransparency.TabIndex = 10
        Me.cbTransparency.Text = "Transparency"
        Me.cbTransparency.UseVisualStyleBackColor = True
        '
        'cbWildcraft
        '
        Me.cbWildcraft.AutoSize = True
        Me.cbWildcraft.ForeColor = System.Drawing.Color.Navy
        Me.cbWildcraft.Location = New System.Drawing.Point(18, 80)
        Me.cbWildcraft.Name = "cbWildcraft"
        Me.cbWildcraft.Size = New System.Drawing.Size(191, 17)
        Me.cbWildcraft.TabIndex = 11
        Me.cbWildcraft.Text = "Wildcraft (only @Columns | Normal)"
        Me.cbWildcraft.UseVisualStyleBackColor = True
        '
        'fmFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(459, 227)
        Me.Controls.Add(Me.cbWildcraft)
        Me.Controls.Add(Me.cbTransparency)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.gbColumns)
        Me.Controls.Add(Me.ssFind)
        Me.Controls.Add(Me.gbSearchMode)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCount)
        Me.Controls.Add(Me.tbToFind)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFilter)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "fmFind"
        Me.ShowInTaskbar = False
        Me.Text = "Find"
        Me.TopMost = True
        Me.gbSearchMode.ResumeLayout(False)
        Me.gbSearchMode.PerformLayout()
        Me.ssFind.ResumeLayout(False)
        Me.ssFind.PerformLayout()
        Me.gbColumns.ResumeLayout(False)
        Me.gbColumns.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbToFind As System.Windows.Forms.TextBox
    Friend WithEvents btnCount As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents gbSearchMode As System.Windows.Forms.GroupBox
    Friend WithEvents rbSearchMode_Normal As System.Windows.Forms.RadioButton
    Friend WithEvents ssFind As System.Windows.Forms.StatusStrip
    Friend WithEvents tsStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents rbSearchMode_SQLSytax As System.Windows.Forms.RadioButton
    Friend WithEvents gbColumns As System.Windows.Forms.GroupBox
    Friend WithEvents rbColumns_All As System.Windows.Forms.RadioButton
    Friend WithEvents rbColumns_Specified As System.Windows.Forms.RadioButton
    Friend WithEvents cbColumns_Specified As System.Windows.Forms.ComboBox
    Friend WithEvents rbColumns_Normal As System.Windows.Forms.RadioButton
    Friend WithEvents tsHelpLink As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents cbTransparency As System.Windows.Forms.CheckBox
    Friend WithEvents cbWildcraft As System.Windows.Forms.CheckBox
End Class
