Option Explicit On
Option Strict On

Imports System.Text.RegularExpressions

Module Mod_Functions
    '''<summary>Bits einer Bitmask auslesen.</summary>
    Public Function GetBitsFromBitMask(_BitMask As UInteger) As List(Of UInteger)
        Dim _Bits As New List(Of UInteger)

        For _i As Integer = 31 To 0 Step -1
            If _BitMask - 2 ^ _i >= 0 Then
                _BitMask = CUInt(_BitMask - 2 ^ _i)
                _Bits.Add(CUInt(2 ^ _i))
            End If
        Next

        Return _Bits
    End Function

    ''' <summary>Zeigt eine Debugnachricht, falls Debug Mode enabled.</summary>
    Public Sub DebugMessage(_Message As String)
        If My.Settings.DebugMode Then
            MessageBox.Show(_Message, "Debug message.", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ''' <summary>Eine Character Structure in einen String umwandeln.</summary>
    Public Function GeneratePrintCharakter(_Character As Character) As String
        Dim _Output As String = vbCrLf + "Name: " + _Character.Name + _
                                         " | Account ID: " + _Character.AccountID.ToString + _
                                         " | GUID: " + _Character.GUID.ToString + _
                                         " | INT_0: " + _Character.INT_0.ToString + _
                                         " | INT_1: " + _Character.INT_1.ToString + _
                                         " | INT_2: " + _Character.INT_2.ToString + _
                                         " | INT_3: " + _Character.INT_3.ToString + _
                                         " | INT_4: " + _Character.INT_4.ToString
        If Not _Character.NothingChanged Then _Output += " | Last knownTitles: """ + _Character.BitmaskBackup + """"
        Return _Output
    End Function

    ''' <summary>Generiert SQL Update Querys, anhand einer Character Full List und der Variable NothingChanged bei jedem Character.</summary>
    Public Function GenerateSQLQuery(_CharacterFullList As List(Of Character)) As String
        Dim _SQLQuery As String = ""
        For Each _Char In _CharacterFullList
            If Not _Char.NothingChanged Then
                '// Allgemeine Informationen zu dem Charakter auflisten
                _SQLQuery += "/* Character: " + _Char.Name +
                             " | GUID: " + _Char.GUID.ToString +
                             " | Account ID: " + _Char.AccountID.ToString +
                             " | Last Bitmask: """ + _Char.BitmaskBackup + """" + vbCrLf

                '// Alle gebannten Titel auflisten
                For _i As Integer = 0 To _Char.AffectedTitles.Count - 1
                    _SQLQuery += "REMOVED | INT: " + _Char.AffectedTitles.Item(_i).IntID.ToString + _
                                 " | BIT: " + _Char.AffectedTitles.Item(_i).Bit.ToString + _
                                 " | TitleID: " + _Char.AffectedTitles.Item(_i).TitleID.ToString + _
                                 " | Title: " + _Char.AffectedTitles.Item(_i).MaleTitle
                    If _i = (_Char.AffectedTitles.Count - 1) Then _SQLQuery += " */"
                    _SQLQuery += vbCrLf
                Next

                '// Den Update Query für den Charakter erstellen
                _SQLQuery += "UPDATE `characters` SET `knownTitles`=""" + _Char.INT_0.ToString + " " + _
                                                                          _Char.INT_1.ToString + " " + _
                                                                          _Char.INT_2.ToString + " " + _
                                                                          _Char.INT_3.ToString + " " + _
                                                                          _Char.INT_4.ToString + " " + _
                                                                          _Char.INT_5.ToString + """ WHERE `guid`=" + _
                                                                          _Char.GUID.ToString + ";" + vbCrLf
            End If
        Next
        Return _SQLQuery
    End Function

    ''' <summary>Öffnet einen SaveFileDialog und gibt den Pfad + Dateiname + Endung zurück, falls korrekt.</summary>
    Public Function OpenSaveFileDialog(_Filter As String, _FileName As String, Optional _FilterIndex As Integer = 1) As String
        Dim _SetPathDialog As New SaveFileDialog
        _SetPathDialog.Filter = _Filter
        _SetPathDialog.FilterIndex = _FilterIndex
        _SetPathDialog.RestoreDirectory = True
        _SetPathDialog.FileName = _FileName
        If _SetPathDialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return _SetPathDialog.FileName.ToString
        End If
        Return ""
    End Function

    ''' <summary>Entfernt alle Leeren Zeilen in der Textbox.</summary>
    Public Sub Remove_EmptyLines(_TextBox As Windows.Forms.TextBox)
        _TextBox.Lines = (From s As String In _TextBox.Lines Where s.Length > 0 Select s).ToArray
        ReDim Preserve _TextBox.Lines(_TextBox.Lines.Count - 1)
    End Sub

    ''' <summary>Eine Liste aller aktuell ausgewählten Titels bekommen.</summary>
    Public Function GetSelectedTitles(_DataTable As DataTable) As List(Of CharTitle)
        Dim _SelectedTitles As New List(Of CharTitle)

        Select Case _DataTable.TableName
            Case "dtShort"
                For Each _Title As dsSelectedTitles.dtShortRow In _DataTable.Rows
                    If _Title.colChoose = True Then
                        _SelectedTitles.Add(_TitelList_All.Find(Function(c) c.TitleID = _Title.colTitleID))
                    End If
                Next
            Case "dtExtended"
                For Each _Title As dsSelectedTitles.dtExtendedRow In _DataTable.Rows
                    If _Title.colChoose = True Then
                        _SelectedTitles.Add(_TitelList_All.Find(Function(c) c.TitleID = _Title.colTitleID))
                    End If
                Next
        End Select

        Return _SelectedTitles
        '// http://regexhero.net/tester/
    End Function
End Module
