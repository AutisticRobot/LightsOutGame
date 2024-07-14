using Godot;
using System;
using System.Collections.Generic;

public partial class VisualMode : Node2D
{
			 public globalData data;

			 public int XSize;
			 public int YSize;
	[Export] public Sprite2D SwitchBoard;
			 public Vector2 BoardLength;
	[Export] public MaskedGrid GridState;
	[Export] public Grid solution;

	[Export] public Panel LightBoard;
	[Export] public Panel FuseBoard;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		data = GetNode<globalData>("/root/GlobalData");
		XSize = data.XSize;
		YSize = data.YSize;

		BoardLength = SwitchBoard.Scale * SwitchBoard.Texture.GetSize();

		if(solution == null)
		{
			solution = new();
			solution.startGrid(XSize, YSize);

			solution.fillState(false);

			GD.Print("Solution is set = " + Grid.isReady(solution));
		}
		if(GridState == null)
		{
			GridState = new();
			GridState.startGrid(XSize, YSize);

			GridState.fillState(false);

			GD.Print("GridState is set = " + Grid.isReady(GridState));
		}

		LightBoard.UpdateState(GridState);
		FuseBoard.UpdateState(GridState);


		LightBoard.Start();
		FuseBoard.Start();

		LightBoard.UpdateCrossView();
		FuseBoard.UpdateView();
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

		LightBoard.State.pressSimple(X,Y);
		LightBoard.UpdateCrossView();

		//FuseBoard.State.pressSimple(X,Y);
		FuseBoard.UpdateView();

	}
	
}
