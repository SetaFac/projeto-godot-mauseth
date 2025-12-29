using Godot;
using System;
using System.Collections.Generic;

public enum PlayerStates {NORMAL, HITTED, DEAD};

public partial class Player : CharacterBody2D
{
	public delegate void VitalPlayerHandler();
	public event VitalPlayerHandler OnHealthChange;


	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;


	private Dictionary<string, Timer> cooldown;
	private PlayerStates vitalState = PlayerStates.NORMAL;

	private int maxHealth = 100;
	private int health = 0;
	private int x_dir = 1;

	private ExtendedSprite2D sprite = null;

	public override void _Ready()
	{
		base._Ready();

		health = maxHealth;
		cooldown = new Dictionary<string, Timer>()
		{
			{"HITTED", new Timer(){WaitTime=1, Autostart=false, OneShot=true}}
		};
		cooldown["HITTED"].Timeout += () => 
		{vitalState = PlayerStates.NORMAL; sprite.StopEffect();};
		foreach(Timer t in cooldown.Values)
		{
			AddChild(t);
		}

		sprite = GetNode<ExtendedSprite2D>("Sprite");
	}

	public override void _Process(double delta)
	{
		sprite.FlipH = x_dir < 0;
	}

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("left", "right", "up", "down");
		velocity.X = direction.X * Speed;

		if(direction != Vector2.Zero)
		{
			x_dir = (int)direction.X;
		}

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}		

		Velocity = velocity;
		MoveAndSlide();
	}


	public void TakeDamage(int damage)
	{
		vitalState = PlayerStates.HITTED;
		Health -= damage;
		cooldown["HITTED"].Start();
		sprite.LoadEffect(TypeEXTEffect.FADE);
		sprite.PlayEffect();
	}

	public int Health
	{
		get
		{
			return health;
		}
		set
		{
			value = Math.Min(value, maxHealth);
			value = Math.Max(value, 0);

			health = value;
			OnHealthChange?.Invoke();
		}
	}
}
