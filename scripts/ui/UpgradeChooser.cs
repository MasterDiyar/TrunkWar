using Godot;
using System;
using TrunkWar.scripts.trees;

public partial class UpgradeChooser : Control
{
    [Export] public Button[] buttons;
    public Button refButton;
    private int whichPressed;

    [Export] private Control mother;

    public void Init(string loadout, Button rfb, Tree tree)
    {
        refButton = rfb;

        switch (tree.treeType)
        {
            case "world tree":
                var wtl = Upgrades.WorldTreeList;
                var ti = TreeInfo._imageMap;
                buttons = new Button[wtl.Length];
                for (int i = 0; i < buttons.Length; i++)
                {
                    var btn =  new Button();
                    var upgrade = wtl[i];
                    btn.Icon = GD.Load<Texture2D>($"res://assets/upgrades/{ti[upgrade.Name]}.png");
                    btn.Text = upgrade.Name;
                    btn.SizeFlagsVertical = SizeFlags.Expand;
                    buttons[i] = btn;
                    
                    
                }
                break;
        }
    }

    public void Quit()
    {
        refButton = null;
    }


}
