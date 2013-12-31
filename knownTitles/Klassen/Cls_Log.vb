Option Explicit On
Option Strict On

Public Class Cls_Log

    ' Braucht: CharTitle

    ' Suchen:
    ' AddInlineReport("FOUND | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)

    ' Finden:
    ' AddInlineReport("MATCHES | BIT: " + _AffectedTitle.Bit.ToString + " | INT: " + _AffectedTitle.IntID.ToString + " | IntBit: " + _AffectedTitle.BitOfInteger.ToString + " | TitleID: " + _AffectedTitle.TitleID.ToString + " | UnkRef: " + _AffectedTitle.UnkRef.ToString + " | MaleTitle: " + _AffectedTitle.MaleTitle + " | FemaleTitle: " + _AffectedTitle.FemaleTitle + " | InGameOrder: " + _AffectedTitle.InGameOrder.ToString)
    ' AddInlineReport("FOUND | BIT: " + _AffectedTitle.Bit.ToString + " | INT: " + _AffectedTitle.IntID.ToString + " | IntBit: " + _AffectedTitle.BitOfInteger.ToString + " | TitleID: " + _AffectedTitle.TitleID.ToString + " | UnkRef: " + _AffectedTitle.UnkRef.ToString + " | MaleTitle: " + _AffectedTitle.MaleTitle + " | FemaleTitle: " + _AffectedTitle.FemaleTitle + " | InGameOrder: " + _AffectedTitle.InGameOrder.ToString)

    ' Entfernen:
    ' AddInlineReport("GRANTED | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)
    ' AddInlineReport("REMOVED | BIT: " + _FoundTitle.Bit.ToString + " | INT: " + _FoundTitle.IntID.ToString + " | IntBit: " + _FoundTitle.BitOfInteger.ToString + " | TitleID: " + _FoundTitle.TitleID.ToString + " | UnkRef: " + _FoundTitle.UnkRef.ToString + " | MaleTitle: " + _FoundTitle.MaleTitle + " | FemaleTitle: " + _FoundTitle.FemaleTitle + " | InGameOrder: " + _FoundTitle.InGameOrder.ToString)

    ' Braucht: Nichts

    ' Header bei allen:
    'AddInlineReport("____________________________________________________________________________________" + vbCrLf + _
    '                "// CHARACTER TITLE DATA" + vbCrLf)

    ' Braucht: Character anhand den Infos wird das abgeändert:

    ' Generierte Charakterinfos:
    ' Dim _Output As String = vbCrLf + "Name: " + _Character.Name + _
    '                             " | Account ID: " + _Character.AccountID.ToString + _
    '                             " | GUID: " + _Character.GUID.ToString + _
    '                             " | INT_0: " + _Character.INT_0.ToString + _
    '                             " | INT_1: " + _Character.INT_1.ToString + _
    '                             " | INT_2: " + _Character.INT_2.ToString + _
    '                             " | INT_3: " + _Character.INT_3.ToString + _
    '                             " | INT_4: " + _Character.INT_4.ToString




#Region "Deklarationen"

#End Region

    Public Sub New()
    End Sub

    'Public Function Strg_HEADER() As String

    'End Function

    'Public Function Strg_FOUND(_CharTitle As CharTitle) As String

    'End Function

    'Public Function Strg_MATCHES(_CharTitle As CharTitle) As String

    'End Function

    'Public Function Strg_REMOVED(_CharTitle As CharTitle) As String

    'End Function

End Class
