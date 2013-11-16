Option Explicit On
Option Strict On

Module TitleDBC_Mod

#Region "Language Deklarationen"
    Public _LANG_TitelList_All As List(Of CharTitle)
    Public _LANG_TitleList_INT_0 As List(Of CharTitle)
    Public _LANG_TitleList_INT_1 As List(Of CharTitle)
    Public _LANG_TitleList_INT_2 As List(Of CharTitle)
    Public _LANG_TitleList_INT_3 As List(Of CharTitle)
    Public _LANG_TitleList_INT_4 As List(Of CharTitle)
#End Region

    '// Charactertitles from DBC - ENGLISCH
#Region "CharTitles from DBC"
    Private _1_ENG As New CharTitle With {.TitleID = 1, .UnkRef = 5879, .MaleTitle = "Private %s", .FemaleTitle = "Private %s", .InGameOrder = 1, .IntID = 0, .IntID_Double = 0.03125, .BitOfInteger = 1, .Bit = 2}
    Private _2_ENG As New CharTitle With {.TitleID = 2, .UnkRef = 5880, .MaleTitle = "Corporal %s", .FemaleTitle = "Corporal %s", .InGameOrder = 2, .IntID = 0, .IntID_Double = 0.0625, .BitOfInteger = 2, .Bit = 4}
    Private _3_ENG As New CharTitle With {.TitleID = 3, .UnkRef = 5881, .MaleTitle = "Sergeant %s", .FemaleTitle = "Sergeant %s", .InGameOrder = 3, .IntID = 0, .IntID_Double = 0.09375, .BitOfInteger = 3, .Bit = 8}
    Private _4_ENG As New CharTitle With {.TitleID = 4, .UnkRef = 5882, .MaleTitle = "Master Sergeant %s", .FemaleTitle = "Master Sergeant %s", .InGameOrder = 4, .IntID = 0, .IntID_Double = 0.125, .BitOfInteger = 4, .Bit = 16}
    Private _5_ENG As New CharTitle With {.TitleID = 5, .UnkRef = 5883, .MaleTitle = "Sergeant Major %s", .FemaleTitle = "Sergeant Major %s", .InGameOrder = 5, .IntID = 0, .IntID_Double = 0.15625, .BitOfInteger = 5, .Bit = 32}
    Private _6_ENG As New CharTitle With {.TitleID = 6, .UnkRef = 5884, .MaleTitle = "Knight %s", .FemaleTitle = "Knight %s", .InGameOrder = 6, .IntID = 0, .IntID_Double = 0.1875, .BitOfInteger = 6, .Bit = 64}
    Private _7_ENG As New CharTitle With {.TitleID = 7, .UnkRef = 5885, .MaleTitle = "Knight-Lieutenant %s", .FemaleTitle = "Knight-Lieutenant %s", .InGameOrder = 7, .IntID = 0, .IntID_Double = 0.21875, .BitOfInteger = 7, .Bit = 128}
    Private _8_ENG As New CharTitle With {.TitleID = 8, .UnkRef = 5886, .MaleTitle = "Knight-Captain %s", .FemaleTitle = "Knight-Captain %s", .InGameOrder = 8, .IntID = 0, .IntID_Double = 0.25, .BitOfInteger = 8, .Bit = 256}
    Private _9_ENG As New CharTitle With {.TitleID = 9, .UnkRef = 5887, .MaleTitle = "Knight-Champion %s", .FemaleTitle = "Knight-Champion %s", .InGameOrder = 9, .IntID = 0, .IntID_Double = 0.28125, .BitOfInteger = 9, .Bit = 512}
    Private _10_ENG As New CharTitle With {.TitleID = 10, .UnkRef = 5888, .MaleTitle = "Lieutenant Commander %s", .FemaleTitle = "Lieutenant Commander %s", .InGameOrder = 10, .IntID = 0, .IntID_Double = 0.3125, .BitOfInteger = 10, .Bit = 1024}
    Private _11_ENG As New CharTitle With {.TitleID = 11, .UnkRef = 5889, .MaleTitle = "Commander %s", .FemaleTitle = "Commander %s", .InGameOrder = 11, .IntID = 0, .IntID_Double = 0.34375, .BitOfInteger = 11, .Bit = 2048}
    Private _12_ENG As New CharTitle With {.TitleID = 12, .UnkRef = 5890, .MaleTitle = "Marshal %s", .FemaleTitle = "Marshal %s", .InGameOrder = 12, .IntID = 0, .IntID_Double = 0.375, .BitOfInteger = 12, .Bit = 4096}
    Private _13_ENG As New CharTitle With {.TitleID = 13, .UnkRef = 5891, .MaleTitle = "Field Marshal %s", .FemaleTitle = "Field Marshal %s", .InGameOrder = 13, .IntID = 0, .IntID_Double = 0.40625, .BitOfInteger = 13, .Bit = 8192}
    Private _14_ENG As New CharTitle With {.TitleID = 14, .UnkRef = 5892, .MaleTitle = "Grand Marshal %s", .FemaleTitle = "Grand Marshal %s", .InGameOrder = 14, .IntID = 0, .IntID_Double = 0.4375, .BitOfInteger = 14, .Bit = 16384}
    Private _15_ENG As New CharTitle With {.TitleID = 15, .UnkRef = 5893, .MaleTitle = "Scout %s", .FemaleTitle = "Scout %s", .InGameOrder = 15, .IntID = 0, .IntID_Double = 0.46875, .BitOfInteger = 15, .Bit = 32768}
    Private _16_ENG As New CharTitle With {.TitleID = 16, .UnkRef = 5894, .MaleTitle = "Grunt %s", .FemaleTitle = "Grunt %s", .InGameOrder = 16, .IntID = 0, .IntID_Double = 0.5, .BitOfInteger = 16, .Bit = 65536}
    Private _17_ENG As New CharTitle With {.TitleID = 17, .UnkRef = 5895, .MaleTitle = "Sergeant %s", .FemaleTitle = "Sergeant %s", .InGameOrder = 17, .IntID = 1, .IntID_Double = 0.53125, .BitOfInteger = 17, .Bit = 131072}
    Private _18 As New CharTitle With {.TitleID = 18, .UnkRef = 5896, .MaleTitle = "Senior Sergeant %s", .FemaleTitle = "Senior Sergeant %s", .InGameOrder = 18, .IntID = 1, .IntID_Double = 0.5625, .BitOfInteger = 18, .Bit = 262144}
    Private _19 As New CharTitle With {.TitleID = 19, .UnkRef = 5897, .MaleTitle = "First Sergeant %s", .FemaleTitle = "First Sergeant %s", .InGameOrder = 19, .IntID = 1, .IntID_Double = 0.59375, .BitOfInteger = 19, .Bit = 524288}
    Private _20 As New CharTitle With {.TitleID = 20, .UnkRef = 5898, .MaleTitle = "Stone Guard %s", .FemaleTitle = "Stone Guard %s", .InGameOrder = 20, .IntID = 1, .IntID_Double = 0.625, .BitOfInteger = 20, .Bit = 1048576}
    Private _21 As New CharTitle With {.TitleID = 21, .UnkRef = 5899, .MaleTitle = "Blood Guard %s", .FemaleTitle = "Blood Guard %s", .InGameOrder = 21, .IntID = 1, .IntID_Double = 0.65625, .BitOfInteger = 21, .Bit = 2097152}
    Private _22 As New CharTitle With {.TitleID = 22, .UnkRef = 5900, .MaleTitle = "Legionnaire %s", .FemaleTitle = "Legionnaire %s", .InGameOrder = 22, .IntID = 1, .IntID_Double = 0.6875, .BitOfInteger = 22, .Bit = 4194304}
    Private _23 As New CharTitle With {.TitleID = 23, .UnkRef = 5901, .MaleTitle = "Centurion %s", .FemaleTitle = "Centurion %s", .InGameOrder = 23, .IntID = 1, .IntID_Double = 0.71875, .BitOfInteger = 23, .Bit = 8388608}
    Private _24 As New CharTitle With {.TitleID = 24, .UnkRef = 5902, .MaleTitle = "Champion %s", .FemaleTitle = "Champion %s", .InGameOrder = 24, .IntID = 1, .IntID_Double = 0.75, .BitOfInteger = 24, .Bit = 16777216}
    Private _25 As New CharTitle With {.TitleID = 25, .UnkRef = 5903, .MaleTitle = "Lieutenant General %s", .FemaleTitle = "Lieutenant General %s", .InGameOrder = 25, .IntID = 1, .IntID_Double = 0.78125, .BitOfInteger = 25, .Bit = 33554432}
    Private _26 As New CharTitle With {.TitleID = 26, .UnkRef = 5904, .MaleTitle = "General %s", .FemaleTitle = "General %s", .InGameOrder = 26, .IntID = 1, .IntID_Double = 0.8125, .BitOfInteger = 26, .Bit = 67108864}
    Private _27 As New CharTitle With {.TitleID = 27, .UnkRef = 5905, .MaleTitle = "Warlord %s", .FemaleTitle = "Warlord %s", .InGameOrder = 27, .IntID = 1, .IntID_Double = 0.84375, .BitOfInteger = 27, .Bit = 134217728}
    Private _28 As New CharTitle With {.TitleID = 28, .UnkRef = 5906, .MaleTitle = "High Warlord %s", .FemaleTitle = "High Warlord %s", .InGameOrder = 28, .IntID = 1, .IntID_Double = 0.875, .BitOfInteger = 28, .Bit = 268435456}
    Private _42 As New CharTitle With {.TitleID = 42, .UnkRef = 0, .MaleTitle = "Gladiator %s", .FemaleTitle = "Gladiator %s", .InGameOrder = 29, .IntID = 1, .IntID_Double = 0.90625, .BitOfInteger = 29, .Bit = 536870912}
    Private _43 As New CharTitle With {.TitleID = 43, .UnkRef = 0, .MaleTitle = "Duelist %s", .FemaleTitle = "Duelist %s", .InGameOrder = 30, .IntID = 1, .IntID_Double = 0.9375, .BitOfInteger = 30, .Bit = 1073741824}
    Private _44 As New CharTitle With {.TitleID = 44, .UnkRef = 0, .MaleTitle = "Rival %s", .FemaleTitle = "Rival %s", .InGameOrder = 31, .IntID = 1, .IntID_Double = 0.96875, .BitOfInteger = 31, .Bit = 2147483648}
    Private _45 As New CharTitle With {.TitleID = 45, .UnkRef = 0, .MaleTitle = "Challenger %s", .FemaleTitle = "Challenger %s", .InGameOrder = 32, .IntID = 1, .IntID_Double = 1, .BitOfInteger = 0, .Bit = 1}
    Private _46 As New CharTitle With {.TitleID = 46, .UnkRef = 6341, .MaleTitle = "Scarab Lord %s", .FemaleTitle = "Scarab Lord %s", .InGameOrder = 33, .IntID = 1, .IntID_Double = 1.03125, .BitOfInteger = 1, .Bit = 2}
    Private _47 As New CharTitle With {.TitleID = 47, .UnkRef = 6407, .MaleTitle = "Conqueror %s", .FemaleTitle = "Conqueror %s", .InGameOrder = 34, .IntID = 1, .IntID_Double = 1.0625, .BitOfInteger = 2, .Bit = 4}
    Private _48 As New CharTitle With {.TitleID = 48, .UnkRef = 6406, .MaleTitle = "Justicar %s", .FemaleTitle = "Justicar %s", .InGameOrder = 35, .IntID = 1, .IntID_Double = 1.09375, .BitOfInteger = 3, .Bit = 8}
    Private _53 As New CharTitle With {.TitleID = 53, .UnkRef = 6686, .MaleTitle = "%s, Champion of the Naaru", .FemaleTitle = "%s, Champion of the Naaru", .InGameOrder = 36, .IntID = 1, .IntID_Double = 1.125, .BitOfInteger = 4, .Bit = 16}
    Private _62 As New CharTitle With {.TitleID = 62, .UnkRef = 0, .MaleTitle = "Merciless Gladiator %s", .FemaleTitle = "Merciless Gladiator %s", .InGameOrder = 37, .IntID = 1, .IntID_Double = 1.15625, .BitOfInteger = 5, .Bit = 32}
    Private _63 As New CharTitle With {.TitleID = 63, .UnkRef = 6806, .MaleTitle = "%s of the Shattered Sun", .FemaleTitle = "%s of the Shattered Sun", .InGameOrder = 38, .IntID = 1, .IntID_Double = 1.1875, .BitOfInteger = 6, .Bit = 64}
    Private _64 As New CharTitle With {.TitleID = 64, .UnkRef = 6944, .MaleTitle = "%s, Hand of A'dal", .FemaleTitle = "%s, Hand of A'dal", .InGameOrder = 39, .IntID = 1, .IntID_Double = 1.21875, .BitOfInteger = 7, .Bit = 128}
    Private _71 As New CharTitle With {.TitleID = 71, .UnkRef = 0, .MaleTitle = "Vengeful Gladiator %s", .FemaleTitle = "Vengeful Gladiator %s", .InGameOrder = 40, .IntID = 1, .IntID_Double = 1.25, .BitOfInteger = 8, .Bit = 256}
    Private _72 As New CharTitle With {.TitleID = 72, .UnkRef = 7530, .MaleTitle = "Battlemaster %s", .FemaleTitle = "Battlemaster %s", .InGameOrder = 41, .IntID = 1, .IntID_Double = 1.28125, .BitOfInteger = 9, .Bit = 512}
    Private _74 As New CharTitle With {.TitleID = 74, .UnkRef = 7533, .MaleTitle = "Elder %s", .FemaleTitle = "Elder %s", .InGameOrder = 43, .IntID = 1, .IntID_Double = 1.34375, .BitOfInteger = 11, .Bit = 2048}
    Private _75 As New CharTitle With {.TitleID = 75, .UnkRef = 7534, .MaleTitle = "Flame Warden %s", .FemaleTitle = "Flame Warden %s", .InGameOrder = 44, .IntID = 1, .IntID_Double = 1.375, .BitOfInteger = 12, .Bit = 4096}
    Private _76 As New CharTitle With {.TitleID = 76, .UnkRef = 7535, .MaleTitle = "Flame Keeper %s", .FemaleTitle = "Flame Keeper %s", .InGameOrder = 45, .IntID = 1, .IntID_Double = 1.40625, .BitOfInteger = 13, .Bit = 8192}
    Private _77 As New CharTitle With {.TitleID = 77, .UnkRef = 7565, .MaleTitle = "%s the Exalted", .FemaleTitle = "%s the Exalted", .InGameOrder = 46, .IntID = 1, .IntID_Double = 1.4375, .BitOfInteger = 14, .Bit = 16384}
    Private _78 As New CharTitle With {.TitleID = 78, .UnkRef = 7695, .MaleTitle = "%s the Explorer", .FemaleTitle = "%s the Explorer", .InGameOrder = 47, .IntID = 1, .IntID_Double = 1.46875, .BitOfInteger = 15, .Bit = 32768}
    Private _79 As New CharTitle With {.TitleID = 79, .UnkRef = 7748, .MaleTitle = "%s the Diplomat", .FemaleTitle = "%s the Diplomat", .InGameOrder = 48, .IntID = 2, .IntID_Double = 1.5, .BitOfInteger = 16, .Bit = 65536}
    Private _80 As New CharTitle With {.TitleID = 80, .UnkRef = 0, .MaleTitle = "Brutal Gladiator %s", .FemaleTitle = "Brutal Gladiator %s", .InGameOrder = 49, .IntID = 2, .IntID_Double = 1.53125, .BitOfInteger = 17, .Bit = 131072}
    Private _81 As New CharTitle With {.TitleID = 81, .UnkRef = 7759, .MaleTitle = " %s the Seeker", .FemaleTitle = "%s the Seeker", .InGameOrder = 42, .IntID = 1, .IntID_Double = 1.3125, .BitOfInteger = 10, .Bit = 1024}
    Private _82_ENG As New CharTitle With {.TitleID = 82, .UnkRef = 7749, .MaleTitle = "Arena Master %s", .FemaleTitle = "Arena Master %s", .InGameOrder = 50, .IntID = 2, .IntID_Double = 1.5625, .BitOfInteger = 18, .Bit = 262144}
    Private _83_ENG As New CharTitle With {.TitleID = 83, .UnkRef = 7750, .MaleTitle = "Salty %s", .FemaleTitle = "Salty %s", .InGameOrder = 51, .IntID = 2, .IntID_Double = 1.59375, .BitOfInteger = 19, .Bit = 524288}
    Private _84_ENG As New CharTitle With {.TitleID = 84, .UnkRef = 7754, .MaleTitle = "Chef %s", .FemaleTitle = "Chef %s", .InGameOrder = 52, .IntID = 2, .IntID_Double = 1.625, .BitOfInteger = 20, .Bit = 1048576}
    Private _85_ENG As New CharTitle With {.TitleID = 85, .UnkRef = 0, .MaleTitle = "%s the Supreme", .FemaleTitle = "%s the Supreme", .InGameOrder = 53, .IntID = 2, .IntID_Double = 1.65625, .BitOfInteger = 21, .Bit = 2097152}
    Private _86_ENG As New CharTitle With {.TitleID = 86, .UnkRef = 0, .MaleTitle = "%s of the Ten Storms", .FemaleTitle = "%s of the Ten Storms", .InGameOrder = 54, .IntID = 2, .IntID_Double = 1.6875, .BitOfInteger = 22, .Bit = 4194304}
    Private _87_ENG As New CharTitle With {.TitleID = 87, .UnkRef = 0, .MaleTitle = "%s of the Emerald Dream", .FemaleTitle = "%s of the Emerald Dream", .InGameOrder = 55, .IntID = 2, .IntID_Double = 1.71875, .BitOfInteger = 23, .Bit = 8388608}
    Private _89_ENG As New CharTitle With {.TitleID = 89, .UnkRef = 0, .MaleTitle = "Prophet %s", .FemaleTitle = "Prophet %s", .InGameOrder = 57, .IntID = 2, .IntID_Double = 1.78125, .BitOfInteger = 25, .Bit = 33554432}
    Private _90_ENG As New CharTitle With {.TitleID = 90, .UnkRef = 0, .MaleTitle = "%s the Malefic", .FemaleTitle = "%s the Malefic", .InGameOrder = 58, .IntID = 2, .IntID_Double = 1.8125, .BitOfInteger = 26, .Bit = 67108864}
    Private _91_ENG As New CharTitle With {.TitleID = 91, .UnkRef = 0, .MaleTitle = "Stalker %s", .FemaleTitle = "Stalker %s", .InGameOrder = 59, .IntID = 2, .IntID_Double = 1.84375, .BitOfInteger = 27, .Bit = 134217728}
    Private _92_ENG As New CharTitle With {.TitleID = 92, .UnkRef = 0, .MaleTitle = "%s of the Ebon Blade", .FemaleTitle = "%s of the Ebon Blade", .InGameOrder = 60, .IntID = 2, .IntID_Double = 1.875, .BitOfInteger = 28, .Bit = 268435456}
    Private _93_ENG As New CharTitle With {.TitleID = 93, .UnkRef = 0, .MaleTitle = "Archmage %s", .FemaleTitle = "Archmage %s", .InGameOrder = 61, .IntID = 2, .IntID_Double = 1.90625, .BitOfInteger = 29, .Bit = 536870912}
    Private _94_ENG As New CharTitle With {.TitleID = 94, .UnkRef = 0, .MaleTitle = "Warbringer %s", .FemaleTitle = "Warbringer %s", .InGameOrder = 62, .IntID = 2, .IntID_Double = 1.9375, .BitOfInteger = 30, .Bit = 1073741824}
    Private _95_ENG As New CharTitle With {.TitleID = 95, .UnkRef = 0, .MaleTitle = "Assassin %s", .FemaleTitle = "Assassin %s", .InGameOrder = 63, .IntID = 2, .IntID_Double = 1.96875, .BitOfInteger = 31, .Bit = 2147483648}
    Private _96_ENG As New CharTitle With {.TitleID = 96, .UnkRef = 0, .MaleTitle = "Grand Master Alchemist %s", .FemaleTitle = "Grand Master Alchemist %s", .InGameOrder = 64, .IntID = 2, .IntID_Double = 2, .BitOfInteger = 0, .Bit = 1}
    Private _97_ENG As New CharTitle With {.TitleID = 97, .UnkRef = 0, .MaleTitle = "Grand Master Blacksmith %s", .FemaleTitle = "Grand Master Blacksmith %s", .InGameOrder = 65, .IntID = 2, .IntID_Double = 2.03125, .BitOfInteger = 1, .Bit = 2}
    Private _98_ENG As New CharTitle With {.TitleID = 98, .UnkRef = 0, .MaleTitle = "Iron Chef %s", .FemaleTitle = "Iron Chef %s", .InGameOrder = 66, .IntID = 2, .IntID_Double = 2.0625, .BitOfInteger = 2, .Bit = 4}
    Private _99_ENG As New CharTitle With {.TitleID = 99, .UnkRef = 0, .MaleTitle = "Grand Master Enchanter %s", .FemaleTitle = "Grand Master Enchanter %s", .InGameOrder = 67, .IntID = 2, .IntID_Double = 2.09375, .BitOfInteger = 3, .Bit = 8}
    Private _100_ENG As New CharTitle With {.TitleID = 100, .UnkRef = 0, .MaleTitle = "Grand Master Engineer %s", .FemaleTitle = "Grand Master Engineer %s", .InGameOrder = 68, .IntID = 2, .IntID_Double = 2.125, .BitOfInteger = 4, .Bit = 16}
    Private _101 As New CharTitle With {.TitleID = 101, .UnkRef = 0, .MaleTitle = "Doctor %s", .FemaleTitle = "Doctor %s", .InGameOrder = 69, .IntID = 2, .IntID_Double = 2.15625, .BitOfInteger = 5, .Bit = 32}
    Private _102 As New CharTitle With {.TitleID = 102, .UnkRef = 0, .MaleTitle = "Grand Master Angler %s", .FemaleTitle = "Grand Master Angler %s", .InGameOrder = 70, .IntID = 2, .IntID_Double = 2.1875, .BitOfInteger = 6, .Bit = 64}
    Private _103 As New CharTitle With {.TitleID = 103, .UnkRef = 0, .MaleTitle = "Grand Master Herbalist %s", .FemaleTitle = "Grand Master Herbalist %s", .InGameOrder = 71, .IntID = 2, .IntID_Double = 2.21875, .BitOfInteger = 7, .Bit = 128}
    Private _104 As New CharTitle With {.TitleID = 104, .UnkRef = 0, .MaleTitle = "Grand Master Scribe %s", .FemaleTitle = "Grand Master Scribe %s", .InGameOrder = 72, .IntID = 2, .IntID_Double = 2.25, .BitOfInteger = 8, .Bit = 256}
    Private _105 As New CharTitle With {.TitleID = 105, .UnkRef = 0, .MaleTitle = "Grand Master Jewelcrafter %s", .FemaleTitle = "Grand Master Jewelcrafter %s", .InGameOrder = 73, .IntID = 2, .IntID_Double = 2.28125, .BitOfInteger = 9, .Bit = 512}
    Private _106 As New CharTitle With {.TitleID = 106, .UnkRef = 0, .MaleTitle = "Grand Master Leatherworker %s", .FemaleTitle = "Grand Master Leatherworker %s", .InGameOrder = 74, .IntID = 2, .IntID_Double = 2.3125, .BitOfInteger = 10, .Bit = 1024}
    Private _107 As New CharTitle With {.TitleID = 107, .UnkRef = 0, .MaleTitle = "Grand Master Miner %s", .FemaleTitle = "Grand Master Miner %s", .InGameOrder = 75, .IntID = 2, .IntID_Double = 2.34375, .BitOfInteger = 11, .Bit = 2048}
    Private _108 As New CharTitle With {.TitleID = 108, .UnkRef = 0, .MaleTitle = "Grand Master Skinner %s", .FemaleTitle = "Grand Master Skinner %s", .InGameOrder = 76, .IntID = 2, .IntID_Double = 2.375, .BitOfInteger = 12, .Bit = 4096}
    Private _109 As New CharTitle With {.TitleID = 109, .UnkRef = 0, .MaleTitle = "Grand Master Tailor %s", .FemaleTitle = "Grand Master Tailor %s", .InGameOrder = 77, .IntID = 2, .IntID_Double = 2.40625, .BitOfInteger = 13, .Bit = 8192}
    Private _110 As New CharTitle With {.TitleID = 110, .UnkRef = 0, .MaleTitle = "%s of Quel'Thalas", .FemaleTitle = "%s of Quel'Thalas", .InGameOrder = 78, .IntID = 2, .IntID_Double = 2.4375, .BitOfInteger = 14, .Bit = 16384}
    Private _111 As New CharTitle With {.TitleID = 111, .UnkRef = 0, .MaleTitle = "%s of Argus", .FemaleTitle = "%s of Argus", .InGameOrder = 79, .IntID = 2, .IntID_Double = 2.46875, .BitOfInteger = 15, .Bit = 32768}
    Private _112 As New CharTitle With {.TitleID = 112, .UnkRef = 0, .MaleTitle = "%s of Khaz Modan", .FemaleTitle = "%s of Khaz Modan", .InGameOrder = 80, .IntID = 2, .IntID_Double = 2.5, .BitOfInteger = 16, .Bit = 65536}
    Private _113 As New CharTitle With {.TitleID = 113, .UnkRef = 8236, .MaleTitle = "%s of Gnomeregan", .FemaleTitle = "%s of Gnomeregan", .InGameOrder = 81, .IntID = 3, .IntID_Double = 2.53125, .BitOfInteger = 17, .Bit = 131072}
    Private _114 As New CharTitle With {.TitleID = 114, .UnkRef = 0, .MaleTitle = "%s the Lion Hearted", .FemaleTitle = "%s the Lion Hearted", .InGameOrder = 82, .IntID = 3, .IntID_Double = 2.5625, .BitOfInteger = 18, .Bit = 262144}
    Private _115 As New CharTitle With {.TitleID = 115, .UnkRef = 0, .MaleTitle = "%s, Champion of Elune", .FemaleTitle = "%s, Champion of Elune", .InGameOrder = 83, .IntID = 3, .IntID_Double = 2.59375, .BitOfInteger = 19, .Bit = 524288}
    Private _116 As New CharTitle With {.TitleID = 116, .UnkRef = 0, .MaleTitle = "%s, Hero of Orgrimmar", .FemaleTitle = "%s, Hero of Orgrimmar", .InGameOrder = 84, .IntID = 3, .IntID_Double = 2.625, .BitOfInteger = 20, .Bit = 1048576}
    Private _117_ENG As New CharTitle With {.TitleID = 117, .UnkRef = 0, .MaleTitle = "Plainsrunner %s", .FemaleTitle = "Plainsrunner %s", .InGameOrder = 85, .IntID = 3, .IntID_Double = 2.65625, .BitOfInteger = 21, .Bit = 2097152}
    Private _118_ENG As New CharTitle With {.TitleID = 118, .UnkRef = 0, .MaleTitle = "%s of the Darkspear", .FemaleTitle = "%s of the Darkspear", .InGameOrder = 86, .IntID = 3, .IntID_Double = 2.6875, .BitOfInteger = 22, .Bit = 4194304}
    Private _119_ENG As New CharTitle With {.TitleID = 119, .UnkRef = 0, .MaleTitle = "%s the Forsaken", .FemaleTitle = "%s the Forsaken", .InGameOrder = 87, .IntID = 3, .IntID_Double = 2.71875, .BitOfInteger = 23, .Bit = 8388608}
    Private _120_ENG As New CharTitle With {.TitleID = 120, .UnkRef = 7812, .MaleTitle = "%s the Magic Seeker", .FemaleTitle = "%s the Magic Seeker", .InGameOrder = 88, .IntID = 3, .IntID_Double = 2.75, .BitOfInteger = 24, .Bit = 16777216}
    Private _121_ENG As New CharTitle With {.TitleID = 121, .UnkRef = 7813, .MaleTitle = "Twilight Vanquisher %s", .FemaleTitle = "Twilight Vanquisher %s", .InGameOrder = 89, .IntID = 3, .IntID_Double = 2.78125, .BitOfInteger = 25, .Bit = 33554432}
    Private _122_ENG As New CharTitle With {.TitleID = 122, .UnkRef = 7814, .MaleTitle = "%s, Conqueror of Naxxramas", .FemaleTitle = "%s, Conqueror of Naxxramas", .InGameOrder = 90, .IntID = 3, .IntID_Double = 2.8125, .BitOfInteger = 26, .Bit = 67108864}
    Private _123_ENG As New CharTitle With {.TitleID = 123, .UnkRef = 7815, .MaleTitle = "%s, Hero of Northrend", .FemaleTitle = "%s, Hero of Northrend", .InGameOrder = 91, .IntID = 3, .IntID_Double = 2.84375, .BitOfInteger = 27, .Bit = 134217728}
    Private _124_ENG As New CharTitle With {.TitleID = 124, .UnkRef = 7820, .MaleTitle = "%s the Hallowed", .FemaleTitle = "%s the Hallowed", .InGameOrder = 92, .IntID = 3, .IntID_Double = 2.875, .BitOfInteger = 28, .Bit = 268435456}
    Private _125_ENG As New CharTitle With {.TitleID = 125, .UnkRef = 7849, .MaleTitle = "Loremaster %s", .FemaleTitle = "Loremaster %s", .InGameOrder = 93, .IntID = 3, .IntID_Double = 2.90625, .BitOfInteger = 29, .Bit = 536870912}
    Private _126_ENG As New CharTitle With {.TitleID = 126, .UnkRef = 7853, .MaleTitle = "%s of the Alliance", .FemaleTitle = "%s of the Alliance", .InGameOrder = 94, .IntID = 3, .IntID_Double = 2.9375, .BitOfInteger = 30, .Bit = 1073741824}
    Private _127_ENG As New CharTitle With {.TitleID = 127, .UnkRef = 7854, .MaleTitle = "%s of the Horde", .FemaleTitle = "%s of the Horde", .InGameOrder = 95, .IntID = 3, .IntID_Double = 2.96875, .BitOfInteger = 31, .Bit = 2147483648}
    Private _128_ENG As New CharTitle With {.TitleID = 128, .UnkRef = 7856, .MaleTitle = "%s the Flawless Victor", .FemaleTitle = "%s the Flawless Victor", .InGameOrder = 96, .IntID = 3, .IntID_Double = 3, .BitOfInteger = 0, .Bit = 1}
    Private _129_ENG As New CharTitle With {.TitleID = 129, .UnkRef = 7857, .MaleTitle = "%s, Champion of the Frozen Wastes", .FemaleTitle = " %s, Champion of the Frozen Wastes", .InGameOrder = 97, .IntID = 3, .IntID_Double = 3.03125, .BitOfInteger = 1, .Bit = 2}
    Private _130_ENG As New CharTitle With {.TitleID = 130, .UnkRef = 7858, .MaleTitle = "Ambassador %s", .FemaleTitle = "Ambassador %s", .InGameOrder = 98, .IntID = 3, .IntID_Double = 3.0625, .BitOfInteger = 2, .Bit = 4}
    Private _131_ENG As New CharTitle With {.TitleID = 131, .UnkRef = 7859, .MaleTitle = "%s the Argent Champion", .FemaleTitle = "%s the Argent Champion", .InGameOrder = 99, .IntID = 3, .IntID_Double = 3.09375, .BitOfInteger = 3, .Bit = 8}
    Private _132_ENG As New CharTitle With {.TitleID = 132, .UnkRef = 7860, .MaleTitle = "%s, Guardian of Cenarius", .FemaleTitle = "%s, Guardian of Cenarius", .InGameOrder = 100, .IntID = 3, .IntID_Double = 3.125, .BitOfInteger = 4, .Bit = 16}
    Private _133_ENG As New CharTitle With {.TitleID = 133, .UnkRef = 7861, .MaleTitle = "Brewmaster %s", .FemaleTitle = "Brewmaster %s", .InGameOrder = 101, .IntID = 3, .IntID_Double = 3.15625, .BitOfInteger = 5, .Bit = 32}
    Private _134_ENG As New CharTitle With {.TitleID = 134, .UnkRef = 7864, .MaleTitle = "Merrymaker %s", .FemaleTitle = "Merrymaker %s", .InGameOrder = 102, .IntID = 3, .IntID_Double = 3.1875, .BitOfInteger = 6, .Bit = 64}
    Private _135_ENG As New CharTitle With {.TitleID = 135, .UnkRef = 7875, .MaleTitle = "%s the Love Fool", .FemaleTitle = "%s the Love Fool", .InGameOrder = 103, .IntID = 3, .IntID_Double = 3.21875, .BitOfInteger = 7, .Bit = 128}
    Private _137_ENG As New CharTitle With {.TitleID = 137, .UnkRef = 7893, .MaleTitle = "Matron %s", .FemaleTitle = "Matron %s", .InGameOrder = 104, .IntID = 3, .IntID_Double = 3.25, .BitOfInteger = 8, .Bit = 256}
    Private _138_ENG As New CharTitle With {.TitleID = 138, .UnkRef = 7894, .MaleTitle = "Patron %s", .FemaleTitle = "Patron %s", .InGameOrder = 105, .IntID = 3, .IntID_Double = 3.28125, .BitOfInteger = 9, .Bit = 512}
    Private _139_ENG As New CharTitle With {.TitleID = 139, .UnkRef = 7964, .MaleTitle = "Obsidian Slayer %s", .FemaleTitle = "Obsidian Slayer %s", .InGameOrder = 106, .IntID = 3, .IntID_Double = 3.3125, .BitOfInteger = 10, .Bit = 1024}
    Private _140_ENG As New CharTitle With {.TitleID = 140, .UnkRef = 7965, .MaleTitle = "%s of the Nightfall", .FemaleTitle = "%s of the Nightfall", .InGameOrder = 107, .IntID = 3, .IntID_Double = 3.34375, .BitOfInteger = 11, .Bit = 2048}
    Private _141_ENG As New CharTitle With {.TitleID = 141, .UnkRef = 7990, .MaleTitle = "%s the Immortal", .FemaleTitle = "%s the Immortal", .InGameOrder = 108, .IntID = 3, .IntID_Double = 3.375, .BitOfInteger = 12, .Bit = 4096}
    Private _142_ENG As New CharTitle With {.TitleID = 142, .UnkRef = 7991, .MaleTitle = "%s the Undying", .FemaleTitle = "%s the Undying", .InGameOrder = 109, .IntID = 3, .IntID_Double = 3.40625, .BitOfInteger = 13, .Bit = 8192}
    Private _143_ENG As New CharTitle With {.TitleID = 143, .UnkRef = 7997, .MaleTitle = "%s Jenkins", .FemaleTitle = "%s Jenkins", .InGameOrder = 110, .IntID = 3, .IntID_Double = 3.4375, .BitOfInteger = 14, .Bit = 16384}
    Private _144_ENG As New CharTitle With {.TitleID = 144, .UnkRef = 8045, .MaleTitle = "Bloodsail Admiral %s", .FemaleTitle = "Bloodsail Admiral %s", .InGameOrder = 111, .IntID = 3, .IntID_Double = 3.46875, .BitOfInteger = 15, .Bit = 32768}
    Private _145_ENG As New CharTitle With {.TitleID = 145, .UnkRef = 8121, .MaleTitle = "%s the Insane", .FemaleTitle = "%s the Insane", .InGameOrder = 112, .IntID = 4, .IntID_Double = 3.5, .BitOfInteger = 16, .Bit = 65536}
    Private _146_ENG As New CharTitle With {.TitleID = 146, .UnkRef = 8237, .MaleTitle = "%s of the Exodar", .FemaleTitle = "%s of the Exodar", .InGameOrder = 113, .IntID = 4, .IntID_Double = 3.53125, .BitOfInteger = 17, .Bit = 131072}
    Private _147_ENG As New CharTitle With {.TitleID = 147, .UnkRef = 8238, .MaleTitle = "%s of Darnassus", .FemaleTitle = "%s of Darnassus", .InGameOrder = 114, .IntID = 4, .IntID_Double = 3.5625, .BitOfInteger = 18, .Bit = 262144}
    Private _148_ENG As New CharTitle With {.TitleID = 148, .UnkRef = 8239, .MaleTitle = "%s of Ironforge", .FemaleTitle = "%s of Ironforge", .InGameOrder = 115, .IntID = 4, .IntID_Double = 3.59375, .BitOfInteger = 19, .Bit = 524288}
    Private _149_ENG As New CharTitle With {.TitleID = 149, .UnkRef = 8240, .MaleTitle = "%s of Stormwind", .FemaleTitle = "%s of Stormwind", .InGameOrder = 116, .IntID = 4, .IntID_Double = 3.625, .BitOfInteger = 20, .Bit = 1048576}
    Private _150_ENG As New CharTitle With {.TitleID = 150, .UnkRef = 8241, .MaleTitle = "%s of Orgrimmar", .FemaleTitle = "%s of Orgrimmar", .InGameOrder = 117, .IntID = 4, .IntID_Double = 3.65625, .BitOfInteger = 21, .Bit = 2097152}
    Private _151_ENG As New CharTitle With {.TitleID = 151, .UnkRef = 8242, .MaleTitle = "%s of Sen'jin", .FemaleTitle = "%s of Sen'jin", .InGameOrder = 118, .IntID = 4, .IntID_Double = 3.6875, .BitOfInteger = 22, .Bit = 4194304}
    Private _152_ENG As New CharTitle With {.TitleID = 152, .UnkRef = 8243, .MaleTitle = "%s of Silvermoon", .FemaleTitle = "%s of Silvermoon", .InGameOrder = 119, .IntID = 4, .IntID_Double = 3.71875, .BitOfInteger = 23, .Bit = 8388608}
    Private _153_ENG As New CharTitle With {.TitleID = 153, .UnkRef = 8244, .MaleTitle = "%s of Thunder Bluff", .FemaleTitle = "%s of Thunder Bluff", .InGameOrder = 120, .IntID = 4, .IntID_Double = 3.75, .BitOfInteger = 24, .Bit = 16777216}
    Private _154_ENG As New CharTitle With {.TitleID = 154, .UnkRef = 8245, .MaleTitle = "%s of the Undercity", .FemaleTitle = "%s of the Undercity", .InGameOrder = 121, .IntID = 4, .IntID_Double = 3.78125, .BitOfInteger = 25, .Bit = 33554432}
    Private _155_ENG As New CharTitle With {.TitleID = 155, .UnkRef = 8303, .MaleTitle = "%s the Noble", .FemaleTitle = "%s the Noble", .InGameOrder = 122, .IntID = 4, .IntID_Double = 3.8125, .BitOfInteger = 26, .Bit = 67108864}
    Private _156_ENG As New CharTitle With {.TitleID = 156, .UnkRef = 8332, .MaleTitle = "Crusader %s", .FemaleTitle = "Crusader %s", .InGameOrder = 123, .IntID = 4, .IntID_Double = 3.84375, .BitOfInteger = 27, .Bit = 134217728}
    Private _157_ENG As New CharTitle With {.TitleID = 157, .UnkRef = 0, .MaleTitle = "Deadly Gladiator %s", .FemaleTitle = "Deadly Gladiator %s", .InGameOrder = 56, .IntID = 2, .IntID_Double = 1.75, .BitOfInteger = 24, .Bit = 16777216}
    Private _158_ENG As New CharTitle With {.TitleID = 158, .UnkRef = 8450, .MaleTitle = "%s, Death's Demise", .FemaleTitle = "%s, Death's Demise", .InGameOrder = 124, .IntID = 4, .IntID_Double = 3.875, .BitOfInteger = 28, .Bit = 268435456}
    Private _159_ENG As New CharTitle With {.TitleID = 159, .UnkRef = 8451, .MaleTitle = "%s the Celestial Defender", .FemaleTitle = "%s the Celestial Defender", .InGameOrder = 125, .IntID = 4, .IntID_Double = 3.90625, .BitOfInteger = 29, .Bit = 536870912}
    Private _160_ENG As New CharTitle With {.TitleID = 160, .UnkRef = 8453, .MaleTitle = "%s, Conqueror of Ulduar", .FemaleTitle = "%s, Conqueror of Ulduar", .InGameOrder = 126, .IntID = 4, .IntID_Double = 3.9375, .BitOfInteger = 30, .Bit = 1073741824}
    Private _161_ENG As New CharTitle With {.TitleID = 161, .UnkRef = 8452, .MaleTitle = "%s, Champion of Ulduar", .FemaleTitle = "%s, Champion of Ulduar", .InGameOrder = 127, .IntID = 4, .IntID_Double = 3.96875, .BitOfInteger = 31, .Bit = 2147483648}
    Private _163_ENG As New CharTitle With {.TitleID = 163, .UnkRef = 0, .MaleTitle = "Vanquisher %s", .FemaleTitle = "Vanquisher %s", .InGameOrder = 128, .IntID = 4, .IntID_Double = 4, .BitOfInteger = 0, .Bit = 1}
    Private _164_ENG As New CharTitle With {.TitleID = 164, .UnkRef = 8467, .MaleTitle = "Starcaller %s", .FemaleTitle = "Starcaller %s", .InGameOrder = 129, .IntID = 4, .IntID_Double = 4.03125, .BitOfInteger = 1, .Bit = 2}
    Private _165_ENG As New CharTitle With {.TitleID = 165, .UnkRef = 8468, .MaleTitle = "%s the Astral Walker", .FemaleTitle = "%s the Astral Walker", .InGameOrder = 130, .IntID = 4, .IntID_Double = 4.0625, .BitOfInteger = 2, .Bit = 4}
    Private _166_ENG As New CharTitle With {.TitleID = 166, .UnkRef = 8469, .MaleTitle = "%s, Herald of the Titans", .FemaleTitle = " %s, Herald of the Titans", .InGameOrder = 131, .IntID = 4, .IntID_Double = 4.09375, .BitOfInteger = 3, .Bit = 8}
    Private _167_ENG As New CharTitle With {.TitleID = 167, .UnkRef = 0, .MaleTitle = "Furious Gladiator %s", .FemaleTitle = "Furious Gladiator %s", .InGameOrder = 132, .IntID = 4, .IntID_Double = 4.125, .BitOfInteger = 4, .Bit = 16}
    Private _168_ENG As New CharTitle With {.TitleID = 168, .UnkRef = 8596, .MaleTitle = "%s the Pilgrim", .FemaleTitle = "%s the Pilgrim", .InGameOrder = 133, .IntID = 4, .IntID_Double = 4.15625, .BitOfInteger = 5, .Bit = 32}
    Private _169_ENG As New CharTitle With {.TitleID = 169, .UnkRef = 0, .MaleTitle = "Relentless Gladiator %s", .FemaleTitle = "Relentless Gladiator %s", .InGameOrder = 134, .IntID = 4, .IntID_Double = 4.1875, .BitOfInteger = 6, .Bit = 64}
    Private _170_ENG As New CharTitle With {.TitleID = 170, .UnkRef = 8777, .MaleTitle = "Grand Crusader %s", .FemaleTitle = "Grand Crusader %s", .InGameOrder = 135, .IntID = 4, .IntID_Double = 4.21875, .BitOfInteger = 7, .Bit = 128}
    Private _171_ENG As New CharTitle With {.TitleID = 171, .UnkRef = 8778, .MaleTitle = "%s the Argent Defender", .FemaleTitle = "%s the Argent Defender", .InGameOrder = 136, .IntID = 4, .IntID_Double = 4.25, .BitOfInteger = 8, .Bit = 256}
    Private _172_ENG As New CharTitle With {.TitleID = 172, .UnkRef = 8977, .MaleTitle = "%s the Patient", .FemaleTitle = "%s the Patient", .InGameOrder = 137, .IntID = 4, .IntID_Double = 4.28125, .BitOfInteger = 9, .Bit = 512}
    Private _173_ENG As New CharTitle With {.TitleID = 173, .UnkRef = 9043, .MaleTitle = "%s the Light of Dawn", .FemaleTitle = "%s the Light of Dawn", .InGameOrder = 138, .IntID = 4, .IntID_Double = 4.3125, .BitOfInteger = 10, .Bit = 1024}
    Private _174_ENG As New CharTitle With {.TitleID = 174, .UnkRef = 9045, .MaleTitle = "%s, Bane of the Fallen King", .FemaleTitle = "%s, Bane of the Fallen King", .InGameOrder = 139, .IntID = 4, .IntID_Double = 4.34375, .BitOfInteger = 11, .Bit = 2048}
    Private _175_ENG As New CharTitle With {.TitleID = 175, .UnkRef = 9046, .MaleTitle = "%s the Kingslayer", .FemaleTitle = "%s the Kingslayer", .InGameOrder = 140, .IntID = 4, .IntID_Double = 4.375, .BitOfInteger = 12, .Bit = 4096}
    Private _176_ENG As New CharTitle With {.TitleID = 176, .UnkRef = 9138, .MaleTitle = "%s of the Ashen Verdict", .FemaleTitle = "%s of the Ashen Verdict", .InGameOrder = 141, .IntID = 4, .IntID_Double = 4.40625, .BitOfInteger = 13, .Bit = 8192}
    Private _177_ENG As New CharTitle With {.TitleID = 177, .UnkRef = 0, .MaleTitle = "Wrathful Gladiator %s", .FemaleTitle = "Wrathful Gladiator %s", .InGameOrder = 142, .IntID = 4, .IntID_Double = 4.4375, .BitOfInteger = 14, .Bit = 16384}
#End Region

    '// Charactertitles from DBC - DEUTSCH
#Region "CharTitles from DBC [GERMAN]"
    Private _1_GER As New CharTitle With {.TitleID = 1, .IntID = 0, .DBValue = "2 0 0 0 0 0", .Bit = 2, .MaleTitle = "Gefreiter %s"}
    Private _2_GER As New CharTitle With {.TitleID = 2, .IntID = 0, .DBValue = "4 0 0 0 0 0", .Bit = 4, .MaleTitle = "Fußknecht %s"}
    Private _3_GER As New CharTitle With {.TitleID = 3, .IntID = 0, .DBValue = "8 0 0 0 0 0", .Bit = 8, .MaleTitle = "Landsknecht %s"}
    Private _4_GER As New CharTitle With {.TitleID = 4, .IntID = 0, .DBValue = "16 0 0 0 0 0", .Bit = 16, .MaleTitle = "Feldwebel %s"}
    Private _5_GER As New CharTitle With {.TitleID = 5, .IntID = 0, .DBValue = "32 0 0 0 0 0", .Bit = 32, .MaleTitle = "Fähnrich %s"}
    Private _6_GER As New CharTitle With {.TitleID = 6, .IntID = 0, .DBValue = "64 0 0 0 0 0", .Bit = 64, .MaleTitle = "Leutnant %s"}
    Private _7_GER As New CharTitle With {.TitleID = 7, .IntID = 0, .DBValue = "128 0 0 0 0 0", .Bit = 128, .MaleTitle = "Hauptmann %s"}
    Private _8_GER As New CharTitle With {.TitleID = 8, .IntID = 0, .DBValue = "256 0 0 0 0 0", .Bit = 256, .MaleTitle = "Kürassier %s"}
    Private _9_GER As New CharTitle With {.TitleID = 9, .IntID = 0, .DBValue = "512 0 0 0 0 0", .Bit = 512, .MaleTitle = "Ritter der Allianz %s"}
    Private _10_GER As New CharTitle With {.TitleID = 10, .IntID = 0, .DBValue = "1024 0 0 0 0 0", .Bit = 1024, .MaleTitle = "Feldkommandant %s"}
    Private _11_GER As New CharTitle With {.TitleID = 11, .IntID = 0, .DBValue = "2048 0 0 0 0 0", .Bit = 2048, .MaleTitle = "Rittmeister %s"}
    Private _12_GER As New CharTitle With {.TitleID = 12, .IntID = 0, .DBValue = "4096 0 0 0 0 0", .Bit = 4096, .MaleTitle = "Marschall %s"}
    Private _13_GER As New CharTitle With {.TitleID = 13, .IntID = 0, .DBValue = "8192 0 0 0 0 0", .Bit = 8192, .MaleTitle = "Feldmarschall %s"}
    Private _14_GER As New CharTitle With {.TitleID = 14, .IntID = 0, .DBValue = "16384 0 0 0 0 0", .Bit = 16384, .MaleTitle = "Großmarschall %s"}
    Private _15_GER As New CharTitle With {.TitleID = 15, .IntID = 0, .DBValue = "32768 0 0 0 0 0", .Bit = 32768, .MaleTitle = "Späher %s"}
    Private _16_GER As New CharTitle With {.TitleID = 16, .IntID = 0, .DBValue = "65536 0 0 0 0 0", .Bit = 65536, .MaleTitle = "Grunzer %s"}
    Private _17_GER As New CharTitle With {.TitleID = 17, .IntID = 0, .DBValue = "131072 0 0 0 0 0", .Bit = 131072, .MaleTitle = "Waffenträger %s"}
    Private _18_GER As New CharTitle With {.TitleID = 18, .IntID = 0, .DBValue = "262144 0 0 0 0 0", .Bit = 262144, .MaleTitle = "Schlachtrufer %s"}
    Private _19_GER As New CharTitle With {.TitleID = 19, .IntID = 0, .DBValue = "524288 0 0 0 0 0", .Bit = 524288, .MaleTitle = "Rottenmeister %s"}
    Private _20_GER As New CharTitle With {.TitleID = 20, .IntID = 0, .DBValue = "1048576 0 0 0 0 0", .Bit = 1048576, .MaleTitle = "Steingardist %s"}
    Private _21_GER As New CharTitle With {.TitleID = 21, .IntID = 0, .DBValue = "2097152 0 0 0 0 0", .Bit = 2097152, .MaleTitle = "Blutgardis %s"}
    Private _22_GER As New CharTitle With {.TitleID = 22, .IntID = 0, .DBValue = "4194304 0 0 0 0 0", .Bit = 4194304, .MaleTitle = "Zornbringer %s"}
    Private _23_GER As New CharTitle With {.TitleID = 23, .IntID = 0, .DBValue = "8388608 0 0 0 0 0", .Bit = 8388608, .MaleTitle = "Klinge der Horde %s"}
    Private _24_GER As New CharTitle With {.TitleID = 24, .IntID = 0, .DBValue = "16777216 0 0 0 0 0", .Bit = 16777216, .MaleTitle = "Feldherr %s"}
    Private _25_GER As New CharTitle With {.TitleID = 25, .IntID = 0, .DBValue = "33554432 0 0 0 0 0", .Bit = 33554432, .MaleTitle = "Sturmreiter %s"}
    Private _26_GER As New CharTitle With {.TitleID = 26, .IntID = 0, .DBValue = "67108864 0 0 0 0 0", .Bit = 67108864, .MaleTitle = "Kriegsherr %s"}
    Private _27_GER As New CharTitle With {.TitleID = 27, .IntID = 0, .DBValue = "134217728 0 0 0 0 0", .Bit = 134217728, .MaleTitle = "Kriegsfürst %s"}
    Private _28_GER As New CharTitle With {.TitleID = 28, .IntID = 0, .DBValue = "268435456 0 0 0 0 0", .Bit = 268435456, .MaleTitle = "Oberster Kriegsfürst %s"}
    Private _42_GER As New CharTitle With {.TitleID = 42, .IntID = 0, .DBValue = "536870912 0 0 0 0 0", .Bit = 536870912, .MaleTitle = "Gladiator %s"}
    Private _43_GER As New CharTitle With {.TitleID = 43, .IntID = 0, .DBValue = "1073741824 0 0 0 0 0", .Bit = 1073741824, .MaleTitle = "Duellant %s"}
    Private _44_GER As New CharTitle With {.TitleID = 44, .IntID = 0, .DBValue = "2147483648 0 0 0 0 0", .Bit = 2147483648, .MaleTitle = "Rivale %s"}
    Private _45_GER As New CharTitle With {.TitleID = 45, .IntID = 1, .DBValue = "0 1 0 0 0 0", .Bit = 1, .MaleTitle = "Herausforderer %s"}
    Private _46_GER As New CharTitle With {.TitleID = 46, .IntID = 1, .DBValue = "0 2 0 0 0 0", .Bit = 2, .MaleTitle = "Skarabäusfürst %s"}
    Private _47_GER As New CharTitle With {.TitleID = 47, .IntID = 1, .DBValue = "0 4 0 0 0 0", .Bit = 4, .MaleTitle = "Eroberer %s"}
    Private _48_GER As New CharTitle With {.TitleID = 48, .IntID = 1, .DBValue = "0 8 0 0 0 0", .Bit = 8, .MaleTitle = "Vollstrecker %s"}
    Private _53_GER As New CharTitle With {.TitleID = 53, .IntID = 1, .DBValue = "0 16 0 0 0 0", .Bit = 16, .MaleTitle = "%s, Champion der Naaru"}
    Private _62_GER As New CharTitle With {.TitleID = 62, .IntID = 1, .DBValue = "0 32 0 0 0 0", .Bit = 32, .MaleTitle = "Erbarmungsloser Gladiator %s"}
    Private _63_GER As New CharTitle With {.TitleID = 63, .IntID = 1, .DBValue = "0 64 0 0 0 0", .Bit = 64, .MaleTitle = "%s von der Zerschmetterten Sonne"}
    Private _64_GER As New CharTitle With {.TitleID = 64, .IntID = 1, .DBValue = "0 128 0 0 0 0", .Bit = 128, .MaleTitle = "%s, Hand von A'dal"}
    Private _71_GER As New CharTitle With {.TitleID = 71, .IntID = 1, .DBValue = "0 256 0 0 0 0", .Bit = 256, .MaleTitle = "Rachsüchtiger Gladiator %s"}
    Private _72_GER As New CharTitle With {.TitleID = 72, .IntID = 1, .DBValue = "0 512 0 0 0 0", .Bit = 512, .MaleTitle = "Kampfmeister %s"}
    Private _74_GER As New CharTitle With {.TitleID = 74, .IntID = 1, .DBValue = "0 2048 0 0 0 0", .Bit = 2048, .MaleTitle = "Ältester %s"}
    Private _75_GER As New CharTitle With {.TitleID = 75, .IntID = 1, .DBValue = "0 4096 0 0 0 0", .Bit = 4096, .MaleTitle = "Flammenwächter %s"}
    Private _76_GER As New CharTitle With {.TitleID = 76, .IntID = 1, .DBValue = "0 8192 0 0 0 0", .Bit = 8192, .MaleTitle = "Flammenbewahrer %s"}
    Private _77_GER As New CharTitle With {.TitleID = 77, .IntID = 1, .DBValue = "0 16384 0 0 0 0", .Bit = 16384, .MaleTitle = "%s der Ehrfurchtgebietende"}
    Private _78_GER As New CharTitle With {.TitleID = 78, .IntID = 1, .DBValue = "0 32768 0 0 0 0", .Bit = 32768, .MaleTitle = "%s der Entdecker"}
    Private _79_GER As New CharTitle With {.TitleID = 79, .IntID = 1, .DBValue = "0 65536 0 0 0 0", .Bit = 65536, .MaleTitle = "Diplomat %s"}
    Private _80_GER As New CharTitle With {.TitleID = 80, .IntID = 1, .DBValue = "0 131072 0 0 0 0", .Bit = 131072, .MaleTitle = "Brutaler Gladiator %s"}
    Private _81_GER As New CharTitle With {.TitleID = 81, .IntID = 1, .DBValue = "0 1024 0 0 0 0", .Bit = 1024, .MaleTitle = "%s der Unermüdliche"}
    Private _82_GER As New CharTitle With {.TitleID = 82, .IntID = 1, .DBValue = "0 262144 0 0 0 0", .Bit = 262144, .MaleTitle = "Arenameister %s"}
    Private _83_GER As New CharTitle With {.TitleID = 83, .IntID = 1, .DBValue = "0 524288 0 0 0 0", .Bit = 524288, .MaleTitle = "%s, Schrecken der Meere"}
    Private _84_GER As New CharTitle With {.TitleID = 84, .IntID = 1, .DBValue = "0 1048576 0 0 0 0", .Bit = 1048576, .MaleTitle = "Chefkoch %s"}
    Private _85_GER As New CharTitle With {.TitleID = 85, .IntID = 1, .DBValue = "0 2097152 0 0 0 0", .Bit = 2097152, .MaleTitle = "%s der Große"}
    Private _86_GER As New CharTitle With {.TitleID = 86, .IntID = 1, .DBValue = "0 4194304 0 0 0 0", .Bit = 4194304, .MaleTitle = "%s von den zehn Stürmen"}
    Private _87_GER As New CharTitle With {.TitleID = 87, .IntID = 1, .DBValue = "0 8388608 0 0 0 0", .Bit = 8388608, .MaleTitle = "%s vom Smaragdgrünen Traum"}
    Private _89_GER As New CharTitle With {.TitleID = 89, .IntID = 1, .DBValue = "0 33554432 0 0 0 0", .Bit = 33554432, .MaleTitle = "Prophet %s"}
    Private _90_GER As New CharTitle With {.TitleID = 90, .IntID = 1, .DBValue = "0 67108864 0 0 0 0", .Bit = 67108864, .MaleTitle = "%s der Bösartige"}
    Private _91_GER As New CharTitle With {.TitleID = 91, .IntID = 1, .DBValue = "0 134217728 0 0 0 0", .Bit = 134217728, .MaleTitle = "Pirscher %s"}
    Private _92_GER As New CharTitle With {.TitleID = 92, .IntID = 1, .DBValue = "0 268435456 0 0 0 0", .Bit = 268435456, .MaleTitle = "%s von der Schwarzen Klinge"}
    Private _93_GER As New CharTitle With {.TitleID = 93, .IntID = 1, .DBValue = "0 536870912 0 0 0 0", .Bit = 536870912, .MaleTitle = "Erzmagier %s"}
    Private _94_GER As New CharTitle With {.TitleID = 94, .IntID = 1, .DBValue = "0 1073741824 0 0 0 0", .Bit = 1073741824, .MaleTitle = "Kriegshetzer %s"}
    Private _95_GER As New CharTitle With {.TitleID = 95, .IntID = 1, .DBValue = "0 2147483648 0 0 0 0", .Bit = 2147483648, .MaleTitle = "Assassine %s"}
    Private _96_GER As New CharTitle With {.TitleID = 96, .IntID = 2, .DBValue = "0 0 1 0 0 0", .Bit = 1, .MaleTitle = "%s, Großmeister der Alchemie"}
    Private _97_GER As New CharTitle With {.TitleID = 97, .IntID = 2, .DBValue = "0 0 2 0 0 0", .Bit = 2, .MaleTitle = "%s, Großmeister der Schmiedekunst"}
    Private _98_GER As New CharTitle With {.TitleID = 98, .IntID = 2, .DBValue = "0 0 4 0 0 0", .Bit = 4, .MaleTitle = "Eiserner Chefkoch %s"}
    Private _99_GER As New CharTitle With {.TitleID = 99, .IntID = 2, .DBValue = "0 0 8 0 0 0", .Bit = 8, .MaleTitle = "%s, Großmeister der Verzauberkunst"}
    Private _100_GER As New CharTitle With {.TitleID = 100, .IntID = 2, .DBValue = "0 0 16 0 0 0", .Bit = 16, .MaleTitle = "%s, Ingenieursgroßmeister"}
    Private _101_GER As New CharTitle With {.TitleID = 101, .IntID = 2, .DBValue = "0 0 32 0 0 0", .Bit = 32, .MaleTitle = "Doktor %s"}
    Private _102_GER As New CharTitle With {.TitleID = 102, .IntID = 2, .DBValue = "0 0 64 0 0 0", .Bit = 64, .MaleTitle = "%s, Großmeister des Angelns"}
    Private _103_GER As New CharTitle With {.TitleID = 103, .IntID = 2, .DBValue = "0 0 128 0 0 0", .Bit = 128, .MaleTitle = "%s, Großmeister der Kräuterkunde"}
    Private _104_GER As New CharTitle With {.TitleID = 104, .IntID = 2, .DBValue = "0 0 256 0 0 0", .Bit = 256, .MaleTitle = "%s, Großmeister der Inschriftenkunde"}
    Private _105_GER As New CharTitle With {.TitleID = 105, .IntID = 2, .DBValue = "0 0 512 0 0 0", .Bit = 512, .MaleTitle = "%s, Großmeister der Juwelierskunst"}
    Private _106_GER As New CharTitle With {.TitleID = 106, .IntID = 2, .DBValue = "0 0 1024 0 0 0", .Bit = 1024, .MaleTitle = "%s, Großmeister der Lederverarbeitung"}
    Private _107_GER As New CharTitle With {.TitleID = 107, .IntID = 2, .DBValue = "0 0 2048 0 0 0", .Bit = 2048, .MaleTitle = "%s, Großmeister des Bergbaus"}
    Private _108_GER As New CharTitle With {.TitleID = 108, .IntID = 2, .DBValue = "0 0 4096 0 0 0", .Bit = 4096, .MaleTitle = "%s, Großmeister der Kürschnerei"}
    Private _109_GER As New CharTitle With {.TitleID = 109, .IntID = 2, .DBValue = "0 0 8192 0 0 0", .Bit = 8192, .MaleTitle = "%s, Großmeister der Schneiderei"}
    Private _110_GER As New CharTitle With {.TitleID = 110, .IntID = 2, .DBValue = "0 0 16384 0 0 0", .Bit = 16384, .MaleTitle = "%s von Quel'Thalas"}
    Private _111_GER As New CharTitle With {.TitleID = 111, .IntID = 2, .DBValue = "0 0 32768 0 0 0", .Bit = 32768, .MaleTitle = "%s von Argus"}
    Private _112_GER As New CharTitle With {.TitleID = 112, .IntID = 2, .DBValue = "0 0 65536 0 0 0", .Bit = 65536, .MaleTitle = "%s von Khaz Modan"}
    Private _113_GER As New CharTitle With {.TitleID = 113, .IntID = 2, .DBValue = "0 0 131072 0 0 0", .Bit = 131072, .MaleTitle = "%s von Gnomeregan"}
    Private _114_GER As New CharTitle With {.TitleID = 114, .IntID = 2, .DBValue = "0 0 262144 0 0 0", .Bit = 262144, .MaleTitle = "%s Löwenherz"}
    Private _115_GER As New CharTitle With {.TitleID = 115, .IntID = 2, .DBValue = "0 0 524288 0 0 0", .Bit = 524288, .MaleTitle = "%s, Elunes Champion"}
    Private _116_GER As New CharTitle With {.TitleID = 116, .IntID = 2, .DBValue = "0 0 1048576 0 0 0", .Bit = 1048576, .MaleTitle = "%s, Held von Orgrimmar"}
    Private _117_GER As New CharTitle With {.TitleID = 117, .IntID = 2, .DBValue = "0 0 2097152 0 0 0", .Bit = 2097152, .MaleTitle = "Ebenenläufer %s"}
    Private _118_GER As New CharTitle With {.TitleID = 118, .IntID = 2, .DBValue = "0 0 4194304 0 0 0", .Bit = 4194304, .MaleTitle = "%s von den Dunkelspeer"}
    Private _119_GER As New CharTitle With {.TitleID = 119, .IntID = 2, .DBValue = "0 0 8388608 0 0 0", .Bit = 8388608, .MaleTitle = "%s von den Verlassenen"}
    Private _120_GER As New CharTitle With {.TitleID = 120, .IntID = 2, .DBValue = "0 0 16777216 0 0 0", .Bit = 16777216, .MaleTitle = "%s der Magiesuchende"}
    Private _121_GER As New CharTitle With {.TitleID = 121, .IntID = 2, .DBValue = "0 0 33554432 0 0 0", .Bit = 33554432, .MaleTitle = "Zwielichtbezwinger %s"}
    Private _122_GER As New CharTitle With {.TitleID = 122, .IntID = 2, .DBValue = "0 0 67108864 0 0 0", .Bit = 67108864, .MaleTitle = "%s, Bezwinger von Naxxramas"}
    Private _123_GER As New CharTitle With {.TitleID = 123, .IntID = 2, .DBValue = "0 0 134217728 0 0 0", .Bit = 134217728, .MaleTitle = "%s, Held Nordends"}
    Private _124_GER As New CharTitle With {.TitleID = 124, .IntID = 2, .DBValue = "0 0 268435456 0 0 0", .Bit = 268435456, .MaleTitle = "Nachtschrecken %s"}
    Private _125_GER As New CharTitle With {.TitleID = 125, .IntID = 2, .DBValue = "0 0 536870912 0 0 0", .Bit = 536870912, .MaleTitle = "Meister der Lehren %s"}
    Private _126_GER As New CharTitle With {.TitleID = 126, .IntID = 2, .DBValue = "0 0 1073741824 0 0 0", .Bit = 1073741824, .MaleTitle = "%s von der Allianz"}
    Private _127_GER As New CharTitle With {.TitleID = 127, .IntID = 2, .DBValue = "0 0 2147483648 0 0 0", .Bit = 2147483648, .MaleTitle = "%s von der Horde"}
    Private _128_GER As New CharTitle With {.TitleID = 128, .IntID = 3, .DBValue = "0 0 0 1 0 0", .Bit = 1, .MaleTitle = "Triumphator %s"}
    Private _129_GER As New CharTitle With {.TitleID = 129, .IntID = 3, .DBValue = "0 0 0 2 0 0", .Bit = 2, .MaleTitle = "%s, Held der eisigen Weiten"}
    Private _130_GER As New CharTitle With {.TitleID = 130, .IntID = 3, .DBValue = "0 0 0 4 0 0", .Bit = 4, .MaleTitle = "Botschafter %s"}
    Private _131_GER As New CharTitle With {.TitleID = 131, .IntID = 3, .DBValue = "0 0 0 8 0 0", .Bit = 8, .MaleTitle = "%s der Argentumchampion"}
    Private _132_GER As New CharTitle With {.TitleID = 132, .IntID = 3, .DBValue = "0 0 0 16 0 0", .Bit = 16, .MaleTitle = "%s, Wächter des Cenarius"}
    Private _133_GER As New CharTitle With {.TitleID = 133, .IntID = 3, .DBValue = "0 0 0 32 0 0", .Bit = 32, .MaleTitle = "Braumeister %s"}
    Private _134_GER As New CharTitle With {.TitleID = 134, .IntID = 3, .DBValue = "0 0 0 64 0 0", .Bit = 64, .MaleTitle = "Winterhauchengel %s"}
    Private _135_GER As New CharTitle With {.TitleID = 135, .IntID = 3, .DBValue = "0 0 0 128 0 0", .Bit = 128, .MaleTitle = "Liebesgott %s"}
    Private _137_GER As New CharTitle With {.TitleID = 137, .IntID = 3, .DBValue = "0 0 0 256 0 0", .Bit = 256, .MaleTitle = "Patron %s"}
    Private _138_GER As New CharTitle With {.TitleID = 138, .IntID = 3, .DBValue = "0 0 0 512 0 0", .Bit = 512, .MaleTitle = "Patron %s"}
    Private _139_GER As New CharTitle With {.TitleID = 139, .IntID = 3, .DBValue = "0 0 0 1024 0 0", .Bit = 1024, .MaleTitle = "Obsidianvernichter %s"}
    Private _140_GER As New CharTitle With {.TitleID = 140, .IntID = 3, .DBValue = "0 0 0 2048 0 0", .Bit = 2048, .MaleTitle = "Nachtherr %s"}
    Private _141_GER As New CharTitle With {.TitleID = 141, .IntID = 3, .DBValue = "0 0 0 4096 0 0", .Bit = 4096, .MaleTitle = "%s der Unsterbliche"}
    Private _142_GER As New CharTitle With {.TitleID = 142, .IntID = 3, .DBValue = "0 0 0 8192 0 0", .Bit = 8192, .MaleTitle = "%s der Unverwüstliche"}
    Private _143_GER As New CharTitle With {.TitleID = 143, .IntID = 3, .DBValue = "0 0 0 16384 0 0", .Bit = 16384, .MaleTitle = "%s Jenkins"}
    Private _144_GER As New CharTitle With {.TitleID = 144, .IntID = 3, .DBValue = "0 0 0 32768 0 0", .Bit = 32768, .MaleTitle = "Blutsegeladmiral %s"}
    Private _145_GER As New CharTitle With {.TitleID = 145, .IntID = 3, .DBValue = "0 0 0 65536 0 0", .Bit = 65536, .MaleTitle = "%s der Wahnsinnige"}
    Private _146_GER As New CharTitle With {.TitleID = 146, .IntID = 3, .DBValue = "0 0 0 131072 0 0", .Bit = 131072, .MaleTitle = "%s von der Exodar"}
    Private _147_GER As New CharTitle With {.TitleID = 147, .IntID = 3, .DBValue = "0 0 0 262144 0 0", .Bit = 262144, .MaleTitle = "%s von Darnassus"}
    Private _148_GER As New CharTitle With {.TitleID = 148, .IntID = 3, .DBValue = "0 0 0 524288 0 0", .Bit = 524288, .MaleTitle = "%s von Eisenschmiede"}
    Private _149_GER As New CharTitle With {.TitleID = 149, .IntID = 3, .DBValue = "0 0 0 1048576 0 0", .Bit = 1048576, .MaleTitle = "%s von Sturmwind"}
    Private _150_GER As New CharTitle With {.TitleID = 150, .IntID = 3, .DBValue = "0 0 0 2097152 0 0", .Bit = 2097152, .MaleTitle = "%s von Orgrimmar"}
    Private _151_GER As New CharTitle With {.TitleID = 151, .IntID = 3, .DBValue = "0 0 0 4194304 0 0", .Bit = 4194304, .MaleTitle = "%s von Sen'jin"}
    Private _152_GER As New CharTitle With {.TitleID = 152, .IntID = 3, .DBValue = "0 0 0 8388608 0 0", .Bit = 8388608, .MaleTitle = "%s von Silbermond"}
    Private _153_GER As New CharTitle With {.TitleID = 153, .IntID = 3, .DBValue = "0 0 0 16777216 0 0", .Bit = 16777216, .MaleTitle = "%s von Donnerfels"}
    Private _154_GER As New CharTitle With {.TitleID = 154, .IntID = 3, .DBValue = "0 0 0 33554432 0 0", .Bit = 33554432, .MaleTitle = "%s von Unterstadt"}
    Private _155_GER As New CharTitle With {.TitleID = 155, .IntID = 3, .DBValue = "0 0 0 67108864 0 0", .Bit = 67108864, .MaleTitle = "%s der Noble"}
    Private _156_GER As New CharTitle With {.TitleID = 156, .IntID = 3, .DBValue = "0 0 0 134217728 0 0", .Bit = 134217728, .MaleTitle = "Kreuzfahrer %s"}
    Private _157_GER As New CharTitle With {.TitleID = 157, .IntID = 1, .DBValue = "0 16777216 0 0 0 0", .Bit = 16777216, .MaleTitle = "Tödlicher Gladiator %s"}
    Private _158_GER As New CharTitle With {.TitleID = 158, .IntID = 3, .DBValue = "0 0 0 268435456 0 0", .Bit = 268435456, .MaleTitle = "Todesbote %s"}
    Private _159_GER As New CharTitle With {.TitleID = 159, .IntID = 3, .DBValue = "0 0 0 536870912 0 0", .Bit = 536870912, .MaleTitle = "%s der Himmelsverteidiger"}
    Private _160_GER As New CharTitle With {.TitleID = 160, .IntID = 3, .DBValue = "0 0 0 1073741824 0 0", .Bit = 1073741824, .MaleTitle = "%s, Eroberer von Ulduar"}
    Private _161_GER As New CharTitle With {.TitleID = 161, .IntID = 3, .DBValue = "0 0 0 2147483648 0 0", .Bit = 2147483648, .MaleTitle = "%s, Champion von Ulduar"}
    Private _163_GER As New CharTitle With {.TitleID = 163, .IntID = 4, .DBValue = "0 0 0 0 1 0", .Bit = 1, .MaleTitle = "Bezwinger %s"}
    Private _164_GER As New CharTitle With {.TitleID = 164, .IntID = 4, .DBValue = "0 0 0 0 2 0", .Bit = 2, .MaleTitle = "Sternenrufer %s"}
    Private _165_GER As New CharTitle With {.TitleID = 165, .IntID = 4, .DBValue = "0 0 0 0 4 0", .Bit = 4, .MaleTitle = "Astralwandler %s"}
    Private _166_GER As New CharTitle With {.TitleID = 166, .IntID = 4, .DBValue = "0 0 0 0 8 0", .Bit = 8, .MaleTitle = "%s, Herold der Titanen"}
    Private _167_GER As New CharTitle With {.TitleID = 167, .IntID = 4, .DBValue = "0 0 0 0 16 0", .Bit = 16, .MaleTitle = "Wütender Gladiator %s"}
    Private _168_GER As New CharTitle With {.TitleID = 168, .IntID = 4, .DBValue = "0 0 0 0 32 0", .Bit = 32, .MaleTitle = "%s der Pilger"}
    Private _169_GER As New CharTitle With {.TitleID = 169, .IntID = 4, .DBValue = "0 0 0 0 64 0", .Bit = 64, .MaleTitle = "Unerbittlicher Gladiator %s"}
    Private _170_GER As New CharTitle With {.TitleID = 170, .IntID = 4, .DBValue = "0 0 0 0 128 0", .Bit = 128, .MaleTitle = "Oberster Kreuzfahrer %s"}
    Private _171_GER As New CharTitle With {.TitleID = 171, .IntID = 4, .DBValue = "0 0 0 0 256 0", .Bit = 256, .MaleTitle = "%s der Argentumverteidiger"}
    Private _172_GER As New CharTitle With {.TitleID = 172, .IntID = 4, .DBValue = "0 0 0 0 512 0", .Bit = 512, .MaleTitle = "%s der Geduldige"}
    Private _173_GER As New CharTitle With {.TitleID = 173, .IntID = 4, .DBValue = "0 0 0 0 1024 0", .Bit = 1024, .MaleTitle = "%s, das Licht des Morgens"}
    Private _174_GER As New CharTitle With {.TitleID = 174, .IntID = 4, .DBValue = "0 0 0 0 2048 0", .Bit = 2048, .MaleTitle = "%s, Bezwinger des gefallenen Königs"}
    Private _175_GER As New CharTitle With {.TitleID = 175, .IntID = 4, .DBValue = "0 0 0 0 4096 0", .Bit = 4096, .MaleTitle = "%s der Königsmörder"}
    Private _176_GER As New CharTitle With {.TitleID = 176, .IntID = 4, .DBValue = "0 0 0 0 8192 0", .Bit = 8192, .MaleTitle = "%s vom Äschernen Verdikt"}
    Private _177_GER As New CharTitle With {.TitleID = 177, .IntID = 4, .DBValue = "0 0 0 0 16384 0", .Bit = 16384, .MaleTitle = "Zornerfüllter Gladiator %s"}
#End Region

    '// List of CharTitles - ENGLISCH
    Public ReadOnly _TitleList_All_ENG As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_1_ENG, _2_ENG, _3_ENG, _4_ENG, _5_ENG, _6_ENG, _7_ENG, _8_ENG, _9_ENG, _10_ENG, _11_ENG, _12_ENG, _13_ENG, _14_ENG, _15_ENG, _16_ENG, _17_ENG, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _42, _43, _44, _45, _46, _47, _48, _53, _62, _63, _64, _71, _72, _74, _75, _76, _77, _78, _79, _80, _81, _82_ENG, _83_ENG, _84_ENG, _85_ENG, _86_ENG, _87_ENG, _89_ENG, _90_ENG, _91_ENG, _92_ENG, _93_ENG, _94_ENG, _95_ENG, _96_ENG, _97_ENG, _98_ENG, _99_ENG, _100_ENG, _101, _102, _103, _104, _105, _106, _107, _108, _109, _110, _111, _112, _113, _114, _115, _116, _117_ENG, _118_ENG, _119_ENG, _120_ENG, _121_ENG, _122_ENG, _123_ENG, _124_ENG, _125_ENG, _126_ENG, _127_ENG, _128_ENG, _129_ENG, _130_ENG, _131_ENG, _132_ENG, _133_ENG, _134_ENG, _135_ENG, _137_ENG, _138_ENG, _139_ENG, _140_ENG, _141_ENG, _142_ENG, _143_ENG, _144_ENG, _145_ENG, _146_ENG, _147_ENG, _148_ENG, _149_ENG, _150_ENG, _151_ENG, _152_ENG, _153_ENG, _154_ENG, _155_ENG, _156_ENG, _157_ENG, _158_ENG, _159_ENG, _160_ENG, _161_ENG, _163_ENG, _164_ENG, _165_ENG, _166_ENG, _167_ENG, _168_ENG, _169_ENG, _170_ENG, _171_ENG, _172_ENG, _173_ENG, _174_ENG, _175_ENG, _176_ENG, _177_ENG})

    Public ReadOnly _TitleList_INT_0_ENG As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_1_ENG, _2_ENG, _3_ENG, _4_ENG, _5_ENG, _6_ENG, _7_ENG, _8_ENG, _9_ENG, _10_ENG, _11_ENG, _12_ENG, _13_ENG, _14_ENG, _15_ENG, _16_ENG})
    Public ReadOnly _TitleList_INT_1_ENG As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_17_ENG, _18, _19, _20, _21, _22, _23, _24, _25, _26, _27, _28, _42, _43, _44, _45, _46, _47, _48, _53, _62, _63, _64, _71, _72, _74, _75, _76, _77, _78, _81})
    Public ReadOnly _TitleList_INT_2_ENG As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_79, _80, _82_ENG, _83_ENG, _84_ENG, _85_ENG, _86_ENG, _87_ENG, _89_ENG, _90_ENG, _91_ENG, _92_ENG, _93_ENG, _94_ENG, _95_ENG, _96_ENG, _97_ENG, _98_ENG, _99_ENG, _100_ENG, _101, _102, _103, _104, _105, _106, _107, _108, _109, _110, _111, _112, _157_ENG})
    Public ReadOnly _TitleList_INT_3_ENG As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_113, _114, _115, _116, _117_ENG, _118_ENG, _119_ENG, _120_ENG, _121_ENG, _122_ENG, _123_ENG, _124_ENG, _125_ENG, _126_ENG, _127_ENG, _128_ENG, _129_ENG, _130_ENG, _131_ENG, _132_ENG, _133_ENG, _134_ENG, _135_ENG, _137_ENG, _138_ENG, _139_ENG, _140_ENG, _141_ENG, _142_ENG, _143_ENG, _144_ENG})
    Public ReadOnly _TitleList_INT_4_ENG As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_145_ENG, _146_ENG, _147_ENG, _148_ENG, _149_ENG, _150_ENG, _151_ENG, _152_ENG, _153_ENG, _154_ENG, _155_ENG, _156_ENG, _158_ENG, _159_ENG, _160_ENG, _161_ENG, _163_ENG, _164_ENG, _165_ENG, _166_ENG, _167_ENG, _168_ENG, _169_ENG, _170_ENG, _171_ENG, _172_ENG, _173_ENG, _174_ENG, _175_ENG, _176_ENG, _177_ENG})

    '// List of CharTitle  DEUTSCH
    Public ReadOnly _TitleList_All_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_1_GER, _2_GER, _3_GER, _4_GER, _5_GER, _6_GER, _7_GER, _8_GER, _9_GER, _10_GER, _11_GER, _12_GER, _13_GER, _14_GER, _15_GER, _16_GER, _17_GER, _18_GER, _19_GER, _20_GER, _21_GER, _22_GER, _23_GER, _24_GER, _25_GER, _26_GER, _27_GER, _28_GER, _42_GER, _43_GER, _44_GER, _45_GER, _46_GER, _47_GER, _48_GER, _53_GER, _62_GER, _63_GER, _64_GER, _71_GER, _72_GER, _74_GER, _75_GER, _76_GER, _77_GER, _78_GER, _79_GER, _80_GER, _81_GER, _82_GER, _83_GER, _84_GER, _85_GER, _86_GER, _87_GER, _89_GER, _90_GER, _91_GER, _92_GER, _93_GER, _94_GER, _95_GER, _96_GER, _97_GER, _98_GER, _99_GER, _100_GER, _101_GER, _102_GER, _103_GER, _104_GER, _105_GER, _106_GER, _107_GER, _108_GER, _109_GER, _110_GER, _111_GER, _112_GER, _113_GER, _114_GER, _115_GER, _116_GER, _117_GER, _118_GER, _119_GER, _120_GER, _121_GER, _122_GER, _123_GER, _124_GER, _125_GER, _126_GER, _127_GER, _128_GER, _129_GER, _130_GER, _131_GER, _132_GER, _133_GER, _134_GER, _135_GER, _137_GER, _138_GER, _139_GER, _140_GER, _141_GER, _142_GER, _143_GER, _144_GER, _145_GER, _146_GER, _147_GER, _148_GER, _149_GER, _150_GER, _151_GER, _152_GER, _153_GER, _154_GER, _155_GER, _156_GER, _157_GER, _158_GER, _159_GER, _160_GER, _161_GER, _163_GER, _164_GER, _165_GER, _166_GER, _167_GER, _168_GER, _169_GER, _170_GER, _171_GER, _172_GER, _173_GER, _174_GER, _175_GER, _176_GER, _177_GER})

    Public ReadOnly _TitleList_INT_0_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_1_GER, _2_GER, _3_GER, _4_GER, _5_GER, _6_GER, _7_GER, _8_GER, _9_GER, _10_GER, _11_GER, _12_GER, _13_GER, _14_GER, _15_GER, _16_GER, _17_GER, _18_GER, _19_GER, _20_GER, _21_GER, _22_GER, _23_GER, _24_GER, _25_GER, _26_GER, _27_GER, _28_GER, _42_GER, _43_GER, _44_GER})
    Public ReadOnly _TitleList_INT_1_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_45_GER, _46_GER, _47_GER, _48_GER, _53_GER, _62_GER, _63_GER, _64_GER, _71_GER, _72_GER, _74_GER, _75_GER, _76_GER, _77_GER, _78_GER, _79_GER, _80_GER, _81_GER, _82_GER, _83_GER, _84_GER, _85_GER, _86_GER, _87_GER, _89_GER, _90_GER, _91_GER, _92_GER, _93_GER, _94_GER, _95_GER, _157_GER})
    Public ReadOnly _TitleList_INT_2_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_96_GER, _97_GER, _98_GER, _99_GER, _100_GER, _101_GER, _102_GER, _103_GER, _104_GER, _105_GER, _106_GER, _107_GER, _108_GER, _109_GER, _110_GER, _111_GER, _112_GER, _113_GER, _114_GER, _115_GER, _116_GER, _117_GER, _118_GER, _119_GER, _120_GER, _121_GER, _122_GER, _123_GER, _124_GER, _125_GER, _126_GER, _127_GER})
    Public ReadOnly _TitleList_INT_3_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_128_GER, _129_GER, _130_GER, _131_GER, _132_GER, _133_GER, _134_GER, _135_GER, _137_GER, _138_GER, _139_GER, _140_GER, _141_GER, _142_GER, _143_GER, _144_GER, _145_GER, _146_GER, _147_GER, _148_GER, _149_GER, _150_GER, _151_GER, _152_GER, _153_GER, _154_GER, _155_GER, _156_GER, _158_GER, _159_GER, _160_GER, _161_GER})
    Public ReadOnly _TitleList_INT_4_GER As List(Of CharTitle) = New List(Of CharTitle)(New CharTitle() {_163_GER, _164_GER, _165_GER, _166_GER, _167_GER, _168_GER, _169_GER, _170_GER, _171_GER, _172_GER, _173_GER, _174_GER, _175_GER, _176_GER, _177_GER})

End Module
