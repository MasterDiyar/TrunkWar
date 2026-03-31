using Godot;
using System;
using System.Collections.Generic;
using System.Text;

public partial class TreeInfo : Control
{
	[Export] public string treeType;
	[Export] Label inputLabel, outputLabel;
	[Export] private Button b1, b2, b3, b4, leave;
	[Export] private TextureRect leaf, trunc, branch, root, treeImage;

	private UpgradeChooser UC;
	

	public void ApplyTree(Tree tree)
	{
		_inputText(tree);
		
		
		
		
	}

	void _inputText(Tree tree)
	{
		StringBuilder ProductionText = new StringBuilder();
		
		ProductionText.AppendLine(treeType);
		foreach (var con in tree.Consuming)
			ProductionText.AppendLine($"{con.Key}: {con.Value}");

		_imageFetch(tree.components[0].Name, "leaf", tree);
		Show();
	}

	public override void _Ready()
	{
		base._Ready();

		leave.Pressed += Hide;

		UC = GD.Load<PackedScene>("res://scenes/ui/upgradeChooser.tscn").Instantiate<UpgradeChooser>();
		UC.Hide();
		GetParent().CallDeferred("add_child",UC);
	}

	void _imageFetch(string name, string whom, Tree tree)
	{
		switch (whom) {
			case "leaf" :
				leaf.Texture = GD.Load<Texture2D>($"res://assets/upgrades/{_imageMap[name]}.png");
				b1.Pressed += () =>
				{
					UC.Show();
					UC.LeafInit(leaf, tree);
				};
				break;
			case "branch":
				
				break;
			case "trunc" :
				
				break;
			case "root":
				
				break;
		}
	}

	public static readonly Dictionary<string, string> _imageMap = new()
	{
		{ "Default World Tree", "defaultLeaf" },
		{ "Golden Leaf", "goldenLeaf" },
		{ "Oak Leaf", "oakLeaf" },
		{ "Catalpa Leaf", "catalpa" },
		{ "Hoya Leaf", "randLeaf" }
	};
}
