Option Explicit On
Option Strict On

Imports System.Text.RegularExpressions

Module Functions_Mod
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
                For _i As Integer = 0 To _Char.ChangedTitles.Count - 1
                    _SQLQuery += "REMOVED | INT: " + _Char.ChangedTitles.Item(_i).IntID.ToString + _
                                 " | BIT: " + _Char.ChangedTitles.Item(_i).Bit.ToString + _
                                 " | TitleID: " + _Char.ChangedTitles.Item(_i).TitleID.ToString + _
                                 " | Title: " + _Char.ChangedTitles.Item(_i).MaleTitle
                    If _i = (_Char.ChangedTitles.Count - 1) Then _SQLQuery += " */"
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

    ''' <summary>Reload der Titles Input CheckBoxList.</summary>
    Public Sub Reload_TitlesInput(_CheckState As Boolean)
        fmMain.clbTitlesInput.Items.Clear()
        '// Erweiterte Ansicht
        If _CheckState Then
            For Each _Title In _LANG_TitelList_All
                fmMain.clbTitlesInput.Items.Add("INT: " + _Title.IntID.ToString + " (" + _Title.IntID_Double.ToString + _
                                                ") | BIT: " + _Title.Bit.ToString + _
                                                " | TitleID: " + _Title.TitleID.ToString + _
                                                " | IntBit: " + _Title.BitOfInteger.ToString + _
                                                " | UnkRef: " + _Title.UnkRef.ToString + _
                                                " | MaleTitle: " + _Title.MaleTitle + _
                                                " | FemaleTitle: " + _Title.FemaleTitle + _
                                                " | InGameOrder: " + _Title.InGameOrder.ToString)
            Next
        Else
            '// Einfache Ansicht
            For Each _Title In _LANG_TitelList_All
                fmMain.clbTitlesInput.Items.Add("INT: " + _Title.IntID.ToString + _
                                                " | BIT: " + _Title.Bit.ToString + _
                                                " | TitleID: " + _Title.TitleID.ToString + _
                                                " | Title: " + _Title.MaleTitle)
            Next
        End If
    End Sub

    ''' <summary>Entfernt alle Leeren Zeilen in der Textbox.</summary>
    Public Sub Remove_EmptyLines(_TextBox As Windows.Forms.TextBox)
        Dim _Content As String = ""
        For Each _Line In _TextBox.Lines
            If _Line.EndsWith(" ") Then
                _Content += _Line.Remove(_Line.Length - 1) + vbCrLf
            Else
                _Content += _Line + vbCrLf
            End If
        Next
        _TextBox.Text = _Content

        _TextBox.Lines = (From s As String In _TextBox.Lines Where s.Length > 0 Select s).ToArray
        ReDim Preserve _TextBox.Lines(_TextBox.Lines.Count - 1)
    End Sub

    ''' <summary>Eine Liste aller aktuell ausgewählten Titels bekommen.</summary>
    Public Function GetSelectedTitles(_CheckedListBox As System.Windows.Forms.CheckedListBox, _Debug As Boolean) As List(Of CharTitle)
        Dim _SelectedTitles As New List(Of CharTitle)
        '// Findet "D: 1234".
        Dim _RegEx As Regex = New Regex("D: [0-9]+")

        For Each _SelectedTitel In _CheckedListBox.CheckedItems
            Dim _Match As Match = _RegEx.Match(_SelectedTitel.ToString)

            If _Match.Success Then '// Obligatorisch, kann normal niemals False sein.
                For Each _Title In _LANG_TitelList_All
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
End Module
