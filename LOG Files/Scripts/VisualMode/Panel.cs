using Godot;
using System;
using System.Collections.Generic;

public partial class Panel : Control
{
	[Export] VisualMode SceneMan;
			 public int XSize;
			 public int YSize;
			 public Vector2 BoardLength;
			 public Vector2 BoardPos;
	[Export] public PackedScene SwitchPrefab;
	[Export] public DataSwitchRes SwitchRes;
				public Vector2 SwitchScale;
					 public Vector2 SwitchScaleModifier;
			 public List<Switch> allSwitches = new();
			 public Grid State;

			 public bool test;
	// Called when the node enters the scene tree for the first time.
	public void Start()
	{
		XSize = SceneMan.XSize;
		YSize = SceneMan.YSize;
		BoardLength = SceneMan.BoardLength;
		BoardPos = SceneMan.SwitchBoard.Position;
		SwitchScaleModifier = SwitchRes.SwitchScaleModifier;

		SwitchScale = new
		(
			(BoardLength.X * (1 + SwitchScaleModifier.X)) / XSize ,
			(BoardLength.X * (1 + SwitchScaleModifier.Y)) / XSize  
		);


		for(int Y=0;Y<YSize;Y++)
		{
			for(int X=0;X<XSize;X++)
			{
				CreateSwitch(X,Y);
			}

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void UpdateState(Grid grid)
	{
		State = grid;
	}
	
	public void CreateSwitch(int X, int Y)
	{
		GD.Print("X: " + X + " Y: " + Y);

		Switch swt = SwitchPrefab.Instantiate<Switch>();
		float outX;
		float outY;

		swt.onState = SwitchRes.onState;
		swt.offState = SwitchRes.offState;


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
		outX += BoardPos.X;
		outY += BoardPos.Y;

        swt.Position = new Vector2(outX,outY);
		swt.Scale = SwitchScale / swt.Texture.GetSize();
		swt.X = X;
		swt.Y = Y;


		//GD.Print(swt.Position);
		swt.Toggle(test);
		test = !test;
		AddChild(swt);
		allSwitches.Add(swt);

	}
}
