using Godot;
using System;

public partial class blue : Area2D
{
	public override void _Ready()
	{
		if(GameManager.Instance != null)
		{
			GameManager.Instance.PrintMessage("GameManager est actif");
		}
		else {
			GD.Print("Le GameManager na pas ete trouve");
		}
		Connect("body_entered", new Callable(this,"OnBodyEntered"));
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print("Triggered blue pelote");
		
		if(body.IsInGroup("Player"))
		{
			GameManager.Instance.AddPoints(10);
			QueueFree(); 
			GD.Print("Touching");
		}
	}
}
