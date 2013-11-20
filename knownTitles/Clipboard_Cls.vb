Option Explicit On
Option Strict On

Imports System.Text.RegularExpressions

Public Class Clipboard_Cls

#Region "Deklarationen"
    '// Variablen
    Private _Debug As Boolean = False
    Private _ClipboardContent As String = ""

    '// Events
    Public Event StatusReport(sender As Object, e As StatusReportEArgs)
    Public Event ClipboardImport_Completed(_Content As String, _WrongContent As String, _WrongCount As Integer, _Guid As Guid)

    '// Ein eindeutiger Bezeichner für diesen Task.
    Private _Guid As Guid = Guid.NewGuid()
#End Region

#Region "Propertys"
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property
#End Region

    Sub New(ClipboardContent As String, DebugStatus As Boolean)
        _Debug = DebugStatus
        _ClipboardContent = ClipboardContent
    End Sub

    ''' <summary>Gibt den Text aus der Zwischenablage je nach Syntax gekürzt zurück.</summary>
    Public Sub GetDataFromClipboard()
        RaiseEvent StatusReport(Me, New StatusReportEArgs(0, "Running...", _Guid))

        Dim _Content As String = ""
        Dim _WrongCount As Integer = 0
        Dim _WrongContent As String = ""

        '// Wir splitten den Text bei allen vbCrLf und prüfen ob die Syntax passt.
        Dim _ClipboardLines() As String = Regex.Split(_ClipboardContent, vbCrLf)

        For _i As Integer = 0 To _ClipboardLines.Count - 1
            If Not _ClipboardLines(_i) = "" Then
                Select Case My.Settings.ClipboardSyntax
                    Case 0  '// "INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1, 'ABC', '0 0 0 0 0 0 ');"
                        If _ClipboardLines(_i).Contains("INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (") Then
                            Dim _ToCheck As String = (_ClipboardLines(_i).Substring(76, _ClipboardLines(_i).Length - 80).Replace(",", "").Replace("'", ""))
                            If Regex.IsMatch(_ToCheck, "[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0", RegexOptions.None) Then
                                _Content += _ToCheck + vbCrLf
                                If _Debug Then MessageBox.Show("Clipboard Line Added: """ + _ToCheck + """")
                            Else
                                _WrongContent += ((_i + 1).ToString + ": """ + _ClipboardLines(_i) + """") + vbCrLf
                                _WrongCount += 1
                            End If
                        Else
                            _WrongContent += ((_i + 1).ToString + ": """ + _ClipboardLines(_i) + """") + vbCrLf
                            _WrongCount += 1
                        End If
                    Case 1 '// "1 1 ABC 0 0 0 0 0 "
                        If Regex.IsMatch(_ClipboardLines(_i), "[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0 ", RegexOptions.None) Then
                            Dim _Checked As String = _ClipboardLines(_i).Substring(0, _ClipboardLines(_i).Length - 2)

                            _Content += _Checked + vbCrLf
                            If _Debug Then MessageBox.Show("Clipboard Line Added: """ + _Checked + """")
                        Else
                            _WrongContent += ((_i + 1).ToString + ": """ + _ClipboardLines(_i) + """") + vbCrLf
                            _WrongCount += 1
                        End If
                End Select
            End If
            RaiseEvent StatusReport(Me, New StatusReportEArgs(CInt(((_i + 1) / _ClipboardLines.Count) * 100), "Running... " + (_i + 1).ToString + " of " + _ClipboardLines.Count.ToString, _Guid))
        Next
        '// Das letzte vbCrLf muss nicht gelöscht werden.

        RaiseEvent ClipboardImport_Completed(_Content, _WrongContent, _WrongCount, _Guid)
    End Sub
End Class
