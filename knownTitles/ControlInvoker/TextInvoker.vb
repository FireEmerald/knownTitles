
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

Public Class TextInvoker
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
