using Godot;
using System;

public partial class yellow : Area2D
{
	 public override void _Ready()
	{
		Connect("body_entered", new Callable(this, "OnBodyEntered"));
	}

	private void OnBodyEntered(Node body)
	{	
		if (body.IsInGroup("Player"))
		{
			
			GameManager.Instance.AddPoints(2);
			QueueFree(); 
		}
	}
}
