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

    Private _StartTime As Date

    '// Speichert die laufenden Threads
    Private _Hashtable As New Hashtable
#End Region

    '// Button Pressed Handler
    Private Sub ButtonClickedHandler(sender As Object, e As EventArgs) Handles _
        btnAdd.Click,
        btnImportFromClipboard.Click,
        btnRemove.Click,
        btnWhichTitle.Click,
        btnLogfilePath.Click,
        btnSQLQueryPath.Click

        Select Case True
            Case sender Is btnAdd
                MessageBox.Show("Not implemented yet.", "Informatione", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case sender Is btnImportFromClipboard
                Dim _ClipboardContent As String = GetDataFromClipboard(_Debug)
                If Not _ClipboardContent = "" Then tbPlayerInput.Text = _ClipboardContent
            Case sender Is btnRemove
                tbPlayerOutput.Text = ""
                ProcessRemoveStart(GetSelectedTitles)
            Case sender Is btnWhichTitle
                MessageBox.Show("Not implemented yet.", "Informatione", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Case sender Is btnLogfilePath
                Dim _Path As String = OpenSaveFileDialog(".txt files (*.txt)|*.txt|All files (*.*)|*.*", "kT_Log")
                If Not _Path = "" Then tbLogfilePath.Text = _Path
            Case sender Is btnSQLQueryPath
                Dim _Path As String = OpenSaveFileDialog(".sql files (*.sql)|*.sql|All files (*.*)|*.*", "kT_Query")
                If Not _Path = "" Then tbSQLQueryPath.Text = _Path
        End Select
    End Sub

    Private Sub ProcessRemoveStart(_SelectedTitles As List(Of CharTitle))
        '// Das Task-Objekt erstellen.
        Dim _MainProcess As New Main_Cls(_SelectedTitles, tbPlayerInput.Text, tbLogfilePath.Text, tbSQLQueryPath.Text, _Debug, _InlineReport, _LogToHarddrive, _GenerateSQLQuery)
        AddHandler _MainProcess.InlineReport, AddressOf InlineReport_Handler
        AddHandler _MainProcess.StatusReport, AddressOf StatusReport_Handler
        AddHandler _MainProcess.CompletedReport, AddressOf CompletedReport_Handler

        '// Startzeit festhalten & Buttons auf der Form sperren
        _StartTime = Date.Now
        btnX_setState(False)

        '// Den Thread erstellen.
        Dim _MainProcess_Thread As New Thread(AddressOf _MainProcess.ProcessRemove)
        _MainProcess_Thread.Start()
        _Hashtable.Add(_MainProcess.P_Guid.ToString, _MainProcess_Thread)
    End Sub

#Region "Main Process Handler"
    Private Sub InlineReport_Handler(sender As Object, e As InlineReportEArgs)
        '// Eine thread-sichere Aktualisierung durchführen.
        tbPlayerOutput_AddText(e.P_LogMessage + vbCrLf)
    End Sub

    Private Sub StatusReport_Handler(sender As Object, e As StatusReportEArgs)
        '// Eine thread-sichere Aktualisierung durchführen.
        tsMain_setAll(e.P_PercentDone, e.P_StatusMessage)
    End Sub

    Private Sub CompletedReport_Handler(sender As Object, e As CompletedReportEArgs)
        '// Abschließende Informationen anzeigen.
        If Not e.P_InlineReport Then
            tbPlayerOutput_AddText(e.P_Log + vbCrLf + _
                                   "Thread GUID: " + e.P_Guid.ToString + ")" + _
                                   " | Start: " + _StartTime.ToString + _
                                   " | Finished: " + Date.Now.ToString + _
                                   " | Elapsed: " + Date.Compare(Date.Now, _StartTime).ToString)
        End If
        '// ToolStrip aktualisieren.
        tsMain_setAll(100, "Done!")
        '// Buttons auf der Form entsperren.
        btnX_setState(True)

        '// Das Task-Objekt löschen.
        SyncLock _Hashtable
            _Hashtable.Remove(e.P_Guid.ToString)
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
        Dim _Buttons() As Windows.Forms.Button = {btnAdd, btnImportFromClipboard, btnRemove, btnWhichTitle}
        Dim _btnControl As New ControlButtonUpdater(_Buttons)

        '// Formelemente sperren / entsperren.
        _btnControl.setState(_State)
    End Sub

    Private Sub tbPlayerOutput_AddText(_Text As String)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tbPlayerOutput As New ControlTextUpdater(tbPlayerOutput)

        _tbPlayerOutput.AddText(_Text)
    End Sub

    Private Sub tsMain_setAll(_Percent As Integer, _Text As String)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New ControlStatusStripUpdater(tsPbStatusPercent, tsSlStatusPercent, tsSlStatusText)

        _tsMain.setAll(_Percent, _Text)
    End Sub
    Private Sub tsMain_setPercent(_Percent As Integer)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New ControlStatusStripUpdater(tsPbStatusPercent, tsSlStatusPercent, tsSlStatusText)

        _tsMain.setPercent(_Percent)
    End Sub
    Private Sub tsMain_setText(_Text As String)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New ControlStatusStripUpdater(tsPbStatusPercent, tsSlStatusPercent, tsSlStatusText)

        _tsMain.setText(_Text)
    End Sub
#End Region

    ''' <summary>Eine Liste aller aktuell ausgewählten Titels bekommen.</summary>
    Private Function GetSelectedTitles() As List(Of CharTitle)
        Dim _SelectedTitles As New List(Of CharTitle)
        '// Findet "D: 1234".
        Dim _RegEx As Regex = New Regex("D: [0-9]+")

        For Each _SelectedTitel In clbBannedAddedTitel.CheckedItems
            Dim _Match As Match = _RegEx.Match(_SelectedTitel.ToString)

            If _Match.Success Then '// Obligatorisch, kann normal niemals False sein.
                For Each _Title In _TitleList_All
                    If _Title.TitleID = CInt(Replace(_Match.Value, "D: ", "")) Then
                        _SelectedTitles.Add(_Title)
                    End If
                Next
                If _Debug Then MessageBox.Show("_Match.Success: """ + Replace(_Match.Value, "D: ", "") + """ (" + _SelectedTitel.ToString + ")")
            Else
                MessageBox.Show("NO _Match.Success @ " + _SelectedTitel.ToString, "GetSelectedTitles Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Next
        Return _SelectedTitles
        '// http://regexhero.net/tester/
    End Function


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
        clbBannedAddedTitel.Items.Clear()
        If cbExtendedTitles.CheckState = CheckState.Checked Then
            For Each _Title In _TitleList_All
                clbBannedAddedTitel.Items.Add("INT: " + _Title.IntID.ToString + " (" + _Title.IntID_Double.ToString + _
                                              ") | BIT: " + _Title.Bit.ToString + _
                                              " | TitleID: " + _Title.TitleID.ToString + _
                                              " | IntBit: " + _Title.BitOfInteger.ToString + _
                                              " | UnkRef: " + _Title.UnkRef.ToString + _
                                              " | MaleTitle: " + _Title.MaleTitle + _
                                              " | FemaleTitle: " + _Title.FemaleTitle + _
                                              " | InGameOrder: " + _Title.InGameOrder.ToString)
            Next

            '// GroupBox neu anordnen
            gbPlayerInput.Location = New Point(gbBannedAddedTitels.Location.X, gbBannedAddedTitels.Location.Y)
            gbBannedAddedTitels.Location = New Point(gbBannedAddedTitels.Location.X, gbOutput.Location.Y)
            gbBannedAddedTitels.Size = New Size(gbOutput.Width, CInt(gbOutput.Height / 2))

            gbOutput.Location = New Point(gbBannedAddedTitels.Location.X, gbBannedAddedTitels.Location.Y + gbBannedAddedTitels.Height + 5)
            gbOutput.Size = New Size(gbBannedAddedTitels.Width, gbBannedAddedTitels.Height)

            '// Text/CheckList neu anordnen

            clbBannedAddedTitel.Size = New Size(tbPlayerOutput.Width, gbBannedAddedTitels.Height - 20)
            tbPlayerOutput.Size = New Size(clbBannedAddedTitel.Width, clbBannedAddedTitel.Height)
        Else
            For Each _Title In _TitleList_All
                clbBannedAddedTitel.Items.Add("INT: " + _Title.IntID.ToString + _
                                              " | BIT: " + _Title.Bit.ToString + _
                                              " | TitleID: " + _Title.TitleID.ToString + _
                                              " | Title: " + _Title.MaleTitle)
            Next
        End If
    End Sub
#End Region

    Private Sub fmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        tbLogfilePath.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_Log.txt"
        tbSQLQueryPath.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\kT_Query.sql"
        tsPbStatusPercent.Maximum = 100
        'setPoint(New Point() = {New Point(tbLogfilePath.Location.X,tbLogfilePath.Location.Y)}

        
    End Sub
End Class
