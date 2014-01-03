Option Explicit On
Option Strict On

'// Unterscheidung zwischen Clipboard/Validation
Public Enum ErrorProcessingID
    CLIPBOARD_IMPORT_VALIDATION = 0
    MAIN_PROCESS_VALIDATION = 1
    MAIN_PROCESS_INLINE = 2
End Enum

Public Structure ErrorProcessing
    Dim WrongContent As String
    Dim WrongCounter As Integer
    Dim ID As ErrorProcessingID
End Structure

Public Class EArgs_ValidationProcessCompleted
    '// Vererbung
    Inherits EventArgs

#Region "Deklarationen"
    '// Informationen zu dem Hauptprozess (Add/Remove/Lookup)
    Private _MainProcess As MainProcessing

    '// Informationen zu dem Clipboard Content
    Private _ValidatedClipboardContent As String
    Private _Guid As Guid

    '// Für die Verarbeitung der Fehler bei der Validierung von beiden
    Private _ErrorProcess As New ErrorProcessing
#End Region

    '// Nur für den Hauptprozess (Add/Remove/Lookup)
    Sub New(MainProcess As MainProcessing, ErrorProcess As ErrorProcessing)
        '// Informationen zu dem Hauptprozess.
        _MainProcess = MainProcess
        _Guid = MainProcess.Guid

        '// Für die Fehler bei der Validierung.
        _ErrorProcess.ID = ErrorProcess.ID
        _ErrorProcess.WrongContent = ErrorProcess.WrongContent
        _ErrorProcess.WrongCounter = ErrorProcess.WrongCounter
    End Sub

    '// Nur für den Clipboard Import.
    Sub New(ValidatedClipboardContent As String, ErrorProcess As ErrorProcessing, Guid As Guid)
        '// Informationen zu dem Clipboard Content.
        _ValidatedClipboardContent = ValidatedClipboardContent
        _Guid = Guid

        '// Für die Fehler bei der Validierung.
        _ErrorProcess.ID = ErrorProcess.ID
        _ErrorProcess.WrongContent = ErrorProcess.WrongContent
        _ErrorProcess.WrongCounter = ErrorProcess.WrongCounter
    End Sub

    '// Für beide Abläufe.
    Public ReadOnly Property P_ErrorProcess As ErrorProcessing
        Get
            Return _ErrorProcess
        End Get
    End Property

    '// Nur für den Hauptprozess.
    Public ReadOnly Property P_MainProcess As MainProcessing
        Get
            Return _MainProcess
        End Get
    End Property

    '// Nur für Clipboard Import.
    Public ReadOnly Property P_ValidatedClipboardContent As String
        Get
            Return _ValidatedClipboardContent
        End Get
    End Property
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property
End Class
