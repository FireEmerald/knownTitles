Option Explicit On
Option Strict On

Public Structure ControlData
    Dim Control As Control
    Dim Location As Point
    Dim Size As Size
End Structure

Public Class Cls_DataGridView

#Region "Location & Size Deklarationen"
    Private _SavedPosition_gbPlayerInput As ControlData
    Private _SavedPosition_tbPlayerInput As ControlData
    Private _SavedPosition_gbSelectedTitles As ControlData
    Private _SavedPosition_dgvSelectedTitles As ControlData
    Private _SavedPosition_gbLog As ControlData
    Private _SavedPosition_tbLog As ControlData
#End Region

    '// Defaultpositionen speichern
    Public Sub New(gbPlayerInput As ControlData,
                   tbPlayerInput As ControlData,
                   gbTitlesInput As ControlData,
                   dgvSelectedTitles As ControlData,
                   gbLog As ControlData,
                   tbLog As ControlData)

        _SavedPosition_gbPlayerInput = gbPlayerInput
        _SavedPosition_tbPlayerInput = tbPlayerInput
        _SavedPosition_gbSelectedTitles = gbTitlesInput
        _SavedPosition_dgvSelectedTitles = dgvSelectedTitles
        _SavedPosition_gbLog = gbLog
        _SavedPosition_tbLog = tbLog
    End Sub

    ''' <summary>Position und Größe des DataGridView anpassen.</summary>
    Public Sub Relocate_DataGridView(_ExtendedView As Boolean)
        Reload_DataTable(_ExtendedView)

        If _ExtendedView Then
            '// Erweiterte Titel anzeigen
            With fmMain
                .gbSelectedTitles.Size = New Size(.gbLog.Width, .gbSelectedTitles.Height)
                .dgvSelectedTitles.Size = New Size(.tbLog.Width, .dgvSelectedTitles.Height)

                .gbLog.Size = New Size(CInt(.gbLog.Width / 1.3), .gbLog.Height)
                .tbLog.Size = New Size(CInt(.tbLog.Width / 1.3) - 2, .tbLog.Height)

                .gbPlayerInput.Location = New Point(.gbLog.Location.X + .gbLog.Width + 4, .gbLog.Location.Y)
                .gbPlayerInput.Size = New Size(.gbSelectedTitles.Width - .gbLog.Width - 4, .gbLog.Height)

                .tbPlayerInput.Size = New Size(.gbPlayerInput.Width - 12, .tbLog.Height)
                .gbPlayerInput.Text = "GUID, AccountID, Name and knownTitles"
            End With
        Else
            '// Einfache Titel anzeigen
            With fmMain
                .gbPlayerInput.Location = _SavedPosition_gbPlayerInput.Location
                .gbPlayerInput.Size = _SavedPosition_gbPlayerInput.Size
                .gbPlayerInput.Text = "GUID, AccountID, Name and knownTitles | One Character each Line."

                .tbPlayerInput.Location = _SavedPosition_tbPlayerInput.Location
                .tbPlayerInput.Size = _SavedPosition_tbPlayerInput.Size

                .dgvSelectedTitles.Location = _SavedPosition_dgvSelectedTitles.Location
                .dgvSelectedTitles.Size = _SavedPosition_dgvSelectedTitles.Size

                .gbSelectedTitles.Location = _SavedPosition_gbSelectedTitles.Location
                .gbSelectedTitles.Size = _SavedPosition_gbSelectedTitles.Size

                .gbLog.Location = _SavedPosition_gbLog.Location
                .gbLog.Size = _SavedPosition_gbLog.Size

                .tbLog.Size = _SavedPosition_tbLog.Size
            End With
        End If
    End Sub

    ''' <summary>Inhalt des DataGridView ändern, je nach Sprache in Einstellungen.</summary>
    Public Sub Reload_DataTable(_ExtendedView As Boolean)
        If _ExtendedView Then
            '// Erweiterte Ansicht
            '// Hinzufügen der Titel
            fmMain.DsSelectedTitles.dtExtended.Clear()
            For Each _Title In _TitelList_All
                Dim _NewRow As dsSelectedTitles.dtExtendedRow = fmMain.DsSelectedTitles.dtExtended.NewdtExtendedRow

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

                fmMain.DsSelectedTitles.dtExtended.Rows.Add(_NewRow)
            Next

            '// Neue DataSource setzen.
            With fmMain.dgvSelectedTitles
                .DataSource = fmMain.DsSelectedTitles.dtExtended
            End With

            '// Die Colums vom Table dtExtended anpassen.
            SetColumnWidthAndHeaderText("X", 0, 10)
            SetColumnWidthAndHeaderText("TitleID", 1)
            SetColumnWidthAndHeaderText("InGameOrder", 2)
            SetColumnWidthAndHeaderText("IntID", 3)
            SetColumnWidthAndHeaderText("BitOfInt", 4)
            SetColumnWidthAndHeaderText("Bit", 5)
            SetColumnWidthAndHeaderText("DBValue", 6)
            SetColumnWidthAndHeaderText("IntID Double", 7)
            SetColumnWidthAndHeaderText("UnkRef", 8)
            SetColumnWidthAndHeaderText("MaleTitle", 9)
            SetColumnWidthAndHeaderText("Female Title", 10)

            With fmMain.dgvSelectedTitles.Columns
                .Item(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Item(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Item(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Item(10).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                For _i As Integer = 1 To 10
                    .Item(_i).ReadOnly = True
                Next
            End With
        Else
            '// Einfache Ansicht
            '// Hinzufügen der Titel
            fmMain.DsSelectedTitles.dtShort.Clear()
            For Each _Title In _TitelList_All
                Dim _NewRow As dsSelectedTitles.dtShortRow = fmMain.DsSelectedTitles.dtShort.NewdtShortRow

                With _NewRow
                    .colChoose = False
                    .colTitleID = _Title.TitleID
                    .colMaleTitle = _Title.MaleTitle
                End With

                fmMain.DsSelectedTitles.dtShort.Rows.Add(_NewRow)
            Next

            '// Neue DataSource setzen.
            With fmMain.dgvSelectedTitles
                .DataSource = fmMain.DsSelectedTitles.dtShort
            End With

            '// Die Colums vom Table dtShort anpassen.
            SetColumnWidthAndHeaderText("X", 0, 10)
            SetColumnWidthAndHeaderText("ID", 1)

            With fmMain.dgvSelectedTitles.Columns
                .Item(1).ReadOnly = True

                .Item(2).HeaderText = "MaleTitle"
                .Item(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                .Item(2).ReadOnly = True
            End With
        End If
    End Sub

    ''' <summary>Ändert den Text und die Breite einer Spalte.</summary>
    Private Sub SetColumnWidthAndHeaderText(_ColumnHeaderText As String, _ColumnID As Integer, Optional _Offset As Integer = 25)
        With fmMain.dgvSelectedTitles.Columns
            .Item(_ColumnID).HeaderText = _ColumnHeaderText
            .Item(_ColumnID).Width = TextRenderer.MeasureText(_ColumnHeaderText, fmMain.dgvSelectedTitles.Font).Width + _Offset
            .Item(_ColumnID).MinimumWidth = TextRenderer.MeasureText(_ColumnHeaderText, fmMain.dgvSelectedTitles.Font).Width + _Offset
        End With
    End Sub

End Class
