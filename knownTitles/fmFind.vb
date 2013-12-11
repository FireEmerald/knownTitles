Option Explicit On
Option Strict On

Public Class fmFind

#Region "Deklarationen"
    Private Enum SEARCH
        COUNT = 0
        FILTER = 1
    End Enum
    Private Enum COL
        CHOOSE = 0
        TITLE_ID = 1
        IN_GAME_ORDER = 2
        INT_ID = 3
        BIT_OF_INTEGER = 4
        BIT = 5
        DB_VALUE = 6
        INT_ID_DOUBLE = 7
        UNK_REF = 8
        MALE_TITLE = 9
        MALE_TITLE_SHORT = 2
        FEMALE_TITLE = 10
    End Enum
#End Region

    Private Sub Button_Click_Handler(sender As Object, e As EventArgs) Handles _
        btnCount.Click,
        btnFilter.Click,
        btnReset.Click,
        btnClose.Click,
        tsHelpLink.Click,
        cbTransparency.Click,
        cbWildcraft.Click

        Select Case True
            Case sender Is btnCount
                Progress_Search(SEARCH.COUNT)
            Case sender Is btnFilter
                Progress_Search(SEARCH.FILTER)
            Case sender Is btnReset
                Reset()
            Case sender Is btnClose
                Me.Close()
            Case sender Is tsHelpLink
                ShowMySQLSyntaxHelp()
            Case sender Is cbTransparency
                My.Settings.Transparency = Not cbTransparency.Checked
            Case sender Is cbWildcraft
                My.Settings.Wildcraft = Not cbWildcraft.Checked
        End Select
    End Sub

    Private Sub Progress_Search(_SearchType As Integer)
        Dim _RowFilter As String = ""
        Dim _Wild As String = ""
        '// Falls kein Text eingegeben wurde, resetten.
        If tbToFind.Text = "" Then
            Reset()
            Return
        End If
        '// Wildcraft aktivieren.
        If cbWildcraft.Checked Then
            _Wild = "*"
        End If
        Select Case True
            Case rbSearchMode_Normal.Checked
                Select Case True
                    Case rbColumns_Normal.Checked
                        '// Normal = Nur Titelnamen
                        Select Case True
                            Case CType(fmMain.dgvSelectedTitles.DataSource, DataTable) Is fmMain.DsSelectedTitles.dtExtended
                                _RowFilter = "colMaleTitle LIKE '" + _Wild + tbToFind.Text + _Wild + "' OR colFemaleTitle LIKE '" + _Wild + tbToFind.Text + _Wild
                            Case CType(fmMain.dgvSelectedTitles.DataSource, DataTable) Is fmMain.DsSelectedTitles.dtShort
                                _RowFilter = "colMaleTitle LIKE '" + _Wild + tbToFind.Text + _Wild
                        End Select
                    Case rbColumns_All.Checked
                        '// Alle Spalten prüfen

                        '// Auf Boolesche Variable prüfen.
                        Dim _Value As Boolean
                        Try
                            _Value = CBool(tbToFind.Text)
                            _RowFilter += "colChoose = '" + _Value.ToString + "' OR "
                        Catch
                        End Try

                        Select Case True
                            Case CType(fmMain.dgvSelectedTitles.DataSource, DataTable) Is fmMain.DsSelectedTitles.dtExtended
                                If IsNumeric(tbToFind.Text) AndAlso Not tbToFind.Text.Contains("+") AndAlso Not tbToFind.Text.Contains("-") Then
                                    '// Numerisch
                                    _RowFilter += "colTitleID = '" + tbToFind.Text + _
                                     "' OR colInGameOrder = '" + tbToFind.Text + _
                                     "' OR colIntID = '" + tbToFind.Text + _
                                     "' OR colBitOfInteger = '" + tbToFind.Text + _
                                     "' OR colBit = '" + tbToFind.Text + _
                                     "' OR colDBValue LIKE '" + tbToFind.Text + _
                                     "' OR colIntID_Double = '" + tbToFind.Text + _
                                     "' OR colUnkRef = '" + tbToFind.Text + _
                                     "' OR colMaleTitle LIKE '" + tbToFind.Text + _
                                     "' OR colFemaleTitle LIKE '" + tbToFind.Text
                                Else
                                    '// Nicht Numerisch
                                    _RowFilter += "colDBValue LIKE '" + tbToFind.Text + _
                                                 "' OR colMaleTitle LIKE '" + tbToFind.Text + _
                                                 "' OR colFemaleTitle LIKE '" + tbToFind.Text
                                End If
                            Case CType(fmMain.dgvSelectedTitles.DataSource, DataTable) Is fmMain.DsSelectedTitles.dtShort
                                If IsNumeric(tbToFind.Text) AndAlso Not tbToFind.Text.Contains("+") AndAlso Not tbToFind.Text.Contains("-") Then
                                    '// Numerisch
                                    _RowFilter += "colTitleID = '" + tbToFind.Text + _
                                                 "' OR colMaleTitle LIKE '" + tbToFind.Text
                                Else
                                    '// Nicht Numerisch
                                    _RowFilter += "colMaleTitle LIKE '" + tbToFind.Text
                                End If
                        End Select
                    Case rbColumns_Specified.Checked
                        '// Spezielle Spalte prüfen

                        If cbColumns_Specified.SelectedIndex = COL.CHOOSE Then
                            '// Auf Boolesche Variable prüfen.
                            Dim _Value As Boolean = Nothing
                            Try
                                _Value = CBool(tbToFind.Text)
                            Catch ex As Exception
                                tsStatusLabel.Text = "Only Boolean expressions are allowed on this column!"
                                Return
                            End Try
                            _RowFilter += "colChoose = '" + _Value.ToString
                            Exit Select
                        End If
                        Select Case True
                            Case CType(fmMain.dgvSelectedTitles.DataSource, DataTable) Is fmMain.DsSelectedTitles.dtExtended
                                _RowFilter += "col" + cbColumns_Specified.SelectedItem.ToString.Replace(" ", "_")
                                Select Case cbColumns_Specified.SelectedIndex
                                    Case COL.DB_VALUE
                                        _RowFilter += " LIKE '"
                                    Case COL.MALE_TITLE
                                        _RowFilter += " LIKE '"
                                    Case COL.FEMALE_TITLE
                                        _RowFilter += " LIKE '"
                                    Case Else
                                        If IsNumeric(tbToFind.Text) AndAlso Not tbToFind.Text.Contains("+") AndAlso Not tbToFind.Text.Contains("-") Then
                                            '// Numerisch
                                            _RowFilter += " = '"
                                        Else
                                            '// Mit einem String o.ä. kann nicht in einem Integer gesucht werden.
                                            tsStatusLabel.Text = "Only Numeric expressions are allowed on this column!"
                                            Return
                                        End If
                                End Select
                            Case CType(fmMain.dgvSelectedTitles.DataSource, DataTable) Is fmMain.DsSelectedTitles.dtShort
                                _RowFilter += "col" + cbColumns_Specified.SelectedItem.ToString.Replace("ID", "TitleID")
                                Select Case cbColumns_Specified.SelectedIndex
                                    Case COL.MALE_TITLE_SHORT
                                        _RowFilter += " LIKE '"
                                    Case Else
                                        If IsNumeric(tbToFind.Text) AndAlso Not tbToFind.Text.Contains("+") AndAlso Not tbToFind.Text.Contains("-") Then
                                            '// Numerisch
                                            _RowFilter += " = '"
                                        Else
                                            '// Mit einem String o.ä. kann nicht in einem Integer gesucht werden.
                                            tsStatusLabel.Text = "Only Numeric expressions are allowed on this column!"
                                            Return
                                        End If
                                End Select
                        End Select
                        '// Wird bei einer Booleschen Variable übersprungen.
                        _RowFilter += tbToFind.Text
                End Select
                _RowFilter += "'"
            Case rbSearchMode_SQLSytax.Checked
                '// MySQL Syntax, kann zu Fehlern führen!
                _RowFilter = tbToFind.Text
        End Select

        Select Case _SearchType
            Case SEARCH.COUNT
                '// Suchmaske anwenden.
                Dim _Rows() As DataRow = CType(fmMain.dgvSelectedTitles.DataSource, DataTable).Select(_RowFilter)

                '// Zählen der passenden Zeilen.
                tsStatusLabel.Text = "Count: " + _Rows.Count.ToString + " matches."
            Case SEARCH.FILTER
                Try
                    '// Filter anwenden.
                    CType(fmMain.dgvSelectedTitles.DataSource, DataTable).DefaultView.RowFilter = _RowFilter
                Catch ex As Exception
                    '// Fehlerbehandlung bei MySQL Syntax.
                    tsStatusLabel.Text = ex.Message
                    tsHelpLink.Visible = True
                    Return
                End Try

                '// Zählen der verbleibenden Zeilen.
                tsStatusLabel.Text = "Found: " + fmMain.dgvSelectedTitles.Rows.Count.ToString + " matches."
        End Select
        '// Erfolgreich durchgeführt.
        tsHelpLink.Visible = False
        RefreshVisualRowColor()
    End Sub
    'http://www.vb-tips.com/dbpages.aspx?IA=DG2

    ''' <summary>Setzt das DataGridView auf den Ausgangszustand zurück.</summary>
    Private Sub Reset()
        CType(fmMain.dgvSelectedTitles.DataSource, DataTable).DefaultView.RowFilter = "colMaleTitle LIKE '*'"
        tsStatusLabel.Text = ""
        tsHelpLink.Visible = False
        RefreshVisualRowColor()
    End Sub

    ''' <summary>MessageBox mit Hilfe zur SQL Syntax anzeigen.</summary>
    Private Sub ShowMySQLSyntaxHelp()
        Static _Show As Boolean = True

        If _Show Then
            Select Case MessageBox.Show("It's highly recommended, that you take a look at how the syntax should look like, would you like?" + vbCrLf + vbCrLf + _
                                    "You have to use this column names instead of the visibles:" + vbCrLf + _
                                    """X"" ⇒ ""colChoose""" + vbCrLf + _
                                    """ID/TitleID"" ⇒ ""colTitleID""" + vbCrLf + _
                                    """IntID Double"" ⇒ ""colIntID_Double""" + vbCrLf + vbCrLf + _
                                    "Don't forget to add a ""col"" for each column name, like shown!", _
                                    "Important informations!", MessageBoxButtons.YesNo, MessageBoxIcon.Information)

                Case Windows.Forms.DialogResult.Yes
                    Process.Start("http://www.csharp-examples.net/dataview-rowfilter/")
            End Select
            _Show = False
        End If
    End Sub

#Region "Funktionelle Events"
    Private Sub rbSearchMode_SQLSytax_CheckedChanged(sender As Object, e As EventArgs) Handles rbSearchMode_SQLSytax.CheckedChanged
        '// Columns GroupBox & Count disabeln, während MySQL Syntax ausgewählt ist.
        gbColumns.Enabled = Not rbSearchMode_SQLSytax.Checked
        btnCount.Enabled = Not rbSearchMode_SQLSytax.Checked

        If rbSearchMode_SQLSytax.Checked Then ShowMySQLSyntaxHelp()
    End Sub

    Private Sub cbColumns_Specified_DropDown(sender As Object, e As EventArgs) Handles cbColumns_Specified.DropDown
        '// Wenn das DropDown Menü der einzelnen Spalten geöffnet wird, automatisch den RadioButton aktivieren.
        rbColumns_Specified.Checked = True
    End Sub

    Private Sub TextBox_KeyDown_Handler(sender As Object, e As KeyEventArgs) Handles tbToFind.KeyDown
        '// Filter anwenden bei ENTER
        Select Case e.KeyCode
            Case Keys.Enter
                Progress_Search(SEARCH.FILTER)
        End Select
    End Sub
#End Region

#Region "Laden & Speichern der RadioButtons"
    Private Sub fmFind_Load(sender As Object, e As EventArgs) Handles Me.Load
        '// Laden der RadioButtons.
        With My.Settings
            rbSearchMode_Normal.Checked = .SearchMode_Normal
            rbSearchMode_SQLSytax.Checked = .SearchMode_SQLSyntax

            rbColumns_All.Checked = .Columns_All
            rbColumns_Normal.Checked = .Columns_Normal
            rbColumns_Specified.Checked = .Columns_Specified

            cbTransparency.Checked = .Transparency
            cbWildcraft.Checked = .Wildcraft
        End With
        '// Laden der ComboBox Items & Auswählen des ersten Items.
        For Each _Column As DataGridViewColumn In fmMain.dgvSelectedTitles.Columns
            cbColumns_Specified.Items.Add(_Column.HeaderText)
        Next
        cbColumns_Specified.SelectedIndex = 0
    End Sub

    Private Sub fmFind_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        '// Speichern der RadioButtons.
        With My.Settings
            .SearchMode_Normal = rbSearchMode_Normal.Checked
            .SearchMode_SQLSyntax = rbSearchMode_SQLSytax.Checked

            .Columns_All = rbColumns_All.Checked
            .Columns_Normal = rbColumns_Normal.Checked
            .Columns_Specified = rbColumns_Specified.Checked

            .Transparency = cbTransparency.Checked
            .Wildcraft = cbWildcraft.Checked
        End With

        fmMain._fmFind = Nothing
    End Sub
#End Region

#Region "Transparenz"
    Private Sub fmFind_Leave(sender As Object, e As EventArgs) Handles Me.Activated
        If cbTransparency.Checked Then Me.Opacity = 1
    End Sub

    Private Sub fmFind_Enter(sender As Object, e As EventArgs) Handles Me.Deactivate
        If cbTransparency.Checked Then Me.Opacity = 0.3
    End Sub
#End Region
End Class