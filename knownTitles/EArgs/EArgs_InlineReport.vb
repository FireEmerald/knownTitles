
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

Public Class EArgs_InlineReport
    '// Vererbung
    Inherits EventArgs

    '// Variablen
    Private _LogMessage As String
    Private _Guid As Guid

    '// Sub New - Was an die Form übergeben werden soll.
    Public Sub New(LogMessage As String, Guid As Guid)
        _LogMessage = LogMessage
        _Guid = Guid
    End Sub

    '// Propertys
    Public ReadOnly Property P_LogMessage As String
        Get
            Return _LogMessage
        End Get
    End Property
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property
End Class
