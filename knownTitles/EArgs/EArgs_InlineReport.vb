Option Explicit On
Option Strict On

Public Class EArgs_InlineReport
    '// Vererbung
    Inherits EventArgs

    '// Variablen
    Private _LogMessage As String
    Private _Guid As Guid

    '// Sub New - Was an die Form übergeben werden soll.
    Public Sub New(LogMessage As String, Guid As Guid)
        _LogMessage = LogMessage
        _Guid = Guid
    End Sub

    '// Propertys
    Public ReadOnly Property P_LogMessage As String
        Get
            Return _LogMessage
        End Get
    End Property
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property
End Class
