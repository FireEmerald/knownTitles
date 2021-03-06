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

Public Class DataGridViewInvoker

#Region "Deklarationen"
    '// Die Main Form mit dem Fensterhandle für die DataGridViews.
    Private _fmMain As fmMain
#End Region

    '// Daten die an die Klasse übergeben werden.
    Public Sub New(winForm As fmMain)
        _fmMain = winForm
    End Sub

    '// Alle Charakterdaten den DataTablen hinzufügen.
    Public Sub AddCharacterData(_FullCharacterList As List(Of Character))
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New StatusStripInvoker(_fmMain.tsPbStatusPercent, _fmMain.tsSlStatusPercent, _fmMain.tsSlStatusText)

        '// Alte Zeilen löschen.
        With _fmMain.DsResults
            .dtCharacters.Rows.Clear()
            .dtCharacterTitles.Rows.Clear()
        End With

        For Each _Character As Character In _FullCharacterList
            Dim _RemovedCnt As Integer = 0
            Dim _LeftCnt As Integer = 0

            '// Alle Titel des Charakters zum DataTable hinzufügen.
            For Each _Title As CharTitle In _Character.AffectedTitles
                Dim _NewTitleRow As dsResults.dtCharacterTitlesRow = _fmMain.DsResults.dtCharacterTitles.NewdtCharacterTitlesRow

                With _NewTitleRow
                    .colGUID = _Character.GUID
                    .colState = [Enum].GetName(GetType(State), _Title.State)
                    .colTitleID = _Title.TitleID
                    .colInGameOrder = _Title.InGameOrder
                    .colIntID = _Title.IntID
                    .colBitOfInteger = _Title.BitOfInteger
                    .colBit = _Title.Bit
                    .colDBValue = _Title.DBValue
                    .colIntID_Double = _Title.IntID_Double
                    .colUnkRef = _Title.UnkRef
                    .colMaleTitle = _Title.MaleTitle
                    .colFemaleTitle = _Title.FemaleTitle
                End With

                If _Title.State = State.REMOVED Then
                    _RemovedCnt += 1
                Else
                    _LeftCnt += 1
                End If

                '// Den Titel zum DataTable hinzufügen.
                _fmMain.DsResults.dtCharacterTitles.Rows.Add(_NewTitleRow)
            Next

            '// Den Charakter zum DataTable hinzufügen.
            Dim _NewCharacterRow As dsResults.dtCharactersRow = _fmMain.DsResults.dtCharacters.NewdtCharactersRow

            With _NewCharacterRow
                .colName = _Character.Name
                .colGUID = _Character.GUID
                .colAccountID = _Character.AccountID
                .colKnownTitlesBackup = _Character.KnownTitlesBackup
                .colAffected = _Character.AffectedTitles.Count
                .colRemoved = _RemovedCnt
                .colLeft = _LeftCnt
            End With

            '// Den Charakter zum DataTable hinzufügen.
            _fmMain.DsResults.dtCharacters.Rows.Add(_NewCharacterRow)

            '// Statusbar aktualisieren.
            _tsMain.setAll(CInt((_fmMain.DsResults.dtCharacters.Rows.Count / _FullCharacterList.Count) * 100), "Process character data... " + _fmMain.DsResults.dtCharacters.Rows.Count.ToString + " of " + _FullCharacterList.Count.ToString)
        Next
    End Sub

    ''' <summary>Teilt einem DataGridView eine neue DataSource und DataMember zu. (Invoked)</summary>
    Public Sub NewSourceAndMember(GridView As DataGridView, NewSource As Object, NewMember As String)
        _fmMain.Invoke(Sub() InvokeSourceAndMember(GridView, NewSource, NewMember))
    End Sub
    Private Sub InvokeSourceAndMember(_dgv As DataGridView, _newSource As Object, _newMember As String)
        _dgv.DataSource = _newSource
        _dgv.DataMember = _newMember
    End Sub

    ''' <summary>Legt alle Spaltennamen und deren Breite neu fest.</summary>
    Public Sub SetColumnNamesAndWidth()
        _fmMain.Invoke(Sub() InvokeColumnNames())
    End Sub
    Private Sub InvokeColumnNames()
        With _fmMain
            '// Charakterdaten.
            SetColumnHeaderTextAndWidth(.dgvCharacters, 0, "Name", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacters, 1, "GUID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacters, 2, "Account ID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacters, 3, "KnownTitles", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacters, 4, "Affected", DataGridViewAutoSizeColumnMode.Fill)
            SetColumnHeaderTextAndWidth(.dgvCharacters, 5, "Removed", DataGridViewAutoSizeColumnMode.Fill)
            SetColumnHeaderTextAndWidth(.dgvCharacters, 6, "Left", DataGridViewAutoSizeColumnMode.Fill)
            '// Titeldaten zu Charakter.
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 0, "GUID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 1, "State", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 2, "Titel ID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 3, "InGameOrder", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 4, "IntID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 5, "BitOfInteger", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 6, "Bit", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 7, "DB Value", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 8, "IntID Double", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 9, "UnkRef", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 10, "MaleTitle", DataGridViewAutoSizeColumnMode.Fill)
            SetColumnHeaderTextAndWidth(.dgvCharacterTitles, 11, "FemaleTitle", DataGridViewAutoSizeColumnMode.Fill)
        End With
    End Sub

    ''' <summary>Verbirgt gewisse Spalten im DGV, je nach ExtendedView.</summary>
    Public Sub ReloadVisibleDataGridViewValues(_IsExtendedView As Boolean)
        _fmMain.Invoke(Sub() InvokeVisibleDataGridViewValues(_IsExtendedView))
    End Sub
    Private Sub InvokeVisibleDataGridViewValues(_IsExtendedView As Boolean)
        With _fmMain.dgvCharacterTitles
            If Not .Columns.Count = 0 Then
                '// Bei True: Spalten verbergen (False), wenn das DGV verkleinert wird.
                .Columns(5).Visible = Not _IsExtendedView
                .Columns(8).Visible = Not _IsExtendedView
                .Columns(9).Visible = Not _IsExtendedView
                .Columns(11).Visible = Not _IsExtendedView
            End If
        End With
    End Sub
End Class
