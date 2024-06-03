using Godot;
using System;

public partial class light_box_scene : Node2D
{
			 public MaskedGrid grid = new();
	[Export] public LineEdit XInput;
	[Export] public LineEdit YInput;
	[Export] public Label LightGrid;
	[Export] public Label SwitchGrid;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		grid.startGrid(5,5);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		SwitchGrid.Text = TextOnlyDisplay.GetDisplay(grid, 0);
		LightGrid.Text = TextOnlyDisplay.GetDisplay(grid, 1);
	}

	public void onGetCord()
	{
		int X;
		int Y;
		try
		{
		X = int.Parse(XInput.Text);
		}catch{
			GD.Print("XInput is not a number");

			XInput.Text = "";
			X = 0;
		}
		try
		{
		Y = int.Parse(YInput.Text);
		}catch{
			GD.Print("YInput is not a number");

			YInput.Text = "";
			Y = 0;
		}

		GD.Print("cord press" + X + ", " + Y);

		grid.pressSimple(X,Y);
	}
}
