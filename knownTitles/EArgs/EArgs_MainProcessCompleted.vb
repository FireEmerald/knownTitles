
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

Imports System.Text

Public Class EArgs_MainProcessCompleted
    '// Vererbung
    Inherits EventArgs

#Region "Deklarationen"
    '// Der Hauptprozess
    Private _MainProcess As MainProcessing

    '// Variablen
    Private _SQLUpdateQuery As String
    Private _FullCharacterList As List(Of Character)
#End Region

    '// Sub New - Was an die Form übergeben werden soll.
    Sub New(SQLUpdateQuery As String, FullCharacterList As List(Of Character), MainProcess As MainProcessing)
        _SQLUpdateQuery = SQLUpdateQuery
        _FullCharacterList = FullCharacterList
        _MainProcess = MainProcess
    End Sub

    '// Propertys
    Public ReadOnly Property GetSQLUpdateQuery As String
        Get
            Return _SQLUpdateQuery
        End Get
    End Property
    Public ReadOnly Property GetFullCharacterList As List(Of Character)
        Get
            Return _FullCharacterList
        End Get
    End Property
    Public ReadOnly Property GetMainProcess As MainProcessing
        Get
            Return _MainProcess
        End Get
    End Property

End Class
