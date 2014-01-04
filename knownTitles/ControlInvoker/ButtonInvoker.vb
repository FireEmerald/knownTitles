
'* Copyright (C) 2013-2014 FireEmerald <https://github.com/FireEmerald>
'*
'* Project: knownTitles | For TrinityCore
'*
'* Requires: .NET Framework 4 or higher.
'*
'* This program is free software; you can redistribute it and/or modify it
'* under the terms of the GNU General Public License as published by the
'* Free Software Foundation; either version 2 of the License, or (at your
'* option) any later version.
'*
'* This program is distributed in the hope that it will be useful, but WITHOUT
'* ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
'* FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for
'* more details.
'*
'* You should have received a copy of the GNU General Public License along
'* with this program. If not, see <http://www.gnu.org/licenses/>.

Option Strict On
Option Explicit On

Public Class ButtonInvoker
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
