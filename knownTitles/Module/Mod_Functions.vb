
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

Module Mod_Functions
    '''<summary>Bits einer Bitmask auslesen.</summary>
    Public Function GetBitsFromBitMask(_BitMask As UInteger) As List(Of UInteger)
        Dim _Bits As New List(Of UInteger)

        For _i As Integer = 31 To 0 Step -1
            If _BitMask - 2 ^ _i >= 0 Then
                _BitMask = CUInt(_BitMask - 2 ^ _i)
                _Bits.Add(CUInt(2 ^ _i))
            End If
        Next

        Return _Bits
    End Function

    ''' <summary>Erstellt die SQL Update/Backup Querys, anhand einer Charakterliste und der Variable NothingChanged bei jedem Character.</summary>
    Public Function GenSQLUpdateQuery(_CharacterFullList As List(Of Character)) As String
        Dim _SQLUpdateQuerys As New StringBuilder
        Dim _SQLBackupQuerys As New StringBuilder

        '// SQL Header
        _SQLUpdateQuerys.AppendLine("/* ******************************************************************************" + vbCrLf + _
                                    " * This *.sql file contains all SQL Update Query's AND all SQL Backup Query's." + vbCrLf + _
                                    " *" + vbCrLf + _
                                    " * Note: Don't use the whole *.sql script!" + vbCrLf + _
                                    " *" + vbCrLf + _
                                    " *     - If you would like to delete the selected titles, use the UPDATE query's." + vbCrLf + _
                                    " *     - If you would like to reset the changes, use the BACKUP query's." + vbCrLf + _
                                    " * *****************************************************************************/" + vbCrLf + vbCrLf + _
                                    "-- SQL Update Query's")
        _SQLBackupQuerys.AppendLine("-- SQL Backup Query's")

        For Each _Character In _CharacterFullList
            If Not _Character.NothingChanged Then
                '// Informationen zu dem Charakter auflisten
                _SQLUpdateQuerys.Append("/* Name: " + _Character.Name +
                                        " | GUID: " + _Character.GUID.ToString +
                                        " | Account ID: " + _Character.AccountID.ToString)
                _SQLBackupQuerys.AppendLine("-- Name: " + _Character.Name +
                                            " | GUID: " + _Character.GUID.ToString +
                                            " | Account ID: " + _Character.AccountID.ToString)

                '// Alle gebannten Titel auflisten
                For _i As Integer = 0 To _Character.AffectedTitles.Count - 1
                    If _Character.AffectedTitles(_i).State = State.REMOVED Then
                        _SQLUpdateQuerys.Append(vbCrLf + "REMOVED | TitleID: " + _Character.AffectedTitles.Item(_i).TitleID.ToString + _
                                                         " | IntID: " + _Character.AffectedTitles.Item(_i).IntID.ToString + _
                                                         " | MaleTitle: " + _Character.AffectedTitles.Item(_i).MaleTitle + _
                                                         " | Bit: " + _Character.AffectedTitles.Item(_i).Bit.ToString)

                    End If
                    If _i = (_Character.AffectedTitles.Count - 1) Then _SQLUpdateQuerys.AppendLine(" */")
                Next

                '// Update & Backup Query für den Charakter erstellen
                _SQLUpdateQuerys.AppendLine("UPDATE `characters` SET `knownTitles`=""" + _Character.INT_0.ToString + " " + _
                                                                                         _Character.INT_1.ToString + " " + _
                                                                                         _Character.INT_2.ToString + " " + _
                                                                                         _Character.INT_3.ToString + " " + _
                                                                                         _Character.INT_4.ToString + " " + _
                                                                                         _Character.INT_5.ToString + " "" WHERE `guid`=" + _Character.GUID.ToString + ";" + vbCrLf)

                _SQLBackupQuerys.AppendLine("UPDATE `characters` SET `knownTitles`=""" + _Character.KnownTitlesBackup + """ WHERE `guid`=" + _Character.GUID.ToString + ";" + vbCrLf)
            End If
        Next

        Return _SQLUpdateQuerys.ToString + vbCrLf + "/* ******************************************************************************" + vbCrLf + _
                                                    " * Note: The following query's are ONLY a backup of each character!" + vbCrLf + _
                                                    " *" + vbCrLf + _
                                                    " *     - If you would like to reset the changes, use these BACKUP query's." + vbCrLf + _
                                                    " * *****************************************************************************/" + vbCrLf + vbCrLf + _
                                                    _SQLBackupQuerys.ToString()
    End Function

    ''' <summary>Speichert eine Datei mit einem OpenFileDialog. Falls ein Fehler auftritt, wird dieser angezeigt.</summary>
    Public Function SaveFileWithOpenFileDialog(_TextToSave As String, _Filter As String, _FileName As String, Optional _FilterIndex As Integer = 1) As Boolean
        Dim _Path As String = OpenSaveFileDialog(_Filter, _FileName, _FilterIndex)
        If Not _Path = "" Then
            Try
                My.Computer.FileSystem.WriteAllText(_Path, _TextToSave, False)
                Select Case MessageBox.Show("Would you like to open the file?", "File saved!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                    Case DialogResult.Yes
                        Process.Start(_Path)
                End Select
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            End Try
        End If
        Return True
    End Function

    ''' <summary>Öffnet einen SaveFileDialog und gibt den Pfad + Dateiname + Endung zurück, falls korrekt.</summary>
    Public Function OpenSaveFileDialog(_Filter As String, _FileName As String, Optional _FilterIndex As Integer = 1) As String
        Dim _SetPathDialog As New SaveFileDialog
        _SetPathDialog.Filter = _Filter
        _SetPathDialog.FilterIndex = _FilterIndex
        _SetPathDialog.RestoreDirectory = True
        _SetPathDialog.FileName = _FileName
        If _SetPathDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return _SetPathDialog.FileName.ToString
        End If
        Return ""
    End Function

    ''' <summary>Entfernt alle Leeren Zeilen in der Textbox.</summary>
    Public Sub Remove_EmptyLines(_TextBox As Windows.Forms.TextBox)
        _TextBox.Lines = (From s As String In _TextBox.Lines Where s.Length > 0 Select s).ToArray
        ReDim Preserve _TextBox.Lines(_TextBox.Lines.Count - 1)
    End Sub

    ''' <summary>Erstellt eine Liste mit allen aktuell ausgewählten Titeln.</summary>
    Public Function GetSelectedTitles(_DataTable As DataTable) As List(Of CharTitle)
        Dim _SelectedTitles As New List(Of CharTitle)

        For Each _Title As dsSelectedTitles.dtExtendedRow In _DataTable.Rows
            If _Title.colChoose = True Then
                _SelectedTitles.Add(_TitelList_All.Find(Function(c) c.TitleID = _Title.colTitleID))
            End If
        Next

        Return _SelectedTitles
        '// http://regexhero.net/tester/
    End Function

    ''' <summary>Alle markierten Zeilen grün hinterlegen.</summary>
    Public Sub RefreshVisualRowColor(_dgv As DataGridView)
        For Each _Row As DataGridViewRow In _dgv.Rows
            If CType(_Row.Cells(0).Value, Boolean) = True Then
                _Row.DefaultCellStyle.BackColor = Color.LightGreen
            Else
                _Row.DefaultCellStyle.BackColor = Color.White
            End If
        Next
    End Sub

    ''' <summary>Ändert den Text und die Breite einer Spalte in einem DataGridView.</summary>
    ''' <param name="_dgv">Das DataGridView, welches angepasst werden soll.</param>
    ''' <param name="_colID">Die ColumnID, beginnend von links mit 0.</param>
    ''' <param name="_colHeaderText">Der neue Name der Spalte.</param>
    ''' <param name="_Offset">Wenn angegeben, wird die AutoSizeMode überschrieben.</param>
    Public Sub SetColumnHeaderTextAndWidth(_dgv As DataGridView, _colID As Integer, _colHeaderText As String, _colAutoSizeMode As DataGridViewAutoSizeColumnMode, Optional _Offset As Integer = 25)
        With _dgv.Columns
            .Item(_colID).HeaderText = _colHeaderText

            If _Offset = 25 Then
                .Item(_colID).AutoSizeMode = _colAutoSizeMode
                Return
            End If

            .Item(_colID).Width = TextRenderer.MeasureText(_colHeaderText, _dgv.Font).Width + _Offset
            .Item(_colID).MinimumWidth = TextRenderer.MeasureText(_colHeaderText, _dgv.Font).Width + _Offset
        End With
    End Sub
End Module
