using Godot;
using System;

public partial class Switch : Sprite2D
{
	public int X;
	public int Y;
    public Texture2D onState;
    public Texture2D offState;

	public bool state = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public bool Toggle()
	{
		if(state)
		{
			Texture = offState;
			state = !state;
		}else{
			Texture = onState;
			state = !state;
		}
		return state;
	}
	public bool Toggle(bool setState)
	{
		if(setState)
		{
			Texture = offState;
		}else{
			Texture = onState;
		}
			state = setState;
		return state;
	}
}
