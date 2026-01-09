using System.Collections.Generic;
using Godot;

public partial class DROP_HealStar : Area2D
{
	public const int HEAL = 35;


	public override void _Ready()
	{
		this.BodyEntered += __heal_entity;
	}

	private void __heal_entity(Node other)
	{
		IEntity entity = other as IEntity;
		if(entity != null)
		{
			if(entity.Health >= entity.MaxHealth) return;
			entity.Health += HEAL;
			QueueFree();
		}
	}
}
