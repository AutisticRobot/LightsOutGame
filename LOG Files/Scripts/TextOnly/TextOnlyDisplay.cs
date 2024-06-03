

public partial class TextOnlyDisplay
{
    public static string GetDisplay(Grid grid, int type)
    {
        int XSize = grid.getXSize();
        int YSize = grid.getYSize();
        string display = "";

        for(int Y=0;Y<YSize;Y++)
        {
            for(int X=0;X<XSize;X++)
            {
                switch (type)
                {
                    case 0://direct display
                        if(grid.get(X,Y))
                        {display += "#";}else{display += "~";}
                    break;
                    case 1://cross display
                        if(grid.getCross(X,Y))
                        {display += "#";}else{display += "~";}
                    break;
                    default:
                    display += "&";
                    break;
                }
            }

            display += "\n";
        }     

        return display;
    }
}
