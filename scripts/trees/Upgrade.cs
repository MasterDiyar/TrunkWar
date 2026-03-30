using System.Collections.Generic;

namespace TrunkWar.scripts.trees;

public class Upgrade
{
    public Tree myTree;
    public string Name;

    public Upgrade(Dictionary<string, float> add_data, Dictionary<string, float> consume_data, string name)
    {
        Name = name;
        foreach( var pair in add_data)
            adds[pair.Key] = pair.Value;
        foreach( var pair in consume_data)
            consumes[pair.Key] = pair.Value;
    }

    public Dictionary<string, float> adds = new()
        {
            { "Energy", 0 },
            { "Oxygen", 0 },
            { "Carbon", 0 },
            { "Nitrogen", 0 },
            { "Phosphorus", 0 },
            { "Water", 0 },
            { "Sugar", 0 },
            { "Chitin", 0 }
        }, consumes = new()
        {
            { "Energy", 0 },
            { "Oxygen", 0 },
            { "Carbon", 0 },
            { "Nitrogen", 0 },
            { "Phosphorus", 0 },
            { "Water", 0 },
            { "Sugar", 0 },
            { "Chitin", 0 }
        };
    
    

    public void OnAdd()
    {
        foreach (var key in myTree.Consuming)
        {
            myTree.AddConsumer(key.Key, consumes[key.Key]);
            myTree.AddProducer(key.Key, adds[key.Key]);
        }
    }

    public void OnRemove()
    {
        foreach (var key in myTree.Consuming)
        {
            myTree.AddConsumer(key.Key, -adds[key.Key]);
            myTree.AddProducer(key.Key, -adds[key.Key]);
        }
    }
}