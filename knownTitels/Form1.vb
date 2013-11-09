Option Explicit On
Option Strict On

Structure CharTitle
    Dim TitleID As Integer
    Dim UnkRef As Integer
    Dim MaleTitle As String
    Dim FemaleTitle As String
    Dim InGameOrder As Integer
    Dim WhichIntegerRounded As Integer
    Dim BitOfInteger As Integer
    Dim Bit As Int64
End Structure

Structure Character
    Dim GUID As Integer
    Dim Namen As String
    Dim INT_0 As UInteger
    Dim INT_1 As UInteger
    Dim INT_2 As UInteger
    Dim INT_3 As UInteger
    Dim INT_4 As UInteger
    Dim INT_5 As UInteger
    Dim NothingChanged As Boolean
End Structure

Public Class Form1
    Private _Debug As Boolean = False

    Private _1 As New CharTitle With {.TitleID = 1, .UnkRef = 5879, .MaleTitle = "Private %s", .FemaleTitle = "Private %s", .InGameOrder = 1}
    Private _2 As New CharTitle With {.TitleID = 2, .UnkRef = 5880, .MaleTitle = "Corporal %s", .FemaleTitle = "Corporal %s", .InGameOrder = 2}
    Private _3 As New CharTitle With {.TitleID = 3, .UnkRef = 5881, .MaleTitle = "Sergeant %s", .FemaleTitle = "Sergeant %s", .InGameOrder = 3}
    Private _4 As New CharTitle With {.TitleID = 4, .UnkRef = 5882, .MaleTitle = "Master Sergeant %s", .FemaleTitle = "Master Sergeant %s", .InGameOrder = 4}
    Private _5 As New CharTitle With {.TitleID = 5, .UnkRef = 5883, .MaleTitle = "Sergeant Major %s", .FemaleTitle = "Sergeant Major %s", .InGameOrder = 5}
    Private _6 As New CharTitle With {.TitleID = 6, .UnkRef = 5884, .MaleTitle = "Knight %s", .FemaleTitle = "Knight %s", .InGameOrder = 6}
    Private _7 As New CharTitle With {.TitleID = 7, .UnkRef = 5885, .MaleTitle = "Knight-Lieutenant %s", .FemaleTitle = "Knight-Lieutenant %s", .InGameOrder = 7}
    Private _8 As New CharTitle With {.TitleID = 8, .UnkRef = 5886, .MaleTitle = "Knight-Captain %s", .FemaleTitle = "Knight-Captain %s", .InGameOrder = 8}
    Private _9 As New CharTitle With {.TitleID = 9, .UnkRef = 5887, .MaleTitle = "Knight-Champion %s", .FemaleTitle = "Knight-Champion %s", .InGameOrder = 9}
    Private _10 As New CharTitle With {.TitleID = 10, .UnkRef = 5888, .MaleTitle = "Lieutenant Commander %s", .FemaleTitle = "Lieutenant Commander %s", .InGameOrder = 10}
    Private _11 As New CharTitle With {.TitleID = 11, .UnkRef = 5889, .MaleTitle = "Commander %s", .FemaleTitle = "Commander %s", .InGameOrder = 11}
    Private _12 As New CharTitle With {.TitleID = 12, .UnkRef = 5890, .MaleTitle = "Marshal %s", .FemaleTitle = "Marshal %s", .InGameOrder = 12}
    Private _13 As New CharTitle With {.TitleID = 13, .UnkRef = 5891, .MaleTitle = "Field Marshal %s", .FemaleTitle = "Field Marshal %s", .InGameOrder = 13}
    Private _14 As New CharTitle With {.TitleID = 14, .UnkRef = 5892, .MaleTitle = "Grand Marshal %s", .FemaleTitle = "Grand Marshal %s", .InGameOrder = 14}
    Private _15 As New CharTitle With {.TitleID = 15, .UnkRef = 5893, .MaleTitle = "Scout %s", .FemaleTitle = "Scout %s", .InGameOrder = 15}
    Private _16 As New CharTitle With {.TitleID = 16, .UnkRef = 5894, .MaleTitle = "Grunt %s", .FemaleTitle = "Grunt %s", .InGameOrder = 16}
    Private _17 As New CharTitle With {.TitleID = 17, .UnkRef = 5895, .MaleTitle = "Sergeant %s", .FemaleTitle = "Sergeant %s", .InGameOrder = 17}
    Private _18 As New CharTitle With {.TitleID = 18, .UnkRef = 5896, .MaleTitle = "Senior Sergeant %s", .FemaleTitle = "Senior Sergeant %s", .InGameOrder = 18}
    Private _19 As New CharTitle With {.TitleID = 19, .UnkRef = 5897, .MaleTitle = "First Sergeant %s", .FemaleTitle = "First Sergeant %s", .InGameOrder = 19}
    Private _20 As New CharTitle With {.TitleID = 20, .UnkRef = 5898, .MaleTitle = "Stone Guard %s", .FemaleTitle = "Stone Guard %s", .InGameOrder = 20}
    Private _21 As New CharTitle With {.TitleID = 21, .UnkRef = 5899, .MaleTitle = "Blood Guard %s", .FemaleTitle = "Blood Guard %s", .InGameOrder = 21}
    Private _22 As New CharTitle With {.TitleID = 22, .UnkRef = 5900, .MaleTitle = "Legionnaire %s", .FemaleTitle = "Legionnaire %s", .InGameOrder = 22}
    Private _23 As New CharTitle With {.TitleID = 23, .UnkRef = 5901, .MaleTitle = "Centurion %s", .FemaleTitle = "Centurion %s", .InGameOrder = 23}
    Private _24 As New CharTitle With {.TitleID = 24, .UnkRef = 5902, .MaleTitle = "Champion %s", .FemaleTitle = "Champion %s", .InGameOrder = 24}
    Private _25 As New CharTitle With {.TitleID = 25, .UnkRef = 5903, .MaleTitle = "Lieutenant General %s", .FemaleTitle = "Lieutenant General %s", .InGameOrder = 25}
    Private _26 As New CharTitle With {.TitleID = 26, .UnkRef = 5904, .MaleTitle = "General %s", .FemaleTitle = "General %s", .InGameOrder = 26}
    Private _27 As New CharTitle With {.TitleID = 27, .UnkRef = 5905, .MaleTitle = "Warlord %s", .FemaleTitle = "Warlord %s", .InGameOrder = 27}
    Private _28 As New CharTitle With {.TitleID = 28, .UnkRef = 5906, .MaleTitle = "High Warlord %s", .FemaleTitle = "High Warlord %s", .InGameOrder = 28}
    Private _42 As New CharTitle With {.TitleID = 42, .UnkRef = 0, .MaleTitle = "Gladiator %s", .FemaleTitle = "Gladiator %s", .InGameOrder = 29}
    Private _43 As New CharTitle With {.TitleID = 43, .UnkRef = 0, .MaleTitle = "Duelist %s", .FemaleTitle = "Duelist %s", .InGameOrder = 30}
    Private _44 As New CharTitle With {.TitleID = 44, .UnkRef = 0, .MaleTitle = "Rival %s", .FemaleTitle = "Rival %s", .InGameOrder = 31}
    Private _45 As New CharTitle With {.TitleID = 45, .UnkRef = 0, .MaleTitle = "Challenger %s", .FemaleTitle = "Challenger %s", .InGameOrder = 32}
    Private _46 As New CharTitle With {.TitleID = 46, .UnkRef = 6341, .MaleTitle = "Scarab Lord %s", .FemaleTitle = "Scarab Lord %s", .InGameOrder = 33}
    Private _47 As New CharTitle With {.TitleID = 47, .UnkRef = 6407, .MaleTitle = "Conqueror %s", .FemaleTitle = "Conqueror %s", .InGameOrder = 34}
    Private _48 As New CharTitle With {.TitleID = 48, .UnkRef = 6406, .MaleTitle = "Justicar %s", .FemaleTitle = "Justicar %s", .InGameOrder = 35}
    Private _53 As New CharTitle With {.TitleID = 53, .UnkRef = 6686, .MaleTitle = " %s, Champion of the Naaru", .FemaleTitle = " %s, Champion of the Naaru", .InGameOrder = 36}
    Private _62 As New CharTitle With {.TitleID = 62, .UnkRef = 0, .MaleTitle = "Merciless Gladiator %s", .FemaleTitle = "Merciless Gladiator %s", .InGameOrder = 37}
    Private _63 As New CharTitle With {.TitleID = 63, .UnkRef = 6806, .MaleTitle = " %s of the Shattered Sun", .FemaleTitle = " %s of the Shattered Sun", .InGameOrder = 38}
    Private _64 As New CharTitle With {.TitleID = 64, .UnkRef = 6944, .MaleTitle = " %s, Hand of A'dal", .FemaleTitle = " %s, Hand of A'dal", .InGameOrder = 39}
    Private _71 As New CharTitle With {.TitleID = 71, .UnkRef = 0, .MaleTitle = "Vengeful Gladiator %s", .FemaleTitle = "Vengeful Gladiator %s", .InGameOrder = 40}
    Private _72 As New CharTitle With {.TitleID = 72, .UnkRef = 7530, .MaleTitle = "Battlemaster %s", .FemaleTitle = "Battlemaster %s", .InGameOrder = 41}
    Private _74 As New CharTitle With {.TitleID = 74, .UnkRef = 7533, .MaleTitle = "Elder %s", .FemaleTitle = "Elder %s", .InGameOrder = 43}
    Private _75 As New CharTitle With {.TitleID = 75, .UnkRef = 7534, .MaleTitle = "Flame Warden %s", .FemaleTitle = "Flame Warden %s", .InGameOrder = 44}
    Private _76 As New CharTitle With {.TitleID = 76, .UnkRef = 7535, .MaleTitle = "Flame Keeper %s", .FemaleTitle = "Flame Keeper %s", .InGameOrder = 45}
    Private _77 As New CharTitle With {.TitleID = 77, .UnkRef = 7565, .MaleTitle = " %s the Exalted", .FemaleTitle = " %s the Exalted", .InGameOrder = 46}
    Private _78 As New CharTitle With {.TitleID = 78, .UnkRef = 7695, .MaleTitle = " %s the Explorer", .FemaleTitle = " %s the Explorer", .InGameOrder = 47}
    Private _79 As New CharTitle With {.TitleID = 79, .UnkRef = 7748, .MaleTitle = " %s the Diplomat", .FemaleTitle = " %s the Diplomat", .InGameOrder = 48}
    Private _80 As New CharTitle With {.TitleID = 80, .UnkRef = 0, .MaleTitle = "Brutal Gladiator %s", .FemaleTitle = "Brutal Gladiator %s", .InGameOrder = 49}
    Private _81 As New CharTitle With {.TitleID = 81, .UnkRef = 7759, .MaleTitle = " %s the Seeker", .FemaleTitle = " %s the Seeker", .InGameOrder = 42}
    Private _82 As New CharTitle With {.TitleID = 82, .UnkRef = 7749, .MaleTitle = "Arena Master %s", .FemaleTitle = "Arena Master %s", .InGameOrder = 50}
    Private _83 As New CharTitle With {.TitleID = 83, .UnkRef = 7750, .MaleTitle = "Salty %s", .FemaleTitle = "Salty %s", .InGameOrder = 51}
    Private _84 As New CharTitle With {.TitleID = 84, .UnkRef = 7754, .MaleTitle = "Chef %s", .FemaleTitle = "Chef %s", .InGameOrder = 52}
    Private _85 As New CharTitle With {.TitleID = 85, .UnkRef = 0, .MaleTitle = " %s the Supreme", .FemaleTitle = " %s the Supreme", .InGameOrder = 53}
    Private _86 As New CharTitle With {.TitleID = 86, .UnkRef = 0, .MaleTitle = " %s of the Ten Storms", .FemaleTitle = " %s of the Ten Storms", .InGameOrder = 54}
    Private _87 As New CharTitle With {.TitleID = 87, .UnkRef = 0, .MaleTitle = " %s of the Emerald Dream", .FemaleTitle = " %s of the Emerald Dream", .InGameOrder = 55}
    Private _89 As New CharTitle With {.TitleID = 89, .UnkRef = 0, .MaleTitle = "Prophet %s", .FemaleTitle = "Prophet %s", .InGameOrder = 57}
    Private _90 As New CharTitle With {.TitleID = 90, .UnkRef = 0, .MaleTitle = " %s the Malefic", .FemaleTitle = " %s the Malefic", .InGameOrder = 58}
    Private _91 As New CharTitle With {.TitleID = 91, .UnkRef = 0, .MaleTitle = "Stalker %s", .FemaleTitle = "Stalker %s", .InGameOrder = 59}
    Private _92 As New CharTitle With {.TitleID = 92, .UnkRef = 0, .MaleTitle = " %s of the Ebon Blade", .FemaleTitle = " %s of the Ebon Blade", .InGameOrder = 60}
    Private _93 As New CharTitle With {.TitleID = 93, .UnkRef = 0, .MaleTitle = "Archmage %s", .FemaleTitle = "Archmage %s", .InGameOrder = 61}
    Private _94 As New CharTitle With {.TitleID = 94, .UnkRef = 0, .MaleTitle = "Warbringer %s", .FemaleTitle = "Warbringer %s", .InGameOrder = 62}
    Private _95 As New CharTitle With {.TitleID = 95, .UnkRef = 0, .MaleTitle = "Assassin %s", .FemaleTitle = "Assassin %s", .InGameOrder = 63}
    Private _96 As New CharTitle With {.TitleID = 96, .UnkRef = 0, .MaleTitle = "Grand Master Alchemist %s", .FemaleTitle = "Grand Master Alchemist %s", .InGameOrder = 64}
    Private _97 As New CharTitle With {.TitleID = 97, .UnkRef = 0, .MaleTitle = "Grand Master Blacksmith %s", .FemaleTitle = "Grand Master Blacksmith %s", .InGameOrder = 65}
    Private _98 As New CharTitle With {.TitleID = 98, .UnkRef = 0, .MaleTitle = "Iron Chef %s", .FemaleTitle = "Iron Chef %s", .InGameOrder = 66}
    Private _99 As New CharTitle With {.TitleID = 99, .UnkRef = 0, .MaleTitle = "Grand Master Enchanter %s", .FemaleTitle = "Grand Master Enchanter %s", .InGameOrder = 67}
    Private _100 As New CharTitle With {.TitleID = 100, .UnkRef = 0, .MaleTitle = "Grand Master Engineer %s", .FemaleTitle = "Grand Master Engineer %s", .InGameOrder = 68}
    Private _101 As New CharTitle With {.TitleID = 101, .UnkRef = 0, .MaleTitle = "Doctor %s", .FemaleTitle = "Doctor %s", .InGameOrder = 69}
    Private _102 As New CharTitle With {.TitleID = 102, .UnkRef = 0, .MaleTitle = "Grand Master Angler %s", .FemaleTitle = "Grand Master Angler %s", .InGameOrder = 70}
    Private _103 As New CharTitle With {.TitleID = 103, .UnkRef = 0, .MaleTitle = "Grand Master Herbalist %s", .FemaleTitle = "Grand Master Herbalist %s", .InGameOrder = 71}
    Private _104 As New CharTitle With {.TitleID = 104, .UnkRef = 0, .MaleTitle = "Grand Master Scribe %s", .FemaleTitle = "Grand Master Scribe %s", .InGameOrder = 72}
    Private _105 As New CharTitle With {.TitleID = 105, .UnkRef = 0, .MaleTitle = "Grand Master Jewelcrafter %s", .FemaleTitle = "Grand Master Jewelcrafter %s", .InGameOrder = 73}
    Private _106 As New CharTitle With {.TitleID = 106, .UnkRef = 0, .MaleTitle = "Grand Master Leatherworker %s", .FemaleTitle = "Grand Master Leatherworker %s", .InGameOrder = 74}
    Private _107 As New CharTitle With {.TitleID = 107, .UnkRef = 0, .MaleTitle = "Grand Master Miner %s", .FemaleTitle = "Grand Master Miner %s", .InGameOrder = 75}
    Private _108 As New CharTitle With {.TitleID = 108, .UnkRef = 0, .MaleTitle = "Grand Master Skinner %s", .FemaleTitle = "Grand Master Skinner %s", .InGameOrder = 76}
    Private _109 As New CharTitle With {.TitleID = 109, .UnkRef = 0, .MaleTitle = "Grand Master Tailor %s", .FemaleTitle = "Grand Master Tailor %s", .InGameOrder = 77}
    Private _110 As New CharTitle With {.TitleID = 110, .UnkRef = 0, .MaleTitle = " %s of Quel'Thalas", .FemaleTitle = " %s of Quel'Thalas", .InGameOrder = 78}
    Private _111 As New CharTitle With {.TitleID = 111, .UnkRef = 0, .MaleTitle = " %s of Argus", .FemaleTitle = " %s of Argus", .InGameOrder = 79}
    Private _112 As New CharTitle With {.TitleID = 112, .UnkRef = 0, .MaleTitle = " %s of Khaz Modan", .FemaleTitle = " %s of Khaz Modan", .InGameOrder = 80}
    Private _113 As New CharTitle With {.TitleID = 113, .UnkRef = 8236, .MaleTitle = " %s of Gnomeregan", .FemaleTitle = " %s of Gnomeregan", .InGameOrder = 81}
    Private _114 As New CharTitle With {.TitleID = 114, .UnkRef = 0, .MaleTitle = " %s the Lion Hearted", .FemaleTitle = " %s the Lion Hearted", .InGameOrder = 82}
    Private _115 As New CharTitle With {.TitleID = 115, .UnkRef = 0, .MaleTitle = " %s, Champion of Elune", .FemaleTitle = " %s, Champion of Elune", .InGameOrder = 83}
    Private _116 As New CharTitle With {.TitleID = 116, .UnkRef = 0, .MaleTitle = " %s, Hero of Orgrimmar", .FemaleTitle = " %s, Hero of Orgrimmar", .InGameOrder = 84}
    Private _117 As New CharTitle With {.TitleID = 117, .UnkRef = 0, .MaleTitle = "Plainsrunner %s", .FemaleTitle = "Plainsrunner %s", .InGameOrder = 85}
    Private _118 As New CharTitle With {.TitleID = 118, .UnkRef = 0, .MaleTitle = " %s of the Darkspear", .FemaleTitle = " %s of the Darkspear", .InGameOrder = 86}
    Private _119 As New CharTitle With {.TitleID = 119, .UnkRef = 0, .MaleTitle = " %s the Forsaken", .FemaleTitle = " %s the Forsaken", .InGameOrder = 87}
    Private _120 As New CharTitle With {.TitleID = 120, .UnkRef = 7812, .MaleTitle = " %s the Magic Seeker", .FemaleTitle = " %s the Magic Seeker", .InGameOrder = 88}
    Private _121 As New CharTitle With {.TitleID = 121, .UnkRef = 7813, .MaleTitle = "Twilight Vanquisher %s", .FemaleTitle = "Twilight Vanquisher %s", .InGameOrder = 89}
    Private _122 As New CharTitle With {.TitleID = 122, .UnkRef = 7814, .MaleTitle = " %s, Conqueror of Naxxramas", .FemaleTitle = " %s, Conqueror of Naxxramas", .InGameOrder = 90}
    Private _123 As New CharTitle With {.TitleID = 123, .UnkRef = 7815, .MaleTitle = " %s, Hero of Northrend", .FemaleTitle = " %s, Hero of Northrend", .InGameOrder = 91}
    Private _124 As New CharTitle With {.TitleID = 124, .UnkRef = 7820, .MaleTitle = " %s the Hallowed", .FemaleTitle = " %s the Hallowed", .InGameOrder = 92}
    Private _125 As New CharTitle With {.TitleID = 125, .UnkRef = 7849, .MaleTitle = "Loremaster %s", .FemaleTitle = "Loremaster %s", .InGameOrder = 93}
    Private _126 As New CharTitle With {.TitleID = 126, .UnkRef = 7853, .MaleTitle = " %s of the Alliance", .FemaleTitle = " %s of the Alliance", .InGameOrder = 94}
    Private _127 As New CharTitle With {.TitleID = 127, .UnkRef = 7854, .MaleTitle = " %s of the Horde", .FemaleTitle = " %s of the Horde", .InGameOrder = 95}
    Private _128 As New CharTitle With {.TitleID = 128, .UnkRef = 7856, .MaleTitle = " %s the Flawless Victor", .FemaleTitle = " %s the Flawless Victor", .InGameOrder = 96}
    Private _129 As New CharTitle With {.TitleID = 129, .UnkRef = 7857, .MaleTitle = " %s, Champion of the Frozen Wastes", .FemaleTitle = " %s, Champion of the Frozen Wastes", .InGameOrder = 97}
    Private _130 As New CharTitle With {.TitleID = 130, .UnkRef = 7858, .MaleTitle = "Ambassador %s", .FemaleTitle = "Ambassador %s", .InGameOrder = 98}
    Private _131 As New CharTitle With {.TitleID = 131, .UnkRef = 7859, .MaleTitle = " %s the Argent Champion", .FemaleTitle = " %s the Argent Champion", .InGameOrder = 99}
    Private _132 As New CharTitle With {.TitleID = 132, .UnkRef = 7860, .MaleTitle = " %s, Guardian of Cenarius", .FemaleTitle = " %s, Guardian of Cenarius", .InGameOrder = 100}
    Private _133 As New CharTitle With {.TitleID = 133, .UnkRef = 7861, .MaleTitle = "Brewmaster %s", .FemaleTitle = "Brewmaster %s", .InGameOrder = 101}
    Private _134 As New CharTitle With {.TitleID = 134, .UnkRef = 7864, .MaleTitle = "Merrymaker %s", .FemaleTitle = "Merrymaker %s", .InGameOrder = 102}
    Private _135 As New CharTitle With {.TitleID = 135, .UnkRef = 7875, .MaleTitle = " %s the Love Fool", .FemaleTitle = " %s the Love Fool", .InGameOrder = 103}
    Private _137 As New CharTitle With {.TitleID = 137, .UnkRef = 7893, .MaleTitle = "Matron %s", .FemaleTitle = "Matron %s", .InGameOrder = 104}
    Private _138 As New CharTitle With {.TitleID = 138, .UnkRef = 7894, .MaleTitle = "Patron %s", .FemaleTitle = "Patron %s", .InGameOrder = 105}
    Private _139 As New CharTitle With {.TitleID = 139, .UnkRef = 7964, .MaleTitle = "Obsidian Slayer %s", .FemaleTitle = "Obsidian Slayer %s", .InGameOrder = 106}
    Private _140 As New CharTitle With {.TitleID = 140, .UnkRef = 7965, .MaleTitle = " %s of the Nightfall", .FemaleTitle = " %s of the Nightfall", .InGameOrder = 107}
    Private _141 As New CharTitle With {.TitleID = 141, .UnkRef = 7990, .MaleTitle = " %s the Immortal", .FemaleTitle = " %s the Immortal", .InGameOrder = 108}
    Private _142 As New CharTitle With {.TitleID = 142, .UnkRef = 7991, .MaleTitle = " %s the Undying", .FemaleTitle = " %s the Undying", .InGameOrder = 109}
    Private _143 As New CharTitle With {.TitleID = 143, .UnkRef = 7997, .MaleTitle = " %s Jenkins", .FemaleTitle = " %s Jenkins", .InGameOrder = 110}
    Private _144 As New CharTitle With {.TitleID = 144, .UnkRef = 8045, .MaleTitle = "Bloodsail Admiral %s", .FemaleTitle = "Bloodsail Admiral %s", .InGameOrder = 111}
    Private _145 As New CharTitle With {.TitleID = 145, .UnkRef = 8121, .MaleTitle = " %s the Insane", .FemaleTitle = " %s the Insane", .InGameOrder = 112}
    Private _146 As New CharTitle With {.TitleID = 146, .UnkRef = 8237, .MaleTitle = " %s of the Exodar", .FemaleTitle = " %s of the Exodar", .InGameOrder = 113}
    Private _147 As New CharTitle With {.TitleID = 147, .UnkRef = 8238, .MaleTitle = " %s of Darnassus", .FemaleTitle = " %s of Darnassus", .InGameOrder = 114}
    Private _148 As New CharTitle With {.TitleID = 148, .UnkRef = 8239, .MaleTitle = " %s of Ironforge", .FemaleTitle = " %s of Ironforge", .InGameOrder = 115}
    Private _149 As New CharTitle With {.TitleID = 149, .UnkRef = 8240, .MaleTitle = " %s of Stormwind", .FemaleTitle = " %s of Stormwind", .InGameOrder = 116}
    Private _150 As New CharTitle With {.TitleID = 150, .UnkRef = 8241, .MaleTitle = " %s of Orgrimmar", .FemaleTitle = " %s of Orgrimmar", .InGameOrder = 117}
    Private _151 As New CharTitle With {.TitleID = 151, .UnkRef = 8242, .MaleTitle = " %s of Sen'jin", .FemaleTitle = " %s of Sen'jin", .InGameOrder = 118}
    Private _152 As New CharTitle With {.TitleID = 152, .UnkRef = 8243, .MaleTitle = " %s of Silvermoon", .FemaleTitle = " %s of Silvermoon", .InGameOrder = 119}
    Private _153 As New CharTitle With {.TitleID = 153, .UnkRef = 8244, .MaleTitle = " %s of Thunder Bluff", .FemaleTitle = " %s of Thunder Bluff", .InGameOrder = 120}
    Private _154 As New CharTitle With {.TitleID = 154, .UnkRef = 8245, .MaleTitle = " %s of the Undercity", .FemaleTitle = " %s of the Undercity", .InGameOrder = 121}
    Private _155 As New CharTitle With {.TitleID = 155, .UnkRef = 8303, .MaleTitle = " %s the Noble", .FemaleTitle = " %s the Noble", .InGameOrder = 122}
    Private _156 As New CharTitle With {.TitleID = 156, .UnkRef = 8332, .MaleTitle = "Crusader %s", .FemaleTitle = "Crusader %s", .InGameOrder = 123}
    Private _157 As New CharTitle With {.TitleID = 157, .UnkRef = 0, .MaleTitle = "Deadly Gladiator %s", .FemaleTitle = "Deadly Gladiator %s", .InGameOrder = 56}
    Private _158 As New CharTitle With {.TitleID = 158, .UnkRef = 8450, .MaleTitle = " %s, Death's Demise", .FemaleTitle = " %s, Death's Demise", .InGameOrder = 124}
    Private _159 As New CharTitle With {.TitleID = 159, .UnkRef = 8451, .MaleTitle = " %s the Celestial Defender", .FemaleTitle = " %s the Celestial Defender", .InGameOrder = 125}
    Private _160 As New CharTitle With {.TitleID = 160, .UnkRef = 8453, .MaleTitle = " %s, Conqueror of Ulduar", .FemaleTitle = " %s, Conqueror of Ulduar", .InGameOrder = 126}
    Private _161 As New CharTitle With {.TitleID = 161, .UnkRef = 8452, .MaleTitle = " %s, Champion of Ulduar", .FemaleTitle = " %s, Champion of Ulduar", .InGameOrder = 127}
    Private _163 As New CharTitle With {.TitleID = 163, .UnkRef = 0, .MaleTitle = "Vanquisher %s", .FemaleTitle = "Vanquisher %s", .InGameOrder = 128}
    Private _164 As New CharTitle With {.TitleID = 164, .UnkRef = 8467, .MaleTitle = "Starcaller %s", .FemaleTitle = "Starcaller %s", .InGameOrder = 129}
    Private _165 As New CharTitle With {.TitleID = 165, .UnkRef = 8468, .MaleTitle = " %s the Astral Walker", .FemaleTitle = " %s the Astral Walker", .InGameOrder = 130}
    Private _166 As New CharTitle With {.TitleID = 166, .UnkRef = 8469, .MaleTitle = " %s, Herald of the Titans", .FemaleTitle = " %s, Herald of the Titans", .InGameOrder = 131}
    Private _167 As New CharTitle With {.TitleID = 167, .UnkRef = 0, .MaleTitle = "Furious Gladiator %s", .FemaleTitle = "Furious Gladiator %s", .InGameOrder = 132}
    Private _168 As New CharTitle With {.TitleID = 168, .UnkRef = 8596, .MaleTitle = " %s the Pilgrim", .FemaleTitle = " %s the Pilgrim", .InGameOrder = 133}
    Private _169 As New CharTitle With {.TitleID = 169, .UnkRef = 0, .MaleTitle = "Relentless Gladiator %s", .FemaleTitle = "Relentless Gladiator %s", .InGameOrder = 134}
    Private _170 As New CharTitle With {.TitleID = 170, .UnkRef = 8777, .MaleTitle = "Grand Crusader %s", .FemaleTitle = "Grand Crusader %s", .InGameOrder = 135}
    Private _171 As New CharTitle With {.TitleID = 171, .UnkRef = 8778, .MaleTitle = " %s the Argent Defender", .FemaleTitle = " %s the Argent Defender", .InGameOrder = 136}
    Private _172 As New CharTitle With {.TitleID = 172, .UnkRef = 8977, .MaleTitle = " %s the Patient", .FemaleTitle = " %s the Patient", .InGameOrder = 137}
    Private _173 As New CharTitle With {.TitleID = 173, .UnkRef = 9043, .MaleTitle = " %s the Light of Dawn", .FemaleTitle = " %s the Light of Dawn", .InGameOrder = 138}
    Private _174 As New CharTitle With {.TitleID = 174, .UnkRef = 9045, .MaleTitle = " %s, Bane of the Fallen King", .FemaleTitle = " %s, Bane of the Fallen King", .InGameOrder = 139}
    Private _175 As New CharTitle With {.TitleID = 175, .UnkRef = 9046, .MaleTitle = " %s the Kingslayer", .FemaleTitle = " %s the Kingslayer", .InGameOrder = 140}
    Private _176 As New CharTitle With {.TitleID = 176, .UnkRef = 9138, .MaleTitle = " %s of the Ashen Verdict", .FemaleTitle = " %s of the Ashen Verdict", .InGameOrder = 141}
    Private _177 As New CharTitle With {.TitleID = 177, .UnkRef = 0, .MaleTitle = "Wrathful Gladiator %s", .FemaleTitle = "Wrathful Gladiator %s", .InGameOrder = 142}

    Private _TitleList As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_1, _2, _3, _4, _5, _6, _7, _8, _9, _10, _11, _12, _13, _14, _15, _16, _17, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _42, _43, _44, _45, _46, _47, _48, _53, _62, _63, _64, _71, _72, _74, _75, _76, _77, _78, _79, _80, _81, _82, _83, _84, _85, _86, _87, _89, _90, _91, _92, _93, _94, _95, _96, _97, _98, _99, _100, _101, _102, _103, _104, _105, _106, _107, _108, _109, _110, _111, _112, _113, _114, _115, _116, _117, _118, _119, _120, _121, _122, _123, _124, _125, _126, _127, _128, _129, _130, _131, _132, _133, _134, _135, _137, _138, _139, _140, _141, _142, _143, _144, _145, _146, _147, _148, _149, _150, _151, _152, _153, _154, _155, _156, _157, _158, _159, _160, _161, _163, _164, _165, _166, _167, _168, _169, _170, _171, _172, _173, _174, _175, _176, _177})

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Help()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim _Log As String = ""
        Dim _NewLine As Boolean = False

        Dim _CharacterFullList As New List(Of Character)

        '// 1234 Roki 0 64 0 0 0
        For Each _CharacterInfo In tbMask.Lines
            If _NewLine Then
                _Log += vbCrLf
            Else
                _NewLine = True
            End If
            _Log += "____________________________________________________________________________________" + vbCrLf + _
                    "// CHARACTER TITLE DATA"
            Dim _SplittedCharacterInfo() As String = Split(_CharacterInfo)
            If _SplittedCharacterInfo.Length = 8 Then
                Dim _ValueCounter As Integer = 0
                Dim _GUID As Integer = 0
                Dim _Namen As String = "n/a"
                Dim _INT_0 As UInteger = 0
                Dim _INT_1 As UInteger = 0
                Dim _INT_2 As UInteger = 0
                Dim _INT_3 As UInteger = 0
                Dim _INT_4 As UInteger = 0
                Dim _INT_5 As UInteger = 0
                Dim _NothingChanged As Boolean = True

                For Each _Value In _SplittedCharacterInfo
                    Select Case _ValueCounter
                        Case 0 '// GUID
                            _GUID = CInt(_Value)
                        Case 1 '// NAME
                            _Namen = _Value
                        Case 2 '// INT_0
                            _INT_0 = CUInt(_Value)
                        Case 3 '// INT_1
                            Dim _Bits As List(Of UInteger) = GetBitsFromBitMask(CUInt(_Value)) '// Bits = Alle Titel wo der Charakter aktuell besitzt
                            Dim _GrantedBits As New List(Of UInteger)

                            For Each _Title As CharTitle In _TitleList '// Wir nehmen einen Titel aus der Liste, 
                                If _Title.WhichIntegerRounded = 1 Then '// Wir prüfen erstmal, ob der zufällige Titel auch in die Kategorie INT_1 gehört.
                                    For Each _Bit In _Bits '// Dann schauen wir ob das Bit des zufälligen Titels, mit einem von dem Spieler übereinstimmt.
                                        If _Title.Bit = _Bit Then '// Der Spieler hat diesen zufällige Titel.
                                            '// Nun Prüfen wir ob der Titel zulässig ist oder nicht.
                                            Dim _NoBannedTitelsFound As Boolean = True
                                            For Each _BannedTitle In tbBannedTitel.Lines '// Dazu vergleichen wir das _Title.Bit mit einer Liste, gebannter Bits.
                                                If _BannedTitle.StartsWith("1") Then '// Wir prüfen ob das gebannte Title Bit, zu INT_1 gehört.
                                                    If CLng(_BannedTitle.Substring(1)) = _Title.Bit Then '// Wir prüfen ob das Bit mit einem gebannten Bit übereinstimmt.
                                                        If _Debug Then MessageBox.Show("GEBANNT:" + _BannedTitle.Substring(1) + " = " + CStr(_Title.Bit))
                                                        '// Das Bit ist gebannt. Wir müssen nicht weiter suchen und verlassen die For-Schleife.
                                                        _NoBannedTitelsFound = False
                                                        Exit For
                                                    Else
                                                        If _Debug Then MessageBox.Show("Nicht gebannt:" + _BannedTitle.Substring(1) + " = " + CStr(_Title.Bit))
                                                        '// Das Bit ist nicht gebannt. Wir schauen ob das nächste Bit gebannt ist.
                                                        Continue For
                                                    End If
                                                End If
                                            Next
                                            If _NoBannedTitelsFound Then '// Wir prüfen ob eine Übereinstimmung festgestellt wurde.
                                                '// Falls nicht, das Bit ist nicht gebannt.
                                                _Log += vbCrLf + "GRANTED | BIT: " + CStr(_Title.Bit) + " | INT: " + CStr(_Title.WhichIntegerRounded) + " | IntBit: " + CStr(_Title.BitOfInteger) + " | TitleID: " + CStr(_Title.TitleID) + " | UnkRef: " + CStr(_Title.UnkRef) + " | MaleTitle: " + _Title.MaleTitle + " | FemaleTitle: " + _Title.FemaleTitle + " | InGameOrder: " + CStr(_Title.InGameOrder)
                                                _GrantedBits.Add(_Bit) '// Das nicht gebannte Bit, der Liste der nicht gebannten Bits hinzufügen.
                                            Else
                                                _NothingChanged = False
                                                '// Falls doch, das Bit ist gebannt.
                                                _Log += vbCrLf + "BANNED | BIT: " + CStr(_Title.Bit) + " | INT: " + CStr(_Title.WhichIntegerRounded) + " | IntBit: " + CStr(_Title.BitOfInteger) + " | TitleID: " + CStr(_Title.TitleID) + " | UnkRef: " + CStr(_Title.UnkRef) + " | MaleTitle: " + _Title.MaleTitle + " | FemaleTitle: " + _Title.FemaleTitle + " | InGameOrder: " + CStr(_Title.InGameOrder)
                                            End If
                                        End If
                                    Next
                                End If
                            Next

                            Dim _GrantedBitmask As UInteger = Nothing
                            '// Wir haben nun eine Liste mit nicht gebannten Bits.
                            For Each _GrantedBit In _GrantedBits '// Nun Addieren wir alle nicht gebannten Bits zu einer Bitmask.
                                _GrantedBitmask += _GrantedBit
                            Next

                            _INT_1 = _GrantedBitmask '// Diese Bitmask ist die neue _INI_1 Bitmask.
                        Case 4 '// INT_2
                            _INT_2 = CUInt(_Value)
                        Case 5 '// INT_3
                            _INT_3 = CUInt(_Value)
                        Case 6 '// INT_4
                            _INT_4 = CUInt(_Value)
                        Case 7 '// INT_5
                            _INT_5 = CUInt(_Value)
                    End Select
                    _ValueCounter += 1
                Next
                Dim _Char As New Character With {.GUID = _GUID, .Namen = _Namen, .INT_0 = _INT_0, .INT_1 = _INT_1, .INT_2 = _INT_2, .INT_3 = _INT_3, .INT_4 = _INT_4, .NothingChanged = _NothingChanged}
                _Log += PrintCharakter(_Char)
                _CharacterFullList.Add(_Char)
            Else
                MessageBox.Show("""_SplittedCharacterInfo.Length != 7"" !", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                For Each _SplitCharInfo In _SplittedCharacterInfo
                    MessageBox.Show(_SplitCharInfo)
                Next
            End If
        Next
        tbMaskTitels.Text = _Log
        My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\log.txt", _Log, False)
        GenerateSQLQuery(_CharacterFullList)
    End Sub

    Private Sub GenerateSQLQuery(_CharacterFullList As List(Of Character))
        Dim _SQLQuery As String = ""
        Dim _NewLine As Boolean = False
        For Each _Char In _CharacterFullList
            If Not _Char.NothingChanged Then
                If _NewLine Then
                    _SQLQuery += vbCrLf
                Else
                    _NewLine = True
                End If
                _SQLQuery += "UPDATE `characters` SET `knownTitles`=""" + CStr(_Char.INT_0) + " " + _
                                                                        CStr(_Char.INT_1) + " " + _
                                                                        CStr(_Char.INT_2) + " " + _
                                                                        CStr(_Char.INT_3) + " " + _
                                                                        CStr(_Char.INT_4) + " " + _
                                                                        CStr(_Char.INT_5) + """ WHERE `guid`=" + _
                                                                        CStr(_Char.GUID) + "; -- " + _Char.Namen
            Else
                Continue For
            End If
        Next
        My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.Desktop + "\char_sql.sql", _SQLQuery, False)
        MessageBox.Show("DONE!", "DONE", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Function PrintCharakter(_Character As Character) As String
        Return vbCrLf + vbCrLf + "Name: " + _Character.Namen + _
                                 " | GUID: " + CStr(_Character.GUID) + _
                                 " | INT_0: " + CStr(_Character.INT_0) + _
                                 " | INT_1: " + CStr(_Character.INT_1) + _
                                 " | INT_2: " + CStr(_Character.INT_2) + _
                                 " | INT_3: " + CStr(_Character.INT_3) + _
                                 " | INT_4: " + CStr(_Character.INT_4)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbOutput.Text = ""
        Dim _NewLine As Boolean = False
        Dim _FullList As New List(Of CharTitle)
        For Each _Title As CharTitle In _TitleList
            Dim _WhichInteger As Double = _Title.InGameOrder / 32
            Dim _WhichIntegerRounded As Integer = CInt(_WhichInteger)
            Dim _BitOfInteger As Integer = CInt(_Title.InGameOrder Mod 32)
            Dim _CorrectBit As Int64 = CLng(2 ^ _BitOfInteger)


            _Title.WhichIntegerRounded = _WhichIntegerRounded
            _Title.BitOfInteger = _BitOfInteger
            _Title.Bit = _CorrectBit

            _FullList.Add(_Title)
            If _NewLine Then
                tbOutput.Text = tbOutput.Text + vbCrLf
            Else
                _NewLine = True
            End If
            tbOutput.Text = tbOutput.Text + "BIT: " + CStr(_Title.Bit) + " | INT: " + CStr(_Title.WhichIntegerRounded) + " (" + CStr(_WhichInteger) + ") | IntBit: " + CStr(_Title.BitOfInteger) + " | TitleID: " + CStr(_Title.TitleID) + " | UnkRef: " + CStr(_Title.UnkRef) + " | MaleTitle: " + _Title.MaleTitle + " | FemaleTitle: " + _Title.FemaleTitle + " | InGameOrder: " + CStr(_Title.InGameOrder)
        Next
        _TitleList.Clear()
        _TitleList.AddRange(_FullList)
    End Sub

    Private Sub Help()
        Dim _ListHelp As String = ""
        Dim _ID As Integer = 0
        For Each Row In tbInput.Lines
            _ID += 1
            Select Case _ID
                Case 1 '// TitleID
                    _ListHelp += vbCrLf + "{_" + Row
                    tbOutput.Text = tbOutput.Text + "Private _" + Row + " As New CharTitle With {.TitleID = " + Row
                Case 2 '// UnkRef?
                    tbOutput.Text = tbOutput.Text + ", .UnkRef = " + Row
                Case 3 '// MaleTitle
                    tbOutput.Text = tbOutput.Text + ", .MaleTitle = """ + Row
                Case 4 '// FemaleTitle
                    tbOutput.Text = tbOutput.Text + """, .FemaleTitle = """ + Row
                Case 5 '// InGameOrder
                    tbOutput.Text = tbOutput.Text + """, .InGameOrder = " + Row + "}"
                Case 6 '// Reset - TitelID
                    _ListHelp += ", _" + Row
                    _ID = 1
                    tbOutput.Text = tbOutput.Text + vbCrLf + "Private _" + Row + " As New CharTitle With {.TitleID = " + Row
            End Select
        Next
        tbOutput.Text = tbOutput.Text + vbCrLf + _ListHelp
    End Sub

    '''<summary>Bits einer Bitmask auslesen.</summary>
    Public Function GetBitsFromBitMask(_BitMask As UInteger) As List(Of UInteger)
        Dim _Bits As New List(Of UInteger)

        For _i As Integer = 31 To 0 Step -1
            If _BitMask - 2 ^ _i >= 0 Then
                _BitMask = CUInt(_BitMask - 2 ^ _i)
                _Bits.Add(CUInt(2 ^ _i))
            End If
        Next

        Return _Bits
    End Function

    Private Sub cbDebug_CheckStateChanged(sender As Object, e As EventArgs) Handles cbDebug.CheckStateChanged
        If cbDebug.CheckState = CheckState.Checked Then
            _Debug = True
        Else
            _Debug = False
        End If
    End Sub
End Class
