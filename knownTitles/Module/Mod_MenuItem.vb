Module Mod_MenuStrip
    ''' <summary>
    ''' Dieses Modul behandelt ausschließlich jene ToolStripMenuItems, welche eine CheckState besitzen!
    ''' </summary>

#Region "Deklarationen"
    Public Enum CLIPBOARD_SYNTAX
        INSERT_INTO = 0
        ONLY_WITH_SPACES = 1
    End Enum

    Private _fmMain As fmMain
#End Region

    ''' <summary>Lädt visuell alle ToolStripMenuItems neu, je nach Settings.</summary>
    Public Sub Initialize_LoadAllSettings(winForm As fmMain)
        _fmMain = winForm

        Dim _ToLoad As New List(Of Object)
        With _fmMain
            _ToLoad.Add(.miSettings_DebugMode)
            _ToLoad.Add(.miSettings_ExtendedTitles)
            _ToLoad.Add(.miSettings_Shortcuts)
            _ToLoad.Add(.miSaveLogfile)
            _ToLoad.Add(.miGenerateSQLUpdateQuerys)
        End With
        For Each _MenuItem In _ToLoad
            SetSettings(_MenuItem)
        Next
        SetClipboardSyntax()
    End Sub

    ''' <summary>Syntax des Clipboard Imports ändern.</summary>
    Public Sub SetClipboardSyntax(Optional _SetNewState As Integer = -1)
        If Not _SetNewState = -1 Then
            With My.Settings
                .ClipboardSyntax = _SetNewState
                .Save()
                .Reload()
            End With
        End If
        Select Case My.Settings.ClipboardSyntax
            Case CLIPBOARD_SYNTAX.INSERT_INTO  '// "INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1, 'ABC', '0 0 0 0 0 0 ');"
                With _fmMain
                    SetForeColor_CheckState(.miSelectSyntax_1, False)
                    SetForeColor_CheckState(.miSelectSyntax_0, True)
                End With
            Case CLIPBOARD_SYNTAX.ONLY_WITH_SPACES '// "1 1 ABC 0 0 0 0 0 "
                With _fmMain
                    SetForeColor_CheckState(.miSelectSyntax_0, False)
                    SetForeColor_CheckState(.miSelectSyntax_1, True)
                End With
        End Select
    End Sub

    ''' <summary>Einzelnes MenuItem neu festlegen bzw. laden.</summary>
    Public Sub SetSettings(_sender As Object, Optional _SetNewState As Boolean = False)
        Dim _MenuItem As ToolStripMenuItem = CType(_sender, ToolStripMenuItem)

        Select Case True
            Case _MenuItem Is _fmMain.miSettings_DebugMode
                If _SetNewState Then
                    My.Settings.DebugMode = Not My.Settings.DebugMode
                End If
                SetForeColor_CheckState(_MenuItem, My.Settings.DebugMode)
            Case _MenuItem Is _fmMain.miSettings_ExtendedTitles
                If _SetNewState Then
                    My.Settings.ExtendedView = Not My.Settings.ExtendedView
                End If
                SetForeColor_CheckState(_MenuItem, My.Settings.ExtendedView)
            Case _MenuItem Is _fmMain.miSettings_Shortcuts
                If _SetNewState Then
                    My.Settings.Shortcuts = Not My.Settings.Shortcuts
                End If
                SetForeColor_CheckState(_MenuItem, My.Settings.Shortcuts)
            Case _MenuItem Is _fmMain.miSaveLogfile
                If _SetNewState Then
                    My.Settings.SaveLogfile = Not My.Settings.SaveLogfile
                End If
                SetForeColor_CheckState(_MenuItem, My.Settings.SaveLogfile)
            Case _MenuItem Is _fmMain.miGenerateSQLUpdateQuerys
                If _SetNewState Then
                    My.Settings.SaveSQLQuery = Not My.Settings.SaveSQLQuery
                End If
                SetForeColor_CheckState(_MenuItem, My.Settings.SaveSQLQuery)
        End Select
    End Sub

    ''' <summary>Ändert die ForeColor eines ToolStrpMenuItem sowie die CheckState.</summary>
    Private Sub SetForeColor_CheckState(_MenuItem As ToolStripMenuItem, _Setting As Boolean)
        Select Case _Setting
            Case True
                _MenuItem.CheckState = CheckState.Checked
                _MenuItem.ForeColor = Color.Green
            Case False
                _MenuItem.CheckState = CheckState.Unchecked
                _MenuItem.ForeColor = Color.Navy
        End Select
    End Sub

    ''' <summary>Prüfen ob in einem Hashtabel ein Item enthalten ist.</summary>
    Public Function ThreadIsRunning(_Hashtable As Hashtable) As Boolean
        If _Hashtable.Count = 0 Then Return False
        Return True
    End Function
End Module
