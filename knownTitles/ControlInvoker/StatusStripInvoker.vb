Option Explicit On
Option Strict On

Public Class StatusStripInvoker
    '// Der Verweis wird als generisches Steuerelement gespeichert, so dass
    '// diese Hilfsklasse in anderen Szenarien wiederverwendet werden kann.
    Private _tsProgressBar As Windows.Forms.ToolStripProgressBar
    Private _tsLabel_Percent,
            _tsLabel_TextStatus As Windows.Forms.ToolStripLabel

    '// Speichert den hinzuzufügenden Text.
    Private _Percent As Integer
    Private _TextStatus As String

    '// Sub New - Element welches geupdated werden soll.
    Sub New(ProgressBar As Windows.Forms.ToolStripProgressBar,
            Label_Percent As Windows.Forms.ToolStripLabel,
            Label_TextStatus As Windows.Forms.ToolStripLabel)

        _tsLabel_Percent = Label_Percent
        _tsLabel_TextStatus = Label_TextStatus
        _tsProgressBar = ProgressBar
    End Sub
    Sub New(ProgressBar As Windows.Forms.ToolStripProgressBar,
            Label_Percent As Windows.Forms.ToolStripLabel)
        _tsLabel_Percent = Label_Percent
        _tsProgressBar = ProgressBar
    End Sub
    Sub New(Label_TextStatus As Windows.Forms.ToolStripLabel)
        _tsLabel_TextStatus = Label_TextStatus
    End Sub


    Public Sub setAll(Percent As Integer, Text As String)
        _TextStatus = Text
        _Percent = Percent

        SyncLock Me
            _tsLabel_TextStatus.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeTextStatus))
            _tsLabel_Percent.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangePercentStatus))
            _tsProgressBar.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeProgressBar))
        End SyncLock
    End Sub
    Public Sub setPercent(Percent As Integer)
        _Percent = Percent

        SyncLock Me
            _tsLabel_Percent.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangePercentStatus))
            _tsProgressBar.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeProgressBar))
        End SyncLock
    End Sub
    Public Sub setText(Text As String)
        _TextStatus = Text

        SyncLock Me
            _tsLabel_TextStatus.GetCurrentParent.Invoke(New MethodInvoker(AddressOf ThreadSafeChangeTextStatus))
        End SyncLock
    End Sub

    Private Sub ThreadSafeChangeProgressBar()
        _tsProgressBar.Value = _Percent
    End Sub
    Private Sub ThreadSafeChangePercentStatus()
        _tsLabel_Percent.Text = _Percent.ToString + " % |"
    End Sub
    Private Sub ThreadSafeChangeTextStatus()
        _tsLabel_TextStatus.Text = _TextStatus
    End Sub

End Class
