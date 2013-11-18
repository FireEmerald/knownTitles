﻿Option Explicit On
Option Strict On

Imports System.Threading

'// Struktur für einen Charakter
Public Structure Character
    Dim GUID, AccountID As Integer
    Dim Name, BitmaskBackup As String
    Dim INT_0, INT_1, INT_2, INT_3, INT_4, INT_5 As UInteger
    Dim ChangedTitles As List(Of CharTitle)
    Dim NothingChanged As Boolean
End Structure

'// Struktur für einen Charaktertitel
Public Structure CharTitle
    Dim TitleID As Integer
    Dim UnkRef As Integer
    Dim MaleTitle As String
    Dim FemaleTitle As String
    Dim InGameOrder As Integer
    Dim IntID As Integer
    Dim IntID_Double As Double
    Dim BitOfInteger As Integer
    Dim Bit As Int64
    Dim DBValue As String
End Structure

Public Class Main_Cls

#Region "Deklarationen"
    '// Variablen
    Private _Log As String = ""
    Private _PlayerInput As String
    Private _SelectedTitles As List(Of CharTitle)

    Private _LogfilePath As String = ""
    Private _SQLQueryPath As String = ""
    Private _Debug, _InlineReport, _LogToHarddrive, _GenerateSQLQuery As Boolean

    '// Events
    Public Event InlineReport(sender As Object, e As InlineReportEArgs)
    Public Event StatusReport(sender As Object, e As StatusReportEArgs)
    Public Event CompletedReport(sender As Object, e As CompletedReportEArgs)

    '// Ein eindeutiger Bezeichner für diesen Task.
    Private _Guid As Guid = Guid.NewGuid()
#End Region

    '// Properties
#Region "Propertys"
    Public ReadOnly Property P_Guid() As Guid
        Get
            Return _Guid
        End Get
    End Property
    Private Property P_SelectedTitles As List(Of CharTitle)
        Get
            Return _SelectedTitles
        End Get
        Set(value As List(Of CharTitle))
            _SelectedTitles = value
        End Set
    End Property
    Private Property P_PlayerInput As String
        Get
            Return _PlayerInput
        End Get
        Set(_Value As String)
            _PlayerInput = _Value
        End Set
    End Property
#End Region

    '// Sub New - Informationen die von der Form an die Klasse übergeben werden.
    Public Sub New(SelectedTitles As List(Of CharTitle), PlayerInput As String, LogfilePath As String, SQLQueryPath As String, Debug As Boolean, InlineReport As Boolean, LogToHarddrive As Boolean, GenerateSQLQuery As Boolean)
        _Debug = Debug
        P_SelectedTitles = SelectedTitles
        P_PlayerInput = PlayerInput
        _LogfilePath = LogfilePath
        _SQLQueryPath = SQLQueryPath
        _InlineReport = InlineReport
        _LogToHarddrive = LogToHarddrive
        _GenerateSQLQuery = GenerateSQLQuery
    End Sub
    Public Sub New(PlayerInput As String, LogfilePath As String, Debug As Boolean, InlineReport As Boolean, LogToHarddrive As Boolean)
        P_PlayerInput = PlayerInput
        _LogfilePath = LogfilePath
        _Debug = Debug
        _InlineReport = InlineReport
        _LogToHarddrive = LogToHarddrive
    End Sub

    ' Diese Methode wird im neuen Thread ausgeführt.
    Public Sub LookupProcess()
        RaiseEvent StatusReport(Me, New StatusReportEArgs(0, "Running...", _Guid))

        Dim _ProgressCounter As Integer = 0
        Dim _PlayerInput_Splitted As New List(Of String)(Split(_PlayerInput, vbCrLf))

        '// 1234 Roki 0 64 0 0 0
        For _i As Integer = 0 To _PlayerInput_Splitted.Count - 1
            AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
                            "// CHARACTER TITLE DATA" + vbCrLf)

            Dim _SplittedCharacterInfo() As String = Split(_PlayerInput_Splitted(_i), " ")
            If _SplittedCharacterInfo.Length = 9 Then
                Dim _ValueCounter As Integer = 0

                '// Charakterdaten
                Dim _Char As New Character With {.NothingChanged = True}

                For Each _Value As String In _SplittedCharacterInfo
                    Select Case _ValueCounter
                        Case 0 '// GUID
                            _Char.GUID = CInt(_Value)
                        Case 1 '// Account ID
                            _Char.AccountID = CInt(_Value)
                        Case 2 '// NAME
                            _Char.Name = _Value
                        Case 3 '// INT_0
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_0 = 0
                            Else
                                _Char.INT_0 = GetTitlesFromINT(0, _Value, _LANG_TitleList_INT_0)
                            End If
                        Case 4 '// INT_1
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_1 = 0
                            Else
                                _Char.INT_1 = GetTitlesFromINT(1, _Value, _LANG_TitleList_INT_1)
                            End If
                        Case 5 '// INT_2
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_2 = 0
                            Else
                                _Char.INT_2 = GetTitlesFromINT(2, _Value, _LANG_TitleList_INT_2)
                            End If
                        Case 6 '// INT_3
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_3 = 0
                            Else
                                _Char.INT_3 = GetTitlesFromINT(3, _Value, _LANG_TitleList_INT_3)
                            End If
                        Case 7 '// INT_4
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_4 = 0
                            Else
                                _Char.INT_4 = GetTitlesFromINT(4, _Value, _LANG_TitleList_INT_4)
                            End If
                        Case 8 '// INT_5
                            '// Int 5 enthält nie einen Titel.
                            _Char.INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next
                '// Charakterdaten generieren und ausgeben.
                AddInlineReport(GeneratePrintCharakter(_Char))

                '// +1 zur Liste aller abgearbeiteter Charaktere hinzuzählen.
                _ProgressCounter += 1

                '// Aktualisierung der abgearbeiteten Charaktere.
                RaiseEvent StatusReport(Me, New StatusReportEArgs(CInt((_ProgressCounter / _PlayerInput_Splitted.Count) * 100), "Running... " + _ProgressCounter.ToString + " of " + _PlayerInput_Splitted.Count.ToString, _Guid))
            Else
                Static _IgnoreWrongValues As Boolean = False

                '// Fehler bei der Länge des Charakter Input.
                If _IgnoreWrongValues = False Then
                    Select Case MessageBox.Show("The character input contains lines with a wrong syntax." + vbCrLf + "Affected line: """ + _PlayerInput_Splitted(_i) + """" + vbCrLf + vbCrLf + "This character will be ignored!" + vbCrLf + "Would you like to hide this warning during the current process?", "Warning: Wrong character syntax.", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                        Case DialogResult.Yes
                            _IgnoreWrongValues = True
                        Case DialogResult.No
                    End Select
                End If

                AddInlineReport("WARNING | Wrong character syntax! | Affected line: """ + _PlayerInput_Splitted(_i) + """")
            End If
        Next

        '// Logfile Lokal speichern, falls dies zuvor ausgewählt wurde.
        If _LogToHarddrive Then
            RaiseEvent StatusReport(Me, New StatusReportEArgs(100, "Running... Save log to hard disk...", _Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log, False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent CompletedReport(Me, New CompletedReportEArgs(_Log, _InlineReport, _Guid))
    End Sub

    Private Function GetTitlesFromINT(_IntID As Integer, _IntValue As String, _TitleList_INT_ID As List(Of CharTitle)) As UInteger
        '// Titel Bits der Bitmask auslesen.
        Dim _CharacterTitleBits As List(Of UInteger) = GetBitsFromBitMask(CUInt(_IntValue))
        '// Speichern der Titel für den Spieler.
        Dim _FoundTitles As UInteger = 0
        '// Falls die Bitmask vorhanden ist, aber keine Bitmask ist.
        If _CharacterTitleBits.Count = 0 Then
            Return _FoundTitles
        End If

        For Each _TitleBit In _CharacterTitleBits
            Dim _FoundTitle As CharTitle = _TitleList_INT_ID.Find(Function(c) c.IntID = _IntID AndAlso c.Bit = _TitleBit)

            AddInlineReport("FOUND | BIT: " + CStr(_FoundTitle.Bit) + " | INT: " + CStr(_FoundTitle.IntID) + " | IntBit: " + CStr(_FoundTitle.BitOfInteger) + " | TitleID: " + CStr(_FoundTitle.TitleID) + " | UnkRef: " + CStr(_FoundTitle.UnkRef) + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + CStr(_FoundTitle.InGameOrder))
            _FoundTitles += CUInt(_FoundTitle.Bit)
        Next
        Return _FoundTitles
    End Function

    Public Sub RemoveProcess()
        RaiseEvent StatusReport(Me, New StatusReportEArgs(0, "Running...", _Guid))
        Dim _CharacterFullList As New List(Of Character)
        Dim _PlayerInput_Splitted As New List(Of String)(Split(_PlayerInput, vbCrLf))

        '// 1234 Roki 0 64 0 0 0
        For Each _CharacterInfo In _PlayerInput_Splitted

            AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
                            "// CHARACTER TITLE DATA" + vbCrLf)
            Dim _SplittedCharacterInfo() As String = Split(_CharacterInfo)
            If _SplittedCharacterInfo.Length = 9 Then
                Dim _ValueCounter As Integer = 0
                Dim _Character_GUID As Integer = 0
                Dim _AccountID As Integer = 0
                Dim _Namen As String = "n/a"
                Dim _INT_0 As UInteger = 0
                Dim _INT_1 As UInteger = 0
                Dim _INT_2 As UInteger = 0
                Dim _INT_3 As UInteger = 0
                Dim _INT_4 As UInteger = 0
                Dim _INT_5 As UInteger = 0
                Dim _BitmaskBackup As String = ""
                Dim _ChangedTitles As New List(Of CharTitle)
                Dim _NothingChanged As Boolean = True

                For Each _Value As String In _SplittedCharacterInfo
                    Select Case _ValueCounter
                        Case 0 '// GUID
                            _Character_GUID = CInt(_Value)
                        Case 1 '// Account ID
                            _AccountID = CInt(_Value)
                        Case 2 '// NAME
                            _Namen = _Value
                        Case 3 '// INT_0
                            GetTitlesFromINT(0, _Value, _LANG_TitleList_INT_0)
                            _BitmaskBackup += _Value
                            _INT_0 = GetGrantedBitmaskFromINT(0, _Value, _ChangedTitles, _NothingChanged, _LANG_TitleList_INT_0)
                        Case 4 '// INT_1
                            _BitmaskBackup += " " + _Value
                            _INT_1 = GetGrantedBitmaskFromINT(1, _Value, _ChangedTitles, _NothingChanged, _LANG_TitleList_INT_1)
                        Case 5 '// INT_2
                            _BitmaskBackup += " " + _Value
                            _INT_2 = GetGrantedBitmaskFromINT(2, _Value, _ChangedTitles, _NothingChanged, _LANG_TitleList_INT_2)
                        Case 6 '// INT_3
                            _BitmaskBackup += " " + _Value
                            _INT_3 = GetGrantedBitmaskFromINT(3, _Value, _ChangedTitles, _NothingChanged, _LANG_TitleList_INT_3)
                        Case 7 '// INT_4
                            _BitmaskBackup += " " + _Value
                            _INT_4 = GetGrantedBitmaskFromINT(4, _Value, _ChangedTitles, _NothingChanged, _LANG_TitleList_INT_4)
                        Case 8 '// INT_5
                            _BitmaskBackup += " " + _Value
                            _INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next
                Dim _Char As New Character With {.GUID = _Character_GUID, .AccountID = _AccountID, .Name = _Namen, .INT_0 = _INT_0, .INT_1 = _INT_1, .INT_2 = _INT_2, .INT_3 = _INT_3, .INT_4 = _INT_4, .BitmaskBackup = _BitmaskBackup, .ChangedTitles = _ChangedTitles, .NothingChanged = _NothingChanged}
                AddInlineReport(GeneratePrintCharakter(_Char))

                '// Charakter zur Liste alle abgearbeiteten Chars hinzuzählen.
                _CharacterFullList.Add(_Char)

                '// Aktualisierung der abgearbeiteten Charaktere.
                RaiseEvent StatusReport(Me, New StatusReportEArgs(CInt((_CharacterFullList.Count / _PlayerInput_Splitted.Count) * 100), "Running... " + _CharacterFullList.Count.ToString + " of " + _PlayerInput_Splitted.Count.ToString, _Guid))
                'Delay(1.12)
            Else
                MessageBox.Show("""_SplittedCharacterInfo.Length != 9"" !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                For Each _SplitCharInfo In _SplittedCharacterInfo
                    MessageBox.Show(_SplitCharInfo)
                Next
            End If
        Next

        '// Logfile Lokal speichern, falls dies zuvor ausgewählt wurde.
        If _LogToHarddrive Then
            RaiseEvent StatusReport(Me, New StatusReportEArgs(100, "Running... Save log to hard disk...", _Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log, False)
        End If

        '// SQL Query erstellen, falls dies zuvor ausgewählt wurde.
        If _GenerateSQLQuery Then
            RaiseEvent StatusReport(Me, New StatusReportEArgs(100, "Running... Generate SQL update querys...", _Guid))
            My.Computer.FileSystem.WriteAllText(_SQLQueryPath, GenerateSQLQuery(_CharacterFullList), False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent CompletedReport(Me, New CompletedReportEArgs(_Log, _InlineReport, _Guid))
    End Sub

    Private Function GetGrantedBitmaskFromINT(_INT_ID As Integer, _INT_Value As String, ByRef _ChangedTitles As List(Of CharTitle), ByRef _NothingChanged As Boolean, _TitleList_INT_ID As List(Of CharTitle)) As UInteger

        Dim _Bits As List(Of UInteger) = GetBitsFromBitMask(CUInt(_INT_Value)) '// Bits = Alle Titel wo der Charakter aktuell besitzt
        Dim _GrantedBits As New List(Of UInteger)

        For Each _Title As CharTitle In _TitleList_INT_ID '// Wir nehmen einen Titel aus der Liste, 
            If _Title.IntID = _INT_ID Then '// Wir prüfen erstmal, ob der zufällige Titel auch in die Kategorie INT_1 gehört.
                For Each _Bit In _Bits '// Dann schauen wir ob das Bit des zufälligen Titels, mit einem von dem Spieler übereinstimmt.
                    If _Title.Bit = _Bit Then '// Der Spieler hat diesen zufälligen Titel.
                        '// Nun Prüfen wir ob der Titel zulässig ist oder nicht.
                        Dim _NoBannedTitlesFound As Boolean = True
                        For Each _BannedTitle In _SelectedTitles '// Dazu vergleichen wir das _Title.Bit mit einer Liste, gebannter Bits.
                            If _BannedTitle.IntID = _INT_ID Then '// Wir prüfen ob das gebannte Title Bit, zu INT_1 gehört.
                                If CLng(_BannedTitle.Bit) = _Title.Bit Then '// Wir prüfen ob das Bit mit einem gebannten Bit übereinstimmt.
                                    If _Debug Then MessageBox.Show("GEBANNT: " + _BannedTitle.Bit.ToString + " = " + CStr(_Title.Bit))
                                    '// Das Bit ist gebannt. Wir müssen nicht weiter suchen und verlassen die For-Schleife.
                                    _NoBannedTitlesFound = False
                                    Exit For
                                Else
                                    If _Debug Then MessageBox.Show("Nicht gebannt: " + _BannedTitle.Bit.ToString + " = " + CStr(_Title.Bit))
                                    '// Das Bit ist nicht gebannt. Wir schauen ob das nächste Bit gebannt ist.
                                    Continue For
                                End If
                            End If
                        Next
                        If _NoBannedTitlesFound Then '// Wir prüfen ob eine Übereinstimmung festgestellt wurde.
                            '// Falls nicht, das Bit ist nicht gebannt.
                            AddInlineReport("GRANTED | BIT: " + CStr(_Title.Bit) + " | INT: " + CStr(_Title.IntID) + " | IntBit: " + CStr(_Title.BitOfInteger) + " | TitleID: " + CStr(_Title.TitleID) + " | UnkRef: " + CStr(_Title.UnkRef) + " | MaleTitle: " + _Title.MaleTitle + " | FemaleTitle: " + _Title.FemaleTitle + " | InGameOrder: " + CStr(_Title.InGameOrder))
                            _GrantedBits.Add(_Bit) '// Das nicht gebannte Bit, der Liste der nicht gebannten Bits hinzufügen.
                        Else
                            _NothingChanged = False
                            '// Falls doch, das Bit ist gebannt.
                            _ChangedTitles.Add(_Title)
                            AddInlineReport("REMOVED | BIT: " + CStr(_Title.Bit) + " | INT: " + CStr(_Title.IntID) + " | IntBit: " + CStr(_Title.BitOfInteger) + " | TitleID: " + CStr(_Title.TitleID) + " | UnkRef: " + CStr(_Title.UnkRef) + " | MaleTitle: " + _Title.MaleTitle + " | FemaleTitle: " + _Title.FemaleTitle + " | InGameOrder: " + CStr(_Title.InGameOrder))
                        End If
                    End If
                Next
            End If
        Next
        '// Wir haben nun eine Liste mit nicht gebannten Bits.
        Dim _GrantedBitmask As UInteger = Nothing
        '// Nun Addieren wir alle nicht gebannten Bits zu einer Bitmask.
        For Each _GrantedBit In _GrantedBits
            _GrantedBitmask += _GrantedBit
        Next
        Return _GrantedBitmask
    End Function

    Public Sub AddProcess()

    End Sub

    Public Sub AddInlineReport(_Message As String)
        If _InlineReport Then
            RaiseEvent InlineReport(Me, New InlineReportEArgs(_Message, _Guid))
        Else
            _Log += _Message + vbCrLf
        End If
    End Sub


    ' Diese Methode wird vom Haupt-Thread aufgerufen, um den Task-Status zu überprüfen.
    'Public ReadOnly Property P_CharactersDone() As UInteger
    '    Get
    '        Return _CharactersDone
    '    End Get
    'End Property

    ' Diese Methode wird vom Haupt-Thread aufgerufen, um das Task-Ergebnis abzurufen.
    'Public Function CheckIfCompleted() As Boolean
    '    If _IsCompleted Then
    '        Return True
    '    Else
    '        Throw New InvalidOperationException("Not completed.")
    '    End If
    'End Function


    Private Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents() ' Allow windows messages to be processed
        Loop

    End Sub

End Class
