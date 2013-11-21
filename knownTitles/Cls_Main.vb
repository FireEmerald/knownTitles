Option Explicit On
Option Strict On

Imports System.Threading
Imports System.Text.RegularExpressions

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
    Dim Bit As UInt32
    Dim DBValue As String
End Structure

Public Class Cls_Main

#Region "Deklarationen"
    '// Hauptprozessstruktur mit einem eindeutigen Bezeichner für diesen Task.
    Private _MainProcess As New MainProcessing With {.Guid = Guid.NewGuid}

    '// Variablen
    Private _Log As String = ""

    Private _LogfilePath As String = ""
    Private _SQLQueryPath As String = ""
    Private _Debug, _InlineReport, _LogToHarddrive, _GenerateSQLQuery As Boolean

    '// Events
    Public Event InlineReport(sender As Object, e As EArgs_InlineReport)
    Public Event StatusReport(sender As Object, e As EArgs_StatusReport)
    Public Event MainProcess_Completed(sender As Object, e As EArgs_MainProcessCompleted)
#End Region

    '// Properties
#Region "Propertys"
    Public ReadOnly Property P_MainProcess_Guid() As Guid
        Get
            Return _MainProcess.Guid
        End Get
    End Property
#End Region

    '// Sub New - Informationen die von der Form an die Klasse übergeben werden.
    Public Sub New(MainProcess As MainProcessing, LogfilePath As String, SQLQueryPath As String, Debug As Boolean, InlineReport As Boolean, LogToHarddrive As Boolean, GenerateSQLQuery As Boolean)
        _Debug = Debug
        _MainProcess.SelectedTitles = MainProcess.SelectedTitles
        _MainProcess.ValidatedPlayerInput = MainProcess.ValidatedPlayerInput
        _LogfilePath = LogfilePath
        _SQLQueryPath = SQLQueryPath
        _InlineReport = InlineReport
        _LogToHarddrive = LogToHarddrive
        _GenerateSQLQuery = GenerateSQLQuery
    End Sub
    Public Sub New(MainProcess As MainProcessing, LogfilePath As String, Debug As Boolean, InlineReport As Boolean, LogToHarddrive As Boolean)
        _MainProcess.ValidatedPlayerInput = MainProcess.ValidatedPlayerInput
        _LogfilePath = LogfilePath
        _Debug = Debug
        _InlineReport = InlineReport
        _LogToHarddrive = LogToHarddrive
    End Sub

    ' Diese Methode wird im neuen Thread ausgeführt.
    Public Sub Lookup()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running...", _MainProcess.Guid))

        Dim _PlayerInput_Splitted As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        '// 1234 Roki 0 64 0 0 0
        For _i As Integer = 0 To _PlayerInput_Splitted.Count - 1
            AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
                            "// CHARACTER TITLE DATA" + vbCrLf)

            Dim _SplittedCharacterInfo() As String = Regex.Split(_PlayerInput_Splitted(_i), " ")
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
                                GetTitleBitsFromINT(0, _Value, _LANG_TitleList_INT_0)
                                _Char.INT_0 = CUInt(_Value)
                            End If
                        Case 4 '// INT_1
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_1 = 0
                            Else
                                GetTitleBitsFromINT(1, _Value, _LANG_TitleList_INT_1)
                                _Char.INT_1 = CUInt(_Value)
                            End If
                        Case 5 '// INT_2
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_2 = 0
                            Else
                                GetTitleBitsFromINT(2, _Value, _LANG_TitleList_INT_2)
                                _Char.INT_2 = CUInt(_Value)
                            End If
                        Case 6 '// INT_3
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_3 = 0
                            Else
                                GetTitleBitsFromINT(3, _Value, _LANG_TitleList_INT_3)
                                _Char.INT_3 = CUInt(_Value)
                            End If
                        Case 7 '// INT_4
                            If _Value = "0" Then
                                '// Wenn keine Titel vorhanden sind, brauchen wir nach keinen suchen.
                                _Char.INT_4 = 0
                            Else
                                GetTitleBitsFromINT(4, _Value, _LANG_TitleList_INT_4)
                                _Char.INT_4 = CUInt(_Value)
                            End If
                        Case 8 '// INT_5
                            '// Int 5 enthält nie einen Titel.
                            _Char.INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next

                '// Charakterdaten generieren und ausgeben.
                AddInlineReport(GeneratePrintCharakter(_Char))
            Else
                '// Fehler bei der Länge des Charakter Input / dürfte normal nie vorkommen!
                MessageBox.Show("The character input contains a line with a wrong syntax." + vbCrLf + "Line " + (_i + 1).ToString + " affected: """ + _PlayerInput_Splitted(_i) + """" + vbCrLf + vbCrLf + "Take a closer look at this character!" + vbCrLf + "The current process will be canceled now.", "Error: Wrong character syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted("", _InlineReport, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _PlayerInput_Splitted.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _PlayerInput_Splitted.Count.ToString, _MainProcess.Guid))
        Next

        '// Logfile Lokal speichern, falls dies zuvor ausgewählt wurde.
        If _LogToHarddrive Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Save log to hard disk...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log, False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _InlineReport, _MainProcess))
    End Sub

    Private Function GetTitleBitsFromINT(_IntID As Integer, _IntValue As String, _TitleList_INT_ID As List(Of CharTitle)) As List(Of UInteger)
        '// Titel Bits der Bitmask auslesen.
        Dim _CharacterTitleBits As List(Of UInteger) = GetBitsFromBitMask(CUInt(_IntValue))
        '// Speichern der Titel für den Spieler.
        Dim _FoundTitles As New List(Of UInteger)
        '// Falls die Bitmask vorhanden ist, aber keine Bitmask ist.
        If _CharacterTitleBits.Count = 0 Then
            'TODO MÖGLICHER CRASH !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Return _CharacterTitleBits
        End If

        For Each _TitleBit In _CharacterTitleBits
            '// c.Bit = _TitleBit müsste normal nicht überprüft werden.
            Dim _FoundTitle As CharTitle = _TitleList_INT_ID.Find(Function(c) c.IntID = _IntID AndAlso c.Bit = _TitleBit)

            AddInlineReport("FOUND | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)
            _FoundTitles.Add(_FoundTitle.Bit)
        Next
        Return _FoundTitles
    End Function



    Public Sub Remove()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running...", _MainProcess.Guid))

        Dim _WrongCounter As Integer = 0

        Dim _CharacterFullList As New List(Of Character)
        Dim _PlayerInput_Splitted As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        '// 1234 Roki 0 64 0 0 0
        For Each _CharacterInfo In _PlayerInput_Splitted

            AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
                            "// CHARACTER TITLE DATA" + vbCrLf)
            Dim _SplittedCharacterInfo() As String = Regex.Split(_CharacterInfo, " ")
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
                RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt((_CharacterFullList.Count / _PlayerInput_Splitted.Count) * 100), "Running... " + _CharacterFullList.Count.ToString + " of " + _PlayerInput_Splitted.Count.ToString, _MainProcess.Guid))
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
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Running... Save log to hard disk...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log, False)
        End If

        '// SQL Query erstellen, falls dies zuvor ausgewählt wurde.
        If _GenerateSQLQuery Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Running... Generate SQL update querys...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_SQLQueryPath, GenerateSQLQuery(_CharacterFullList), False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _InlineReport, _MainProcess))
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
                        For Each _BannedTitle In _MainProcess.SelectedTitles '// Dazu vergleichen wir das _Title.Bit mit einer Liste, gebannter Bits.
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

    Public Sub Add()

    End Sub

    Public Sub AddInlineReport(_Message As String)
        If _InlineReport Then
            RaiseEvent InlineReport(Me, New EArgs_InlineReport(_Message, _MainProcess.Guid))
        Else
            _Log += _Message + vbCrLf
        End If
    End Sub


#Region "Backup"
    'Private Sub Delay(ByVal dblSecs As Double)
    '    Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
    '    Dim dblWaitTil As Date
    '    Now.AddSeconds(OneSec)
    '    dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
    '    Do Until Now > dblWaitTil
    '        Application.DoEvents() ' Allow windows messages to be processed
    '    Loop

    'End Sub

    'Throw New InvalidOperationException("Not completed.")
#End Region

End Class
