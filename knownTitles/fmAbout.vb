Public Class fmAbout

#Region "Deklarationen"
    Dim _MovedWhileDown As Boolean = False
    Dim _MouseDown As Boolean = False

    Dim mouseOffset As Point
#End Region


#Region "Fenster Movement"
    Private Sub Me_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
        _MouseDown = True
        mouseOffset = New Point(-e.X, -e.Y)
    End Sub
    Private Sub Me_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
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
    Private Sub Me_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseUp
        If Not _MovedWhileDown Then
            Me.Hide()
        Else
            _MouseDown = False
            _MovedWhileDown = False
        End If
    End Sub
#End Region
End Class