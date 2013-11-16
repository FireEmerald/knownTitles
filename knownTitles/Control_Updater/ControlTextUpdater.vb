Option Explicit On
Option Strict On

Public Class ControlTextUpdater
    '// Der Verweis wird als generisches Steuerelement gespeichert, so dass
    '// diese Hilfsklasse in anderen Szenarien wiederverwendet werden kann.
    Private _ControlToUpdate As Control

    '// Speichert den hinzuzufügenden Text.
    Private _NewText As String

    '// Sub New - Element welches geupdated werden soll.
    Public Sub New(ByVal ControlToUpdate As Control)
        _ControlToUpdate = ControlToUpdate
    End Sub

    '// Propertys
    Private ReadOnly Property P_ControlToUpdate() As Control
        Get
            Return _ControlToUpdate
        End Get
    End Property

    Public Sub AddText(ByVal newText As String)
        SyncLock Me
            _NewText = newText
            P_ControlToUpdate.Invoke(New MethodInvoker(AddressOf ThreadSafeAddText))
        End SyncLock
    End Sub
    Private Sub ThreadSafeAddText()
        Me.P_ControlToUpdate.Text += _NewText
    End Sub

    Public Sub ReplaceText(ByVal newText As String)
        SyncLock Me
            _NewText = newText
            P_ControlToUpdate.Invoke(New MethodInvoker(AddressOf ThreadSafeReplaceText))
        End SyncLock
    End Sub
    Private Sub ThreadSafeReplaceText()
        Me.P_ControlToUpdate.Text = _NewText
    End Sub
End Class
