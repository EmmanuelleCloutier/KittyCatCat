using Godot;
using System;

public partial class Coin : Area2D
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
		Connect("_on_body_entered", new Callable(this,"OnBodyEntered"));
	}

	private void OnBodyEntered(Node body)
	{
		GD.Print("Triggered");
		
		if(body.IsInGroup("Player"))
		{
			GameManager.Instance.AddPoints(10);
			QueueFree(); 
			GD.Print("Touching");
		}
	}
}
