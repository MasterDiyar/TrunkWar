using Godot;
using System;

public partial class VisibilityChangeOnPress : Node
{
	[Export] string InputName = "";
	[Export] private Node2D parent;

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed(InputName))
			parent.Visible = !parent.Visible;
	}
}
