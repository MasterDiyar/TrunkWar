using System.Collections.Generic;

namespace TrunkWar.scripts.trees;

public static class Upgrades
{

    public static Upgrade GoldenLeaf()
    {
        var upgrade = new Upgrade(
            new Dictionary<string, float>()
            {
                {"Energy", 10}
            },
            "Golden Leaf"
            );
        
        
        return upgrade;
    }
}