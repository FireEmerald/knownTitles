Option Explicit On
Option Strict On

Imports System.Text
Imports System.IO

Public Enum PRÄFIX
    INFO
    DEBUG
    WARNING
    EXCEPTION
End Enum

Public Enum MaxLen As Integer
    CHAR_NAME = 21
    CHAR_GUID = 21
    CHAR_ACCOUNT = 22
    CHAR_KNOWNTITLES = 57
    CHAR_AFFECTED = 13
    TITLE_STATE = 7
    TITLE_ID = 12
    TITLE_INTID = 8
    TITLE_MALE = 58
    TITLE_BIT = 15
    TITLE_GAMEORDER = 16
    TITLE_UNKREF = 12
    CHAR_INT = 22
    CHAR_REMLEFT = 21
    FOOTER_TOTAL_AFFECTED = 26
    FOOTER_TOTAL_REMLEFT = 41
    FOOTER_ELAPSED = 46
End Enum

Module Mod_Log
#Region "Deklarationen"
    '// Speichert den Namen des Logfiles.
    Private _LogfilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\knownTitles.log"
    '// Enthält den kompletten Log.
    Private _Log As New StringBuilder
    '// Der StreamWriter für den Log.
    Private _LogWriter As StreamWriter
#End Region

#Region "Propertys"
    Public ReadOnly Property GetLog As String
        Get
            Return _Log.ToString
        End Get
    End Property
    Public Property Log_LogfilePath As String
        Get
            Return _LogfilePath
        End Get
        Set(value As String)
            _LogfilePath = value
        End Set
    End Property
#End Region

#Region "Log System"
    ''' <summary>Erstellt einen Logeintrag mit Info-Präfix.</summary>
    Public Sub Log_MsgInfo(_Message As String)
        Log_Msg(PRÄFIX.INFO, _Message)
    End Sub

    ''' <summary>Erstellt einen Logeintrag, gefolgt von einer neuen Zeile.</summary>
    Public Sub Log_Msg(_Präfix As PRÄFIX, _Message As String)
        '// Debugmessages werden nicht verarbeitet, wenn nicht aktiviert.
        If _Präfix = PRÄFIX.DEBUG AndAlso Not My.Settings.DebugMode Then Return

        Dim _LogMsg As String = GetSyntax(_Präfix) + _Message
        _Log.AppendLine(_LogMsg)

        If My.Settings.SaveLogfile Then
            _LogWriter = New StreamWriter(_LogfilePath, True, Encoding.UTF8)
            _LogWriter.WriteLine(_LogMsg)
            _LogWriter.Close()
            _LogWriter.Dispose()
        End If
    End Sub

    ''' <summary>Löscht den kompletten Log.</summary>
    Public Sub Log_Clear()
        _Log.Clear()
    End Sub

    ''' <summary>Returns the header präfix for the logsystem.</summary>
    Private Function GetSyntax(_Präfix As PRÄFIX) As String
        Return DateTime.Now.ToString("| yyyy.dd.MM | HH:mm ss | ") + [Enum].GetName(GetType(PRÄFIX), _Präfix) + " | "
    End Function
#End Region
    
#Region "Header, Body and Footer"
    ''' <summary>Erstellt den Header für den Main Prozesses und speichert diesen im Log.</summary>
    Public Sub GenLogfileHeader(_StartTime As Date)
        Log_MsgInfo("╔════════════════════════════╦══════════════════════════════════════════════════════════════╦════════════════════╦═══════════════════════════════════╗")
        Log_MsgInfo("║ Start: " + _StartTime.ToString("dd.MM.yyyy HH:mm:ss") + " ║                        knownTitles Log                       ║ Version: " + Application.ProductVersion.Substring(0, 5) + " x64 ║ Copyright (C) 2014 by FireEmerald ║")
        Log_MsgInfo("╚════════════════════════════╩══════════════════════════════════════════════════════════════╩════════════════════╩═══════════════════════════════════╝")
    End Sub

    ''' <summary>Erstellt den Footer für den Main Prozess und speichert diesen im Log.</summary>
    Public Sub GenLogfileFooter(_EndTime As Date, _ProgressTime As TimeSpan, _MainProcess As MainProcessing)
        Dim _ElapsedTime As String = String.Format("{0:0.##} minute(s), {1:0},{2:0} second(s)", _ProgressTime.Minutes, _ProgressTime.Seconds, _ProgressTime.Milliseconds)

        Log_MsgInfo("╒════════════════════════════╤═══════════════════════════════════════════╤══════════════════════════╤════════════════════════════════════════════════╕")
        Log_MsgInfo("│" + FillSpaces("Total affected: " + _MainProcess.TotalAffected.ToString, MaxLen.FOOTER_TOTAL_AFFECTED) + _
                          FillSpaces("Total removed/left: " + _MainProcess.TotalRemoved.ToString + "/" + _MainProcess.TotalLeft.ToString, MaxLen.FOOTER_TOTAL_REMLEFT) + _
                                     " End: " + _EndTime.ToString("dd.MM.yyyy HH:mm:ss │") + _
                          FillSpaces("Elapsed: " + _ElapsedTime, MaxLen.FOOTER_ELAPSED))
        Log_MsgInfo("╘════════════════════════════╧═══════════════════════════════════════════╧══════════════════════════╧════════════════════════════════════════════════╛")
    End Sub

    ''' <summary>Erstellt für jeden Charakter die Logeinträge und speichert diese im Log. Ausserdem werden alle Total-Werte errechnet.</summary>
    Public Sub GenLogfileBody(_FullCharacterList As List(Of Character), ByRef _MainProcess As MainProcessing)
        '// Das Aktualisierungsobjekt erstellen.
        Dim _tsMain As New StatusStripInvoker(_MainProcess.fmMain.tsPbStatusPercent, _MainProcess.fmMain.tsSlStatusPercent, _MainProcess.fmMain.tsSlStatusText)
        Dim _ProgressCnt As Integer = 0

        For Each _Character In _FullCharacterList
            '// Für jeden einzelnen Charakter.
            Dim _RemovedCnt As Integer = 0
            Dim _LeftCnt As Integer = 0

            '// Charakter Header.
            Log_MsgInfo("╒═══════════════════════╤═══════════════════════╤════════════════════════╤═══════════════════════════════════════════════════════════╤═══════════════╕")
            Log_MsgInfo("│" + FillSpaces("Name: " + _Character.Name, MaxLen.CHAR_NAME) + _
                              FillSpaces("GUID: " + _Character.GUID.ToString, MaxLen.CHAR_GUID) + _
                              FillSpaces("Account ID: " + _Character.AccountID.ToString, MaxLen.CHAR_ACCOUNT) + _
                              FillSpaces("KnownTitles: " + _Character.KnownTitlesBackup, MaxLen.CHAR_KNOWNTITLES) + _
                              FillSpaces("Affected: " + _Character.AffectedTitles.Count.ToString, MaxLen.CHAR_AFFECTED))
            Log_MsgInfo("╘═══════════════════════╧═══════════════════════╧════════════════════════╧═══════════════════════════════════════════════════════════╧═══════════════╛")

            '// Einzelne Titel des Charakters.
            If Not _Character.AffectedTitles.Count = 0 Then
                Log_MsgInfo("┌─────────┬──────────────┬──────────┬────────────────────────────────────────────────────────────┬─────────────────┬──────────────────┬──────────────┐")
                For _i As Integer = 0 To _Character.AffectedTitles.Count - 1
                    If Not _i = 0 Then Log_MsgInfo("├─────────┼──────────────┼──────────┼────────────────────────────────────────────────────────────┼─────────────────┼──────────────────┼──────────────┤")

                    Log_MsgInfo("│" + FillSpaces([Enum].GetName(GetType(State), _Character.AffectedTitles(_i).State), MaxLen.TITLE_STATE) + _
                                      FillSpaces("TitelID: " + _Character.AffectedTitles(_i).TitleID.ToString, MaxLen.TITLE_ID) + _
                                      FillSpaces("IntID: " + _Character.AffectedTitles(_i).IntID.ToString, MaxLen.TITLE_INTID) + _
                                      FillSpaces("MaleTitle: " + _Character.AffectedTitles(_i).MaleTitle, MaxLen.TITLE_MALE) + _
                                      FillSpaces("Bit: " + _Character.AffectedTitles(_i).Bit.ToString, MaxLen.TITLE_BIT) + _
                                      FillSpaces("InGameOrder: " + _Character.AffectedTitles(_i).InGameOrder.ToString, MaxLen.TITLE_GAMEORDER) + _
                                      FillSpaces("UnkRef: " + _Character.AffectedTitles(_i).UnkRef.ToString, MaxLen.TITLE_UNKREF))

                    If _Character.AffectedTitles(_i).State = State.REMOVED Then
                        _RemovedCnt += 1
                    Else
                        _LeftCnt += 1
                    End If
                Next
                Log_MsgInfo("└─────────┴──────────────┴──────────┴────────────────────────────────────────────────────────────┴─────────────────┴──────────────────┴──────────────┘")
            End If

            '// Charakter Footer.
            Log_MsgInfo("╒════════════════════════╤════════════════════════╤════════════════════════╤════════════════════════╤════════════════════════╤═══════════════════════╕")
            Log_MsgInfo("│" + FillSpaces("INT_0: " + _Character.INT_0.ToString, MaxLen.CHAR_INT) + _
                              FillSpaces("INT_1: " + _Character.INT_1.ToString, MaxLen.CHAR_INT) + _
                              FillSpaces("INT_2: " + _Character.INT_2.ToString, MaxLen.CHAR_INT) + _
                              FillSpaces("INT_3: " + _Character.INT_3.ToString, MaxLen.CHAR_INT) + _
                              FillSpaces("INT_4: " + _Character.INT_4.ToString, MaxLen.CHAR_INT) + _
                              FillSpaces("Removed/Left: " + _RemovedCnt.ToString + "/" + _LeftCnt.ToString, MaxLen.CHAR_REMLEFT))
            Log_MsgInfo("╘════════════════════════╧════════════════════════╧════════════════════════╧════════════════════════╧════════════════════════╧═══════════════════════╛")

            '// Komplette Statistik.
            _MainProcess.TotalAffected += _Character.AffectedTitles.Count
            _MainProcess.TotalRemoved += _RemovedCnt
            _MainProcess.TotalLeft += _LeftCnt
            _ProgressCnt += 1

            _tsMain.setAll(CInt((_ProgressCnt / _FullCharacterList.Count) * 100), "Generate Logfile... " + _ProgressCnt.ToString + " of " + _FullCharacterList.Count.ToString)
        Next
    End Sub

    ''' <summary>Füllt einen String mit Leerzeichen bis zu einer vorgegebenen maximalen Länge. Überschreitet die schon vorhandene Länge das Maximum, so wird der Input gekürzt.</summary>
    ''' <param name="_Msg">Zu füllender String.</param>
    ''' <param name="_MaximumLength">Rückgabelänge nachdem der Input Text mit Leerzeichen aufgefüllt wurde.</param>
    Private Function FillSpaces(_Msg As String, _MaximumLength As MaxLen) As String
        If _Msg.Length > _MaximumLength Then
            Log_Msg(PRÄFIX.WARNING, "Message """ + _Msg + """ (" + _Msg.Length.ToString + ") exceeded the maximum length of " + [Enum].GetName(GetType(MaxLen), _MaximumLength) + " (" + _MaximumLength.ToString + ")")
            Return " " + _Msg.Substring(0, _MaximumLength) + " │"
        End If

        Dim _Result As New StringBuilder
        _Result.Append(" " + _Msg)
        For _i As Integer = 0 To _MaximumLength - _Msg.Length - 1
            _Result.Append(" ")
        Next
        _Result.Append(" │")
        Return _Result.ToString
    End Function
#End Region
End Module
