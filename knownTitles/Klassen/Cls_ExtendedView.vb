
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

Public Structure ControlData
    Dim Control As Control
    Dim Location As Point
    Dim Size As Size
End Structure

Public Class Cls_ExtendedView

#Region "Location & Size Deklarationen"
    '// Form Main wird übergeben.
    Private _fmMain As fmMain

    Private _SavedPosition_gbPlayerInput As ControlData
    Private _SavedPosition_tbPlayerInput As ControlData
    Private _SavedPosition_gbSelectedTitles As ControlData
    Private _SavedPosition_dgvSelectedTitles As ControlData
    Private _SavedPosition_gbResults As ControlData
    Private _SavedPosition_dgvCharacters As ControlData

    '// Verändert das Verhältnis von Log zu minimized PlayerInput
    Private _Ratio As Double = 1.4
#End Region

    '// Defaultpositionen speichern
    Public Sub New(winForm As fmMain,
                   gbPlayerInput As ControlData,
                   tbPlayerInput As ControlData,
                   gbTitlesInput As ControlData,
                   dgvSelectedTitles As ControlData,
                   gbResults As ControlData,
                   dgvCharacters As ControlData)

        _fmMain = winForm
        _SavedPosition_gbPlayerInput = gbPlayerInput
        _SavedPosition_tbPlayerInput = tbPlayerInput
        _SavedPosition_gbSelectedTitles = gbTitlesInput
        _SavedPosition_dgvSelectedTitles = dgvSelectedTitles
        _SavedPosition_gbResults = gbResults
        _SavedPosition_dgvCharacters = dgvCharacters
    End Sub

#Region "Extern"
    ''' <summary>Ändert die Sprache der DGV Einträge sowie die Ausrichten der WinForms.</summary>
    Public Sub Initialize(_IsExtendedView As Boolean)
        RelocateWinFormElements(_IsExtendedView)
        ReloadDataGridViewValues()
        SetColumnNamesAndWidth()
        ReloadVisibleDataGridViewValues(_IsExtendedView)
    End Sub

    ''' <summary>Ändert die Ausrichtung der WinForms.</summary>
    Public Sub SwitchExtendedTitles(_IsExtendedView As Boolean)
        RelocateWinFormElements(_IsExtendedView)
        ReloadVisibleDataGridViewValues(_IsExtendedView)
    End Sub

    ''' <summary>Ändert die Sprache der DGV Einträge.</summary>
    Public Sub SwitchExtendedTitlesLanguage(_IsExtended As Boolean)
        ReloadDataGridViewValues()
        SetColumnNamesAndWidth()
        ReloadVisibleDataGridViewValues(_IsExtended)
    End Sub
#End Region

#Region "Intern"
    ''' <summary>Position und Größe der DataGridViews anpassen.</summary>
    Private Sub RelocateWinFormElements(_IsExtendedView As Boolean)
        If _IsExtendedView Then
            '// Erweiterte Titel anzeigen
            With _fmMain
                .gbSelectedTitles.Size = New Size(.gbResults.Width, .gbSelectedTitles.Height)
                .dgvSelectedTitles.Size = New Size(.dgvCharacters.Width, .dgvSelectedTitles.Height)

                .gbResults.Size = New Size(CInt(.gbResults.Width / _Ratio), .gbResults.Height)
                .dgvCharacters.Size = New Size(CInt(.dgvCharacters.Width / _Ratio) - 2, .dgvCharacters.Height)
                .dgvCharacterTitles.Size = New Size(CInt(.dgvCharacterTitles.Width / _Ratio) - 2, .dgvCharacterTitles.Height)

                .gbPlayerInput.Location = New Point(.gbResults.Location.X + .gbResults.Width + 4, .gbResults.Location.Y)
                .gbPlayerInput.Size = New Size(.gbSelectedTitles.Width - .gbResults.Width - 4, .gbResults.Height)

                .tbPlayerInput.Size = New Size(.gbPlayerInput.Width - 12, (.dgvCharacterTitles.Location.Y + .dgvCharacterTitles.Height) - .dgvCharacters.Location.Y)
                .gbPlayerInput.Text = "GUID, AccountID, Name and knownTitles"
            End With
        Else
            '// Einfache Titel anzeigen
            With _fmMain
                .gbPlayerInput.Location = _SavedPosition_gbPlayerInput.Location
                .gbPlayerInput.Size = _SavedPosition_gbPlayerInput.Size
                .gbPlayerInput.Text = "GUID, AccountID, Name and knownTitles | One Character each Line."

                .tbPlayerInput.Location = _SavedPosition_tbPlayerInput.Location
                .tbPlayerInput.Size = _SavedPosition_tbPlayerInput.Size

                .dgvSelectedTitles.Location = _SavedPosition_dgvSelectedTitles.Location
                .dgvSelectedTitles.Size = _SavedPosition_dgvSelectedTitles.Size

                .gbSelectedTitles.Location = _SavedPosition_gbSelectedTitles.Location
                .gbSelectedTitles.Size = _SavedPosition_gbSelectedTitles.Size

                .gbResults.Location = _SavedPosition_gbResults.Location
                .gbResults.Size = _SavedPosition_gbResults.Size

                .dgvCharacters.Size = _SavedPosition_dgvCharacters.Size
                .dgvCharacterTitles.Size = _SavedPosition_dgvCharacters.Size
            End With
        End If
    End Sub

    ''' <summary>Werte der DBC Titeldaten neu einlesen. Bei LanguageChange.</summary>
    Private Sub ReloadDataGridViewValues()
        '// Löschen der bereits vorhandenen Zeilen.
        _fmMain.DsSelectedTitles.dtExtended.Rows.Clear()

        '// Hinzufügen der neuen Titel.
        For Each _Title In _TitelList_All
            Dim _NewRow As dsSelectedTitles.dtExtendedRow = _fmMain.DsSelectedTitles.dtExtended.NewdtExtendedRow

            With _NewRow
                .colChoose = False
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

            _fmMain.DsSelectedTitles.dtExtended.Rows.Add(_NewRow)
        Next

        '// Das DGV besitzt im Moment noch die Daten/Columns des dtShort Tables (3 Columns)!
        '// Zuerst den dtShort Table entfernen, da sonst die Columns des dtShort mit dem dtExtended zusammengeführt werden.
        '// Edit: Sollte nicht mehr nötig sein, nach entfernen des dtShort Tables - Wayne.
        With _fmMain.dgvSelectedTitles
            .DataSource = Nothing
            .DataSource = _fmMain.DsSelectedTitles.dtExtended

            '// Die erste Spalte ist änderbar, alle anderen müssen ReadOnly sein.
            For _i = 1 To .Columns.Count - 1 Step 1
                .Columns(_i).ReadOnly = True
            Next
        End With
    End Sub

    ''' <summary>Die Spaltennamen des DataGridViews mit den DBC Titeln ändern.</summary>
    Private Sub SetColumnNamesAndWidth()
        With _fmMain
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 0, "X", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 1, "TitleID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 2, "InGameOrder", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 3, "IntID", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 4, "BitOfInt", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 5, "Bit", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 6, "DBValue", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 7, "IntID Double", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 8, "UnkRef", DataGridViewAutoSizeColumnMode.AllCells)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 9, "MaleTitle", DataGridViewAutoSizeColumnMode.Fill)
            SetColumnHeaderTextAndWidth(.dgvSelectedTitles, 10, "FemaleTitle", DataGridViewAutoSizeColumnMode.Fill)
        End With
    End Sub

    ''' <summary>Alle sichtbare Spalten der DataGridViews ändern, je nach ExtendedView.</summary>
    Private Sub ReloadVisibleDataGridViewValues(_IsExtendedView As Boolean)
        '// Erweiterte Ansicht & Einfache Ansicht
        With _fmMain.dgvCharacterTitles
            If Not .Columns.Count = 0 Then
                '// Bei True: Spalten verbergen (False), wenn das DGV verkleinert wird.
                .Columns(11).Visible = Not _IsExtendedView
                .Columns(9).Visible = Not _IsExtendedView
                .Columns(8).Visible = Not _IsExtendedView
                .Columns(5).Visible = Not _IsExtendedView
            End If
        End With
        With _fmMain.dgvSelectedTitles
            '// Bei True: Spalten NICHT verbergen (True), weil DGV vergrößert wird. 
            For _i = 2 To 8 Step 1
                .Columns(_i).Visible = _IsExtendedView
            Next
            .Columns(10).Visible = _IsExtendedView
        End With
    End Sub
#End Region
End Class
