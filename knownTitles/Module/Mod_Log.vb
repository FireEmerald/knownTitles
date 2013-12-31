Option Explicit On
Option Strict On

Imports System.Text
Imports System.IO

Public Enum PRÄFIX
    INFO
    DEBUG
End Enum

Module Mod_Log
#Region "Deklarationen"
    '// Speichert den Namen des Logfiles.
    Private _LogfilePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + "\knownTitles.log"
    '// Enthält den kompletten Log.
    Private _Log As New StringBuilder
    '// Der StreamWriter für den Log.
    Private _LogWriter As StreamWriter
#End Region

#Region "Propertys"
    Public ReadOnly Property GetLog As String
        Get
            Return _Log.ToString
        End Get
    End Property
    Public Property Log_LogfilePath As String
        Get
            Return _LogfilePath
        End Get
        Set(value As String)
            _LogfilePath = value
        End Set
    End Property
#End Region

    ''' <summary>Adds a string to the log followed by a new line.</summary>
    Public Sub Log_Msg(_Präfix As PRÄFIX, _Message As String)
        Dim _LogMsg As String = GetSyntax(_Präfix) + _Message
        _Log.AppendLine(_LogMsg)

        If My.Settings.SaveLogfile Then
            _LogWriter = New StreamWriter(_LogfilePath, True, Encoding.UTF8)
            _LogWriter.WriteLine(_LogMsg)
            _LogWriter.Close()
            _LogWriter.Dispose()
        End If
    End Sub

    ''' <summary>Löscht den kompletten Log.</summary>
    Public Sub Log_Clear()
        _Log.Clear()
    End Sub

    ''' <summary>Returns the header präfix for the logsystem.</summary>
    Private Function GetSyntax(_Präfix As PRÄFIX) As String
        Return DateTime.Now.ToString("| yyyy.dd.MM | HH:mm ss | ") + [Enum].GetName(GetType(PRÄFIX), _Präfix) + " | "
    End Function
End Module
