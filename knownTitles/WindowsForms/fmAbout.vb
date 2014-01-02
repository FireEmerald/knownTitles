﻿Public Class fmAbout

#Region "Deklarationen"
    Dim _MovedWhileDown As Boolean = False
    Dim _MouseDown As Boolean = False

    Dim mouseOffset As Point
#End Region

#Region "Fenster Movement"
    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseDown
        _MouseDown = True
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub
    Private Sub Me_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseMove
        If _MouseDown Then
            _MovedWhileDown = True
            If e.Button = MouseButtons.Left Then
                Dim mousePos = Control.MousePosition
                mousePos.Offset(mouseOffset.X, mouseOffset.Y)
                Location = mousePos
            End If
        Else
            _MovedWhileDown = False
        End If
    End Sub
    Private Sub Me_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles PictureBox1.MouseUp
        If Not _MovedWhileDown Then
            Me.Hide()
        Else
            _MouseDown = False
            _MovedWhileDown = False
        End If
    End Sub
#End Region

    Private Sub fmAbout_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        fmMain._fmAbout = Nothing
    End Sub

    Private Sub fmAbout_Load(sender As Object, e As EventArgs) Handles Me.Load
        '// Don't want to update the picture whole time. Later this will be removed^^
        lblVersion.Text = "Version: " + Application.ProductVersion.Substring(0, 5) + " 64x"
    End Sub
End Class