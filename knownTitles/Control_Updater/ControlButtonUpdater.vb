Option Explicit On
Option Strict On

Public Class ControlButtonUpdater
    '// Der Verweis wird als generisches Steuerelement gespeichert, so dass
    '// diese Hilfsklasse in anderen Szenarien wiederverwendet werden kann.
    Private _ControlsToUpdate() As Windows.Forms.Button
    Private _ControlToUpdate As Windows.Forms.Button

    '// Speichert den hinzuzufügenden Text.
    Private _NewState As Boolean

    '// Sub New - Element welches geupdated werden soll.
    Public Sub New(ByVal ControlsToUpdate() As Windows.Forms.Button)
        _ControlsToUpdate = ControlsToUpdate
    End Sub

    '// Propertys
    Private ReadOnly Property P_ControlToUpdate() As Control
        Get
            Return _ControlToUpdate
        End Get
    End Property

    Public Sub setState(ByVal newState As Boolean)
        _NewState = newState
        For Each _Control In _ControlsToUpdate
            _ControlToUpdate = _Control
            SyncLock Me
                P_ControlToUpdate.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeState))
            End SyncLock
        Next
    End Sub
    Private Sub ThreadSafeChangeState()
        Me.P_ControlToUpdate.Enabled = _NewState
    End Sub
End Class
