using Godot;
using System;

public partial class MaskedGrid : Grid
{
    public Grid mask;
    public override bool isInOtherParameter(int X, int Y)
    {
        return isInMask(X,Y);
    }

    public bool isInMask(int X, int Y)
    {
        if(mask == null){return false;}
        return mask.isInGrid(X,Y);
    }
}
