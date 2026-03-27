using Godot;
using System;
using System.Text;

public partial class TreeInfo : Control
{
	[Export] public string treeType;
	[Export] Label inputLabel, outputLabel;
	[Export] private Button b1, b2, b3, b4;
	[Export] private TextureRect leaf, trunc, branch, root, treeImage;
	

	public void ApplyTree(Tree tree)
	{
		StringBuilder ProductionText = new StringBuilder();
		
		ProductionText.AppendLine(treeType);
		foreach (var con in tree.Consuming)
			ProductionText.AppendLine($"{con.Key}: {con.Value}");
			
		
		
	}
}
