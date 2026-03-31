using Godot;
using System;
using TrunkWar.scripts.trees;

public partial class UpgradeChooser : Control
{
    [Export] public Button[] buttons;
    public TextureRect refText;
    private int whichPressed;

    [Export] private Control mother;

    void Init(TextureRect rfb)
    {
        Show();
        refText = rfb;
        foreach (var child in mother.GetChildren())child.QueueFree();
    }

    public void LeafInit( TextureRect rfb, Tree tree)
    {
        Init(rfb);
        
        switch (tree.treeType) {
            case "world tree":
            var worldTreeList = Upgrades.WorldTreeList;
            var imageMap = TreeInfo._imageMap;
            buttons = new Button[worldTreeList.Length];
            for (int i = 0; i < buttons.Length; i++) {
                var upgrade = worldTreeList[i];
                var btn = new Button {
                    Text = upgrade.Name,
                    Icon = GD.Load<Texture2D>($"res://assets/upgrades/{imageMap[upgrade.Name]}.png"),
                    SizeFlagsVertical = SizeFlags.Expand
                };
                buttons[i] = btn;
                mother.AddChild(btn);
                var i1 = i;
                btn.Pressed += () => AddButton(i1, btn, tree, upgrade);
            }
            break;
        }
    }
    void AddButton(int i1, Button btn, Tree tree, Upgrade upgrade){
         whichPressed = i1;
         refText.Texture = btn.Icon;
         tree.AddComponent(upgrade,0);
         Quit();
     }

    public void Quit()
    {
        refText = null;
        Hide();
    }


}
