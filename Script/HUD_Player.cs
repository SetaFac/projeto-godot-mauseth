using Godot;
using System;

public partial class HUD_Player : CanvasLayer
{	
	private Player focusPlayer = null;
	private TextureProgressBar healthBar = null;

	public override void _Ready()
	{
		focusPlayer = GetTree().CurrentScene.GetNode<Player>("Player");
		if(focusPlayer == null)
		{
			QueueFree();
			return;
		}
		healthBar = GetNode<TextureProgressBar>("HealthBar");
		focusPlayer.OnHealthChange += __update_player_health;
	}

	private void __update_player_health()
	{
		healthBar.Value = focusPlayer.Health;
	}
}
