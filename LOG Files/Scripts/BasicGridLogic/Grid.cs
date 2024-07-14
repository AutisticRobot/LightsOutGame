using Godot;
using System;

[GlobalClass]
public partial class Grid : Resource
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
    //   Fillers    |
    //=============/

    public void fillState(bool state)
    {
		for(int Y=0;Y<YSize;Y++)
		{
			for(int X=0;X<XSize;X++)
			{
                grid[X,Y] = state;
			}

		}
    }

    //==============\
    //   Getters    |
    //=============/
    public bool hasGrid()
    {
        return grid != null;
    }
    static public bool isReady(Grid grid)
    {
        return (grid != null && grid.hasGrid());
    }

    public int getXSize(){return XSize;}
    public int getYSize(){return YSize;}

    public bool get(int X, int Y)
    {
        try
        {
        if(isInGrid(X,Y))
        {
            return grid[X,Y];
        }else{
            return false;
        }
        }catch{
            GD.Print("!!!!!!!!!!!!!OUT OF BOUNDS ERROR: " + X + ", " + Y + ", size: " + XSize + ", " + YSize);
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
    //   Pressers   |
    //=============/
    public void pressSimple(int X, int Y)
    {
        if(isInGrid(X,Y))
        {
            grid[X,Y] = !grid[X,Y];
        }
    }
    public void pressCross(int X, int Y)
    {
        //check pattern, X = checked spot, Q = start and check
        //*X*
        //XQX
        //*X*

        pressSimple(X,Y);
        pressSimple(X-1,Y);
        pressSimple(X+1,Y);
        pressSimple(X,Y-1);
        pressSimple(X,Y+1);


    }

    //==============\
    //   Checkers   |
    //=============/
    public bool isInGrid(int X, int Y)
    {
        if(0 > X || X >= XSize || 0 > Y || Y >= YSize || isInOtherParameter(X,Y))// N >= NSize because Size vars are 1 grater that the last index in grid 
        {
            return false;
        }else{
            return true;
        }
    }
    public virtual bool isInOtherParameter(int X, int Y) {return false;}
}
