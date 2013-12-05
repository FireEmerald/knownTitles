Option Explicit On
Option Strict On

Imports System.Text
Imports System.Threading
Imports System.Text.RegularExpressions

'// Struktur für einen Charakter
Public Structure Character
    Dim GUID, AccountID As Integer
    Dim Name, BitmaskBackup As String
    Dim INT_0, INT_1, INT_2, INT_3, INT_4, INT_5 As UInteger
    Dim AffectedTitles As List(Of CharTitle)
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
    Private _Log As New StringBuilder

    Private _LogfilePath As String = ""
    Private _SQLQueryPath As String = ""

    '// Events
    Public Event InlineReport(sender As Object, e As EArgs_InlineReport)
    Public Event StatusReport(sender As Object, e As EArgs_StatusReport)
    Public Event MainProcess_Completed(sender As Object, e As EArgs_MainProcessCompleted)

#Region "Enums FieldID"
    Private Enum FieldID
        GUID = 0
        AccountID = 1
        Name = 2
        Int_0 = 3
        Int_1 = 4
        Int_2 = 5
        Int_3 = 6
        Int_4 = 7
        Int_5 = 8
        Maximum = 9
    End Enum
#End Region
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
    Public Sub New(MainProcess As MainProcessing, LogfilePath As String, SQLQueryPath As String)
        _MainProcess.SelectedTitles = MainProcess.SelectedTitles
        _MainProcess.ValidatedPlayerInput = MainProcess.ValidatedPlayerInput
        _LogfilePath = LogfilePath
        _SQLQueryPath = SQLQueryPath
    End Sub
    Public Sub New(MainProcess As MainProcessing, LogfilePath As String)
        _MainProcess.SelectedTitles = MainProcess.SelectedTitles
        _MainProcess.ValidatedPlayerInput = MainProcess.ValidatedPlayerInput
        _LogfilePath = LogfilePath
    End Sub

#Region "LOOKUP CONTENT"
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
                                _Char.INT_0 = 0 '// Keine Titel vorhanden.
                            Else
                                GenerateLogFromFoundTitles(GetTitlesFromIntValue(0, _Value, _TitleList_INT_0))
                                _Char.INT_0 = CUInt(_Value)
                            End If
                        Case 4 '// INT_1
                            If _Value = "0" Then
                                _Char.INT_1 = 0 '// Keine Titel vorhanden.
                            Else
                                GenerateLogFromFoundTitles(GetTitlesFromIntValue(1, _Value, _TitleList_INT_1))
                                _Char.INT_1 = CUInt(_Value)
                            End If
                        Case 5 '// INT_2
                            If _Value = "0" Then
                                _Char.INT_2 = 0 '// Keine Titel vorhanden.
                            Else
                                GenerateLogFromFoundTitles(GetTitlesFromIntValue(2, _Value, _TitleList_INT_2))
                                _Char.INT_2 = CUInt(_Value)
                            End If
                        Case 6 '// INT_3
                            If _Value = "0" Then
                                _Char.INT_3 = 0 '// Keine Titel vorhanden.
                            Else
                                GenerateLogFromFoundTitles(GetTitlesFromIntValue(3, _Value, _TitleList_INT_3))
                                _Char.INT_3 = CUInt(_Value)
                            End If
                        Case 7 '// INT_4
                            If _Value = "0" Then
                                _Char.INT_4 = 0 '// Keine Titel vorhanden.
                            Else
                                GenerateLogFromFoundTitles(GetTitlesFromIntValue(4, _Value, _TitleList_INT_4))
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
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _PlayerInput_Splitted.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _PlayerInput_Splitted.Count.ToString, _MainProcess.Guid))
        Next

        '// Logfile Lokal speichern, falls dies zuvor ausgewählt wurde.
        If My.Settings.LogfileToHDD Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Save log to hard disk...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log.ToString, False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _MainProcess))
    End Sub

    Private Sub GenerateLogFromFoundTitles(_FoundTitles As List(Of CharTitle))
        '// Für jeden gefundenen Titel einen Inline Report ausgeben.
        For Each _FoundTitle In _FoundTitles
            AddInlineReport("FOUND | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)
        Next
    End Sub
#End Region

#Region "Titel suchen"
    Public Sub Search()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running...", _MainProcess.Guid))

        '// Alle Charaktere, bei denen ein ausgewählter Titel gefunden wurde.
        Dim _AffectedCharacters As Integer = 0

        Dim _PlayerInput_Splitted As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        '// 1234 Roki 0 64 0 0 0
        For _i As Integer = 0 To _PlayerInput_Splitted.Count - 1

            Dim _SplittedCharacterInfo() As String = Regex.Split(_PlayerInput_Splitted(_i), " ")
            If _SplittedCharacterInfo.Length = 9 Then
                Dim _ValueCounter As Integer = 0

                '// Charakterdaten
                Dim _Char As New Character With {.NothingChanged = True, .AffectedTitles = New List(Of CharTitle)}

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
                                _Char.INT_0 = 0 '// Keine Titel vorhanden.
                            Else
                                _Char.AffectedTitles.AddRange(GetTitlesFromIntValue(0, _Value, _TitleList_INT_0))
                                _Char.INT_0 = CUInt(_Value)
                            End If
                        Case 4 '// INT_1
                            If _Value = "0" Then
                                _Char.INT_1 = 0 '// Keine Titel vorhanden.
                            Else
                                _Char.AffectedTitles.AddRange(GetTitlesFromIntValue(1, _Value, _TitleList_INT_1))
                                _Char.INT_1 = CUInt(_Value)
                            End If
                        Case 5 '// INT_2
                            If _Value = "0" Then
                                _Char.INT_2 = 0 '// Keine Titel vorhanden.
                            Else
                                _Char.AffectedTitles.AddRange(GetTitlesFromIntValue(2, _Value, _TitleList_INT_2))
                                _Char.INT_2 = CUInt(_Value)
                            End If
                        Case 6 '// INT_3
                            If _Value = "0" Then
                                _Char.INT_3 = 0 '// Keine Titel vorhanden.
                            Else
                                _Char.AffectedTitles.AddRange(GetTitlesFromIntValue(3, _Value, _TitleList_INT_3))
                                _Char.INT_3 = CUInt(_Value)
                            End If
                        Case 7 '// INT_4
                            If _Value = "0" Then
                                _Char.INT_4 = 0 '// Keine Titel vorhanden.
                            Else
                                _Char.AffectedTitles.AddRange(GetTitlesFromIntValue(4, _Value, _TitleList_INT_4))
                                _Char.INT_4 = CUInt(_Value)
                            End If
                        Case 8 '// INT_5
                            '// Int 5 enthält nie einen Titel.
                            _Char.INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next

                For Each _TitleToFind In _MainProcess.SelectedTitles
                    If _Char.AffectedTitles.Contains(_TitleToFind) Then
                        '// Alle Charakterdaten generieren und ausgeben.
                        PrintFoundTitles(_Char.AffectedTitles, _MainProcess.SelectedTitles)
                        AddInlineReport(GeneratePrintCharakter(_Char))

                        '// Betroffene Charaktere aktualisieren.
                        _AffectedCharacters += 1
                        Exit For
                    End If
                Next

            Else
                '// Fehler bei der Länge des Charakter Input / dürfte normal nie vorkommen!
                MessageBox.Show("The character input contains a line with a wrong syntax." + vbCrLf + "Line " + (_i + 1).ToString + " affected: """ + _PlayerInput_Splitted(_i) + """" + vbCrLf + vbCrLf + "Take a closer look at this character!" + vbCrLf + "The current process will be canceled now.", "Error: Wrong character syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _PlayerInput_Splitted.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _PlayerInput_Splitted.Count.ToString + "  | Affected characters: " + _AffectedCharacters.ToString, _MainProcess.Guid))
        Next

        '// Logfile Lokal speichern, falls dies zuvor ausgewählt wurde.
        If My.Settings.LogfileToHDD Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Save log to hard disk...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log.ToString, False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _MainProcess))
    End Sub

    Private Sub PrintFoundTitles(_AffectedTitles As List(Of CharTitle), _TitlesToFind As List(Of CharTitle))
        '// Headerzeile.
        AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
                            "// CHARACTER TITLE DATA" + vbCrLf)

        '// Prüfen ob einer der Titel des Charakters zu suchen war.
        For Each _AffectedTitle In _AffectedTitles
            If _TitlesToFind.Contains(_AffectedTitle) Then
                AddInlineReport("MATCHES | BIT: " + _AffectedTitle.Bit.ToString + " | INT: " + _AffectedTitle.IntID.ToString + " | IntBit: " + _AffectedTitle.BitOfInteger.ToString + " | TitleID: " + _AffectedTitle.TitleID.ToString + " | UnkRef: " + _AffectedTitle.UnkRef.ToString + " | MaleTitle: " + _AffectedTitle.MaleTitle + " | FemaleTitle: " + _AffectedTitle.FemaleTitle + " | InGameOrder: " + _AffectedTitle.InGameOrder.ToString)
            Else
                AddInlineReport("FOUND | BIT: " + _AffectedTitle.Bit.ToString + " | INT: " + _AffectedTitle.IntID.ToString + " | IntBit: " + _AffectedTitle.BitOfInteger.ToString + " | TitleID: " + _AffectedTitle.TitleID.ToString + " | UnkRef: " + _AffectedTitle.UnkRef.ToString + " | MaleTitle: " + _AffectedTitle.MaleTitle + " | FemaleTitle: " + _AffectedTitle.FemaleTitle + " | InGameOrder: " + _AffectedTitle.InGameOrder.ToString)
            End If
        Next
    End Sub
#End Region

    ''' <summary>Aus einer Bitmask, alle Titel, als Liste ausgeben lassen.</summary>
    Private Function GetTitlesFromIntValue(_IntID As Integer, _IntValue As String, _Available_TitleList As List(Of CharTitle)) As List(Of CharTitle)
        '// Titel Bits der Bitmask auslesen.
        Dim _CharacterTitleBits As List(Of UInteger) = GetBitsFromBitMask(CUInt(_IntValue))
        '// Speichern der Titel für den Spieler.
        Dim _FoundTitles As New List(Of CharTitle)

        If _CharacterTitleBits.Count = 0 Then '// Keine Bits gefunden.
            Return _FoundTitles
        End If

        For Each _TitleBit In _CharacterTitleBits
            '// c.Bit = _TitleBit müsste normal nicht überprüft werden.
            Dim _FoundTitle As CharTitle = _Available_TitleList.Find(Function(c) c.IntID = _IntID AndAlso c.Bit = _TitleBit)

            _FoundTitles.Add(_FoundTitle)
        Next
        Return _FoundTitles
    End Function

#Region "REMOVE CONTENT"
    Public Sub Remove()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Process running ...", _MainProcess.Guid))

        Dim _CheckedCharacterList As New List(Of Character)

        Dim _PlayerInfo_Splitted As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        '// 1234 Roki 0 64 0 0 0
        For _i As Integer = 0 To _PlayerInfo_Splitted.Count - 1
            AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
                            "// CHARACTER TITLE DATA" + vbCrLf)

            '// Neuen Charakter erstellen
            Dim _CurrentCharacter As New Character With {.NothingChanged = True,
                                                         .AffectedTitles = New List(Of CharTitle)}

            Dim _SinglePlayerInfo() As String = Regex.Split(_PlayerInfo_Splitted(_i), " ")

            If _SinglePlayerInfo.Length = FieldID.Maximum Then

                For _FieldID As Integer = FieldID.GUID To FieldID.Maximum
                    Select Case _FieldID
                        Case FieldID.GUID
                            _CurrentCharacter.GUID = CInt(_SinglePlayerInfo(_FieldID))
                        Case FieldID.AccountID
                            _CurrentCharacter.AccountID = CInt(_SinglePlayerInfo(_FieldID))
                        Case FieldID.Name
                            _CurrentCharacter.Name = _SinglePlayerInfo(_FieldID)
                        Case FieldID.Int_0
                            _CurrentCharacter.BitmaskBackup += _SinglePlayerInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _SinglePlayerInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_0 = 0
                            Else
                                _CurrentCharacter.INT_0 = GetGrantedBitmask(GetTitlesFromIntValue(0, _SinglePlayerInfo(_FieldID), _TitleList_INT_0),
                                                                            _CurrentCharacter,
                                                                            _TitleList_INT_0)
                            End If
                        Case FieldID.Int_1
                            _CurrentCharacter.BitmaskBackup += _SinglePlayerInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _SinglePlayerInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_1 = 0
                            Else
                                _CurrentCharacter.INT_1 = GetGrantedBitmask(GetTitlesFromIntValue(1, _SinglePlayerInfo(_FieldID), _TitleList_INT_1),
                                                                            _CurrentCharacter,
                                                                            _TitleList_INT_1)
                            End If

                        Case FieldID.Int_2
                            _CurrentCharacter.BitmaskBackup += _SinglePlayerInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _SinglePlayerInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_2 = 0
                            Else
                                _CurrentCharacter.INT_2 = GetGrantedBitmask(GetTitlesFromIntValue(2, _SinglePlayerInfo(_FieldID), _TitleList_INT_2),
                                                                            _CurrentCharacter,
                                                                            _TitleList_INT_2)
                            End If

                        Case FieldID.Int_3
                            _CurrentCharacter.BitmaskBackup += _SinglePlayerInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _SinglePlayerInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_3 = 0
                            Else
                                _CurrentCharacter.INT_3 = GetGrantedBitmask(GetTitlesFromIntValue(3, _SinglePlayerInfo(_FieldID), _TitleList_INT_3),
                                                                            _CurrentCharacter,
                                                                            _TitleList_INT_3)
                            End If

                        Case FieldID.Int_4
                            _CurrentCharacter.BitmaskBackup += _SinglePlayerInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _SinglePlayerInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_4 = 0
                            Else
                                _CurrentCharacter.INT_4 = GetGrantedBitmask(GetTitlesFromIntValue(4, _SinglePlayerInfo(_FieldID), _TitleList_INT_4),
                                                                            _CurrentCharacter,
                                                                            _TitleList_INT_4)
                            End If

                        Case FieldID.Int_5
                            _CurrentCharacter.BitmaskBackup += _SinglePlayerInfo(_FieldID) + " "

                            '// Int 5 enthält nie einen Titel.
                            _CurrentCharacter.INT_5 = CUInt(_SinglePlayerInfo(_FieldID))

                    End Select
                Next

                '// Charakterdaten generieren und ausgeben.
                AddInlineReport(GeneratePrintCharakter(_CurrentCharacter))

                If My.Settings.SQLQueryToHDD Then
                    '// Charakter zur Liste alle abgearbeiteten Chars hinzuzählen.
                    _CheckedCharacterList.Add(_CurrentCharacter)
                End If
            Else
                '// Fehler bei der Länge des Charakter Input / dürfte normal nie vorkommen!
                MessageBox.Show("The character input contains a line with a wrong syntax." + vbCrLf + "Line " + (_i + 1).ToString + " affected: """ + _PlayerInfo_Splitted(_i) + """" + vbCrLf + vbCrLf + "Take a closer look at this character!" + vbCrLf + "The current process will be canceled now.", "Error: Wrong character syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _PlayerInfo_Splitted.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _PlayerInfo_Splitted.Count.ToString, _MainProcess.Guid))
        Next

        '// Logfile Lokal speichern, falls dies zuvor ausgewählt wurde.
        If My.Settings.LogfileToHDD Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Running... Save log to hard disk...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_LogfilePath, _Log.ToString, False)
        End If

        '// SQL Query erstellen, falls dies zuvor ausgewählt wurde.
        If My.Settings.SQLQueryToHDD Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Running... Generate SQL update querys...", _MainProcess.Guid))
            My.Computer.FileSystem.WriteAllText(_SQLQueryPath, GenerateSQLQuery(_CheckedCharacterList), False)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_Log, _MainProcess))
    End Sub

    ''' <summary>Alle nicht gebannten Titel aus den FoundTitles zu einer Bitmask addieren. Referenz zu CurrentCharacter.</summary>
    Private Function GetGrantedBitmask(_FoundTitles As List(Of CharTitle), ByRef _CurrentCharacter As Character, _Available_TitleList As List(Of CharTitle)) As UInteger
        Dim _GrantedBitmask As UInteger = 0

        '// Alle gefundenen Titel
        For Each _FoundTitle In _FoundTitles
            Dim _FoundTitleIsBanned As Boolean = False

            '// Alle gebannten Titel
            For Each _BannedTitle In _MainProcess.SelectedTitles
                If _BannedTitle.Bit = _FoundTitle.Bit Then
                    '// Der Titel ist gebannt.
                    _FoundTitleIsBanned = True
                    Exit For
                Else
                    '// Noch keine Übereinstimmung gefunden, weiter suchen.
                    Continue For
                End If
            Next

            '// Ist der Titel gebannt Ja/Nein?
            If _FoundTitleIsBanned Then
                '// Die Daten zu dem gebannten Titel dem Charakter hinzufügen.
                _CurrentCharacter.AffectedTitles.Add(_FoundTitle)
                AddInlineReport("REMOVED | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)
            Else
                '// Das nicht gebannte Bit wieder zu der Bitmask addieren.
                _GrantedBitmask += _FoundTitle.Bit
                AddInlineReport("GRANTED | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)
            End If
        Next

        Return _GrantedBitmask
    End Function
#End Region

    Public Sub Add()

    End Sub

    Public Sub AddInlineReport(_Message As String)
        If My.Settings.InlineReports Then
            RaiseEvent InlineReport(Me, New EArgs_InlineReport(_Message, _MainProcess.Guid))
        Else
            _Log.Append(_Message + vbCrLf)
        End If
    End Sub


#Region "Delay Sub Backup"
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
