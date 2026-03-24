using Godot;
using System;

public partial class Tree : Area2D
{
	[Export] private Godot.Collections.Dictionary<int, Rect2> levelCrops = new()
	{

	};
	[Export] Sprite2D treeSprite;
	CollisionShape2D collisionShape;
	public override void _Ready()
	{
		collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
	}

	public override void _Process(double delta)
	{
	}

	public void Upgrade()
	{
		treeSprite.RegionRect = levelCrops[1];
		var shape = (RectangleShape2D)collisionShape.Shape;
		shape.Size = levelCrops[1].Size;
	}

	public virtual void Produce()
	{
		
	}
}
