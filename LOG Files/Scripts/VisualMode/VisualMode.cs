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

	[Export] public Panel LightBoard;
	[Export] public Panel FuseBoard;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		BoardLength = SwitchBoard.Scale * SwitchBoard.Texture.GetSize();

		solution.startGrid(XSize, YSize);
		GD.Print("Solution is set = " + Grid.isReady(solution));

		LightBoard.UpdateState(GridState);
		FuseBoard.UpdateState(solution);


		LightBoard.Start();
		FuseBoard.Start();
	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void changePanel()
	{
		LightBoard.Visible = !LightBoard.Visible;
		FuseBoard.Visible = !FuseBoard.Visible;
	}

	public void press(int X, int Y)
	{
		GD.Print("Press at X:" + X + " Y:" + Y);
	}
	
}
