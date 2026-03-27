using Godot;
using System;

public partial class UpgradeChooser : Control
{
    [Export] public Button[] buttons;
    public Button refButton;

    public void Init(string loadout, Button rfb)
    {
        refButton = rfb;
    }

    public void Quit()
    {
        refButton = null;
    }


}
