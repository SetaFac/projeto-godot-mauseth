using Godot;
using System.Collections.Generic;

public partial class OBS_Pike : StaticBody2D
{
	private List<IEntity> entityToDamage = new List<IEntity>();
	private Area2D dmgCollision = null;

	public const int DAMAGE = 20;

	public override void _Ready()
	{
		dmgCollision = GetNode<Area2D>("Damage");
		dmgCollision.BodyEntered += __mark_to_deal_damage;
		dmgCollision.BodyExited += __remove_damage_mark;
	}

	public override void _Process(double delta)
	{
		if(entityToDamage.Count <= 0) return;
		foreach(IEntity e in entityToDamage)
		{
			e.TakeDamage(DAMAGE);
		}
	}

	private void __mark_to_deal_damage(Node other)
	{
		IEntity entity = other as IEntity;
		if(entity != null)
		{
			entityToDamage.Add(entity);
		}		
	}

	private void __remove_damage_mark(Node other)
	{
		IEntity entity = other as IEntity;
		if(entity != null)
		{
			if(!entityToDamage.Contains(entity)) return;
			entityToDamage.Remove(entity);
		}
	}
}
