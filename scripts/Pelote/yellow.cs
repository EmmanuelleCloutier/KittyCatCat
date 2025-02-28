using Godot;
using System;

public partial class yellow : Area2D
{
	 public override void _Ready()
	{
		
		if (GameManager.Instance != null)
		{
			GD.Print("GameManager est actif");
		}
		else
		{
			GD.Print("Le GameManager n'a pas été trouvé");
		}
		
		
		Connect("body_entered", new Callable(this, "OnBodyEntered"));
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print("Triggered yellowball");

		
		if (body.IsInGroup("Player"))
		{
			
			GameManager.Instance.AddPoints(10);
			QueueFree(); 
			GD.Print("Touching");
		}
	}
}
