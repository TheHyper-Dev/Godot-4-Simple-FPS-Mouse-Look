using Godot;
using System;

public partial class MouseLook : Camera3D
{
	[Export] public Vector2 Rot = Vector2.Zero;
	[Export] public Vector2 Sensitivity = Vector2.One;
	public override void _UnhandledInput(InputEvent input)
	{
		if (input is InputEventMouseMotion mouseMotion)
		{
			Rot -= mouseMotion.Relative * Sensitivity;

			if (Math.Abs(Rot.X) > 360f)
				Rot.X = 0f;

			if (Math.Abs(Rot.Y) > 89.9f)
				Rot.Y = Math.Sign(Rot.Y) * 89.9f;
		}
	}
	public override void _Process(double delta)
	{
		Vector3 final_look_rot = new(Rot.Y, Rot.X, 0f); // Might wanna add other effects such as camera shake, gun recoil and so on 
		GlobalRotationDegrees = final_look_rot;
	}
}
