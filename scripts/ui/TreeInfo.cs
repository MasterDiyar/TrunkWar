using Godot;
using System;
using System.Text;

public partial class TreeInfo : Control
{
	[Export] public string treeType;
	[Export] Label inputLabel, outputLabel;
	[Export] private Button b1, b2, b3, b4, leave;
	[Export] private TextureRect leaf, trunc, branch, root, treeImage;
	

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

		_imageFetch(tree.components[0].Name, "leaf");
		Show();
	}

	public override void _Ready()
	{
		base._Ready();

		leave.Pressed += Hide;
        		
        		
	}

	void _imageFetch(string name, string whom)
	{
		switch (whom)
		{
			case "leaf" :
				leaf.Texture = GD.Load<Texture2D>($"res://assets/upgrades/{_getImage(name)}.png");
				break;
			case "branch":
					
				break;
			case "trunc" :
				break;
					
			case "root":
				
				break;
		}
	}

	string _getImage(string name)
	{
		return name switch
		{
			"Default World Tree" => "defaultLeaf",
			"Golden Leaf" => "goldenLeaf",
			"Oak Leaf" => "oakLeaf",
			"Catalpa Leaf" => "catalpa",
			"Hoya Leaf" => "randLeaf",
			_ => "defaultLea"
		};
	}
}
