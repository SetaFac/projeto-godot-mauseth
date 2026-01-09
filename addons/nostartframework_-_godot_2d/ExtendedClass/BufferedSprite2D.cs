using Godot;
using System;

namespace nostart_framework_godot.ExtendedClass;

public enum EffectStyles
{
	EasyAlphaParse
}

public partial class BufferedSprite2D : Sprite2D
{
	public delegate void BufferedEffects();

	#nullable
	public event BufferedEffects? OnEffectEnded;

	private Godot.Timer effectTimer = new Godot.Timer();

	private EffectStyles effect;

	private bool started = false;
	private bool stopped = false;

	Color alphaDyn;
	float alphaChange = 0;

	public void StartEffect()
	{
		started = true;
		effectTimer.Start();
	}

	public void StopEffect()
	{
		stopped = true;
		SelfModulate = new Color(SelfModulate.R, SelfModulate.G, SelfModulate.B, 1);
	}

	public void ReloadEffect()
	{
		started = false;
		stopped = false;

		alphaDyn = SelfModulate;
	}

	public override void _Ready()
	{
		alphaDyn = SelfModulate;

		effectTimer.Timeout += () =>
		{
			StopEffect();
			ReloadEffect();
			OnEffectEnded?.Invoke();
		};
		AddChild(effectTimer);
	}

	public override void _Process(double delta)
	{
		if (started && !stopped) EffectProcessor();
	}


	private void EffectProcessor()
	{
		switch (effect)
		{
			case EffectStyles.EasyAlphaParse:
				_on_easyalphaparse_effect();
				break;
		}
	}

	private void _on_easyalphaparse_effect()
	{
		float parseValue = 0.1f;
		if (alphaDyn.A >= 1)
		{
			alphaChange = -parseValue;
		}
		else if (alphaDyn.A <= 0)
		{
			alphaChange = parseValue;
		}
		alphaDyn.A += alphaChange;
		SelfModulate = alphaDyn;
	}

	public bool EffectStarted { get{ return started; }}
	public bool EffectStopped { get{ return stopped; }}
	public double EffectTime { get { return effectTimer.WaitTime; } set { effectTimer.WaitTime = value; } }
	public EffectStyles CurrentEffect { get { return effect; } set { effect = value; } }
}
