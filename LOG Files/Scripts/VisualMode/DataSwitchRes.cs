using Godot;
using System;

public partial class DataSwitchRes : Resource
{
    [Export] public Texture2D onState;
    [Export] public Texture2D offState;
	[Export] public float SwitchScaleModifier;
}
