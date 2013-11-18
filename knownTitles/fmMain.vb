Option Explicit On
Option Strict On

Imports System.Threading
Imports System.Text.RegularExpressions

Public Class fmMain

#Region "Deklarationen"
    '// Booleanische Variablen
    Private _Debug As Boolean = False
    Private _InlineReport As Boolean = False
    Private _LogToHarddrive As Boolean = False
    Private _GenerateSQLQuery As Boolean = False

    '// Speichert die Startzeit des laufenden Threads
    Private _StartTime As Date

    '// Speichert die laufenden Threads
    Private _Hashtable As New Hashtable

#Region "Location & Size Deklarationen"
    Structure ControlData
        Dim Control As Control
        Dim Location As Point
        Dim Size As Size
    End Structure

    Private _CD_gbPlayerInput As ControlData
    Private _CD_tbPlayerInput As ControlData
    Private _CD_gbTitlesInput As ControlData
    Private _CD_clbTitlesInput As ControlData
    Private _CD_gbLog As ControlData
    Private _CD_tbLog As ControlData
#End Region
#End Region

    '// Button Pressed Handler
    Private Sub Button_ClickedHandler(sender As Object, e As EventArgs) Handles _
        btnAdd.Click,
        btnImportFromClipboard.Click,
        btnRemove.Click,
        btnLookup.Click,
        btnLogfilePath.Click,
        btnSQLQueryPath.Click

        Select Case True
            Case sender Is btnAdd
                '// Titel hinzufügen
                MessageBox.Show("Not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case sender Is btnImportFromClipboard
                '// Von Zwischenablage importieren
                If Clipboard.ContainsText Then
                    Process_GetClipboardContent_Start(Clipboard.GetText)
                End If
            Case sender Is btnRemove
                '// Titel entfernen
                tbLog.Text = ""
                Remove_EmptyLines(tbPlayerInput)
                Process_RemoveTitles_Start(GetSelectedTitles(clbTitlesInput, _Debug))
            Case sender Is btnLookup
                '// Titel auslesen
                If _Debug Then
                    DebugGermanTitles()
                Else
                    tbLog.Text = ""
                    Remove_EmptyLines(tbPlayerInput)
                    Process_LookupTitles_Start()
                End If
            Case sender Is btnLogfilePath
                '// Logfile Pfad festlegen
                Dim _Path As String = OpenSaveFileDialog(".txt files (*.txt)|*.txt|All files (*.*)|*.*", "kT_Log")
                If Not _Path = "" Then
                    tbLogfilePath.Text = _Path
                End If
            Case sender Is btnSQLQueryPath
                '// SQL Query Pfad festlegen
                Dim _Path As String = OpenSaveFileDialog(".sql files (*.sql)|*.sql|All files (*.*)|*.*", "kT_Query")
                If Not _Path = "" Then
                    tbSQLQueryPath.Text = _Path
                End If
        End Select
    End Sub

    Private Sub Process_GetClipboardContent_Start(ClipboardContent As String)
        '// Das Task-Objekt erstellen.
        Dim _ClipboardProcess As New Clipboard_Cls(ClipboardContent, _Debug)
        AddHandler _ClipboardProcess.StatusReport, AddressOf StatusReport_Handler
        AddHandler _ClipboardProcess.ClipboardImport_Completed, AddressOf ClipboardImport_Completed_Handler

        '// Den Thread erstellen.
        Dim _ClipboardProcess_Thread As New Thread(AddressOf _ClipboardProcess.GetDataFromClipboard)
        _ClipboardProcess_Thread.Start()
    End Sub

    Private Sub Process_LookupTitles_Start()
        '// Das Task-Objekt erstellen.
        Dim _MainProcess As New Main_Cls(tbPlayerInput.Text, tbLogfilePath.Text, _Debug, _InlineReport, _LogToHarddrive)
        AddHandler _MainProcess.InlineReport, AddressOf InlineReport_Handler
        AddHandler _MainProcess.StatusReport, AddressOf StatusReport_Handler
        AddHandler _MainProcess.CompletedReport, AddressOf CompletedReport_Handler

        '// Startzeit festhalten & Buttons auf Form sperren
        _StartTime = Date.Now
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _MainProcess_Thread As New Thread(AddressOf _MainProcess.LookupProcess)
        _MainProcess_Thread.Start()
        _Hashtable.Add(_MainProcess.P_Guid.ToString, _MainProcess_Thread)
    End Sub

    Private Sub Process_RemoveTitles_Start(_SelectedTitles As List(Of CharTitle))
        '// Das Task-Objekt erstellen.
        Dim _MainProcess As New Main_Cls(_SelectedTitles, tbPlayerInput.Text, tbLogfilePath.Text, tbSQLQueryPath.Text, _Debug, _InlineReport, _LogToHarddrive, _GenerateSQLQuery)
        AddHandler _MainProcess.InlineReport, AddressOf InlineReport_Handler
        AddHandler _MainProcess.StatusReport, AddressOf StatusReport_Handler
        AddHandler _MainProcess.CompletedReport, AddressOf CompletedReport_Handler

        '// Startzeit festhalten & Buttons auf der Form sperren
        _StartTime = Date.Now
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _MainProcess_Thread As New Thread(AddressOf _MainProcess.RemoveProcess)
        _MainProcess_Thread.Start()
        _Hashtable.Add(_MainProcess.P_Guid.ToString, _MainProcess_Thread)
    End Sub

#Region "Main Event Handler"
    Private Sub InlineReport_Handler(sender As Object, e As InlineReportEArgs)
        '// Eine thread-sichere Aktualisierung durchführen.
        tbX_AddText(e.P_LogMessage + vbCrLf, tbLog)
    End Sub

    Private Sub StatusReport_Handler(sender As Object, e As StatusReportEArgs)
        '// Eine thread-sichere Aktualisierung durchführen.
        If e.P_StatusMessage = "" Then
            tsMain_setPercent(e.P_PercentDone)
        Else
            tsMain_setAll(e.P_PercentDone, e.P_StatusMessage)
        End If
    End Sub

    Private Sub CompletedReport_Handler(sender As Object, e As CompletedReportEArgs)
        '// Abschließende Informationen anzeigen.
        Dim _ProgressTime As TimeSpan = (Date.Now - _StartTime)

        If Not e.P_InlineReport Then
            tbX_AddText(e.P_Log + vbCrLf + _
                                   "Thread GUID: " + e.P_Guid.ToString + ")" + _
                                   " | Start: " + _StartTime.ToString + _
                                   " | Finished: " + Date.Now.ToString + _
                                   " | Elapsed: " + String.Format("{0:0.##} minute(s), {1:0},{2:0} second(s)", _ProgressTime.Minutes, _ProgressTime.Seconds, _ProgressTime.Milliseconds), tbLog)
        End If
        '// ToolStrip aktualisieren.
        tsMain_setAll(100, "Done!" + String.Format("  | Elapsed: {0:0.##} minute(s), {1:0},{2:0} second(s)", _ProgressTime.Minutes, _ProgressTime.Seconds, _ProgressTime.Milliseconds))
        '// Buttons auf der Form entsperren.
        btnX_setState(True)

        '// Das Task-Objekt löschen.
        SyncLock _Hashtable
            _Hashtable.Remove(e.P_Guid.ToString)
        End SyncLock
    End Sub
#End Region

#Region "Clipboard Event Handler"
    Private Sub ClipboardImport_Completed_Handler(_Content As String, _WrongContent As String, _WrongCount As Integer)
        '// Clipboard Content der Form hinzufügen.
        If Not tbPlayerInput.Lines(tbPlayerInput.Lines.Count - 1) = "" Then
            '// Verhindern dass zwei Charakterdaten in einer Zeile landen.
            tbX_AddText(vbCrLf, tbPlayerInput)
        End If
        tbX_AddText(_Content, tbPlayerInput)

        '// Prüfen ob falsche Einträge gefunden wurden.
        If _WrongCount = 0 Then
            tsMain_setAll(100, "Done!")
        Else
            tsMain_setAll(100, "Done!  | " + _WrongCount.ToString + " wrong entry(s) found!")
            Select Case MessageBox.Show(_WrongCount.ToString + " wrong entry(s) found!" + vbCrLf + "Would you like to see them?", "Wrong format found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.Yes
                    If _WrongCount > 50 Then
                        Try
                            My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_WrongValues.txt", _WrongContent, False)
                            Process.Start(My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_WrongValues.txt")
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Try
                    Else
                        MessageBox.Show(_WrongContent, "Wrong values.", MessageBoxButtons.OK, MessageBoxIcon.None)
                    End If
            End Select
        End If
    End Sub
#End Region

#Region "Threads abbrechen"
    '// Alle noch nicht beendeten Threads abbrechen.
    Private Sub fmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CancelAllThreads()
    End Sub

    '// Alle noch nicht beendeten Threads abbrechen.
    Private Sub CancelAllThreads()
        Dim _ThreadToCancel As Thread

        For Each _Thread As DictionaryEntry In _Hashtable
            _ThreadToCancel = CType(_Thread.Value, Thread)
            If (_ThreadToCancel.ThreadState And ThreadState.Running) = ThreadState.Running Then
                _ThreadToCancel.Abort()
            End If
        Next

        '// Alle Task-Objekte löschen.
        SyncLock _Hashtable
            _Hashtable.Clear()
        End SyncLock
    End Sub
#End Region

#Region "Invoker Subs"
    ''' <summary>Buttons auf der Form sperren oder entsperren.</summary>
    Public Sub btnX_setState(_State As Boolean)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _Buttons() As Windows.Forms.Button = {btnAdd, btnImportFromClipboard, btnRemove, btnLookup}
        Dim _btnControl As New ControlButtonUpdater(_Buttons)

        '// Formelemente sperren / entsperren.
        _btnControl.setState(_State)
    End Sub

    Private Sub tbX_AddText(_Text As String, _TextBox As System.Windows.Forms.TextBox)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tbPlayerOutput As New ControlTextUpdater(_TextBox)

        _tbPlayerOutput.AddText(_Text)
    End Sub

    Private Sub tsMain_setAll(_Percent As Integer, _Text As String)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New ControlStatusStripUpdater(tsPbStatusPercent, tsSlStatusPercent, tsSlStatusText)

        _tsMain.setAll(_Percent, _Text)
    End Sub
    Private Sub tsMain_setPercent(_Percent As Integer)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New ControlStatusStripUpdater(tsPbStatusPercent, tsSlStatusPercent)

        _tsMain.setPercent(_Percent)
    End Sub
    Private Sub tsMain_setText(_Text As String)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New ControlStatusStripUpdater(tsSlStatusText)

        _tsMain.setText(_Text)
    End Sub
#End Region


    '// Verwaltung der oberen Menüleiste
    Private Sub Menu_ClickedHandler(sender As Object, e As EventArgs) Handles _
        miExit.Click,
        miFile_SaveLogfile.Click,
        miInfo_About.Click,
        miLanguage_Save.Click

        Select Case True
            Case sender Is miExit
                CancelAllThreads()
                Application.Exit()
            Case sender Is miFile_SaveLogfile
                '// Logfile Pfad festlegen
                Dim _Path As String = OpenSaveFileDialog(".txt files (*.txt)|*.txt|All files (*.*)|*.*", "kT_Log")
                If Not _Path = "" Then
                    Try
                        My.Computer.FileSystem.WriteAllText(_Path, tbLog.Text, False)
                        Process.Start(_Path)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try
                End If
            Case sender Is miInfo_About
                Dim _fmAbout As New fmAbout
                _fmAbout.StartPosition = FormStartPosition.Manual
                _fmAbout.Location = New Point(CInt((Me.Location.X + (Me.Size.Width / 2)) - (_fmAbout.Size.Width / 2)), CInt((Me.Location.Y + (Me.Size.Height / 2)) - (_fmAbout.Size.Height / 2)))
                _fmAbout.Show()
            Case sender Is miLanguage_Save
                If _Hashtable.Count = 0 Then
                    Select Case miLanguage_ComboBox.SelectedIndex
                        Case 0 '// English
                            ChangeLanguage(0)
                        Case 1 '// German
                            ChangeLanguage(1)
                    End Select
                Else
                    MessageBox.Show("You can't change the language, while processing..." + vbCrLf + "Threads running: " + _Hashtable.Count.ToString, "Wait until finished.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
        End Select
    End Sub

#Region "Checkbox Handler"
    '// Booleanische Variablen ändern.
    Private Sub ChekBox_Handler(sender As Object, e As EventArgs) Handles _
        cbDebug.CheckStateChanged, _
        cbInlineReport.CheckStateChanged, _
        cbLogToHarddrive.CheckStateChanged, _
        cbGenerateSQLQuery.CheckStateChanged

        Select Case True
            Case sender Is cbDebug
                If cbDebug.CheckState = CheckState.Checked Then
                    _Debug = True
                Else
                    _Debug = False
                End If
            Case sender Is cbInlineReport
                If cbInlineReport.CheckState = CheckState.Checked Then
                    _InlineReport = True
                Else
                    _InlineReport = False
                End If
            Case sender Is cbLogToHarddrive
                If cbLogToHarddrive.CheckState = CheckState.Checked Then
                    _LogToHarddrive = True
                Else
                    _LogToHarddrive = False
                End If
            Case sender Is cbGenerateSQLQuery
                If cbGenerateSQLQuery.CheckState = CheckState.Checked Then
                    _GenerateSQLQuery = True
                Else
                    _GenerateSQLQuery = False
                End If
        End Select
    End Sub

    '// Extended Titel umschalten.
    Private Sub cbExtendedBannedTitles_CheckStateChanged(sender As Object, e As EventArgs) Handles cbExtendedTitles.CheckStateChanged
        If cbExtendedTitles.CheckState = CheckState.Checked Then
            '// Erweiterte Titel anzeigen
            Reload_TitlesInput(True)
            '// GroupBox - Größe/Position anpassen
            gbPlayerInput.Location = New Point(gbTitlesInput.Location.X, gbTitlesInput.Location.Y)
            gbPlayerInput.Size = New Size((_CD_gbPlayerInput.Location.X + _CD_gbPlayerInput.Size.Width) - 12, gbPlayerInput.Size.Height)
            gbTitlesInput.Location = New Point(gbTitlesInput.Location.X, gbLog.Location.Y)
            gbTitlesInput.Size = New Size(gbLog.Width, CInt(gbLog.Height / 2.5))

            gbLog.Location = New Point(gbTitlesInput.Location.X, gbTitlesInput.Location.Y + gbTitlesInput.Height + 5)
            gbLog.Size = New Size(gbTitlesInput.Width, (gbLog.Height - gbTitlesInput.Height) - 5)

            '// TextBox/CheckList - Größe anpassen
            tbPlayerInput.Size = New Size(gbPlayerInput.Size.Width - 12, tbPlayerInput.Size.Height)
            clbTitlesInput.Size = New Size(tbLog.Width, gbTitlesInput.Height - 20)

            tbLog.Size = New Size(clbTitlesInput.Width, gbLog.Size.Height - 25)
        Else
            '// Erweiterte Titel ausblenden
            Reload_TitlesInput(False)
            '// GroupBox - Größe/Position anpassen
            gbPlayerInput.Location = _CD_gbPlayerInput.Location
            gbPlayerInput.Size = _CD_gbPlayerInput.Size
            gbTitlesInput.Location = _CD_gbTitlesInput.Location
            gbTitlesInput.Size = _CD_gbTitlesInput.Size
            gbLog.Location = _CD_gbLog.Location
            gbLog.Size = _CD_gbLog.Size
            '// TextBox/CheckList - Größe anpassen
            tbPlayerInput.Size = _CD_tbPlayerInput.Size
            clbTitlesInput.Size = _CD_clbTitlesInput.Size
            tbLog.Size = _CD_tbLog.Size
        End If
    End Sub
#End Region

    '// Form Load - Diverse Sachen laden.
    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        tbLogfilePath.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_Log.txt"
        tbSQLQueryPath.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_Query.sql"
        miLanguage_ComboBox.SelectedIndex = My.Settings.Language
        tsPbStatusPercent.Maximum = 100

        _CD_gbPlayerInput = New ControlData With {.Control = gbPlayerInput, .Location = gbPlayerInput.Location, .Size = gbPlayerInput.Size}
        _CD_tbPlayerInput = New ControlData With {.Control = tbPlayerInput, .Location = tbPlayerInput.Location, .Size = tbPlayerInput.Size}
        _CD_gbTitlesInput = New ControlData With {.Control = gbTitlesInput, .Location = gbTitlesInput.Location, .Size = gbTitlesInput.Size}
        _CD_clbTitlesInput = New ControlData With {.Control = clbTitlesInput, .Location = clbTitlesInput.Location, .Size = clbTitlesInput.Size}
        _CD_gbLog = New ControlData With {.Control = gbLog, .Location = gbLog.Location, .Size = gbLog.Size}
        _CD_tbLog = New ControlData With {.Control = tbLog, .Location = tbLog.Location, .Size = tbLog.Size}

        ChangeLanguage(My.Settings.Language)
    End Sub

    Private Sub ChangeLanguage(_NewLanguageID As Integer)
        Select Case _NewLanguageID
            Case 0 '// English
                _LANG_TitelList_All = _TitleList_All_ENG
                _LANG_TitleList_INT_0 = _TitleList_INT_0_ENG
                _LANG_TitleList_INT_1 = _TitleList_INT_1_ENG
                _LANG_TitleList_INT_2 = _TitleList_INT_2_ENG
                _LANG_TitleList_INT_3 = _TitleList_INT_3_ENG
                _LANG_TitleList_INT_4 = _TitleList_INT_4_ENG
            Case 1 '// German
                _LANG_TitelList_All = _TitleList_All_GER
                _LANG_TitleList_INT_0 = _TitleList_INT_0_GER
                _LANG_TitleList_INT_1 = _TitleList_INT_1_GER
                _LANG_TitleList_INT_2 = _TitleList_INT_2_GER
                _LANG_TitleList_INT_3 = _TitleList_INT_3_GER
                _LANG_TitleList_INT_4 = _TitleList_INT_4_GER
        End Select
        '// Reloads aufrufen um Elemente an neue Sprache anzupassen
        Reload_TitlesInput(CBool(cbExtendedTitles.CheckState))

        My.Settings.Language = _NewLanguageID
        My.Settings.Save()
    End Sub

#Region "Debug Subs"
    Private Sub DebugGermanTitles()
        Dim _Out As String = ""
        Dim _List As String = "Public ReadOnly _TitleList_All_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {"
        Dim _Counter As Integer = 0
        For Each _Line In tbPlayerInput.Lines
            Select Case _Counter
                Case 0
                    _Out += "Private _" + _Line + "_GER As New CharTitle With {.TitleID = " + _Line
                    _List += "_" + _Line + "_GER, "
                Case 1
                    _Out += ", .IntID = " + _Line
                Case 2
                    _Out += ", .DBValue = """ + _Line + """"
                Case 3
                    _Out += ", .Bit = " + _Line
                Case 4
                    If _Line.EndsWith(" ") Then MessageBox.Show("""" + _Line + """ EndsWith Leerzeichen!")
                    _Out += ", .MaleTitle = """ + _Line + """}" + vbCrLf
                    _Counter = 0
                    Continue For
            End Select
            If _Line.EndsWith(" ") Then MessageBox.Show("""" + _Line + """ EndsWith Leerzeichen!")
            _Counter += 1
        Next
        Dim _List_0 As String = "Public ReadOnly _TitleList_INT_0_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {"
        Dim _List_1 As String = "Public ReadOnly _TitleList_INT_1_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {"
        Dim _List_2 As String = "Public ReadOnly _TitleList_INT_2_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {"
        Dim _List_3 As String = "Public ReadOnly _TitleList_INT_3_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {"
        Dim _List_4 As String = "Public ReadOnly _TitleList_INT_4_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {"
        For Each _Title In _TitleList_All_GER
            Select Case _Title.IntID
                Case 0
                    _List_0 += "_" + _Title.TitleID.ToString + "_GER, "
                Case 1
                    _List_1 += "_" + _Title.TitleID.ToString + "_GER, "
                Case 2
                    _List_2 += "_" + _Title.TitleID.ToString + "_GER, "
                Case 3
                    _List_3 += "_" + _Title.TitleID.ToString + "_GER, "
                Case 4
                    _List_4 += "_" + _Title.TitleID.ToString + "_GER, "
                Case Else
                    MessageBox.Show("ERROR")
            End Select
        Next
        tbLog.Text = ""
        tbLog.Text = _Out + vbCrLf +
                              _List + "})" + vbCrLf +
                              _List_0 + "})" + vbCrLf +
                              _List_1 + "})" + vbCrLf +
                              _List_2 + "})" + vbCrLf +
                              _List_3 + "})" + vbCrLf +
                              _List_4 + "})"
    End Sub
#End Region


    Private Sub INSERTINTOcharactersguidaccountnameknownTitlesVALUES11ABC000000ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSERTINTOcharactersguidaccountnameknownTitlesVALUES11ABC000000ToolStripMenuItem.Click
        INSERTINTOcharactersguidaccountnameknownTitlesVALUES11ABC000000ToolStripMenuItem.ForeColor = Color.Green
    End Sub
End Class
