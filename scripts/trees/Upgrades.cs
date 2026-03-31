using System.Collections.Generic;

namespace TrunkWar.scripts.trees;

public static class Upgrades
{

    public static Upgrade DefaultWorldTreeLeaf() => new (
        new ()
        {
            {"Energy", 10}
        },
        new()
        {
            {"Water", 1}
        },
        "Default World Tree"
        
    );
    
    public static Upgrade GoldenLeaf() => new (
            new ()
            {
                {"Energy", 100},
                {"Oxygen", 10}
            },
            new()
            {
                {"Water", 15}
            },
            "Golden Leaf"
            );
    

    public static Upgrade OakLeaf()
    {
        return new Upgrade(new ()
        {
            { "Carbon", 4 },
            { "Oxygen", 6 },
        }, new()
        {
            {"Water", 2.04f },
            {"Nitrogen", 0.33f}
        }, "Oak Leaf");
    }

    public static Upgrade CatalpaLeaf() => new(
    new(){
        { "Carbon", 12 },
        { "Oxygen", 17 },
    }, new()
    {
        {"Water", 5 },
        {"Nitrogen", 2.02f }
    },"Catalpa Leaf");

    public static Upgrade HoyaLeaf() => new(new ()
        {
            {"Carbon", -3 },
            {"Oxygen", -4 },
            {"Energy", -2}
        },
        new()
        {
            {"Water", -1.012f },
            {"Nitrogen", -.74f }
        }, "Hoya Leaf"
        );

    public static readonly Upgrade[] WorldTreeList = [DefaultWorldTreeLeaf(), CatalpaLeaf(), GoldenLeaf(), OakLeaf(), HoyaLeaf()];
}