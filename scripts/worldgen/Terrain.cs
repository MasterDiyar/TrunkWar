using Godot;
using System;

public partial class Terrain : Node2D
{
	[Export] public Camera2D cam;
	[Export] Sprite2D noizeSprite;
	NoiseTexture2D noiseTexture;
	ShaderMaterial mat;
	public override void _Ready()
	{
		noiseTexture = (NoiseTexture2D)noizeSprite.Texture;
		mat = (ShaderMaterial)noizeSprite.Material;
	}

	public override void _Process(double delta)
	{
		noizeSprite.GlobalPosition = cam.GlobalPosition;
		mat.SetShaderParameter("camera_offset", cam.GlobalPosition);
		
	}
}
