using Godot;

namespace TrunkWar.scripts.resources;

[GlobalClass]
public partial class BuildingResource : Resource
{
    [Export] public float MaxHp;
 
    [Export] public Godot.Collections.Dictionary<string, float> Cost = new Godot.Collections.Dictionary<string, float>()
    {
        {"Energy", 0},
        {"Oxygen", 0},
        {"Carbon", 0},
        {"Nitrogen", 0},
        {"Phosphorus", 0},
        {"Water", 0},
        {"Sugar", 0},
        {"Chitin", 0}
    };
}