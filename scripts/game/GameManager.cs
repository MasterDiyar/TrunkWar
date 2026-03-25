using Godot;
using System;
using System.Collections.Generic;

public partial class GameManager : Node2D
{
	public Godot.Collections.Dictionary<string, float> Items = new()
	{
		{"Energy", 0},
		{"Oxygen", 0},
		{"Carbon", 0},
		{"Nitrogen", 0},
		{"Phosphorus", 0},
		{"Water", 0},
		{"Sugar", 0},
		{"Chitin", 0}
	};
	
	public Godot.Collections.Dictionary<string, float> MaxItems = new()
	{
		{"Energy", 100},
		{"Oxygen", 100},
		{"Carbon", 100},
		{"Nitrogen",100},
		{"Phosphorus", 100},
		{"Water",100},
		{"Sugar", 100},
		{"Chitin", 100}
	};

	public UpgradeControl upgrader;
	
	

	public bool CanConsume(Godot.Collections.Dictionary<string, float> count)
	{
		foreach (var (key, f) in count)
			if (Items.TryGetValue(key, out var value))
				if (value < f)
					return false;
		return true;
	}

	public void Consume(Godot.Collections.Dictionary<string, float> count)
	{
		foreach (var (key, f) in count)
			if (Items.ContainsKey(key))
				Items[key] -= f;
	}

	public void Add(Godot.Collections.Dictionary<string, float> count)
	{
		foreach (var (key, f) in count)
			if (Items.TryGetValue(key, out float value))
				Items[key] = float.Max(value + f, MaxItems[key]);
	}
	
	public override void _Ready()
	{
		upgrader = (UpgradeControl)GetTree().GetFirstNodeInGroup("upgrader");
	}

	public void PlaceUpgrader(Vector2 pos)
	{
		upgrader.Show();
		Vector2 exactPos = new Vector2(pos.X, pos.Y);
		upgrader.Position = exactPos;
	}
}
