using Godot;
using System.Linq;

public partial class PUI_Sword : Area2D, IItem
{
    string IItem.Name => "Broken Craved Sword";

    public string Description => "A half part of a craved sword.";

    public double Price => 2000.00;

    public string ItemSprite => "";

    public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("action"))
		{
			Player player = this.GetOverlappingBodies().FirstOrDefault(n => n is Player) as Player;
			if(player != null) QueueFree();
			return;
		}
	}
}
