Option Explicit On
Option Strict On

Public Class CompletedReportEArgs
    '// Vererbung
    Inherits EventArgs

    '// Variablen
    Private _Log As String
    Private _InlineReport As Boolean
    Private _Guid As Guid

    '// Sub New - Was an die Form übergeben werden soll.
    Sub New(Log As String, InlineReport As Boolean, Guid As Guid)
        _Log = Log
        _InlineReport = InlineReport
        _Guid = Guid
    End Sub

    '// Propertys
    Public ReadOnly Property P_Log As String
        Get
            Return _Log
        End Get
    End Property
    Public ReadOnly Property P_InlineReport As Boolean
        Get
            Return _InlineReport
        End Get
    End Property
    Public ReadOnly Property P_Guid As Guid
        Get
            Return _Guid
        End Get
    End Property

End Class
