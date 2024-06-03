using Godot;
using System;

[GlobalClass]
public partial class Grid : GodotObject
{
    private bool[,] grid;
    private int XSize;
    private int YSize;

    public int startGrid(int XSize, int YSize)
    {
        try
        {
            grid = new bool[XSize,YSize];
            this.XSize = XSize;
            this.YSize = YSize;
        }catch{
            return 1;
        }
        return 0;
    }

    //==============\
    //   Getters    |
    //=============/
    public int getXSize(){return XSize;}
    public int getYSize(){return YSize;}

    public bool get(int X, int Y)
    {
        if(isInGrid(X,Y))
        {
            return grid[X,Y];
        }else{
            return false;
        }
    }
    public bool getCross(int X, int Y)
    {
        //check pattern, X = checked spot, Q = start and check
        //*X*
        //XQX
        //*X*
        bool Out = get(X,Y);
        if(get(X+1,Y)){Out = !Out;}
        if(get(X-1,Y)){Out = !Out;}
        if(get(X,Y+1)){Out = !Out;}
        if(get(X,Y-1)){Out = !Out;}

        return Out;
    }

    //==============\
    //   Presser    |
    //=============/
    public void pressSimple(int X, int Y)
    {
        if(isInGrid(X,Y))
        {
            grid[X,Y] = !grid[X,Y];
        }
    }

    //==============\
    //   Checkers   |
    //=============/
    public bool isInGrid(int X, int Y)
    {
        if(0 > X || X >= XSize || 0 > Y || Y >= XSize || isInOtherParameter(X,Y))// Y >= YSize because Size vars are 1 grater that the last index in grid 
        {
            return false;
        }else{
            return true;
        }
    }
    public virtual bool isInOtherParameter(int X, int Y) {return false;}
}
