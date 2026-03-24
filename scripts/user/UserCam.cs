using Godot;
using System;

public partial class UserCam : Camera2D
{
	[Export] public float Speed = 200f;

	public override void _Process(double delta)
	{
		MoveCamera((float)delta);
	}

	void MoveCamera(float delta)
	{
		var mov = Input.GetVector("a", "d", "w", "s");
		
		Position += mov.Normalized() * Speed * delta;
	}
}
