using Godot;
using System;

public partial class VisualMode : Node2D
{
	[Export] public int XSize;
	[Export] public int YSize;
	[Export] public Node2D SwitchBoard;
	[Export] public MaskedGrid GridState;
	[Export] public Grid solution;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		solution.startGrid(XSize, YSize);
		GD.Print("Solution is set = " + Grid.isReady(solution));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
