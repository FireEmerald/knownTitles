
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

Public Class StatusStripInvoker
    '// Der Verweis wird als generisches Steuerelement gespeichert, so dass
    '// diese Hilfsklasse in anderen Szenarien wiederverwendet werden kann.
    Private _tsProgressBar As Windows.Forms.ToolStripProgressBar
    Private _tsLabel_Percent,
            _tsLabel_TextStatus As Windows.Forms.ToolStripLabel

    '// Speichert den hinzuzufügenden Text.
    Private _Percent As Integer
    Private _TextStatus As String

    '// Sub New - Element welches geupdated werden soll.
    Sub New(ProgressBar As Windows.Forms.ToolStripProgressBar,
            Label_Percent As Windows.Forms.ToolStripLabel,
            Label_TextStatus As Windows.Forms.ToolStripLabel)

        _tsLabel_Percent = Label_Percent
        _tsLabel_TextStatus = Label_TextStatus
        _tsProgressBar = ProgressBar
    End Sub
    Sub New(ProgressBar As Windows.Forms.ToolStripProgressBar,
            Label_Percent As Windows.Forms.ToolStripLabel)
        _tsLabel_Percent = Label_Percent
        _tsProgressBar = ProgressBar
    End Sub
    Sub New(Label_TextStatus As Windows.Forms.ToolStripLabel)
        _tsLabel_TextStatus = Label_TextStatus
    End Sub


    Public Sub setAll(Percent As Integer, Text As String)
        _TextStatus = Text
        _Percent = Percent

        SyncLock Me
            _tsLabel_TextStatus.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeTextStatus))
            _tsLabel_Percent.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangePercentStatus))
            _tsProgressBar.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeProgressBar))
        End SyncLock
    End Sub
    Public Sub setPercent(Percent As Integer)
        _Percent = Percent

        SyncLock Me
            _tsLabel_Percent.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangePercentStatus))
            _tsProgressBar.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeProgressBar))
        End SyncLock
    End Sub
    Public Sub setText(Text As String)
        _TextStatus = Text

        SyncLock Me
            _tsLabel_TextStatus.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeTextStatus))
        End SyncLock
    End Sub

    Private Sub ThreadSafeChangeProgressBar()
        _tsProgressBar.Value = _Percent
    End Sub
    Private Sub ThreadSafeChangePercentStatus()
        _tsLabel_Percent.Text = _Percent.ToString + " % |"
    End Sub
    Private Sub ThreadSafeChangeTextStatus()
        _tsLabel_TextStatus.Text = _TextStatus
    End Sub

End Class
