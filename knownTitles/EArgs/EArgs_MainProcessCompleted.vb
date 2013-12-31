Option Explicit On
Option Strict On

Imports System.Text

Public Class EArgs_MainProcessCompleted
    '// Vererbung
    Inherits EventArgs

#Region "Deklarationen"
    '// Der Hauptprozess
    Private _MainProcess As New MainProcessing

    '// Variablen
    Private _SQLUpdateQuery As String
    Private _CheckedCharacterDataList As List(Of Character)
#End Region

    '// Sub New - Was an die Form übergeben werden soll.
    Sub New(SQLUpdateQuery As String, CheckedCharacterDataList As List(Of Character), MainProcess As MainProcessing)
        _SQLUpdateQuery = SQLUpdateQuery
        _CheckedCharacterDataList = CheckedCharacterDataList
        _MainProcess = MainProcess
    End Sub

    '// Propertys
    Public ReadOnly Property GetSQLUpdateQuery As String
        Get
            Return _SQLUpdateQuery
        End Get
    End Property
    Public ReadOnly Property GetCheckedCharacterDataList As List(Of Character)
        Get
            Return _CheckedCharacterDataList
        End Get
    End Property
    Public ReadOnly Property GetMainProcess As MainProcessing
        Get
            Return _MainProcess
        End Get
    End Property

End Class
