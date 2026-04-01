using Godot;
using System;
using TrunkWar.scripts.trees;

public partial class Menu : Control
{
	[Export] private Control playControl;
	[Export] private Button play, start;
	[Export] private OptionButton terrainChoose;
	[Export] private Label difficultyLabel;

	private int index = 0;
	int[] difficulty = [140, 120, 100, 80, 60, 40];
	private string[] treeType = ["world tree", ""];
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
		
		difficultyLabel.Text = $"Difficulty: {difficulty[index]}%\n Tree type: {treeType[index]}.";
		
	}

	void StartGame()
	{
		var gameMap =  GD.Load<PackedScene>("res://scenes/map/game.tscn").Instantiate<Node2D>();
		var terrain =  GD.Load<PackedScene>($"res://scenes/terrains/{terrainName[index]}_terrain.tscn").Instantiate<Terrain>();
		var under =    GD.Load<PackedScene>($"res://scenes/terrains/{terrainName[index]}_underground.tscn").Instantiate<Terrain>();
		var tree =     GD.Load<PackedScene>($"res://scenes/trees/{treeName[index]}.tscn").Instantiate<Tree>();
		var cam =      GD.Load<PackedScene>("res://scenes/user/user_cam.tscn").Instantiate<UserCam>();
		var upgrader = GD.Load<PackedScene>("res://scenes/ui/upgrade.tscn").Instantiate<UpgradeControl>();
		var treeInfo = GD.Load<PackedScene>("res://scenes/ui/tree_info.tscn").Instantiate<TreeInfo>();
		var concole =  GD.Load<PackedScene>("res://scenes/ui/concole.tscn").Instantiate<Concole>();
		var canva = new CanvasLayer();
		
		upgrader.Hide();
		treeInfo.Hide();
		concole.Hide();
		
		terrain.cam = cam;
		under.cam = cam;
		gameMap.AddChild(under);
		gameMap.AddChild(terrain);
		gameMap.AddChild(cam);
		gameMap.AddChild(canva);
		terrain.AddChild(tree);
		canva.AddChild(upgrader);
		canva.AddChild(treeInfo);
		canva.AddChild(concole);
		
		Wrench(tree);
		
		GetTree().Root.AddChild(gameMap);
		QueueFree();
	}

	void Wrench(Tree tRee)
	{
		Upgrade[] s = index
			switch
			{
				0 =>
					[Upgrades.DefaultWorldTreeLeaf(), null, null, null],
				1 =>
					[null, null, null, null],
				_ =>
					[null, null, null, null]
			};
		tRee.components = s;
		tRee.treeType = treeType[index];
	}
}
