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
        Return vbCrLf + "Name: " + _Character.Name + _
                        " | Account ID: " + _Character.AccountID.ToString + _
                        " | GUID: " + _Character.GUID.ToString + _
                        " | INT_0: " + _Character.INT_0.ToString + _
                        " | INT_1: " + _Character.INT_1.ToString + _
                        " | INT_2: " + _Character.INT_2.ToString + _
                        " | INT_3: " + _Character.INT_3.ToString + _
                        " | INT_4: " + _Character.INT_4.ToString
    End Function

    ''' <summary>Generiert SQL Update Querys, anhand einer Character Full List und der Variable NothingChanged bei jedem Character.</summary>
    Public Function GenerateSQLQuery(_CharacterFullList As List(Of Character)) As String
        Dim _SQLQuery As String = ""
        Dim _NewLine As Boolean = False
        For Each _Char In _CharacterFullList
            If Not _Char.NothingChanged Then
                If _NewLine Then
                    _SQLQuery += vbCrLf
                Else
                    _NewLine = True
                End If
                _SQLQuery += "UPDATE `characters` SET `knownTitles`=""" + _Char.INT_0.ToString + " " + _
                                                                          _Char.INT_1.ToString + " " + _
                                                                          _Char.INT_2.ToString + " " + _
                                                                          _Char.INT_3.ToString + " " + _
                                                                          _Char.INT_4.ToString + " " + _
                                                                          _Char.INT_5.ToString + """ WHERE `guid`=" + _
                                                                          _Char.GUID.ToString + "; -- Character: " + _Char.Name + " | Account ID: " + _Char.AccountID.ToString
            Else
                Continue For
            End If
        Next
        Return _SQLQuery
    End Function

    ''' <summary>Gibt den Text aus der Zwischenablage gekürzt zurück.</summary>
    Public Function GetDataFromClipboard(_Debug As Boolean) As String
        Dim _Output As String = ""

        If Clipboard.ContainsText Then
            Dim _ClipboardContent As String = ""
            '// Prüfen ob die letzte Zeile in der Zwischenablage leer war, falls ja, entfernen.
            If Clipboard.GetText.EndsWith(vbCrLf) Then
                _ClipboardContent = Clipboard.GetText.Substring(0, Clipboard.GetText.Length - 2)
                If _Debug Then MessageBox.Show("Last Row in Clipboard was empty - Deleted")
            Else
                _ClipboardContent = Clipboard.GetText
            End If
            '// Wir splitten den Text bei allen vbCrLf und prüfen ob die Syntax passt.
            For Each _Row In Split(_ClipboardContent, vbCrLf)
                If _Row.Contains("INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (") Then
                    Dim _ToCheck As String = Replace(Replace(_Row.Substring(76, _Row.Length - 80), ",", ""), "'", "")
                    If Regex.IsMatch(_ToCheck, "[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0", RegexOptions.None) Then
                        _Output += _ToCheck + vbCrLf
                        If _Debug Then MessageBox.Show("Clipboard Line Added: """ + _ToCheck + """")
                    Else
                        MessageBox.Show("Clipboard Import Error RegEx @" + vbCrLf + """" + _ToCheck + """", "RegEx Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                Else
                    MessageBox.Show("Clipboard Import Error Contains @" + vbCr + """" + _Row + """", "Contains Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Next
        End If
        Return _Output
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
End Module
