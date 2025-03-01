using Godot;
using System;

public partial class GameManager : Node
{
	private int score = 0; 
	public static GameManager Instance {get; private set;}  

	public override void _Ready()
	{
		if (Instance == null)
		{
			Instance = this; 
			GD.Print("GameManager initialisé");
		}
		else
		{
			QueueFree(); 
			GD.Print("Une instance de GameManager existe déjà !");
		}
	}

	public void PrintMessage(string message)
	{
		GD.Print(message);
	}

	public void AddPoints(int amount)
	{
		score += amount;
		GD.Print("Score ajouté: " + score);
	}

	public int GetScore()
	{
		return score;
	}
	
	public void ResetScore()
	{
		score = 0; 
	}
}
