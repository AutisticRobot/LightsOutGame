using Godot;
using System;

public partial class Options : Node2D
{
	public globalData data;
	[Export] public LineEdit XInput;
	[Export] public LineEdit YInput;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		data = GetNode<globalData>("/root/GlobalData");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
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

		GD.Print("Size Set:" + X + ", " + Y);

		data.XSize = X;
		data.YSize = Y;

	}
}
