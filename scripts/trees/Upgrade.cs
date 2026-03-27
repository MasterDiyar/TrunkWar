using System.Collections.Generic;

namespace TrunkWar.scripts.trees;

public class Upgrade
{
    public Tree myTree;
    public string Name;

    public Upgrade(Dictionary<string, float> data, string name)
    {
        Name = name;
        foreach( var pair in data)
            adds[pair.Key] = pair.Value;
    }
    
    public Dictionary<string,float> adds =  new()
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

    public void OnAdd()
    {
        foreach (var key in myTree.Consuming)
        {
            myTree.AddConsumer(key.Key, adds[key.Key]);
        }
    }
}