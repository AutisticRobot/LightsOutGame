using Godot;
using System;

public partial class VisualMode : Node2D
{
	[Export] public int XSize;
	[Export] public int YSize;
	[Export] public Node2D SwitchBoard;
			 public int XBoardLength = 128;
			 public int YBoardLength = 128;
	[Export] public MaskedGrid GridState;
	[Export] public Grid solution;
	[Export] public PackedScene SwitchPrefab;
				public Vector2 SwitchScale;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		XBoardLength = (int)SwitchBoard.Scale.X * 128;
		YBoardLength = (int)SwitchBoard.Scale.Y * 128;
		SwitchScale = new(SwitchBoard.Scale.X / XSize ,SwitchBoard.Scale.Y / YSize);

		solution.startGrid(XSize, YSize);
		GD.Print("Solution is set = " + Grid.isReady(solution));

		for(int Y=0;Y<YSize;Y++)
		{
			for(int X=0;X<YSize;X++)
			{
				CreateSwitch(X,Y);
			}

		}
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void CreateSwitch(int X, int Y)
	{
		GD.Print("X: " + X + " Y: " + Y);

		Switch swt = SwitchPrefab.Instantiate<Switch>();
		int outX;
		int outY;

		//Position relitive to top right of Board
		outX = (XBoardLength/XSize) * X;
		outY = (YBoardLength/YSize) * Y;

		//off set to account for being relative to center of switch
		outX += XBoardLength/(XSize * 2);
		outY += YBoardLength/(YSize * 2);

		//off set to account for being relative to center of Board
		outX -= XBoardLength/2;
		outY -= YBoardLength/2;

		//offset to make relative to global
		outX += (int)SwitchBoard.Position.X;
		outY += (int)SwitchBoard.Position.Y;

        swt.Position = new Vector2(outX,outY);
		swt.Scale = SwitchScale;
		swt.X = X;
		swt.Y = Y;


		GD.Print(swt.Position);
		AddChild(swt);

	}
}
