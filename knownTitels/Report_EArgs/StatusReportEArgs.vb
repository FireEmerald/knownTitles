Option Explicit On
Option Strict On

Public Class StatusReportEArgs
    '// Vererbung
    Inherits EventArgs

    '// Variablen
    Private _StatusMessage As String
    Private _PercentDone As Integer
    Private _Guid As Guid

    '// Sub New - Was an die Form übergeben werden soll.
    Public Sub New(StatusMessage As String, PercentDone As Integer, Guid As Guid)
        _StatusMessage = StatusMessage
        _PercentDone = PercentDone
        _Guid = Guid
    End Sub

    '// Propertys
    Public ReadOnly Property P_StatusMessage As String
        Get
            Return _StatusMessage
        End Get
    End Property
    Public ReadOnly Property P_PercentDone As Integer
        Get
            Return _PercentDone
        End Get
    End Property
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property
End Class
