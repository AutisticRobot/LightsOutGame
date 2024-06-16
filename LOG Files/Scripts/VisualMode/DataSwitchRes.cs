using Godot;
using System;

[GlobalClass]
public partial class DataSwitchRes : Resource
{
    [Export] public Texture2D onState;
    [Export] public Texture2D offState;
	[Export] public Vector2 SwitchScaleModifier;
}
