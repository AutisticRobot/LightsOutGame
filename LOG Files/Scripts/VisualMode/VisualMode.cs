using Godot;
using System;
using System.Collections.Generic;

public partial class VisualMode : Node2D
{
	[Export] public int XSize;
	[Export] public int YSize;
	[Export] public Sprite2D SwitchBoard;
			 public Vector2 BoardLength;
	[Export] public MaskedGrid GridState;
	[Export] public Grid solution;
	[Export] public PackedScene SwitchPrefab;
				public Vector2 SwitchScale;
			[Export] public float SwitchScaleModifier;
			 public List<Switch> allSwitches = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BoardLength = SwitchBoard.Scale * SwitchBoard.Texture.GetSize();
		SwitchScale = new
		(
			(BoardLength.X * (1 + SwitchScaleModifier)) / XSize ,
			(BoardLength.X * (1 + SwitchScaleModifier)) / XSize  
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
		outX = ((float)BoardLength.X/XSize) * X;
		outY = ((float)BoardLength.Y/YSize) * Y;

		//off set to account for being relative to center of switch
		outX += ((float)BoardLength.X)/(XSize * 2);
		outY += ((float)BoardLength.Y)/(YSize * 2);

		//off set to account for being relative to center of Board
		outX -= BoardLength.X/2;
		outY -= BoardLength.Y/2;

		//offset to make relative to global
		outX += SwitchBoard.Position.X;
		outY += SwitchBoard.Position.Y;

        swt.Position = new Vector2(outX,outY);
		swt.Scale = SwitchScale / swt.Texture.GetSize();
		swt.X = X;
		swt.Y = Y;


		//GD.Print(swt.Position);
		AddChild(swt);
		allSwitches.Add(swt);

	}
}
