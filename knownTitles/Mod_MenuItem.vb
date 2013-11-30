Module Mod_MenuStrip
    ''' <summary>
    ''' Dieses Modul behandelt ausschließlich jene ToolStripMenuItems, welche eine CheckState besitzen!
    ''' </summary>

    Public Enum CLIPBOARD_SYNTAX
        INSERT_INTO = 0
        ONLY_WITH_SPACES = 1
    End Enum

    ''' <summary>Ändert alle ToolStripMenu Items je nach Ressourcen-Einstellungen.</summary>
    Public Sub SetAllMenuItems_LikeSettings()
        SetClipboardSyntax()
        SetDebugMode()
        SetExtendedTitles()
        SetInlineReports()
        SetLogfileToHDD()
        SetSQLQueryToHDD()
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
                With fmMain
                    SetForeColor_CheckState(Color.Navy, .miSelectSyntax_1)

                    SetForeColor_CheckState(Color.Green, .miSelectSyntax_0)
                End With
            Case CLIPBOARD_SYNTAX.ONLY_WITH_SPACES '// "1 1 ABC 0 0 0 0 0 "
                With fmMain
                    SetForeColor_CheckState(Color.Navy, .miSelectSyntax_0)

                    SetForeColor_CheckState(Color.Green, .miSelectSyntax_1)
                End With
        End Select
    End Sub

    Public Sub SetDebugMode(Optional _SetNewState As Boolean = False)
        If _SetNewState Then
            Select Case fmMain.miSettings_DebugMode.CheckState
                Case CheckState.Checked
                    My.Settings.DebugMode = False
                Case CheckState.Unchecked
                    My.Settings.DebugMode = True
            End Select
            My.Settings.Save()
            My.Settings.Reload()
        End If
        If My.Settings.DebugMode Then
            SetForeColor_CheckState(Color.Green, fmMain.miSettings_DebugMode)
        Else
            SetForeColor_CheckState(Color.Navy, fmMain.miSettings_DebugMode)
        End If
    End Sub

    Public Sub SetExtendedTitles(Optional _SetNewState As Boolean = False)
        If _SetNewState Then
            Select Case fmMain.miSettings_ExtendedTitles.CheckState
                Case CheckState.Checked
                    My.Settings.ExtendedTitles = False
                Case CheckState.Unchecked
                    My.Settings.ExtendedTitles = True
            End Select
            My.Settings.Save()
            My.Settings.Reload()
        End If
        If My.Settings.ExtendedTitles Then
            SetForeColor_CheckState(Color.Green, fmMain.miSettings_ExtendedTitles)
        Else
            SetForeColor_CheckState(Color.Navy, fmMain.miSettings_ExtendedTitles)
        End If
    End Sub

    Public Sub SetInlineReports(Optional _SetNewState As Boolean = False)
        If _SetNewState Then
            Select Case fmMain.miSettings_InlineReports.CheckState
                Case CheckState.Checked
                    My.Settings.InlineReports = False
                Case CheckState.Unchecked
                    My.Settings.InlineReports = True
            End Select
            My.Settings.Save()
            My.Settings.Reload()
        End If
        If My.Settings.InlineReports Then
            SetForeColor_CheckState(Color.Green, fmMain.miSettings_InlineReports)
        Else
            SetForeColor_CheckState(Color.Navy, fmMain.miSettings_InlineReports)
        End If
    End Sub

    Public Sub SetLogfileToHDD(Optional _SetNewState As Boolean = False)
        If _SetNewState Then
            Select Case fmMain.miLogfile_State.CheckState
                Case CheckState.Checked
                    My.Settings.LogfileToHDD = False
                Case CheckState.Unchecked
                    My.Settings.LogfileToHDD = True
            End Select
            My.Settings.Save()
            My.Settings.Reload()
        End If
        If My.Settings.LogfileToHDD Then
            SetForeColor_CheckState(Color.Green, fmMain.miLogfile_State)
        Else
            SetForeColor_CheckState(Color.Navy, fmMain.miLogfile_State)
        End If
    End Sub

    Public Sub SetSQLQueryToHDD(Optional _SetNewState As Boolean = False)
        If _SetNewState Then
            Select Case fmMain.miSQLQuery_State.CheckState
                Case CheckState.Checked
                    My.Settings.SQLQueryToHDD = False
                Case CheckState.Unchecked
                    My.Settings.SQLQueryToHDD = True
            End Select
            My.Settings.Save()
            My.Settings.Reload()
        End If
        If My.Settings.SQLQueryToHDD Then
            SetForeColor_CheckState(Color.Green, fmMain.miSQLQuery_State)
        Else
            SetForeColor_CheckState(Color.Navy, fmMain.miSQLQuery_State)
        End If
    End Sub

    ''' <summary>Ändert die ForeColor eines ToolStrpMenuItem sowie die CheckState.</summary>
    Private Sub SetForeColor_CheckState(_Color As System.Drawing.Color, _MenuItem As System.Windows.Forms.ToolStripMenuItem)
        _MenuItem.ForeColor = _Color
        Select Case _Color
            Case Color.Green
                _MenuItem.CheckState = CheckState.Checked
            Case Color.Navy
                _MenuItem.CheckState = CheckState.Unchecked
        End Select
    End Sub

    ''' <summary>Prüfen ob in einem Hashtabel ein Item enthalten ist.</summary>
    Public Function ThreadIsRunning(_Hashtable As Hashtable) As Boolean
        If _Hashtable.Count = 0 Then Return False
        Return True
    End Function
End Module
