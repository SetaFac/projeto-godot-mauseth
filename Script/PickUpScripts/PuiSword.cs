using Godot;
using System.Linq;

public partial class PuiSword : Area2D, IPickableItem
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("action"))
		{
			Player player = this.GetOverlappingBodies().FirstOrDefault(n => n is Player) as Player;
			if(player != null) PickUp();
			return;
		}
	}

	public void PickUp()
	{
		QueueFree();
	}
}
