using Godot;
using System;

public partial class Tree : Area2D
{
	[Export] private Godot.Collections.Dictionary<int, Rect2> levelCrops = new();
	[Export] Sprite2D treeSprite;
	
	private CollisionShape2D collisionShape;
	private Timer generatorTimer;
	private GameManager gm;
	
	[ExportGroup("Producing")]
	[Export] public Godot.Collections.Dictionary<string, float> Producing = new();
	[Export] public Godot.Collections.Dictionary<string, float> Consuming = new();
	
	int level = 0;
	private bool mouseHere;
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton { Pressed: true } eventKey && mouseHere)
		{
			
		}
	}

	public override void _Ready()
	{
		gm = GetTree().Root.GetNode<GameManager>("game");
		
		generatorTimer = GetNode<Timer>("Timer");
		collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");

		MouseEntered += () => mouseHere = true;
		MouseExited += () => mouseHere = false;
		
		generatorTimer.Timeout += Produce;
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
