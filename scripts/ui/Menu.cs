using Godot;
using System;

public partial class Menu : Control
{
	[Export] private Control playControl;
	[Export] private Button play, start;
	[Export] private OptionButton terrainChoose;
	[Export] private Label difficultyLabel;

	private int index = 0;
	int[] difficulty = [140, 120, 100, 80, 60, 40];
	private string[] terrainName = ["black_soil"],
		treeName = ["world_tree"];
	public override void _Ready()
	{
		play.Pressed += playControl.Show;
		start.Pressed += StartGame;
		terrainChoose.ItemSelected += TerrainChoose;
	}

	void TerrainChoose(long idx)
	{
		index = (int)idx;
		
		difficultyLabel.Text = $"Difficulty: {difficulty[index]}%";
	}

	void StartGame()
	{
		var gameMap = GD.Load<PackedScene>("res://scenes/map/game.tscn").Instantiate<Node2D>();
		var terrain = GD.Load<PackedScene>($"res://scenes/terrains/{terrainName[index]}_terrain.tscn").Instantiate<Terrain>();
		var underground = GD.Load<PackedScene>($"res://scenes/terrains/{terrainName[index]}_underground.tscn").Instantiate<Terrain>();
		var tree = GD.Load<PackedScene>($"res://scenes/trees/{treeName[index]}.tscn").Instantiate<Tree>();
		var cam = GD.Load<PackedScene>("res://scenes/user/user_cam.tscn").Instantiate<UserCam>();
		terrain.cam = cam;
		underground.cam = cam;
		gameMap.AddChild(underground);
		gameMap.AddChild(terrain);
		gameMap.AddChild(cam);
		gameMap.AddChild(tree);
		GetTree().Root.AddChild(gameMap);
		QueueFree();
	}
	

	public override void _Process(double delta)
	{
	}
}
