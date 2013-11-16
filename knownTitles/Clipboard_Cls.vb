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
    Public Event ClipboardImport_Completed(_Content As String, _WrongContent As String, _WrongCount As Integer)

    '// Ein eindeutiger Bezeichner für diesen Task.
    Private _Guid As Guid = Guid.NewGuid()
#End Region


    Sub New(ClipboardContent As String, DebugStatus As Boolean)
        _Debug = DebugStatus
        _ClipboardContent = ClipboardContent
    End Sub

    ''' <summary>Gibt den Text aus der Zwischenablage gekürzt zurück.</summary>
    Public Sub GetDataFromClipboard()
        RaiseEvent StatusReport(Me, New StatusReportEArgs(0, "Running...", _Guid))
        Dim _Content As String = ""
        Dim _WrongCount As Integer = 0
        Dim _WrongContent As String = ""

        '// Wir splitten den Text bei allen vbCrLf und prüfen ob die Syntax passt.
        Dim _ClipboardLines() As String = Split(_ClipboardContent, vbCrLf)

        For _i As Integer = 0 To _ClipboardLines.Count - 1
            If Not _ClipboardLines(_i) = "" Then
                If _ClipboardLines(_i).Contains("INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (") Then
                    Dim _ToCheck As String = Replace(Replace(_ClipboardLines(_i).Substring(76, _ClipboardLines(_i).Length - 80), ",", ""), "'", "")
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
            End If
            RaiseEvent StatusReport(Me, New StatusReportEArgs(CInt(((_i + 1) / _ClipboardLines.Count) * 100), _Guid))
        Next
        '// Das letzte vbCrLf muss nicht gelöscht werden.

        RaiseEvent ClipboardImport_Completed(_Content, _WrongContent, _WrongCount)
    End Sub
End Class
