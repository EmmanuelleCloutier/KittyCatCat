using Godot;
using System;

public partial class Reseting : Node
{
	public override void _Ready()
	{
		GameManager.Instance.ResetScore();
	}
}
