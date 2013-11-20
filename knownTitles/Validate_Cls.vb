Option Strict On
Option Explicit On

Imports System.Text.RegularExpressions

#Region "ProcessID's"
Public Enum ProcID As Integer
    PROCESS_LOOKUP = 0
    PROCESS_REMOVE = 1
End Enum
#End Region

Public Class Validate_Cls

#Region "Deklarationen"
    '// Variablen
    Private _PlayerInput As String = ""
    Private _ProcessID As Integer = 0

    '// Events
    Public Event StatusReport(sender As Object, e As StatusReportEArgs)
    Public Event Validate_Completed(_ValidatedPlayerInput As String, _WrongContent As String, _WrongCount As Integer, _Guid As Guid)

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

    Sub New(PlayerInput As String, ProcessID As Integer)
        _PlayerInput = PlayerInput
        _ProcessID = ProcessID
    End Sub

    ''' <summary>Überprüft den PlayerInput auf kritische Fehler, die im Prozess selbst nicht geprüft würden und somit zu Abstürzen führen könnten.</summary>
    Public Sub Validate_PlayerInput()
        RaiseEvent StatusReport(Me, New StatusReportEArgs(0, "Running ...", _Guid))

        Dim _WrongCount As Integer = 0
        Dim _WrongContent As String = ""

        Dim _ProgressCounter As Integer = 0
        Dim _ValidatedPlayerInput As String = ""

        Dim _SplittedPlayerInput() As String = Regex.Split(_PlayerInput, vbCrLf)

        For _i As Integer = 0 To _SplittedPlayerInput.Count - 1

            If Regex.IsMatch(_SplittedPlayerInput(_i), "^[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0$", RegexOptions.None) Then
                _ValidatedPlayerInput += _SplittedPlayerInput(_i) + vbCrLf

                _ProgressCounter += 1
                RaiseEvent StatusReport(Me, New StatusReportEArgs(CInt(((_ProgressCounter + _WrongCount) / _SplittedPlayerInput.Count) * 100), "Running... validation. " + (_ProgressCounter + _WrongCount).ToString + " of " + _SplittedPlayerInput.Count.ToString + "  | Syntax error: " + _WrongCount.ToString, _Guid))
            Else
                _WrongCount += 1


            End If
        Next
    End Sub

End Class
