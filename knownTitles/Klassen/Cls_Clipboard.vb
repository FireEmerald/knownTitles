﻿
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
Imports System.Text.RegularExpressions

Public Class Cls_Clipboard

#Region "Deklarationen"
    '// Variablen
    Private _ClipboardContent As String = ""

    '// Events
    Public Event StatusReport(sender As Object, e As EArgs_StatusReport)
    Public Event ClipboardImport_Completed(sender As Object, e As EArgs_ValidationProcessCompleted)

    '// Ein eindeutiger Bezeichner für diesen Task.
    Private _Guid As Guid = Guid.NewGuid()
#End Region

#Region "Propertys"
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property
#End Region

    Sub New(ClipboardContent As String)
        _ClipboardContent = ClipboardContent
    End Sub

    ''' <summary>Gibt den Text aus der Zwischenablage je nach Syntax gekürzt zurück.</summary>
    Public Sub GetDataFromClipboard()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running...", _Guid))

        Dim _ValidatedClipboardContent As New StringBuilder
        Dim _ErrorProcess As New ErrorProcessing With {.ID = ErrorProcessingID.CLIPBOARD_IMPORT_VALIDATION,
                                                       .WrongContent = "",
                                                       .WrongCounter = 0}

        '// Wir splitten den Text bei allen vbCrLf und prüfen ob die Syntax passt.
        Dim _ClipboardLines() As String = Regex.Split(_ClipboardContent, vbCrLf)

        For _i As Integer = 0 To _ClipboardLines.Count - 1
            If Not _ClipboardLines(_i) = "" Then
                Dim _WrongSyntax As Boolean = True

                '// "INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1, 'ABC', '0 0 0 0 0 0 ');"
                If HasBit(My.Settings.ClipboardSyntax, CLIPBOARD_SYNTAX.INSERT_INTO) AndAlso _ClipboardLines(_i).Contains("INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (") Then
                    Dim _Replaced As String = _ClipboardLines(_i).Replace(",", "").Replace("'", "")
                    Dim _ToCheck As String = _Replaced.Substring(73, _Replaced.Length - (73 + ((_Replaced.Length - 1) - _Replaced.LastIndexOf("0"))))
                    If Regex.IsMatch(_ToCheck, "[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0", RegexOptions.None) Then
                        _WrongSyntax = False
                        _ValidatedClipboardContent.AppendLine(_ToCheck)
                        Log_Msg(PRÄFIX.DEBUG, "Clipboard line added """ + _ToCheck + """.")
                    End If
                End If

                '// "1 1 ABC 0 0 0 0 0 0 "
                If HasBit(My.Settings.ClipboardSyntax, CLIPBOARD_SYNTAX.ONLY_WITH_SPACES) AndAlso _WrongSyntax AndAlso Regex.IsMatch(_ClipboardLines(_i), "[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0 $", RegexOptions.None) Then
                    Dim _Checked As String = _ClipboardLines(_i).Substring(0, _ClipboardLines(_i).Length - 1)

                    _WrongSyntax = False
                    _ValidatedClipboardContent.AppendLine(_Checked)
                    Log_Msg(PRÄFIX.DEBUG, "Clipboard line added """ + _Checked + """.")
                End If

                If _WrongSyntax Then
                    _ErrorProcess.WrongContent += ((_i + 1).ToString + ": """ + _ClipboardLines(_i) + """") + vbCrLf
                    _ErrorProcess.WrongCounter += 1
                End If
            End If

            '// Statusbar aktualisieren.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _ClipboardLines.Count) * 100), "Import running... " + (_i + 1).ToString + " of " + _ClipboardLines.Count.ToString + "  | Syntax error: " + _ErrorProcess.WrongCounter.ToString, _Guid))
        Next
        '// Das letzte vbCrLf muss nicht gelöscht werden.

        RaiseEvent ClipboardImport_Completed(Me, New EArgs_ValidationProcessCompleted(_ValidatedClipboardContent.ToString, _ErrorProcess, _Guid))
    End Sub
End Class
