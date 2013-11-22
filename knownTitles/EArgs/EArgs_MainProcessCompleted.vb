﻿Option Explicit On
Option Strict On

Imports System.Text

Public Class EArgs_MainProcessCompleted
    '// Vererbung
    Inherits EventArgs

    '// Der Hauptprozess
    Private _MainProcess As New MainProcessing

    '// Variablen
    Private _Log As StringBuilder
    Private _InlineReport As Boolean

    '// Sub New - Was an die Form übergeben werden soll.
    Sub New(Log As StringBuilder, InlineReport As Boolean, MainProcess As MainProcessing)
        _Log = Log
        _InlineReport = InlineReport

        _MainProcess = MainProcess
    End Sub

    '// Propertys
    Public ReadOnly Property P_Log As StringBuilder
        Get
            Return _Log
        End Get
    End Property
    Public ReadOnly Property P_InlineReport As Boolean
        Get
            Return _InlineReport
        End Get
    End Property
    Public ReadOnly Property P_MainProcess As MainProcessing
        Get
            Return _MainProcess
        End Get
    End Property

End Class
