Option Explicit On
Option Strict On

Imports System.Text
Imports System.Threading
Imports System.Text.RegularExpressions

'// State jedes Titels nach der Verarbeitung
Public Enum State As Integer
    FOUND = 0
    MATCHES = 1
    GRANTED = 2
    REMOVED = 3
End Enum

'// Struktur für einen Charakter
Public Structure Character
    Dim GUID, AccountID As Integer
    Dim Name, KnownTitlesBackup As String
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
    Dim State As State
End Structure

Public Class Cls_Main

#Region "Deklarationen"
    '// Hauptprozessstruktur mit einem eindeutigen Bezeichner für diesen Task.
    Private _MainProcess As MainProcessing

    Private _SQLQueryPath As String = ""

    '// Events
    Public Event InlineReport(sender As Object, e As EArgs_InlineReport)
    Public Event StatusReport(sender As Object, e As EArgs_StatusReport)
    Public Event MainProcess_Completed(sender As Object, e As EArgs_MainProcessCompleted)

#Region "Enum - FieldID"
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
    Public ReadOnly Property GetMainProcess_Guid() As Guid
        Get
            Return _MainProcess.Guid
        End Get
    End Property
#End Region

    '// Wird bei Titel entfernen verwendet.
    Public Sub New(MainProcess As MainProcessing, SQLQueryPath As String)
        _MainProcess = MainProcess
        _SQLQueryPath = SQLQueryPath

        '// Neue GUID für Thread erstellen.
        _MainProcess.Guid = Guid.NewGuid
    End Sub

    '// Wird bei Titel suchen & Titel auflisten verwendet.
    Public Sub New(MainProcess As MainProcessing)
        _MainProcess = MainProcess

        '// Neue GUID für Thread erstellen.
        _MainProcess.Guid = Guid.NewGuid
    End Sub

#Region "Titel auflisten"
    Public Sub Lookup()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running...", _MainProcess.Guid))

        '// Alle Charaktere, bei denen XXX.
        Dim _FullCharacterList As New List(Of Character)
        Dim _EachCharacter As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        For _i As Integer = 0 To _EachCharacter.Count - 1

            '// Auftrennung an den Leerzeichen. (1234 FireEmerald 0 64 0 0 0)
            Dim _CharacterInfo() As String = Regex.Split(_EachCharacter(_i), " ")

            If _CharacterInfo.Length = FieldID.Maximum Then
                '// Neuen Charakter erstellen.
                Dim _CurrentCharacter As New Character With {.NothingChanged = True,
                                                             .AffectedTitles = New List(Of CharTitle)}
                '// Switchen der Einträge.
                Dim _ValueCounter As Integer = 0

                For Each _Value As String In _CharacterInfo
                    Select Case _ValueCounter
                        Case FieldID.GUID
                            _CurrentCharacter.GUID = CInt(_Value)
                        Case FieldID.AccountID
                            _CurrentCharacter.AccountID = CInt(_Value)
                        Case FieldID.Name
                            _CurrentCharacter.Name = _Value
                        Case FieldID.Int_0
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _Value = "0" Then
                                _CurrentCharacter.INT_0 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_0 = CUInt(_Value)
                            _CurrentCharacter.AffectedTitles.AddRange(GetTitleList(_TitleList_INT_0, _Value))
                        Case FieldID.Int_1
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _Value = "0" Then
                                _CurrentCharacter.INT_1 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_1 = CUInt(_Value)
                            _CurrentCharacter.AffectedTitles.AddRange(GetTitleList(_TitleList_INT_1, _Value))
                        Case FieldID.Int_2
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _Value = "0" Then
                                _CurrentCharacter.INT_2 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_2 = CUInt(_Value)
                            _CurrentCharacter.AffectedTitles.AddRange(GetTitleList(_TitleList_INT_2, _Value))
                        Case FieldID.Int_3
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _Value = "0" Then
                                _CurrentCharacter.INT_3 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_3 = CUInt(_Value)
                            _CurrentCharacter.AffectedTitles.AddRange(GetTitleList(_TitleList_INT_3, _Value))
                        Case FieldID.Int_4
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _Value = "0" Then
                                _CurrentCharacter.INT_4 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_4 = CUInt(_Value)
                            _CurrentCharacter.AffectedTitles.AddRange(GetTitleList(_TitleList_INT_4, _Value))
                        Case FieldID.Int_5
                            '// Int 5 enthält nie einen Titel.
                            _CurrentCharacter.INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next

                '// Charakterdaten generieren und ausgeben.
                _FullCharacterList.Add(_CurrentCharacter)
            Else
                '// Fehler bei der Länge des Charakter Input / dürfte normal nie vorkommen!
                MessageBox.Show("The character input contains a line with a wrong syntax." + vbCrLf + "Line " + (_i + 1).ToString + " affected: """ + _EachCharacter(_i) + """" + vbCrLf + vbCrLf + "Take a closer look at this character!" + vbCrLf + "The current process will be canceled now.", "Error: Wrong character syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted("", _FullCharacterList, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _EachCharacter.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _EachCharacter.Count.ToString, _MainProcess.Guid))
        Next

        '// Logfile erstellen.
        If My.Settings.SaveLogfile Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Generate Logfile...", _MainProcess.Guid))
            GenLogfileBody(_FullCharacterList, _MainProcess)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted("", _FullCharacterList, _MainProcess))
    End Sub
#End Region

#Region "Titel suchen"
    Public Sub Search()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running...", _MainProcess.Guid))

        '// Alle Charaktere, bei denen ein ausgewählter Titel gefunden wurde.
        Dim _FullCharacterList As New List(Of Character)
        Dim _EachCharacter As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        For _i As Integer = 0 To _EachCharacter.Count - 1

            '// Auftrennung an den Leerzeichen. (1234 FireEmerald 0 64 0 0 0)
            Dim _CharacterInfo() As String = Regex.Split(_EachCharacter(_i), " ")

            If _CharacterInfo.Length = FieldID.Maximum Then
                '// Neuen Charakter erstellen.
                Dim _CurrentCharacter As New Character With {.NothingChanged = True,
                                                             .AffectedTitles = New List(Of CharTitle)}
                '// Switchen der Einträge.
                Dim _ValueCounter As Integer = 0

                For Each _Value As String In _CharacterInfo
                    Select Case _ValueCounter
                        Case FieldID.GUID
                            _CurrentCharacter.GUID = CInt(_Value)
                        Case FieldID.AccountID
                            _CurrentCharacter.AccountID = CInt(_Value)
                        Case FieldID.Name
                            _CurrentCharacter.Name = _Value
                        Case FieldID.Int_0
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            If _Value = "0" Then
                                _CurrentCharacter.INT_0 = 0 '// Keine Titel vorhanden.
                                Exit Select
                            End If

                            _CurrentCharacter.INT_0 = CUInt(_Value)
                            AddTitlesToCharacterAs(_CurrentCharacter, GetTitleList(_TitleList_INT_0, _Value), State.MATCHES)
                        Case FieldID.Int_1
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            If _Value = "0" Then
                                _CurrentCharacter.INT_1 = 0 '// Keine Titel vorhanden.
                                Exit Select
                            End If

                            _CurrentCharacter.INT_1 = CUInt(_Value)
                            AddTitlesToCharacterAs(_CurrentCharacter, GetTitleList(_TitleList_INT_1, _Value), State.MATCHES)
                        Case FieldID.Int_2
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            If _Value = "0" Then
                                _CurrentCharacter.INT_2 = 0 '// Keine Titel vorhanden.
                                Exit Select
                            End If

                            _CurrentCharacter.INT_2 = CUInt(_Value)
                            AddTitlesToCharacterAs(_CurrentCharacter, GetTitleList(_TitleList_INT_2, _Value), State.MATCHES)
                        Case FieldID.Int_3
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            If _Value = "0" Then
                                _CurrentCharacter.INT_3 = 0 '// Keine Titel vorhanden.
                                Exit Select
                            End If

                            _CurrentCharacter.INT_3 = CUInt(_Value)
                            AddTitlesToCharacterAs(_CurrentCharacter, GetTitleList(_TitleList_INT_3, _Value), State.MATCHES)
                        Case FieldID.Int_4
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            If _Value = "0" Then
                                _CurrentCharacter.INT_4 = 0 '// Keine Titel vorhanden.
                                Exit Select
                            End If

                            _CurrentCharacter.INT_4 = CUInt(_Value)
                            AddTitlesToCharacterAs(_CurrentCharacter, GetTitleList(_TitleList_INT_4, _Value), State.MATCHES)
                        Case FieldID.Int_5
                            _CurrentCharacter.KnownTitlesBackup += _Value + " "

                            '// Int 5 enthält nie einen Titel.
                            _CurrentCharacter.INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next

                '// Charakter zur Liste aller abgearbeiteten Chars hinzufügen, wenn dieser einen zu findenden Titel enthält.
                If _CurrentCharacter.AffectedTitles.Count > 0 OrElse My.Settings.DebugMode Then
                    _FullCharacterList.Add(_CurrentCharacter)
                End If
            Else
                '// Fehler bei der Länge des Charakter Input / dürfte normal nie vorkommen!
                MessageBox.Show("The character input contains a line with a wrong syntax." + vbCrLf + "Line " + (_i + 1).ToString + " affected: """ + _EachCharacter(_i) + """" + vbCrLf + vbCrLf + "Take a closer look at this character!" + vbCrLf + "The current process will be canceled now.", "Error: Wrong character syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted("", _FullCharacterList, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _EachCharacter.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _EachCharacter.Count.ToString + "  | Affected characters: " + _FullCharacterList.Count.ToString, _MainProcess.Guid))
        Next

        '// Logfile erstellen.
        If My.Settings.SaveLogfile Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Generate Logfile...", _MainProcess.Guid))
            GenLogfileBody(_FullCharacterList, _MainProcess)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted("", _FullCharacterList, _MainProcess))
    End Sub

    ''' <summary>Fügt dem gegebenen Charakter jene Titel hinzu, welche sowohl in FoundTitles als auch SelectedTitles existieren. Die State wird dabei wie angegeben geändert.</summary>
    Private Sub AddTitlesToCharacterAs(ByRef _CurrentCharacter As Character, _FoundTitles As List(Of CharTitle), _State As State)
        '// Alle gefundenen Titel durchgehen.
        For Each _FoundTitle In _FoundTitles
            '// Prüfen ob der gefundene Titel in den zu suchenden enthalten ist.
            If _MainProcess.SelectedTitles.Contains(_FoundTitle) Then
                _FoundTitle.State = _State

                _CurrentCharacter.AffectedTitles.Add(_FoundTitle)
            End If
        Next
    End Sub
#End Region

#Region "Titel entfernen"
    Public Sub Remove()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Process running ...", _MainProcess.Guid))

        '// Alle Charaktere, bei denen ein ausgewählter Titel gefunden wurde.
        Dim _FullCharacterList As New List(Of Character)
        Dim _EachCharacter As New List(Of String)(Regex.Split(_MainProcess.ValidatedPlayerInput, vbCrLf))

        For _i As Integer = 0 To _EachCharacter.Count - 1

            '// Auftrennung an den Leerzeichen. (1234 FireEmerald 0 64 0 0 0)
            Dim _CharacterInfo() As String = Regex.Split(_EachCharacter(_i), " ")

            If _CharacterInfo.Length = FieldID.Maximum Then

                '// Neuen Charakter erstellen.
                Dim _CurrentCharacter As New Character With {.NothingChanged = True,
                                                             .AffectedTitles = New List(Of CharTitle)}

                For _FieldID As Integer = FieldID.GUID To FieldID.Maximum
                    Select Case _FieldID
                        Case FieldID.GUID
                            _CurrentCharacter.GUID = CInt(_CharacterInfo(_FieldID))
                        Case FieldID.AccountID
                            _CurrentCharacter.AccountID = CInt(_CharacterInfo(_FieldID))
                        Case FieldID.Name
                            _CurrentCharacter.Name = _CharacterInfo(_FieldID)
                        Case FieldID.Int_0
                            _CurrentCharacter.KnownTitlesBackup += _CharacterInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _CharacterInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_0 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_0 = GetGrantedBitmask(_CurrentCharacter, _
                                                                        GetTitleList(_TitleList_INT_0, _CharacterInfo(_FieldID)))
                        Case FieldID.Int_1
                            _CurrentCharacter.KnownTitlesBackup += _CharacterInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _CharacterInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_1 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_1 = GetGrantedBitmask(_CurrentCharacter, _
                                                                        GetTitleList(_TitleList_INT_1, _CharacterInfo(_FieldID)))
                        Case FieldID.Int_2
                            _CurrentCharacter.KnownTitlesBackup += _CharacterInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _CharacterInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_2 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_2 = GetGrantedBitmask(_CurrentCharacter, _
                                                                        GetTitleList(_TitleList_INT_2, _CharacterInfo(_FieldID)))
                        Case FieldID.Int_3
                            _CurrentCharacter.KnownTitlesBackup += _CharacterInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _CharacterInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_3 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_3 = GetGrantedBitmask(_CurrentCharacter, _
                                                                        GetTitleList(_TitleList_INT_3, _CharacterInfo(_FieldID)))
                        Case FieldID.Int_4
                            _CurrentCharacter.KnownTitlesBackup += _CharacterInfo(_FieldID) + " "

                            '// Bitmask errechnen und Titel entfernen.
                            If _CharacterInfo(_FieldID) = "0" Then
                                _CurrentCharacter.INT_4 = 0
                                Exit Select
                            End If

                            _CurrentCharacter.INT_4 = GetGrantedBitmask(_CurrentCharacter, _
                                                                        GetTitleList(_TitleList_INT_4, _CharacterInfo(_FieldID)))
                        Case FieldID.Int_5
                            _CurrentCharacter.KnownTitlesBackup += _CharacterInfo(_FieldID) + " "

                            '// Int 5 enthält nie einen Titel.
                            _CurrentCharacter.INT_5 = CUInt(_CharacterInfo(_FieldID))
                    End Select
                Next

                '// Charakter zur Liste aller abgearbeiteten Chars hinzufügen.
                If _CurrentCharacter.AffectedTitles.Count > 0 OrElse My.Settings.DebugMode Then
                    _FullCharacterList.Add(_CurrentCharacter)
                End If
            Else
                '// Fehler bei der Länge des Charakter Input / dürfte normal nie vorkommen.
                MessageBox.Show("The character input contains a line with a wrong syntax." + vbCrLf + "Line " + (_i + 1).ToString + " affected: """ + _EachCharacter(_i) + """" + vbCrLf + vbCrLf + "Take a closer look at this character!" + vbCrLf + "The current process will be canceled now.", "Error: Wrong character syntax.", MessageBoxButtons.OK, MessageBoxIcon.Error)
                RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted("", _FullCharacterList, _MainProcess))
                Return
            End If

            '// Aktualisierung der abgearbeiteten Charaktere.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_i + 1) / _EachCharacter.Count) * 100), "Process running... " + (_i + 1).ToString + " of " + _EachCharacter.Count.ToString + "  | Affected characters: " + _FullCharacterList.Count.ToString, _MainProcess.Guid))
        Next

        Dim _SQLUpdateQuery As String = ""
        '// SQL Query erstellen.
        If My.Settings.SaveSQLUpdateQuery Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(100, "Generate SQL update querys...", _MainProcess.Guid))
            _SQLUpdateQuery = GenSQLUpdateQuery(_FullCharacterList)
            My.Computer.FileSystem.WriteAllText(_SQLQueryPath, _SQLUpdateQuery.ToString, False)
        End If

        '// Logfile erstellen.
        If My.Settings.SaveLogfile Then
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Generate Logfile...", _MainProcess.Guid))
            GenLogfileBody(_FullCharacterList, _MainProcess)
        End If

        '// Abschließendes Events ausführen.
        RaiseEvent MainProcess_Completed(Me, New EArgs_MainProcessCompleted(_SQLUpdateQuery, _FullCharacterList, _MainProcess))
    End Sub

    ''' <summary>Gibt eine Liste mit vorhandenen Titeln des gegebenen Integers zurück.</summary>
    ''' <param name="_IntTitleList">Eine Liste mit möglichen Titeln zu dem Integer.</param>
    ''' <param name="_IntValue">Der Integer des Charakters.</param>
    Private Function GetTitleList(_IntTitleList As List(Of CharTitle), _IntValue As String) As List(Of CharTitle)
        '// Alle vorhandenen Titel als Bits des aktuellen Integers.
        Dim _IntTitleBits As List(Of UInteger) = GetBitsFromBitMask(CUInt(_IntValue))
        '// Alle vorhandenen Titel aus dem aktuellen Integer.
        Dim _FoundTitles As New List(Of CharTitle)

        '// Die Bitmask enthielt keine Bits - sollte normal nie vorkommen.
        If _IntTitleBits.Count = 0 Then Return _FoundTitles

        For Each _TitleBit In _IntTitleBits
            Dim _FoundTitle As CharTitle = _IntTitleList.Find(Function(c) c.Bit = _TitleBit)

            '// Falls die Funktion keinen Titel findet. Kann passieren, wenn an den knownTitles gepfuscht wurde. (Custom Titel. Beispiel: "1 1 User 32769 0 0 0 0 0")
            If _FoundTitle.DBValue = Nothing Then
                Log_Msg(PRÄFIX.WARNING, "The title bit " + _TitleBit.ToString + " of the int value " + _IntValue + " couldn't be found in the DBC Values!")
            End If

            _FoundTitles.Add(_FoundTitle)
        Next
        Return _FoundTitles
    End Function

    ''' <summary>Alle nicht gebannten Titel aus den FoundTitles zu einer Bitmask addieren. Referenz zu CurrentCharacter.</summary>
    Private Function GetGrantedBitmask(ByRef _CurrentCharacter As Character, _FoundTitles As List(Of CharTitle)) As UInteger
        Dim _GrantedBitmask As UInteger = 0

        '// Alle gefundenen Titel
        For Each _FoundTitle In _FoundTitles
            Dim _FoundTitleIsBanned As Boolean = False

            '// Alle gebannten Titel. Die IntID sowie das Bit muss übereinstimmen.
            For Each _BannedTitle In _MainProcess.SelectedTitles
                If _BannedTitle.IntID = _FoundTitle.IntID AndAlso _BannedTitle.Bit = _FoundTitle.Bit Then
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
                _FoundTitle.State = State.REMOVED

                '// Vermerken, dass der Charakter gebannte Titel enthält.
                _CurrentCharacter.NothingChanged = False
                _CurrentCharacter.AffectedTitles.Add(_FoundTitle)
            Else
                '// Das nicht gebannte Bit wieder zu der Bitmask addieren.
                _GrantedBitmask += _FoundTitle.Bit

                '// Falls die nicht gebannten Titel auch aufgelistet werden sollen - dafür gibt's aber eigentlich die Search Funktion.
                If My.Settings.DebugMode Then
                    _FoundTitle.State = State.GRANTED
                    _CurrentCharacter.AffectedTitles.Add(_FoundTitle)
                End If
            End If
        Next

        Return _GrantedBitmask
    End Function
#End Region

#Region "Titel hinzufügen"
    Public Sub Add()

    End Sub
#End Region

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
