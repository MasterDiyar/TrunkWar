using Godot;
using System;

public partial class Concole : Control
{
	[Export] private TextEdit textEdit;
	[Export] Label label;

	private GameManager gm;
	public override void _Ready()
	{
		gm = GetTree().Root.GetNode<GameManager>("game");
	}

	public override void _Input(InputEvent @event)
	{
		if (@event.IsActionPressed("tilda"))
		{
			SetVisible(!IsVisible());
			return;
		}
		
		if (!@event.IsActionPressed("enter") || !IsVisible()) return;
		if (textEdit.Text == "") return;

		switch (textEdit.Text)
		{
			case "res":
				string fulltext = "";
				foreach (var items in gm.Items)
				{
					fulltext += $"{items.Key}: {items.Value}\n";
				}
				label.Text = fulltext;
				break;
		}
		
		
		textEdit.Clear();
		
	}
}
