using Godot;
using System;
using System.Collections.Generic;

public partial class Placer : Node
{
	public Dictionary<Vector2I, string> Grid = new Dictionary<Vector2I, string>();

	public void SetTile(int x, int y, string name)
	{
		Grid[new Vector2I(x, y)] = name;
	}

	public string GetTile(int x, int y)
		=> Grid.GetValueOrDefault(new Vector2I(x, y), "Empty");
	
}
