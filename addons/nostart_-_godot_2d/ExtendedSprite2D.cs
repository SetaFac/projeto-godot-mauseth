using Godot;
using System;

public enum TypeEXTEffect {BLINK, WHITE_BLINK, FADE };
public enum EffectLoaderState {STOPPED, PLAYING, LOADED, UNLOADED};


/// <summary>
/// [b]TESTE[/b]
/// 
/// This node extends of Sprite2D adding new animated effects features. Allowing set and load one of 
/// three animated effect types: BLINK, WHITE BLINK, FADE.
/// </summary>
[Tool, Icon("res://addons/nostart_-_godot_2d/ExtendedSprite2D.png")]
public partial class ExtendedSprite2D : Sprite2D
{
	private TypeEXTEffect typeEffect = TypeEXTEffect.FADE;
	private EffectLoaderState effectLoaderState = EffectLoaderState.UNLOADED;

	private Sprite2D originalState = null;
	private bool started = false;
	private float tax_fade_alpha = 0.2f;
	private float fade_alpha;

	public override void _Ready()
	{
		base._Ready();
		originalState = this;
	}

	public override void _Process(double delta)
	{
		if(!started) return;

		switch(typeEffect)
		{
			case TypeEXTEffect.BLINK:
				__play_blink();
			break;

			case TypeEXTEffect.WHITE_BLINK:
				__play_white_blink();
			break;

			case TypeEXTEffect.FADE:
				__play_fade();
			break;
		}
	}


	public void LoadEffect(TypeEXTEffect newEffect)
	{
		typeEffect = newEffect;
		effectLoaderState = EffectLoaderState.LOADED; 
	}

	public void PlayEffect()
	{
		this.Modulate = originalState.Modulate;
		started = true;
		effectLoaderState = EffectLoaderState.PLAYING;
	}

	public void StopEffect()
	{
		started = false;
		this.Modulate = originalState.Modulate;
		effectLoaderState = EffectLoaderState.STOPPED;
	}


	private void __play_blink()
	{
		
	}

	private void __play_white_blink()
	{
		
	}

	private void __play_fade()
	{
		Color newModule = Modulate;
		if(Modulate.A >= 1)
		{
			fade_alpha = -tax_fade_alpha;
		}
		else if(Modulate.A <= 0)
		{
			fade_alpha = tax_fade_alpha;
		}
		newModule.A += fade_alpha;
		Modulate = newModule;
	}

	public bool IsStarted => started;
	public TypeEXTEffect EffectLoaded {get=>typeEffect;}
	public EffectLoaderState EffectLoaderState {get=>effectLoaderState;}
}
