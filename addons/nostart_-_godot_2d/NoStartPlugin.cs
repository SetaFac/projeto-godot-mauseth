#if TOOLS
using Godot;
using System;

[Tool]
public partial class NoStartPlugin : EditorPlugin
{
	public const string TYPE_NAME = "ExtendedSprite2D";
	public const string EXTENDED_TYPE = "Sprite2D";

	public override void _EnterTree()
	{
		Script script = GD.Load<Script>("res://addons/nostart_-_godot_2d/ExtendedSprite2D.cs");
		AddCustomType(TYPE_NAME, EXTENDED_TYPE, script, null);
	}

	public override void _ExitTree()
	{
		RemoveCustomType(TYPE_NAME);
	}
}
#endif
