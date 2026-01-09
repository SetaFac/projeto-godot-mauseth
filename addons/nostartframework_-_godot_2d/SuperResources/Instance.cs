using System;
using Godot;

namespace nostart_framework_godot.SuperResources;

public static class Instance
{
    /*
    public static CanvasLayer CreateHUD(string pathToEnty, Node where)
    {
        PackedScene localInst = GD.Load<PackedScene>(pathToEnty);
        CanvasLayer nodeToInst = localInst.Instantiate<CanvasLayer>();

        where.CallDeferred("add_child", nodeToInst);
        return nodeToInst;
    }
    */

    public static Node2D New(string objPath, Node parent, Vector2 location)
    {
        PackedScene localInst = GD.Load<PackedScene>(objPath);
        Node2D nodeToInst = localInst.Instantiate<Node2D>();

        nodeToInst.GlobalPosition = location;
        parent.CallDeferred("add_child", nodeToInst);
        return nodeToInst;
    }

    public static int CountInstace(Type type, Node where)
    {
        int amount = 0;
        foreach (Node i in where.GetChildren())
        {
            if (type.IsAssignableFrom(i.GetType()))
            {
                amount++;
            }
        }
        return amount;
    }
}