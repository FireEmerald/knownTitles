
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

'// Unterscheidung zwischen Add/Remove/Lookup
Public Enum MainProcessingID As Integer
    PROCESS_LOOKUP = 0
    PROCESS_REMOVE = 1
    PROCESS_ADD = 2
    PROCESS_SEARCH = 3
End Enum

Public Structure MainProcessing
    Dim PlayerInput,
        ValidatedPlayerInput As String
    Dim SelectedTitles As List(Of CharTitle)
    Dim TotalAffected, TotalRemoved, TotalLeft As Integer
    Dim fmMain As fmMain
    Dim ID As MainProcessingID
    Dim Guid As Guid
End Structure

Public Class Cls_Main_Validate

#Region "Deklarationen"
    '// Hauptprozessstruktur mit einem eindeutigen Bezeichner für diesen Task.
    Private _MainProcess As MainProcessing

    '// Events
    Public Event StatusReport(sender As Object, e As EArgs_StatusReport)
    Public Event MainProcess_ValidationCompleted(sender As Object, e As EArgs_ValidationProcessCompleted)
#End Region

#Region "Propertys"
    Public ReadOnly Property P_MainProcess_Guid As Guid
        Get
            Return _MainProcess.Guid
        End Get
    End Property
#End Region

    Sub New(MainProcess As MainProcessing)
        _MainProcess = MainProcess

        '// Neue GUID für Thread erstellen.
        _MainProcess.Guid = Guid.NewGuid
    End Sub

    ''' <summary>Überprüft den PlayerInput auf kritische Fehler, die im Prozess selbst nicht geprüft würden und somit zu Abstürzen führen könnten.</summary>
    Public Sub Validate_PlayerInput()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running ...", _MainProcess.Guid))

        Dim _ErrorProcess As New ErrorProcessing With {.ID = ErrorProcessingID.MAIN_PROCESS_VALIDATION,
                                                       .WrongContent = "",
                                                       .WrongCounter = 0}

        Dim _ValidatedInput As New StringBuilder

        '// Validation Prozess überspringen, wenn bereits validiert wurde.
        If Not IsNothing(_MainProcess.ValidatedPlayerInput) OrElse My.Settings.DebugMode Then
            If My.Settings.DebugMode AndAlso IsNothing(_MainProcess.ValidatedPlayerInput) Then
                Log_Msg(PRÄFIX.DEBUG, "PlayerInput validation was skipped due to debug mode. This could lead to errors while processing!")
            Else
                Log_Msg(PRÄFIX.WARNING, "PlayerInput validation was skipped because the input was already validated.")
            End If
            RaiseEvent MainProcess_ValidationCompleted(Me, New EArgs_ValidationProcessCompleted(_MainProcess, _ErrorProcess))
            Return
        End If

        Dim _ProgressCnt As Integer = 0
        Dim _EachCharacter() As String = Regex.Split(_MainProcess.PlayerInput, vbCrLf)

        For _i As Integer = 0 To _EachCharacter.Count - 1

            If Regex.IsMatch(_EachCharacter(_i), "^[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0$", RegexOptions.None) Then
                _ProgressCnt += 1

                '// Verhindern, dass bei der letzten Zeile ein vbCrLf hinzugefügt wird.
                If _i = _EachCharacter.Count - 1 Then
                    _ValidatedInput.Append(_EachCharacter(_i))
                    Exit For
                End If

                _ValidatedInput.AppendLine(_EachCharacter(_i))
            Else
                _ErrorProcess.WrongCounter += 1
                _ErrorProcess.WrongContent += ((_i + 1).ToString + ": """ + _EachCharacter(_i) + """") + vbCrLf
            End If

            '// Statusbar aktualisieren.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_ProgressCnt + _ErrorProcess.WrongCounter) / _EachCharacter.Count) * 100), "Validation running... " + (_ProgressCnt + _ErrorProcess.WrongCounter).ToString + " of " + _EachCharacter.Count.ToString + "  | Syntax error: " + _ErrorProcess.WrongCounter.ToString, _MainProcess.Guid))
        Next

        '// Validierte Charakterdaten an Mainprozess übertragen.
        _MainProcess.ValidatedPlayerInput = _ValidatedInput.ToString

        '// Abschließendes Event
        RaiseEvent MainProcess_ValidationCompleted(Me, New EArgs_ValidationProcessCompleted(_MainProcess, _ErrorProcess))
    End Sub
End Class
