using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using TrunkWar.scripts.trees;

public partial class Tree : Area2D
{
	[Export] private Godot.Collections.Dictionary<int, Rect2> levelCrops = new();
	[Export] Sprite2D treeSprite;
	[Export] Line2D treeLine;
	
	private CollisionShape2D collisionShape;
	private Timer generatorTimer;
	private GameManager gm;
	
	public Upgrade[] components = new Upgrade[4];
	
	[ExportGroup("Producing")]
	[Export] public Godot.Collections.Dictionary<string, float> Producing = new()
	{
		{ "Energy", 100f},
		{ "Carbon", 10f},
		{ "Oxygen", 7.2f}
	};
	[Export] public Godot.Collections.Dictionary<string, float> Consuming = new()
	{
		{ "Water" , 4.09f},
		{ "Nitrogen", 2}
	};
	
	Godot.Collections.Dictionary<string, float> Saved = new()
	{
		{ "Energy", 0},
		{ "Carbon", 0},
		{ "Oxygen", 0},
		{ "Water" , 0},
		{ "Nitrogen", 0}
	};
	
	int level = 1;
	private bool mouseHere;

	private void OnInputEvent(Node viewport, InputEvent @event, long shapeidx)
	{
		
		if (@event is InputEventMouseButton { Pressed: true } eventKey)
        {
        	UpgradeControl uc = GetTree().GetFirstNodeInGroup("upgrader") as UpgradeControl;
	        uc.GlobalPosition = GlobalPosition;
	        uc.Set(Name, () =>
	        {
		        var a = (TreeInfo)GetTree().GetFirstNodeInGroup("treeinfo");
		        a.ApplyTree(this);
	        }, this.QueueFree);
        }
	}
	
	public override void _Ready()
	{
		gm = GetTree().Root.GetNode<GameManager>("game");
		
		generatorTimer = GetNode<Timer>("Timer");
		collisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		
		InputEvent += OnInputEvent;
		
		generatorTimer.Timeout += Getting;

		treeSprite.RegionRect = levelCrops[level];
		UpdateLine(levelCrops[level]);
		
		MouseEntered += treeLine.Show;
		MouseExited += treeLine.Hide;
	}

	


	public void LevelUp()
	{
		treeSprite.RegionRect = levelCrops[1];
		var shape = (RectangleShape2D)collisionShape.Shape;
		shape.Size = levelCrops[1].Size;
		UpdateLine(levelCrops[level]);
	}

	void Getting()
	{
		if (Consume())
			Produce();
	}

	public virtual void Produce()
	{
		gm.Add(Producing);
	}

	public virtual bool Consume()
	{
		var toConsume = Consuming.Duplicate();
		foreach (var kvp in toConsume)
			toConsume[kvp.Key] += 1;
		
		if (gm.CanConsume(toConsume))
		{
			gm.Consume(toConsume);
			foreach (var svd in toConsume)
				Saved[svd.Key] += 1;
			
			return true;
		}

		bool isAlive = true;
		foreach (var kvp in toConsume)
		{
			Saved[kvp.Key] -= toConsume[kvp.Key] - gm.Items[kvp.Key];
			if (Saved[kvp.Key] < 0)
				isAlive = false;
		}

		return isAlive;
	}

	public void AddComponent(Upgrade upgrade, int to)
	{
		components[to]?.OnRemove(); 
		components[to] = upgrade;    
		upgrade.myTree = this;
		upgrade.OnAdd();             
	}
	

	public void RemoveComponent(int to)
	{
		components[to]?.OnRemove();
		components[to] = null;
	}

	public void AddConsumer(string id, float val)
	{
		if (Consuming.ContainsKey(id))
		{
			Consuming[id] += val;
		}
		else GD.PrintErr("Consumer not found: " + id);
	}
	
	public void AddProducer(string id, float val)
	{
		if (Producing.ContainsKey(id))
			Producing[id] += val;
		else GD.PrintErr("Producing not found: " + id);
			
	}

	void UpdateLine(Rect2 rect)
	{
		Vector2 topLeft = rect.Position;
		Vector2 bottomRight = rect.End; 
        
		Vector2 topRight = new Vector2(bottomRight.X, topLeft.Y);
		Vector2 bottomLeft = new Vector2(topLeft.X, bottomRight.Y);

		Vector2[] points = [topLeft, topRight, bottomRight, bottomLeft];

		treeLine.Points = points;

		treeLine.Position = -rect.GetCenter();
	}
}
