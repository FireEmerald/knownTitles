<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class fmMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(fmMain))
        Me.tbPlayerInput = New System.Windows.Forms.TextBox()
        Me.btnLookup = New System.Windows.Forms.Button()
        Me.gbSelectedTitles = New System.Windows.Forms.GroupBox()
        Me.dgvSelectedTitles = New System.Windows.Forms.DataGridView()
        Me.gbPlayerInput = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.tsPbStatusPercent = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsSlStatusPercent = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsSlStatusText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.miFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFile_SaveLogfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.miFile_SaveSQLUpdateQuery = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miFile_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImport = New System.Windows.Forms.ToolStripMenuItem()
        Me.miImport_FromClipboard = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSelectSyntax_0 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSelectSyntax_1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSettings = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSettings_ExtendedTitles = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSettings_Shortcuts = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSettings_DebugMode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSaveLogfile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miLogfile_NewPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.miLogfile_Path = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miGenerateSQLUpdateQuerys = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miSQlQuery_NewPath = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSQLQuery_Path = New System.Windows.Forms.ToolStripTextBox()
        Me.miLanguage = New System.Windows.Forms.ToolStripMenuItem()
        Me.miLanguage_ComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.miLanguage_Save = New System.Windows.Forms.ToolStripMenuItem()
        Me.miInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.miInfo_TrinityCoreWiki = New System.Windows.Forms.ToolStripMenuItem()
        Me.miInfo_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.dgvCharacters = New System.Windows.Forms.DataGridView()
        Me.gbResults = New System.Windows.Forms.GroupBox()
        Me.dgvCharacterTitles = New System.Windows.Forms.DataGridView()
        Me.DsResults = New knownTitles.dsResults()
        Me.DsSelectedTitles = New knownTitles.dsSelectedTitles()
        Me.gbSelectedTitles.SuspendLayout()
        CType(Me.dgvSelectedTitles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPlayerInput.SuspendLayout()
        Me.ssMain.SuspendLayout()
        Me.msMain.SuspendLayout()
        CType(Me.dgvCharacters, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbResults.SuspendLayout()
        CType(Me.dgvCharacterTitles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsResults, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DsSelectedTitles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbPlayerInput
        '
        Me.tbPlayerInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbPlayerInput.Location = New System.Drawing.Point(6, 19)
        Me.tbPlayerInput.MaxLength = 999999999
        Me.tbPlayerInput.Multiline = True
        Me.tbPlayerInput.Name = "tbPlayerInput"
        Me.tbPlayerInput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbPlayerInput.Size = New System.Drawing.Size(651, 232)
        Me.tbPlayerInput.TabIndex = 6
        Me.tbPlayerInput.Text = resources.GetString("tbPlayerInput.Text")
        Me.tbPlayerInput.WordWrap = False
        '
        'btnLookup
        '
        Me.btnLookup.Location = New System.Drawing.Point(444, 654)
        Me.btnLookup.Name = "btnLookup"
        Me.btnLookup.Size = New System.Drawing.Size(112, 23)
        Me.btnLookup.TabIndex = 7
        Me.btnLookup.Text = "Lookup"
        Me.btnLookup.UseVisualStyleBackColor = True
        '
        'gbSelectedTitles
        '
        Me.gbSelectedTitles.Controls.Add(Me.dgvSelectedTitles)
        Me.gbSelectedTitles.ForeColor = System.Drawing.Color.Navy
        Me.gbSelectedTitles.Location = New System.Drawing.Point(12, 32)
        Me.gbSelectedTitles.Name = "gbSelectedTitles"
        Me.gbSelectedTitles.Size = New System.Drawing.Size(402, 257)
        Me.gbSelectedTitles.TabIndex = 15
        Me.gbSelectedTitles.TabStop = False
        Me.gbSelectedTitles.Text = "Which title(s) would you like to remove/add?"
        '
        'dgvSelectedTitles
        '
        Me.dgvSelectedTitles.AllowUserToAddRows = False
        Me.dgvSelectedTitles.AllowUserToDeleteRows = False
        Me.dgvSelectedTitles.AllowUserToResizeColumns = False
        Me.dgvSelectedTitles.AllowUserToResizeRows = False
        Me.dgvSelectedTitles.BackgroundColor = System.Drawing.Color.White
        Me.dgvSelectedTitles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSelectedTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSelectedTitles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgvSelectedTitles.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvSelectedTitles.Location = New System.Drawing.Point(6, 19)
        Me.dgvSelectedTitles.Name = "dgvSelectedTitles"
        Me.dgvSelectedTitles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSelectedTitles.Size = New System.Drawing.Size(390, 232)
        Me.dgvSelectedTitles.TabIndex = 27
        '
        'gbPlayerInput
        '
        Me.gbPlayerInput.Controls.Add(Me.tbPlayerInput)
        Me.gbPlayerInput.ForeColor = System.Drawing.Color.Navy
        Me.gbPlayerInput.Location = New System.Drawing.Point(420, 32)
        Me.gbPlayerInput.Name = "gbPlayerInput"
        Me.gbPlayerInput.Size = New System.Drawing.Size(663, 257)
        Me.gbPlayerInput.TabIndex = 16
        Me.gbPlayerInput.TabStop = False
        Me.gbPlayerInput.Text = "GUID, AccountID, Name and knownTitles | One Character each Line."
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(706, 654)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(112, 23)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(824, 654)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(112, 23)
        Me.btnRemove.TabIndex = 23
        Me.btnRemove.Text = "Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'ssMain
        '
        Me.ssMain.BackColor = System.Drawing.Color.White
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPbStatusPercent, Me.tsSlStatusPercent, Me.tsSlStatusText})
        Me.ssMain.Location = New System.Drawing.Point(0, 678)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(1095, 22)
        Me.ssMain.SizingGrip = False
        Me.ssMain.TabIndex = 24
        Me.ssMain.Text = "StatusStrip1"
        '
        'tsPbStatusPercent
        '
        Me.tsPbStatusPercent.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.tsPbStatusPercent.Name = "tsPbStatusPercent"
        Me.tsPbStatusPercent.Size = New System.Drawing.Size(300, 16)
        '
        'tsSlStatusPercent
        '
        Me.tsSlStatusPercent.Name = "tsSlStatusPercent"
        Me.tsSlStatusPercent.Size = New System.Drawing.Size(29, 17)
        Me.tsSlStatusPercent.Text = "0% |"
        '
        'tsSlStatusText
        '
        Me.tsSlStatusText.Name = "tsSlStatusText"
        Me.tsSlStatusText.Size = New System.Drawing.Size(76, 17)
        Me.tsSlStatusText.Text = "Status: Done."
        '
        'msMain
        '
        Me.msMain.BackColor = System.Drawing.Color.White
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFile, Me.miImport, Me.miSettings, Me.miLanguage, Me.miInfo})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(1095, 24)
        Me.msMain.TabIndex = 26
        Me.msMain.Text = "MenuStrip1"
        '
        'miFile
        '
        Me.miFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miFile_SaveLogfile, Me.miFile_SaveSQLUpdateQuery, Me.ToolStripSeparator1, Me.miFile_Exit})
        Me.miFile.ForeColor = System.Drawing.Color.Navy
        Me.miFile.Name = "miFile"
        Me.miFile.Size = New System.Drawing.Size(37, 20)
        Me.miFile.Text = "File"
        '
        'miFile_SaveLogfile
        '
        Me.miFile_SaveLogfile.ForeColor = System.Drawing.Color.Navy
        Me.miFile_SaveLogfile.Name = "miFile_SaveLogfile"
        Me.miFile_SaveLogfile.Size = New System.Drawing.Size(233, 22)
        Me.miFile_SaveLogfile.Text = "Save last Logfile as"
        '
        'miFile_SaveSQLUpdateQuery
        '
        Me.miFile_SaveSQLUpdateQuery.ForeColor = System.Drawing.Color.Navy
        Me.miFile_SaveSQLUpdateQuery.Name = "miFile_SaveSQLUpdateQuery"
        Me.miFile_SaveSQLUpdateQuery.Size = New System.Drawing.Size(233, 22)
        Me.miFile_SaveSQLUpdateQuery.Text = "Save last SQL Update Query as"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(230, 6)
        '
        'miFile_Exit
        '
        Me.miFile_Exit.ForeColor = System.Drawing.Color.Navy
        Me.miFile_Exit.Name = "miFile_Exit"
        Me.miFile_Exit.Size = New System.Drawing.Size(233, 22)
        Me.miFile_Exit.Text = "Exit"
        '
        'miImport
        '
        Me.miImport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miImport_FromClipboard, Me.ToolStripSeparator2, Me.ToolStripMenuItem0})
        Me.miImport.ForeColor = System.Drawing.Color.Navy
        Me.miImport.Name = "miImport"
        Me.miImport.Size = New System.Drawing.Size(55, 20)
        Me.miImport.Text = "Import"
        '
        'miImport_FromClipboard
        '
        Me.miImport_FromClipboard.ForeColor = System.Drawing.Color.Navy
        Me.miImport_FromClipboard.Name = "miImport_FromClipboard"
        Me.miImport_FromClipboard.Size = New System.Drawing.Size(194, 22)
        Me.miImport_FromClipboard.Text = "Import from Clipboard"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(191, 6)
        '
        'ToolStripMenuItem0
        '
        Me.ToolStripMenuItem0.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSelectSyntax_0, Me.miSelectSyntax_1})
        Me.ToolStripMenuItem0.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripMenuItem0.Name = "ToolStripMenuItem0"
        Me.ToolStripMenuItem0.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem0.Text = "Select Syntax"
        '
        'miSelectSyntax_0
        '
        Me.miSelectSyntax_0.ForeColor = System.Drawing.Color.Navy
        Me.miSelectSyntax_0.Name = "miSelectSyntax_0"
        Me.miSelectSyntax_0.Size = New System.Drawing.Size(607, 22)
        Me.miSelectSyntax_0.Text = """INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1" & _
    ", 'ABC', '0 0 0 0 0 0 ');"""
        '
        'miSelectSyntax_1
        '
        Me.miSelectSyntax_1.ForeColor = System.Drawing.Color.Navy
        Me.miSelectSyntax_1.Name = "miSelectSyntax_1"
        Me.miSelectSyntax_1.Size = New System.Drawing.Size(607, 22)
        Me.miSelectSyntax_1.Text = """1 1 ABC 0 0 0 0 0 """
        '
        'miSettings
        '
        Me.miSettings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSettings_ExtendedTitles, Me.miSettings_Shortcuts, Me.miSettings_DebugMode, Me.ToolStripSeparator3, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2})
        Me.miSettings.ForeColor = System.Drawing.Color.Navy
        Me.miSettings.Name = "miSettings"
        Me.miSettings.Size = New System.Drawing.Size(61, 20)
        Me.miSettings.Text = "Settings"
        '
        'miSettings_ExtendedTitles
        '
        Me.miSettings_ExtendedTitles.ForeColor = System.Drawing.Color.Navy
        Me.miSettings_ExtendedTitles.Name = "miSettings_ExtendedTitles"
        Me.miSettings_ExtendedTitles.Size = New System.Drawing.Size(176, 22)
        Me.miSettings_ExtendedTitles.Text = "Extended titles"
        '
        'miSettings_Shortcuts
        '
        Me.miSettings_Shortcuts.ForeColor = System.Drawing.Color.Navy
        Me.miSettings_Shortcuts.Name = "miSettings_Shortcuts"
        Me.miSettings_Shortcuts.Size = New System.Drawing.Size(176, 22)
        Me.miSettings_Shortcuts.Text = "Enable shortcuts"
        '
        'miSettings_DebugMode
        '
        Me.miSettings_DebugMode.ForeColor = System.Drawing.Color.Navy
        Me.miSettings_DebugMode.Name = "miSettings_DebugMode"
        Me.miSettings_DebugMode.Size = New System.Drawing.Size(176, 22)
        Me.miSettings_DebugMode.Text = "Debug mode"
        Me.miSettings_DebugMode.Visible = False
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(173, 6)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSaveLogfile, Me.ToolStripSeparator4, Me.miLogfile_NewPath, Me.miLogfile_Path})
        Me.ToolStripMenuItem1.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem1.Text = "Logfile"
        '
        'miSaveLogfile
        '
        Me.miSaveLogfile.ForeColor = System.Drawing.Color.Navy
        Me.miSaveLogfile.Name = "miSaveLogfile"
        Me.miSaveLogfile.Size = New System.Drawing.Size(320, 22)
        Me.miSaveLogfile.Text = "Generate and save a Logfile"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(317, 6)
        '
        'miLogfile_NewPath
        '
        Me.miLogfile_NewPath.ForeColor = System.Drawing.Color.Navy
        Me.miLogfile_NewPath.Name = "miLogfile_NewPath"
        Me.miLogfile_NewPath.Size = New System.Drawing.Size(320, 22)
        Me.miLogfile_NewPath.Text = "New path ..."
        '
        'miLogfile_Path
        '
        Me.miLogfile_Path.Name = "miLogfile_Path"
        Me.miLogfile_Path.Size = New System.Drawing.Size(260, 23)
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miGenerateSQLUpdateQuerys, Me.ToolStripSeparator5, Me.miSQlQuery_NewPath, Me.miSQLQuery_Path})
        Me.ToolStripMenuItem2.ForeColor = System.Drawing.Color.Navy
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(176, 22)
        Me.ToolStripMenuItem2.Text = "SQL Update Querys"
        '
        'miGenerateSQLUpdateQuerys
        '
        Me.miGenerateSQLUpdateQuerys.ForeColor = System.Drawing.Color.Navy
        Me.miGenerateSQLUpdateQuerys.Name = "miGenerateSQLUpdateQuerys"
        Me.miGenerateSQLUpdateQuerys.Size = New System.Drawing.Size(320, 22)
        Me.miGenerateSQLUpdateQuerys.Text = "Generate and save a SQL Update Query"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(317, 6)
        '
        'miSQlQuery_NewPath
        '
        Me.miSQlQuery_NewPath.ForeColor = System.Drawing.Color.Navy
        Me.miSQlQuery_NewPath.Name = "miSQlQuery_NewPath"
        Me.miSQlQuery_NewPath.Size = New System.Drawing.Size(320, 22)
        Me.miSQlQuery_NewPath.Text = "New path ..."
        '
        'miSQLQuery_Path
        '
        Me.miSQLQuery_Path.Name = "miSQLQuery_Path"
        Me.miSQLQuery_Path.Size = New System.Drawing.Size(260, 23)
        '
        'miLanguage
        '
        Me.miLanguage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miLanguage_ComboBox, Me.miLanguage_Save})
        Me.miLanguage.ForeColor = System.Drawing.Color.Navy
        Me.miLanguage.Name = "miLanguage"
        Me.miLanguage.Size = New System.Drawing.Size(71, 20)
        Me.miLanguage.Text = "Language"
        '
        'miLanguage_ComboBox
        '
        Me.miLanguage_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.miLanguage_ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.miLanguage_ComboBox.ForeColor = System.Drawing.Color.Navy
        Me.miLanguage_ComboBox.Items.AddRange(New Object() {"English", "German"})
        Me.miLanguage_ComboBox.Name = "miLanguage_ComboBox"
        Me.miLanguage_ComboBox.Size = New System.Drawing.Size(121, 23)
        '
        'miLanguage_Save
        '
        Me.miLanguage_Save.ForeColor = System.Drawing.Color.Navy
        Me.miLanguage_Save.Name = "miLanguage_Save"
        Me.miLanguage_Save.Size = New System.Drawing.Size(181, 22)
        Me.miLanguage_Save.Text = "Save"
        '
        'miInfo
        '
        Me.miInfo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miInfo_TrinityCoreWiki, Me.miInfo_About})
        Me.miInfo.ForeColor = System.Drawing.Color.Navy
        Me.miInfo.Name = "miInfo"
        Me.miInfo.Size = New System.Drawing.Size(40, 20)
        Me.miInfo.Text = "Info"
        '
        'miInfo_TrinityCoreWiki
        '
        Me.miInfo_TrinityCoreWiki.ForeColor = System.Drawing.Color.Navy
        Me.miInfo_TrinityCoreWiki.Name = "miInfo_TrinityCoreWiki"
        Me.miInfo_TrinityCoreWiki.Size = New System.Drawing.Size(235, 22)
        Me.miInfo_TrinityCoreWiki.Text = "Trinity Core Wiki | knownTitles"
        '
        'miInfo_About
        '
        Me.miInfo_About.ForeColor = System.Drawing.Color.Navy
        Me.miInfo_About.Name = "miInfo_About"
        Me.miInfo_About.Size = New System.Drawing.Size(235, 22)
        Me.miInfo_About.Text = "About knownTitles"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(562, 654)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(112, 23)
        Me.btnSearch.TabIndex = 27
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(965, 654)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(112, 23)
        Me.btnCancel.TabIndex = 28
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'dgvCharacters
        '
        Me.dgvCharacters.AllowUserToAddRows = False
        Me.dgvCharacters.AllowUserToDeleteRows = False
        Me.dgvCharacters.AllowUserToResizeColumns = False
        Me.dgvCharacters.AllowUserToResizeRows = False
        Me.dgvCharacters.BackgroundColor = System.Drawing.Color.White
        Me.dgvCharacters.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCharacters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharacters.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvCharacters.Location = New System.Drawing.Point(6, 19)
        Me.dgvCharacters.Name = "dgvCharacters"
        Me.dgvCharacters.ReadOnly = True
        Me.dgvCharacters.Size = New System.Drawing.Size(1059, 161)
        Me.dgvCharacters.TabIndex = 29
        '
        'gbResults
        '
        Me.gbResults.Controls.Add(Me.dgvCharacterTitles)
        Me.gbResults.Controls.Add(Me.dgvCharacters)
        Me.gbResults.ForeColor = System.Drawing.Color.Navy
        Me.gbResults.Location = New System.Drawing.Point(12, 295)
        Me.gbResults.Name = "gbResults"
        Me.gbResults.Size = New System.Drawing.Size(1071, 353)
        Me.gbResults.TabIndex = 30
        Me.gbResults.TabStop = False
        Me.gbResults.Text = "Results"
        '
        'dgvCharacterTitles
        '
        Me.dgvCharacterTitles.AllowUserToAddRows = False
        Me.dgvCharacterTitles.AllowUserToDeleteRows = False
        Me.dgvCharacterTitles.AllowUserToResizeColumns = False
        Me.dgvCharacterTitles.AllowUserToResizeRows = False
        Me.dgvCharacterTitles.BackgroundColor = System.Drawing.Color.White
        Me.dgvCharacterTitles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCharacterTitles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCharacterTitles.GridColor = System.Drawing.Color.Gainsboro
        Me.dgvCharacterTitles.Location = New System.Drawing.Point(6, 186)
        Me.dgvCharacterTitles.Name = "dgvCharacterTitles"
        Me.dgvCharacterTitles.ReadOnly = True
        Me.dgvCharacterTitles.Size = New System.Drawing.Size(1059, 161)
        Me.dgvCharacterTitles.TabIndex = 31
        '
        'DsResults
        '
        Me.DsResults.DataSetName = "dsResults"
        Me.DsResults.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DsSelectedTitles
        '
        Me.DsSelectedTitles.DataSetName = "dsSelectedTitles"
        Me.DsSelectedTitles.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1095, 700)
        Me.Controls.Add(Me.gbResults)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.msMain)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.gbPlayerInput)
        Me.Controls.Add(Me.gbSelectedTitles)
        Me.Controls.Add(Me.btnLookup)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msMain
        Me.MaximizeBox = False
        Me.Name = "fmMain"
        Me.Text = "kownTitles | A Tool for the TrinityCore Title System"
        Me.gbSelectedTitles.ResumeLayout(False)
        CType(Me.dgvSelectedTitles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPlayerInput.ResumeLayout(False)
        Me.gbPlayerInput.PerformLayout()
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        CType(Me.dgvCharacters, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbResults.ResumeLayout(False)
        CType(Me.dgvCharacterTitles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsResults, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DsSelectedTitles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbPlayerInput As System.Windows.Forms.TextBox
    Friend WithEvents btnLookup As System.Windows.Forms.Button
    Friend WithEvents gbSelectedTitles As System.Windows.Forms.GroupBox
    Friend WithEvents gbPlayerInput As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsPbStatusPercent As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsSlStatusPercent As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsSlStatusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents miFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miFile_SaveLogfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miLanguage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miLanguage_ComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents miLanguage_Save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miInfo_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSelectSyntax_0 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSelectSyntax_1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvSelectedTitles As System.Windows.Forms.DataGridView
    Friend WithEvents DsSelectedTitles As knownTitles.dsSelectedTitles
    Friend WithEvents miSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSettings_ExtendedTitles As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSettings_DebugMode As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miLogfile_Path As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents miSaveLogfile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSQLQuery_Path As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents miGenerateSQLUpdateQuerys As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miImport_FromClipboard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miLogfile_NewPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSQlQuery_NewPath As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miInfo_TrinityCoreWiki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents miSettings_Shortcuts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents miFile_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dgvCharacters As System.Windows.Forms.DataGridView
    Friend WithEvents gbResults As System.Windows.Forms.GroupBox
    Friend WithEvents dgvCharacterTitles As System.Windows.Forms.DataGridView
    Friend WithEvents DsResults As knownTitles.dsResults
    Friend WithEvents miFile_SaveSQLUpdateQuery As System.Windows.Forms.ToolStripMenuItem

End Class
