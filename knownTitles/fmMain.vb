﻿Option Explicit On
Option Strict On

Imports System.Threading
Imports System.Text.RegularExpressions

Public Class fmMain

#Region "Deklarationen"
    '// Booleanische Variablen
    Private _InlineReport As Boolean = False
    Private _LogToHarddrive As Boolean = False
    Private _GenerateSQLQuery As Boolean = False

    '// Speichert die Startzeit des laufenden Threads
    Private _StartTime As Date

    '// Für die Verarbeitung des DataGridView verantwortlich
    Private _DataGridView_Handler As Cls_DataGridView

    '// Speichert die laufenden Threads
    Private _Hashtable As New Hashtable
#End Region

    '// Button Pressed Handler
    Private Sub Button_ClickedHandler(sender As Object, e As EventArgs) Handles _
        btnAdd.Click,
        btnRemove.Click,
        btnLookup.Click,
        btnSearch.Click

        Select Case True
            Case sender Is btnAdd
                '// Titel hinzufügen
                MessageBox.Show("Not implemented yet.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'GetSelectedTitles(DsSelectedTitles.dtShort)
            Case sender Is btnRemove
                '// Titel entfernen
                tbLog.Text = ""
                Remove_EmptyLines(tbPlayerInput)

                Process_ValidatePlayerInput_Start(New MainProcessing With {.ID = MainProcessingID.PROCESS_REMOVE,
                                                                           .PlayerInput = tbPlayerInput.Text})
            Case sender Is btnLookup
                '// Titel auslesen
                tbLog.Text = ""
                Remove_EmptyLines(tbPlayerInput)

                Process_ValidatePlayerInput_Start(New MainProcessing With {.ID = MainProcessingID.PROCESS_LOOKUP,
                                                                           .PlayerInput = tbPlayerInput.Text})
            Case sender Is btnSearch
                '// Titel suchen
                tbLog.Text = ""
                Remove_EmptyLines(tbPlayerInput)

                Process_ValidatePlayerInput_Start(New MainProcessing With {.ID = MainProcessingID.PROCESS_SEARCH,
                                                                           .PlayerInput = tbPlayerInput.Text})
        End Select
    End Sub

#Region "Prozesse starten"
    Private Sub Process_GetClipboardContent_Start(ClipboardContent As String)
        '// Das Task-Objekt erstellen.
        Dim _ClipboardProcess As New Cls_Clipboard(ClipboardContent)
        AddHandler _ClipboardProcess.StatusReport, AddressOf StatusReport_Handler
        AddHandler _ClipboardProcess.ClipboardImport_Completed, AddressOf ClipboardImport_Completed_Handler

        '// Buttons auf der Form sperren
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _ClipboardProcess_Thread As New Thread(AddressOf _ClipboardProcess.GetDataFromClipboard)
        _ClipboardProcess_Thread.Start()
        _Hashtable.Add(_ClipboardProcess.P_Guid.ToString, _ClipboardProcess_Thread)
    End Sub

    Private Sub Process_LookupTitles_Start(_MainProcess As MainProcessing)
        '// Das Task-Objekt erstellen.
        Dim _Process As New Cls_Main(_MainProcess, miLogfile_Path.Text)
        AddHandler _Process.InlineReport, AddressOf InlineReport_Handler
        AddHandler _Process.StatusReport, AddressOf StatusReport_Handler
        AddHandler _Process.MainProcess_Completed, AddressOf MainProcess_Completed_Handler

        '// Startzeit festhalten & Buttons auf Form sperren
        _StartTime = Date.Now
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _Process_Thread As New Thread(AddressOf _Process.Lookup)
        _Process_Thread.Start()
        _Hashtable.Add(_Process.P_MainProcess_Guid.ToString, _Process_Thread)
    End Sub

    Private Sub Process_RemoveTitles_Start(_MainProcess As MainProcessing)
        '// Das Task-Objekt erstellen.
        Dim _Process As New Cls_Main(_MainProcess, miLogfile_Path.Text, miSQLQuery_Path.Text)
        AddHandler _Process.InlineReport, AddressOf InlineReport_Handler
        AddHandler _Process.StatusReport, AddressOf StatusReport_Handler
        AddHandler _Process.MainProcess_Completed, AddressOf MainProcess_Completed_Handler

        '// Startzeit festhalten & Buttons auf der Form sperren
        _StartTime = Date.Now
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _Process_Thread As New Thread(AddressOf _Process.Remove)
        _Process_Thread.Start()
        _Hashtable.Add(_Process.P_MainProcess_Guid.ToString, _Process_Thread)
    End Sub

    Private Sub Process_SearchTitles_Start(_MainProcess As MainProcessing)
        '// Das Task-Object erstellen.
        Dim _Process As New Cls_Main(_MainProcess, miLogfile_Path.Text)
        AddHandler _Process.InlineReport, AddressOf InlineReport_Handler
        AddHandler _Process.StatusReport, AddressOf StatusReport_Handler
        AddHandler _Process.MainProcess_Completed, AddressOf MainProcess_Completed_Handler

        '// Startzeit festhalten & Buttons auf der Form sperren
        _StartTime = Date.Now
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _Process_Thread As New Thread(AddressOf _Process.Search)
        _Process_Thread.Start()
        _Hashtable.Add(_Process.P_MainProcess_Guid.ToString, _Process_Thread)
    End Sub

    Private Sub Process_ValidatePlayerInput_Start(_MainProcess As MainProcessing)
        '// Das Task-Objekt erstellen.
        Dim _ValidateProcess As New Cls_Main_Validate(_MainProcess)
        AddHandler _ValidateProcess.StatusReport, AddressOf StatusReport_Handler
        AddHandler _ValidateProcess.MainProcess_ValidationCompleted, AddressOf MainProcess_ValidationCompleted_Handler

        '// Den Thread erstellen.
        Dim _ValidateProcess_Thread As New Thread(AddressOf _ValidateProcess.Validate_PlayerInput)
        _ValidateProcess_Thread.Start()
        _Hashtable.Add(_ValidateProcess.P_MainProcess_Guid.ToString, _ValidateProcess_Thread)
    End Sub
#End Region

#Region "Clipboard Event Handler"
    Private Sub ClipboardImport_Completed_Handler(sender As Object, e As EArgs_ValidationProcessCompleted)
        '// Clipboard Content der Form hinzufügen.
        '// Prüfen ob die TextBox leer ist, denn dann sind keine Lines vorhanden!
        If Not tbPlayerInput.Text = "" AndAlso
           Not tbPlayerInput.Lines(tbPlayerInput.Lines.Count - 1) = "" Then

            '// Verhindern dass zwei Charakterdaten in einer Zeile landen.
            tbX_AddText(vbCrLf, tbPlayerInput)
        End If
        tbX_AddText(e.P_ValidatedClipboardContent, tbPlayerInput)

        '// Anzeigen ob falsche Einträge gefunden wurden.
        DoErrorProcessing(e)

        '// Buttons auf der Form entsperren
        btnX_setState(True)

        '// Das Task-Objekt löschen.
        SyncLock _Hashtable
            _Hashtable.Remove(e.P_Guid.ToString)
        End SyncLock
    End Sub
#End Region

#Region "MainProcess Event Handler"
    Private Sub InlineReport_Handler(sender As Object, e As EArgs_InlineReport)
        '// Eine thread-sichere Aktualisierung durchführen.
        tbX_AddText(e.P_LogMessage + vbCrLf, tbLog)
    End Sub

    Private Sub StatusReport_Handler(sender As Object, e As EArgs_StatusReport)
        '// Eine thread-sichere Aktualisierung durchführen.
        If e.P_StatusMessage = "" Then
            tsMain_setPercent(e.P_PercentDone)
        Else
            tsMain_setAll(e.P_PercentDone, e.P_StatusMessage)
        End If
    End Sub

    Private Sub MainProcess_Completed_Handler(sender As Object, e As EArgs_MainProcessCompleted)
        '// Abschließende Informationen anzeigen.
        Dim _ProgressTime As TimeSpan = (Date.Now - _StartTime)

        If Not My.Settings.InlineReports Then
            tbX_AddText(e.P_Log.ToString + vbCrLf + _
                                        "Thread GUID: " + e.P_MainProcess.Guid.ToString + _
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
            _Hashtable.Remove(e.P_MainProcess.Guid.ToString)
        End SyncLock
    End Sub
#End Region

#Region "MainProcess Validate Event Handler"
    Private Sub MainProcess_ValidationCompleted_Handler(sender As Object, e As EArgs_ValidationProcessCompleted)
        '// Anzeigen ob falsche Einträge gefunden wurden.
        If DoErrorProcessing(e) Then
            '// Falls ja, wird kein Prozess gestartet!
            Select Case e.P_MainProcess.ID
                Case MainProcessingID.PROCESS_ADD

                Case MainProcessingID.PROCESS_LOOKUP
                    Process_LookupTitles_Start(e.P_MainProcess)
                Case MainProcessingID.PROCESS_REMOVE
                    Dim _MainProcess As New MainProcessing With {.ID = e.P_MainProcess.ID,
                                                                 .SelectedTitles = GetSelectedTitles(CType(dgvSelectedTitles.DataSource, DataTable)),
                                                                 .ValidatedPlayerInput = e.P_MainProcess.ValidatedPlayerInput}
                    Process_RemoveTitles_Start(_MainProcess)
                Case MainProcessingID.PROCESS_SEARCH
                    Dim _MainProcess As New MainProcessing With {.ID = e.P_MainProcess.ID,
                                                                 .SelectedTitles = GetSelectedTitles(CType(dgvSelectedTitles.DataSource, DataTable)),
                                                                 .ValidatedPlayerInput = e.P_MainProcess.ValidatedPlayerInput}
                    Process_SearchTitles_Start(_MainProcess)
            End Select
        End If

        '// Das Task-Objekt löschen.
        SyncLock _Hashtable
            _Hashtable.Remove(e.P_MainProcess.Guid.ToString)
        End SyncLock
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
        Dim _Buttons() As Windows.Forms.Button = {btnAdd, btnRemove, btnLookup}
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

#Region "ErrorProcessing"
    Private Function DoErrorProcessing(e As EArgs_ValidationProcessCompleted) As Boolean
        Dim _ErrorProcessMsg As String = ""

        Select Case e.P_ErrorProcess.ID
            Case ErrorProcessingID.CLIPBOARD_IMPORT_VALIDATION
                _ErrorProcessMsg = "Import"
            Case ErrorProcessingID.MAIN_PROCESS_VALIDATION
                _ErrorProcessMsg = "Validation"
            Case ErrorProcessingID.MAIN_PROCESS_INLINE
                _ErrorProcessMsg = "Process"
        End Select

        If e.P_ErrorProcess.WrongCounter = 0 Then
            tsMain_setAll(100, _ErrorProcessMsg + " done!")
            Return True
        Else
            tsMain_setAll(100, _ErrorProcessMsg + " done!  | " + e.P_ErrorProcess.WrongCounter.ToString + " wrong entry(s) found!")
            Select Case MessageBox.Show(e.P_ErrorProcess.WrongCounter.ToString + " wrong entry(s) found!" + vbCrLf + "Would you like to see them?", "Wrong format found!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                Case Windows.Forms.DialogResult.Yes
                    If e.P_ErrorProcess.WrongCounter > 50 Then
                        Try
                            My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_" + _ErrorProcessMsg + "WrongEntrys.txt", e.P_ErrorProcess.WrongContent, False)
                            Process.Start(My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_" + _ErrorProcessMsg + "WrongEntrys.txt")
                        Catch ex As Exception
                            MessageBox.Show(ex.ToString, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End Try
                    Else
                        MessageBox.Show(e.P_ErrorProcess.WrongContent, "Wrong values.", MessageBoxButtons.OK, MessageBoxIcon.None)
                    End If
            End Select
            Return False
        End If
    End Function
#End Region

#Region "Menüleistenverwaltung"
    '// Verwaltung der oberen Menüleiste
    Private Sub Menu_ClickedHandler(sender As Object, e As EventArgs) Handles _
        miExit.Click,
        miSave_SaveLogfile.Click,
        miInfo_About.Click,
        miInfo_TrinityCoreWiki.Click,
        miLanguage_Save.Click,
        miSettings_DebugMode.Click,
        miSettings_ExtendedTitles.Click,
        miSettings_InlineReports.Click,
        miSelectSyntax_0.Click,
        miSelectSyntax_1.Click,
        miLogfile_State.Click,
        miSQLQuery_State.Click,
        miImport_FromClipboard.Click,
        miLogfile_NewPath.Click,
        miSQlQuery_NewPath.Click

        '// Prüfen ob ein Prozess läuft | Ausnahmen: About und Exit^^
        If ThreadIsRunning(_Hashtable) AndAlso Not sender Is miInfo_About AndAlso Not sender Is miExit AndAlso Not sender Is miInfo_TrinityCoreWiki Then
            MessageBox.Show("You can't change the settings, while processing..." + vbCrLf + "Threads running: " + _Hashtable.Count.ToString, "Wait until finished.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Select Case True
            Case sender Is miExit '// Programm beenden.
                CancelAllThreads()
                Application.Exit()
            Case sender Is miSave_SaveLogfile '// Logfile Pfad festlegen und speichern.

                Dim _Path As String = OpenSaveFileDialog(".txt files (*.txt)|*.txt|All files (*.*)|*.*", "kT_Log")
                If Not _Path = "" Then
                    Try
                        My.Computer.FileSystem.WriteAllText(_Path, tbLog.Text, False)
                        Process.Start(_Path)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    End Try
                End If
            Case sender Is miInfo_About '// Infos über das Programm anzeigen.
                Dim _fmAbout As New fmAbout
                _fmAbout.StartPosition = FormStartPosition.Manual
                _fmAbout.Location = New Point(CInt((Me.Location.X + (Me.Size.Width / 2)) - (_fmAbout.Size.Width / 2)), CInt((Me.Location.Y + (Me.Size.Height / 2)) - (_fmAbout.Size.Height / 2)))
                _fmAbout.Show()
            Case sender Is miInfo_TrinityCoreWiki '// TrinityCore Wiki anzeigen.
                Process.Start("http://collab.kpsn.org/display/tc/Characters+tc2#Characterstc2-knownTitles")
            Case sender Is miLanguage_Save '// Sprache ändern.
                Select Case miLanguage_ComboBox.SelectedIndex
                    Case 0
                        ReloadLanguage(LANGUAGE.ENGLISH)
                    Case 1
                        ReloadLanguage(LANGUAGE.GERMAN)
                End Select
                _DataGridView_Handler.Reload_DataTable(My.Settings.ExtendedTitles)
            Case sender Is miSettings_DebugMode '// Debug Mode de-/aktivieren.
                SetDebugMode(True)
            Case sender Is miSettings_ExtendedTitles '// Erweiterte Titel de-/aktivieren.
                SetExtendedTitles(True)
                _DataGridView_Handler.Relocate_DataGridView(My.Settings.ExtendedTitles)
                _DataGridView_Handler.Reload_DataTable(My.Settings.ExtendedTitles)
            Case sender Is miSettings_InlineReports '// Inline Reports de-/aktivieren.
                SetInlineReports(True)
            Case sender Is miSelectSyntax_0 '// Clipboard Syntax ändern.
                SetClipboardSyntax(CLIPBOARD_SYNTAX.INSERT_INTO)
            Case sender Is miSelectSyntax_1
                SetClipboardSyntax(CLIPBOARD_SYNTAX.ONLY_WITH_SPACES)
            Case sender Is miLogfile_State '// Logfiles speichern de-/aktivieren.
                SetLogfileToHDD(True)
            Case sender Is miSQLQuery_State '// SQL Query speichern de-/aktivieren.
                SetSQLQueryToHDD(True)
            Case sender Is miImport_FromClipboard '// Importieren von Zwischenablage.
                If Clipboard.ContainsText Then
                    Process_GetClipboardContent_Start(Clipboard.GetText)
                End If
            Case sender Is miLogfile_NewPath '// Neuer Logfile Pfad festlegen.
                Dim _Path As String = OpenSaveFileDialog(".txt files (*.txt)|*.txt|All files (*.*)|*.*", "kT_Log")
                If Not _Path = "" Then
                    miLogfile_Path.Text = _Path
                End If
            Case sender Is miSQlQuery_NewPath '// Neuer SQL Query Pfad festlegen.
                Dim _Path As String = OpenSaveFileDialog(".sql files (*.sql)|*.sql|All files (*.*)|*.*", "kT_Query")
                If Not _Path = "" Then
                    miSQLQuery_Path.Text = _Path
                End If
        End Select
    End Sub
#End Region

    '// Form Load - Diverse Sachen laden.
    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        miLogfile_Path.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_Log.txt"
        miSQLQuery_Path.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_Query.sql"
        tsPbStatusPercent.Maximum = 100

        If My.Settings.DebugMode Then miSettings_DebugMode.Visible = True

        '// Sprache an Einstellungen anpassen - Inizialisiert die TitleList's!
        ReloadLanguage()

        '// DataGridView mit gespeicherten Einstellungen inizialisieren.
        Dim _gbPlayerInput As New ControlData With {.Control = gbPlayerInput, .Location = gbPlayerInput.Location, .Size = gbPlayerInput.Size}
        Dim _tbPlayerInput As New ControlData With {.Control = tbPlayerInput, .Location = tbPlayerInput.Location, .Size = tbPlayerInput.Size}
        Dim _gbSelectedTitles As New ControlData With {.Control = gbSelectedTitles, .Location = gbSelectedTitles.Location, .Size = gbSelectedTitles.Size}
        Dim _dgvSelectedTitles As New ControlData With {.Control = dgvSelectedTitles, .Location = dgvSelectedTitles.Location, .Size = dgvSelectedTitles.Size}
        Dim _gbLog As New ControlData With {.Control = gbLog, .Location = gbLog.Location, .Size = gbLog.Size}
        Dim _tbLog As New ControlData With {.Control = tbLog, .Location = tbLog.Location, .Size = tbLog.Size}

        _DataGridView_Handler = New Cls_DataGridView(_gbPlayerInput, _tbPlayerInput, _gbSelectedTitles, _dgvSelectedTitles, _gbLog, _tbLog)
        '// Position & Daten.
        _DataGridView_Handler.Relocate_DataGridView(My.Settings.ExtendedTitles)
        _DataGridView_Handler.Reload_DataTable(My.Settings.ExtendedTitles)

        '// Alle ToolStripMenuItems visuell an Einstellungen anpassen.
        SetAllMenuItems_LikeSettings()
        miLanguage_ComboBox.SelectedIndex = My.Settings.Language

        '// Verstecken des Row Headers
        dgvSelectedTitles.RowHeadersVisible = False
    End Sub

#Region "Spezielle Funktionen [DEBUG]"

    Private Sub EnableDebug_KeyDownHandler(sender As Object, e As KeyEventArgs) Handles btnLookup.KeyDown, btnAdd.KeyDown, btnRemove.KeyDown
        Static _EnteredKey As String = ""

        Select Case e.KeyCode
            Case Keys.Z
                _EnteredKey += "Z"
            Case Keys.E
                _EnteredKey += "E"
            Case Keys.U
                _EnteredKey += "U"
            Case Keys.S
                _EnteredKey += "S"
            Case Else
                _EnteredKey = ""
        End Select
        If _EnteredKey = "ZEUS" Then
            miSettings_DebugMode.Visible = True
        End If
    End Sub
#End Region
    
#Region "Allgemeine Infos zu DGV"
    'Dim col3 As New DataGridViewTextBoxColumn
    'col3.Name = "MaleTitle"
    'col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    'col3.ReadOnly = True
    'col3.ValueType = GetType(String)
    'fmMain.dgvSelectedTitles.Columns.Add(col3)


    ''// Hinzufügen der Titel
    'For Each _Title In _LANG_TitelList_All
    '    With fmMain.dgvSelectedTitles.Rows
    '        .Add(False, _Title.TitleID, _Title.MaleTitle)
    '    End With
    'Next
#End Region

End Class
