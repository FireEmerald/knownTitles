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
        Me.btnWhichTitle = New System.Windows.Forms.Button()
        Me.tbPlayerOutput = New System.Windows.Forms.TextBox()
        Me.cbDebug = New System.Windows.Forms.CheckBox()
        Me.clbBannedAddedTitel = New System.Windows.Forms.CheckedListBox()
        Me.gbBannedAddedTitels = New System.Windows.Forms.GroupBox()
        Me.gbPlayerInput = New System.Windows.Forms.GroupBox()
        Me.btnImportFromClipboard = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbInlineReport = New System.Windows.Forms.CheckBox()
        Me.gbOptions = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.btnSQLQueryPath = New System.Windows.Forms.Button()
        Me.btnLogfilePath = New System.Windows.Forms.Button()
        Me.tbSQLQueryPath = New System.Windows.Forms.TextBox()
        Me.tbLogfilePath = New System.Windows.Forms.TextBox()
        Me.cbExtendedTitles = New System.Windows.Forms.CheckBox()
        Me.cbGenerateSQLQuery = New System.Windows.Forms.CheckBox()
        Me.cbLogToHarddrive = New System.Windows.Forms.CheckBox()
        Me.gbOutput = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.tsMain = New System.Windows.Forms.StatusStrip()
        Me.tsPbStatusPercent = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsSlStatusPercent = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsSlStatusText = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gbBannedAddedTitels.SuspendLayout()
        Me.gbPlayerInput.SuspendLayout()
        Me.gbOptions.SuspendLayout()
        Me.gbOutput.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbPlayerInput
        '
        Me.tbPlayerInput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbPlayerInput.Location = New System.Drawing.Point(6, 19)
        Me.tbPlayerInput.MaxLength = 32767999
        Me.tbPlayerInput.Multiline = True
        Me.tbPlayerInput.Name = "tbPlayerInput"
        Me.tbPlayerInput.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbPlayerInput.Size = New System.Drawing.Size(340, 187)
        Me.tbPlayerInput.TabIndex = 6
        Me.tbPlayerInput.Text = "1234 1 Roki 0 192 0 0 0 0" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5678 2 Loki 0 224 0 0 0 0"
        Me.tbPlayerInput.WordWrap = False
        '
        'btnWhichTitle
        '
        Me.btnWhichTitle.Location = New System.Drawing.Point(12, 634)
        Me.btnWhichTitle.Name = "btnWhichTitle"
        Me.btnWhichTitle.Size = New System.Drawing.Size(174, 23)
        Me.btnWhichTitle.TabIndex = 7
        Me.btnWhichTitle.Text = "Which Title does He/She has?"
        Me.btnWhichTitle.UseVisualStyleBackColor = True
        '
        'tbPlayerOutput
        '
        Me.tbPlayerOutput.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.tbPlayerOutput.Location = New System.Drawing.Point(6, 19)
        Me.tbPlayerOutput.MaxLength = 327679999
        Me.tbPlayerOutput.Multiline = True
        Me.tbPlayerOutput.Name = "tbPlayerOutput"
        Me.tbPlayerOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbPlayerOutput.Size = New System.Drawing.Size(1056, 328)
        Me.tbPlayerOutput.TabIndex = 9
        '
        'cbDebug
        '
        Me.cbDebug.AutoSize = True
        Me.cbDebug.Location = New System.Drawing.Point(6, 41)
        Me.cbDebug.Name = "cbDebug"
        Me.cbDebug.Size = New System.Drawing.Size(124, 17)
        Me.cbDebug.TabIndex = 13
        Me.cbDebug.Text = "Enable Debug Mode"
        Me.cbDebug.UseVisualStyleBackColor = True
        '
        'clbBannedAddedTitel
        '
        Me.clbBannedAddedTitel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbBannedAddedTitel.FormattingEnabled = True
        Me.clbBannedAddedTitel.HorizontalScrollbar = True
        Me.clbBannedAddedTitel.Items.AddRange(New Object() {"INT: 0 | BIT: 2 | TitleID: 1 | Title: Private %s", "INT: 0 | BIT: 4 | TitleID: 2 | Title: Corporal %s", "INT: 0 | BIT: 8 | TitleID: 3 | Title: Sergeant %s", "INT: 0 | BIT: 16 | TitleID: 4 | Title: Master Sergeant %s", "INT: 0 | BIT: 32 | TitleID: 5 | Title: Sergeant Major %s", "INT: 0 | BIT: 64 | TitleID: 6 | Title: Knight %s", "INT: 0 | BIT: 128 | TitleID: 7 | Title: Knight-Lieutenant %s", "INT: 0 | BIT: 256 | TitleID: 8 | Title: Knight-Captain %s", "INT: 0 | BIT: 512 | TitleID: 9 | Title: Knight-Champion %s", "INT: 0 | BIT: 1024 | TitleID: 10 | Title: Lieutenant Commander %s", "INT: 0 | BIT: 2048 | TitleID: 11 | Title: Commander %s", "INT: 0 | BIT: 4096 | TitleID: 12 | Title: Marshal %s", "INT: 0 | BIT: 8192 | TitleID: 13 | Title: Field Marshal %s", "INT: 0 | BIT: 16384 | TitleID: 14 | Title: Grand Marshal %s", "INT: 0 | BIT: 32768 | TitleID: 15 | Title: Scout %s", "INT: 0 | BIT: 65536 | TitleID: 16 | Title: Grunt %s", "INT: 1 | BIT: 131072 | TitleID: 17 | Title: Sergeant %s", "INT: 1 | BIT: 262144 | TitleID: 18 | Title: Senior Sergeant %s", "INT: 1 | BIT: 524288 | TitleID: 19 | Title: First Sergeant %s", "INT: 1 | BIT: 1048576 | TitleID: 20 | Title: Stone Guard %s", "INT: 1 | BIT: 2097152 | TitleID: 21 | Title: Blood Guard %s", "INT: 1 | BIT: 4194304 | TitleID: 22 | Title: Legionnaire %s", "INT: 1 | BIT: 8388608 | TitleID: 23 | Title: Centurion %s", "INT: 1 | BIT: 16777216 | TitleID: 24 | Title: Champion %s", "INT: 1 | BIT: 33554432 | TitleID: 25 | Title: Lieutenant General %s", "INT: 1 | BIT: 67108864 | TitleID: 26 | Title: General %s", "INT: 1 | BIT: 134217728 | TitleID: 27 | Title: Warlord %s", "INT: 1 | BIT: 268435456 | TitleID: 28 | Title: High Warlord %s", "INT: 1 | BIT: 536870912 | TitleID: 42 | Title: Gladiator %s", "INT: 1 | BIT: 1073741824 | TitleID: 43 | Title: Duelist %s", "INT: 1 | BIT: 2147483648 | TitleID: 44 | Title: Rival %s", "INT: 1 | BIT: 1 | TitleID: 45 | Title: Challenger %s", "INT: 1 | BIT: 2 | TitleID: 46 | Title: Scarab Lord %s", "INT: 1 | BIT: 4 | TitleID: 47 | Title: Conqueror %s", "INT: 1 | BIT: 8 | TitleID: 48 | Title: Justicar %s", "INT: 1 | BIT: 16 | TitleID: 53 | Title: %s, Champion of the Naaru", "INT: 1 | BIT: 32 | TitleID: 62 | Title: Merciless Gladiator %s", "INT: 1 | BIT: 64 | TitleID: 63 | Title: %s of the Shattered Sun", "INT: 1 | BIT: 128 | TitleID: 64 | Title: %s, Hand of A'dal", "INT: 1 | BIT: 256 | TitleID: 71 | Title: Vengeful Gladiator %s", "INT: 1 | BIT: 512 | TitleID: 72 | Title: Battlemaster %s", "INT: 1 | BIT: 2048 | TitleID: 74 | Title: Elder %s", "INT: 1 | BIT: 4096 | TitleID: 75 | Title: Flame Warden %s", "INT: 1 | BIT: 8192 | TitleID: 76 | Title: Flame Keeper %s", "INT: 1 | BIT: 16384 | TitleID: 77 | Title: %s the Exalted", "INT: 1 | BIT: 32768 | TitleID: 78 | Title: %s the Explorer", "INT: 2 | BIT: 65536 | TitleID: 79 | Title: %s the Diplomat", "INT: 2 | BIT: 131072 | TitleID: 80 | Title: Brutal Gladiator %s", "INT: 1 | BIT: 1024 | TitleID: 81 | Title:  %s the Seeker", "INT: 2 | BIT: 262144 | TitleID: 82 | Title: Arena Master %s", "INT: 2 | BIT: 524288 | TitleID: 83 | Title: Salty %s", "INT: 2 | BIT: 1048576 | TitleID: 84 | Title: Chef %s", "INT: 2 | BIT: 2097152 | TitleID: 85 | Title: %s the Supreme", "INT: 2 | BIT: 4194304 | TitleID: 86 | Title: %s of the Ten Storms", "INT: 2 | BIT: 8388608 | TitleID: 87 | Title: %s of the Emerald Dream", "INT: 2 | BIT: 33554432 | TitleID: 89 | Title: Prophet %s", "INT: 2 | BIT: 67108864 | TitleID: 90 | Title: %s the Malefic", "INT: 2 | BIT: 134217728 | TitleID: 91 | Title: Stalker %s", "INT: 2 | BIT: 268435456 | TitleID: 92 | Title: %s of the Ebon Blade", "INT: 2 | BIT: 536870912 | TitleID: 93 | Title: Archmage %s", "INT: 2 | BIT: 1073741824 | TitleID: 94 | Title: Warbringer %s", "INT: 2 | BIT: 2147483648 | TitleID: 95 | Title: Assassin %s", "INT: 2 | BIT: 1 | TitleID: 96 | Title: Grand Master Alchemist %s", "INT: 2 | BIT: 2 | TitleID: 97 | Title: Grand Master Blacksmith %s", "INT: 2 | BIT: 4 | TitleID: 98 | Title: Iron Chef %s", "INT: 2 | BIT: 8 | TitleID: 99 | Title: Grand Master Enchanter %s", "INT: 2 | BIT: 16 | TitleID: 100 | Title: Grand Master Engineer %s", "INT: 2 | BIT: 32 | TitleID: 101 | Title: Doctor %s", "INT: 2 | BIT: 64 | TitleID: 102 | Title: Grand Master Angler %s", "INT: 2 | BIT: 128 | TitleID: 103 | Title: Grand Master Herbalist %s", "INT: 2 | BIT: 256 | TitleID: 104 | Title: Grand Master Scribe %s", "INT: 2 | BIT: 512 | TitleID: 105 | Title: Grand Master Jewelcrafter %s", "INT: 2 | BIT: 1024 | TitleID: 106 | Title: Grand Master Leatherworker %s", "INT: 2 | BIT: 2048 | TitleID: 107 | Title: Grand Master Miner %s", "INT: 2 | BIT: 4096 | TitleID: 108 | Title: Grand Master Skinner %s", "INT: 2 | BIT: 8192 | TitleID: 109 | Title: Grand Master Tailor %s", "INT: 2 | BIT: 16384 | TitleID: 110 | Title: %s of Quel'Thalas", "INT: 2 | BIT: 32768 | TitleID: 111 | Title: %s of Argus", "INT: 2 | BIT: 65536 | TitleID: 112 | Title: %s of Khaz Modan", "INT: 3 | BIT: 131072 | TitleID: 113 | Title: %s of Gnomeregan", "INT: 3 | BIT: 262144 | TitleID: 114 | Title: %s the Lion Hearted", "INT: 3 | BIT: 524288 | TitleID: 115 | Title: %s, Champion of Elune", "INT: 3 | BIT: 1048576 | TitleID: 116 | Title: %s, Hero of Orgrimmar", "INT: 3 | BIT: 2097152 | TitleID: 117 | Title: Plainsrunner %s", "INT: 3 | BIT: 4194304 | TitleID: 118 | Title: %s of the Darkspear", "INT: 3 | BIT: 8388608 | TitleID: 119 | Title: %s the Forsaken", "INT: 3 | BIT: 16777216 | TitleID: 120 | Title: %s the Magic Seeker", "INT: 3 | BIT: 33554432 | TitleID: 121 | Title: Twilight Vanquisher %s", "INT: 3 | BIT: 67108864 | TitleID: 122 | Title: %s, Conqueror of Naxxramas", "INT: 3 | BIT: 134217728 | TitleID: 123 | Title: %s, Hero of Northrend", "INT: 3 | BIT: 268435456 | TitleID: 124 | Title: %s the Hallowed", "INT: 3 | BIT: 536870912 | TitleID: 125 | Title: Loremaster %s", "INT: 3 | BIT: 1073741824 | TitleID: 126 | Title: %s of the Alliance", "INT: 3 | BIT: 2147483648 | TitleID: 127 | Title: %s of the Horde", "INT: 3 | BIT: 1 | TitleID: 128 | Title: %s the Flawless Victor", "INT: 3 | BIT: 2 | TitleID: 129 | Title: %s, Champion of the Frozen Wastes", "INT: 3 | BIT: 4 | TitleID: 130 | Title: Ambassador %s", "INT: 3 | BIT: 8 | TitleID: 131 | Title: %s the Argent Champion", "INT: 3 | BIT: 16 | TitleID: 132 | Title: %s, Guardian of Cenarius", "INT: 3 | BIT: 32 | TitleID: 133 | Title: Brewmaster %s", "INT: 3 | BIT: 64 | TitleID: 134 | Title: Merrymaker %s", "INT: 3 | BIT: 128 | TitleID: 135 | Title: %s the Love Fool", "INT: 3 | BIT: 256 | TitleID: 137 | Title: Matron %s", "INT: 3 | BIT: 512 | TitleID: 138 | Title: Patron %s", "INT: 3 | BIT: 1024 | TitleID: 139 | Title: Obsidian Slayer %s", "INT: 3 | BIT: 2048 | TitleID: 140 | Title: %s of the Nightfall", "INT: 3 | BIT: 4096 | TitleID: 141 | Title: %s the Immortal", "INT: 3 | BIT: 8192 | TitleID: 142 | Title: %s the Undying", "INT: 3 | BIT: 16384 | TitleID: 143 | Title: %s Jenkins", "INT: 3 | BIT: 32768 | TitleID: 144 | Title: Bloodsail Admiral %s", "INT: 4 | BIT: 65536 | TitleID: 145 | Title: %s the Insane", "INT: 4 | BIT: 131072 | TitleID: 146 | Title: %s of the Exodar", "INT: 4 | BIT: 262144 | TitleID: 147 | Title: %s of Darnassus", "INT: 4 | BIT: 524288 | TitleID: 148 | Title: %s of Ironforge", "INT: 4 | BIT: 1048576 | TitleID: 149 | Title: %s of Stormwind", "INT: 4 | BIT: 2097152 | TitleID: 150 | Title: %s of Orgrimmar", "INT: 4 | BIT: 4194304 | TitleID: 151 | Title: %s of Sen'jin", "INT: 4 | BIT: 8388608 | TitleID: 152 | Title: %s of Silvermoon", "INT: 4 | BIT: 16777216 | TitleID: 153 | Title: %s of Thunder Bluff", "INT: 4 | BIT: 33554432 | TitleID: 154 | Title: %s of the Undercity", "INT: 4 | BIT: 67108864 | TitleID: 155 | Title: %s the Noble", "INT: 4 | BIT: 134217728 | TitleID: 156 | Title: Crusader %s", "INT: 2 | BIT: 16777216 | TitleID: 157 | Title: Deadly Gladiator %s", "INT: 4 | BIT: 268435456 | TitleID: 158 | Title: %s, Death's Demise", "INT: 4 | BIT: 536870912 | TitleID: 159 | Title: %s the Celestial Defender", "INT: 4 | BIT: 1073741824 | TitleID: 160 | Title: %s, Conqueror of Ulduar", "INT: 4 | BIT: 2147483648 | TitleID: 161 | Title: %s, Champion of Ulduar", "INT: 4 | BIT: 1 | TitleID: 163 | Title: Vanquisher %s", "INT: 4 | BIT: 2 | TitleID: 164 | Title: Starcaller %s", "INT: 4 | BIT: 4 | TitleID: 165 | Title: %s the Astral Walker", "INT: 4 | BIT: 8 | TitleID: 166 | Title: %s, Herald of the Titans", "INT: 4 | BIT: 16 | TitleID: 167 | Title: Furious Gladiator %s", "INT: 4 | BIT: 32 | TitleID: 168 | Title: %s the Pilgrim", "INT: 4 | BIT: 64 | TitleID: 169 | Title: Relentless Gladiator %s", "INT: 4 | BIT: 128 | TitleID: 170 | Title: Grand Crusader %s", "INT: 4 | BIT: 256 | TitleID: 171 | Title: %s the Argent Defender", "INT: 4 | BIT: 512 | TitleID: 172 | Title: %s the Patient", "INT: 4 | BIT: 1024 | TitleID: 173 | Title: %s the Light of Dawn", "INT: 4 | BIT: 2048 | TitleID: 174 | Title: %s, Bane of the Fallen King", "INT: 4 | BIT: 4096 | TitleID: 175 | Title: %s the Kingslayer", "INT: 4 | BIT: 8192 | TitleID: 176 | Title: %s of the Ashen Verdict", "INT: 4 | BIT: 16384 | TitleID: 177 | Title: Wrathful Gladiator %s"})
        Me.clbBannedAddedTitel.Location = New System.Drawing.Point(6, 19)
        Me.clbBannedAddedTitel.Name = "clbBannedAddedTitel"
        Me.clbBannedAddedTitel.ScrollAlwaysVisible = True
        Me.clbBannedAddedTitel.Size = New System.Drawing.Size(390, 180)
        Me.clbBannedAddedTitel.TabIndex = 14
        '
        'gbBannedAddedTitels
        '
        Me.gbBannedAddedTitels.Controls.Add(Me.clbBannedAddedTitel)
        Me.gbBannedAddedTitels.ForeColor = System.Drawing.Color.Navy
        Me.gbBannedAddedTitels.Location = New System.Drawing.Point(12, 12)
        Me.gbBannedAddedTitels.Name = "gbBannedAddedTitels"
        Me.gbBannedAddedTitels.Size = New System.Drawing.Size(402, 215)
        Me.gbBannedAddedTitels.TabIndex = 15
        Me.gbBannedAddedTitels.TabStop = False
        Me.gbBannedAddedTitels.Text = "Banned / Added Titels Input"
        '
        'gbPlayerInput
        '
        Me.gbPlayerInput.Controls.Add(Me.tbPlayerInput)
        Me.gbPlayerInput.ForeColor = System.Drawing.Color.Navy
        Me.gbPlayerInput.Location = New System.Drawing.Point(420, 12)
        Me.gbPlayerInput.Name = "gbPlayerInput"
        Me.gbPlayerInput.Size = New System.Drawing.Size(352, 215)
        Me.gbPlayerInput.TabIndex = 16
        Me.gbPlayerInput.TabStop = False
        Me.gbPlayerInput.Text = "Player Input (GUID ACCOUNT NAME X X X X X X)"
        '
        'btnImportFromClipboard
        '
        Me.btnImportFromClipboard.Location = New System.Drawing.Point(641, 246)
        Me.btnImportFromClipboard.Name = "btnImportFromClipboard"
        Me.btnImportFromClipboard.Size = New System.Drawing.Size(125, 23)
        Me.btnImportFromClipboard.TabIndex = 17
        Me.btnImportFromClipboard.Text = "Import from Clipboard"
        Me.btnImportFromClipboard.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(268, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(498, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "INSERT INTO `characters` (`guid`, `account`, `name`, `knownTitles`) VALUES (1, 1," & _
    " 'ABC', '0 0 0 0 0 0 ');"
        '
        'cbInlineReport
        '
        Me.cbInlineReport.AutoSize = True
        Me.cbInlineReport.Location = New System.Drawing.Point(6, 64)
        Me.cbInlineReport.Name = "cbInlineReport"
        Me.cbInlineReport.Size = New System.Drawing.Size(127, 17)
        Me.cbInlineReport.TabIndex = 19
        Me.cbInlineReport.Text = "Enable Inline Reports"
        Me.cbInlineReport.UseVisualStyleBackColor = True
        '
        'gbOptions
        '
        Me.gbOptions.Controls.Add(Me.CheckBox1)
        Me.gbOptions.Controls.Add(Me.btnSQLQueryPath)
        Me.gbOptions.Controls.Add(Me.btnLogfilePath)
        Me.gbOptions.Controls.Add(Me.tbSQLQueryPath)
        Me.gbOptions.Controls.Add(Me.tbLogfilePath)
        Me.gbOptions.Controls.Add(Me.cbExtendedTitles)
        Me.gbOptions.Controls.Add(Me.cbGenerateSQLQuery)
        Me.gbOptions.Controls.Add(Me.cbLogToHarddrive)
        Me.gbOptions.Controls.Add(Me.cbInlineReport)
        Me.gbOptions.Controls.Add(Me.cbDebug)
        Me.gbOptions.ForeColor = System.Drawing.Color.Navy
        Me.gbOptions.Location = New System.Drawing.Point(778, 12)
        Me.gbOptions.Name = "gbOptions"
        Me.gbOptions.Size = New System.Drawing.Size(302, 215)
        Me.gbOptions.TabIndex = 20
        Me.gbOptions.TabStop = False
        Me.gbOptions.Text = "Options"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(6, 185)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(73, 17)
        Me.CheckBox1.TabIndex = 25
        Me.CheckBox1.Text = "Option #1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'btnSQLQueryPath
        '
        Me.btnSQLQueryPath.Location = New System.Drawing.Point(271, 157)
        Me.btnSQLQueryPath.Name = "btnSQLQueryPath"
        Me.btnSQLQueryPath.Size = New System.Drawing.Size(25, 23)
        Me.btnSQLQueryPath.TabIndex = 26
        Me.btnSQLQueryPath.Text = "..."
        Me.btnSQLQueryPath.UseVisualStyleBackColor = True
        '
        'btnLogfilePath
        '
        Me.btnLogfilePath.Location = New System.Drawing.Point(271, 108)
        Me.btnLogfilePath.Name = "btnLogfilePath"
        Me.btnLogfilePath.Size = New System.Drawing.Size(25, 23)
        Me.btnLogfilePath.TabIndex = 24
        Me.btnLogfilePath.Text = "..."
        Me.btnLogfilePath.UseVisualStyleBackColor = True
        '
        'tbSQLQueryPath
        '
        Me.tbSQLQueryPath.Location = New System.Drawing.Point(6, 159)
        Me.tbSQLQueryPath.Name = "tbSQLQueryPath"
        Me.tbSQLQueryPath.Size = New System.Drawing.Size(259, 20)
        Me.tbSQLQueryPath.TabIndex = 27
        '
        'tbLogfilePath
        '
        Me.tbLogfilePath.Location = New System.Drawing.Point(6, 110)
        Me.tbLogfilePath.Name = "tbLogfilePath"
        Me.tbLogfilePath.Size = New System.Drawing.Size(259, 20)
        Me.tbLogfilePath.TabIndex = 25
        '
        'cbExtendedTitles
        '
        Me.cbExtendedTitles.AutoSize = True
        Me.cbExtendedTitles.Location = New System.Drawing.Point(6, 18)
        Me.cbExtendedTitles.Name = "cbExtendedTitles"
        Me.cbExtendedTitles.Size = New System.Drawing.Size(135, 17)
        Me.cbExtendedTitles.TabIndex = 24
        Me.cbExtendedTitles.Text = "Enable Extended Titels"
        Me.cbExtendedTitles.UseVisualStyleBackColor = True
        '
        'cbGenerateSQLQuery
        '
        Me.cbGenerateSQLQuery.AutoSize = True
        Me.cbGenerateSQLQuery.Location = New System.Drawing.Point(6, 136)
        Me.cbGenerateSQLQuery.Name = "cbGenerateSQLQuery"
        Me.cbGenerateSQLQuery.Size = New System.Drawing.Size(161, 17)
        Me.cbGenerateSQLQuery.TabIndex = 21
        Me.cbGenerateSQLQuery.Text = "Enable Generate SQL Query"
        Me.cbGenerateSQLQuery.UseVisualStyleBackColor = True
        '
        'cbLogToHarddrive
        '
        Me.cbLogToHarddrive.AutoSize = True
        Me.cbLogToHarddrive.Location = New System.Drawing.Point(6, 87)
        Me.cbLogToHarddrive.Name = "cbLogToHarddrive"
        Me.cbLogToHarddrive.Size = New System.Drawing.Size(182, 17)
        Me.cbLogToHarddrive.TabIndex = 20
        Me.cbLogToHarddrive.Text = "Enable Save Logfile to Harddrive"
        Me.cbLogToHarddrive.UseVisualStyleBackColor = True
        '
        'gbOutput
        '
        Me.gbOutput.Controls.Add(Me.tbPlayerOutput)
        Me.gbOutput.ForeColor = System.Drawing.Color.Navy
        Me.gbOutput.Location = New System.Drawing.Point(12, 275)
        Me.gbOutput.Name = "gbOutput"
        Me.gbOutput.Size = New System.Drawing.Size(1068, 353)
        Me.gbOutput.TabIndex = 21
        Me.gbOutput.TabStop = False
        Me.gbOutput.Text = "Output | Log"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(945, 634)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(135, 23)
        Me.btnAdd.TabIndex = 22
        Me.btnAdd.Text = "Add selected Titels"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(804, 634)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(135, 23)
        Me.btnRemove.TabIndex = 23
        Me.btnRemove.Text = "Remove selected Titels"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'tsMain
        '
        Me.tsMain.BackColor = System.Drawing.Color.White
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsPbStatusPercent, Me.tsSlStatusPercent, Me.tsSlStatusText})
        Me.tsMain.Location = New System.Drawing.Point(0, 662)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(1095, 22)
        Me.tsMain.SizingGrip = False
        Me.tsMain.TabIndex = 24
        Me.tsMain.Text = "StatusStrip1"
        '
        'tsPbStatusPercent
        '
        Me.tsPbStatusPercent.Margin = New System.Windows.Forms.Padding(12, 3, 3, 3)
        Me.tsPbStatusPercent.Name = "tsPbStatusPercent"
        Me.tsPbStatusPercent.Size = New System.Drawing.Size(400, 16)
        '
        'tsSlStatusPercent
        '
        Me.tsSlStatusPercent.Name = "tsSlStatusPercent"
        Me.tsSlStatusPercent.Size = New System.Drawing.Size(41, 17)
        Me.tsSlStatusPercent.Text = "100% |"
        '
        'tsSlStatusText
        '
        Me.tsSlStatusText.Name = "tsSlStatusText"
        Me.tsSlStatusText.Size = New System.Drawing.Size(76, 17)
        Me.tsSlStatusText.Text = "Status: Done."
        '
        'fmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1095, 684)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.gbOutput)
        Me.Controls.Add(Me.gbOptions)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnImportFromClipboard)
        Me.Controls.Add(Me.gbPlayerInput)
        Me.Controls.Add(Me.gbBannedAddedTitels)
        Me.Controls.Add(Me.btnWhichTitle)
        Me.ForeColor = System.Drawing.Color.Navy
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "fmMain"
        Me.Text = "kownTitles"
        Me.gbBannedAddedTitels.ResumeLayout(False)
        Me.gbPlayerInput.ResumeLayout(False)
        Me.gbPlayerInput.PerformLayout()
        Me.gbOptions.ResumeLayout(False)
        Me.gbOptions.PerformLayout()
        Me.gbOutput.ResumeLayout(False)
        Me.gbOutput.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbPlayerInput As System.Windows.Forms.TextBox
    Friend WithEvents btnWhichTitle As System.Windows.Forms.Button
    Friend WithEvents tbPlayerOutput As System.Windows.Forms.TextBox
    Friend WithEvents cbDebug As System.Windows.Forms.CheckBox
    Friend WithEvents clbBannedAddedTitel As System.Windows.Forms.CheckedListBox
    Friend WithEvents gbBannedAddedTitels As System.Windows.Forms.GroupBox
    Friend WithEvents gbPlayerInput As System.Windows.Forms.GroupBox
    Friend WithEvents btnImportFromClipboard As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbInlineReport As System.Windows.Forms.CheckBox
    Friend WithEvents gbOptions As System.Windows.Forms.GroupBox
    Friend WithEvents gbOutput As System.Windows.Forms.GroupBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents cbGenerateSQLQuery As System.Windows.Forms.CheckBox
    Friend WithEvents cbLogToHarddrive As System.Windows.Forms.CheckBox
    Friend WithEvents cbExtendedTitles As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogfilePath As System.Windows.Forms.Button
    Friend WithEvents tbLogfilePath As System.Windows.Forms.TextBox
    Friend WithEvents tsMain As System.Windows.Forms.StatusStrip
    Friend WithEvents tsPbStatusPercent As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents tsSlStatusPercent As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsSlStatusText As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnSQLQueryPath As System.Windows.Forms.Button
    Friend WithEvents tbSQLQueryPath As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

End Class
