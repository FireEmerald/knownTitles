Option Strict On
Option Explicit On

Imports System.Text.RegularExpressions

'// Unterscheidung zwischen Add/Remove/Lookup
Public Enum MainProcessingID As Integer
    PROCESS_LOOKUP = 0
    PROCESS_REMOVE = 1
    PROCESS_ADD = 2
End Enum

Public Structure MainProcessing
    Dim PlayerInput,
        ValidatedPlayerInput As String
    Dim SelectedTitles As List(Of CharTitle)
    Dim ID As MainProcessingID
    Dim Guid As Guid
End Structure

Public Class Cls_Main_Validate

#Region "Deklarationen"
    '// Hauptprozessstruktur mit einem eindeutigen Bezeichner für diesen Task.
    Private _MainProcess As New MainProcessing With {.Guid = Guid.NewGuid}

    '// Events
    Public Event StatusReport(sender As Object, e As EArgs_StatusReport)
    Public Event MainProcess_ValidationCompleted(sender As Object, e As EArgs_ValidationProcessCompleted)
#End Region

#Region "Propertys"
    Public ReadOnly Property P_MainProcess_Guid As Guid
        Get
            Return _MainProcess.Guid
        End Get
    End Property
#End Region

    Sub New(MainProcess As MainProcessing)
        _MainProcess.PlayerInput = MainProcess.PlayerInput
        _MainProcess.ID = MainProcess.ID
    End Sub

    ''' <summary>Überprüft den PlayerInput auf kritische Fehler, die im Prozess selbst nicht geprüft würden und somit zu Abstürzen führen könnten.</summary>
    Public Sub Validate_PlayerInput()
        RaiseEvent StatusReport(Me, New EArgs_StatusReport(0, "Running ...", _MainProcess.Guid))

        Dim _ErrorProcess As New ErrorProcessing With {.ID = ErrorProcessingID.MAIN_PROCESS_VALIDATION,
                                                       .WrongContent = "",
                                                       .WrongCounter = 0}

        _MainProcess.ValidatedPlayerInput = _MainProcess.PlayerInput
        RaiseEvent MainProcess_ValidationCompleted(Me, New EArgs_ValidationProcessCompleted(_MainProcess, _ErrorProcess))
        Return

        Dim _ProgressCounter As Integer = 0

        Dim _SplittedPlayerInput() As String = Regex.Split(_MainProcess.PlayerInput, vbCrLf)

        For _i As Integer = 0 To _SplittedPlayerInput.Count - 1

            If Regex.IsMatch(_SplittedPlayerInput(_i), "^[0-9]+? [0-9]+? [a-z|A-Z]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? [0-9]+? 0$", RegexOptions.None) Then
                _MainProcess.ValidatedPlayerInput += _SplittedPlayerInput(_i)

                '// Verhindern, dass bei der letzten Zeile ein vbCrLf hinzugefügt wird.
                If Not _i = (_SplittedPlayerInput.Count - 1) Then
                    _MainProcess.ValidatedPlayerInput += vbCrLf
                End If

                _ProgressCounter += 1
            Else
                _ErrorProcess.WrongCounter += 1
                _ErrorProcess.WrongContent += ((_i + 1).ToString + ": """ + _SplittedPlayerInput(_i) + """") + vbCrLf
            End If

            '// Statusbar aktualisieren.
            RaiseEvent StatusReport(Me, New EArgs_StatusReport(CInt(((_ProgressCounter + _ErrorProcess.WrongCounter) / _SplittedPlayerInput.Count) * 100), "Validation running... " + (_ProgressCounter + _ErrorProcess.WrongCounter).ToString + " of " + _SplittedPlayerInput.Count.ToString + "  | Syntax error: " + _ErrorProcess.WrongCounter.ToString, _MainProcess.Guid))
        Next

        '// Abschließendes Event
        RaiseEvent MainProcess_ValidationCompleted(Me, New EArgs_ValidationProcessCompleted(_MainProcess, _ErrorProcess))
    End Sub

End Class
