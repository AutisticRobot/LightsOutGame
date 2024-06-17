using Godot;
using System;

public partial class Switch : Sprite2D
{
	[Export] public Button button;
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

	public void onPress()
	{
		
	}

	public void setButtonSize(Vector2 size)
	{
		button.Size = size;
        Vector2 tmp = new()
        {
            X = -size.X,
            Y = -size.Y
        };
        button.Position = tmp;
	}

	public bool Toggle()
	{
		if(state)
		{
			setButtonSize(offState.GetSize());
			Texture = offState;
			state = !state;
		}else{
			setButtonSize(onState.GetSize());
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
			setButtonSize(offState.GetSize());
		}else{
			Texture = onState;
			setButtonSize(onState.GetSize());
		}
			state = setState;
		return state;
	}
}
