Module Location_Mod


    Private _Loc_gbBannedAddedTitels,
            _Loc_gbPlayerInput,
            _Loc_gbOutput,
            _Loc_btnWhichTitle,
            _Loc_btnRemove,
            _Loc_btnAdd As Point

    Private _Sz_gbBannedAddedTitels,
            _Sz_gbPlayerInput,
            _Sz_gbOutput,
            _Sz_clbBannedAddedTitel,
            _Sz_tbPlayerInput,
            _Sz_tbPlayerOutput As Size

    Public Sub setPoint(PointCollection() As Point)
        _Loc_btnAdd = PointCollection(0)
        _Loc_btnRemove = PointCollection(1)
        _Loc_btnWhichTitle = PointCollection(2)
        _Loc_gbBannedAddedTitels = PointCollection(3)
        _Loc_gbOutput = PointCollection(4)
        _Loc_gbPlayerInput = PointCollection(5)
    End Sub
    Public Sub setSize(SizeCollection() As Size)
        _Sz_clbBannedAddedTitel = SizeCollection(0)
        _Sz_gbBannedAddedTitels = SizeCollection(1)
        _Sz_gbOutput = SizeCollection(2)
        _Sz_gbPlayerInput = SizeCollection(3)
        _Sz_tbPlayerInput = SizeCollection(4)
        _Sz_tbPlayerOutput = SizeCollection(5)
    End Sub

End Module
