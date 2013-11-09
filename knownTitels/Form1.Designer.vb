<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbInput = New System.Windows.Forms.TextBox()
        Me.tbOutput = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.tbMask = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbMaskTitels = New System.Windows.Forms.TextBox()
        Me.tbBannedTitel = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbDebug = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(40, 383)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Merge New"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbInput
        '
        Me.tbInput.Location = New System.Drawing.Point(12, 12)
        Me.tbInput.Multiline = True
        Me.tbInput.Name = "tbInput"
        Me.tbInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbInput.Size = New System.Drawing.Size(103, 365)
        Me.tbInput.TabIndex = 3
        '
        'tbOutput
        '
        Me.tbOutput.Location = New System.Drawing.Point(121, 12)
        Me.tbOutput.Multiline = True
        Me.tbOutput.Name = "tbOutput"
        Me.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbOutput.Size = New System.Drawing.Size(920, 365)
        Me.tbOutput.TabIndex = 4
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(966, 383)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "List All Titles"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'tbMask
        '
        Me.tbMask.Location = New System.Drawing.Point(12, 441)
        Me.tbMask.MaxLength = 32767999
        Me.tbMask.Multiline = True
        Me.tbMask.Name = "tbMask"
        Me.tbMask.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbMask.Size = New System.Drawing.Size(299, 216)
        Me.tbMask.TabIndex = 6
        Me.tbMask.Text = "1234 Roki 0 192 0 0 0 0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5678 Loki 0 224 0 0 0 0"
        Me.tbMask.WordWrap = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(317, 412)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(174, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Which Title does He/She has?"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 425)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(166, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Mask: (GUID NAME X X X X X X)"
        '
        'tbMaskTitels
        '
        Me.tbMaskTitels.Location = New System.Drawing.Point(317, 441)
        Me.tbMaskTitels.MaxLength = 327679999
        Me.tbMaskTitels.Multiline = True
        Me.tbMaskTitels.Name = "tbMaskTitels"
        Me.tbMaskTitels.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbMaskTitels.Size = New System.Drawing.Size(858, 216)
        Me.tbMaskTitels.TabIndex = 9
        '
        'tbBannedTitel
        '
        Me.tbBannedTitel.Location = New System.Drawing.Point(1047, 83)
        Me.tbBannedTitel.Multiline = True
        Me.tbBannedTitel.Name = "tbBannedTitel"
        Me.tbBannedTitel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbBannedTitel.Size = New System.Drawing.Size(128, 294)
        Me.tbBannedTitel.TabIndex = 10
        Me.tbBannedTitel.Text = "1 536870912" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1 1073741824" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1 2147483648" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1044, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Gebannte Titel:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1044, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 52)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "INT_ID TITLE_BIT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(INT_ID = 0-5)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(TITEL_BIT = Bit)"
        '
        'cbDebug
        '
        Me.cbDebug.AutoSize = True
        Me.cbDebug.Location = New System.Drawing.Point(497, 416)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(58, 17)
        Me.cbDebug.TabIndex = 13
        Me.cbDebug.Text = "Debug"
        Me.cbDebug.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1190, 669)
        Me.Controls.Add(Me.cbDebug)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbBannedTitel)
        Me.Controls.Add(Me.tbMaskTitels)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.tbMask)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.tbOutput)
        Me.Controls.Add(Me.tbInput)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents tbInput As System.Windows.Forms.TextBox
    Friend WithEvents tbOutput As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents tbMask As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbMaskTitels As System.Windows.Forms.TextBox
    Friend WithEvents tbBannedTitel As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbDebug As System.Windows.Forms.CheckBox

End Class
