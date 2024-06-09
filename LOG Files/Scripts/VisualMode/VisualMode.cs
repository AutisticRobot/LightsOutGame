using Godot;
using System;
using System.Collections.Generic;

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
			[Export] public float SwitchScaleModifier;
			 public List<Switch> allSwitches = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		XBoardLength = (int)SwitchBoard.Scale.X * 128;
		YBoardLength = (int)SwitchBoard.Scale.Y * 128;
		SwitchScale = new
		(
			(SwitchBoard.Scale.X + SwitchScaleModifier) / XSize ,
			(SwitchBoard.Scale.Y + SwitchScaleModifier) / YSize  
		);

		solution.startGrid(XSize, YSize);
		GD.Print("Solution is set = " + Grid.isReady(solution));

		for(int Y=0;Y<YSize;Y++)
		{
			for(int X=0;X<XSize;X++)
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
		//GD.Print("X: " + X + " Y: " + Y);

		Switch swt = SwitchPrefab.Instantiate<Switch>();
		float outX;
		float outY;

		//Position relitive to top right of Board
		outX = ((float)XBoardLength/XSize) * X;
		outY = ((float)YBoardLength/YSize) * Y;

		//off set to account for being relative to center of switch
		outX += ((float)XBoardLength)/(XSize * 2);
		outY += ((float)YBoardLength)/(YSize * 2);

		//off set to account for being relative to center of Board
		outX -= XBoardLength/2;
		outY -= YBoardLength/2;

		//offset to make relative to global
		outX += SwitchBoard.Position.X;
		outY += SwitchBoard.Position.Y;

        swt.Position = new Vector2(outX,outY);
		swt.Scale = SwitchScale;
		swt.X = X;
		swt.Y = Y;


		//GD.Print(swt.Position);
		AddChild(swt);
		allSwitches.Add(swt);

	}
}
