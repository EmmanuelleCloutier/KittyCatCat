using Godot;
using System;

public class Hud : Node2D
{
	[Export] public Label stopwatchLabel;
	[Export] public Label scoreLabel;

	private Stopwatch stopwatch; 

	public override void _Ready()
	{
		
		stopwatch = GetNode<Stopwatch>("Stopwatch"); 

		if (stopwatch != null)
		{
			GD.Print("Stopwatch trouvé");
		}
		else
		{
			GD.Print("Aucune instance de Stopwatch trouvee");
		}

		if (GameManager.Instance != null)
		{
			GD.Print("gamemanager est accessible");
		}
		else
		{
			GD.Print("Aucune instance de game manager trouvee");
		}
	}

	public override void Process(float delta)
	{
		UpdateStopwatchLabel();
		UpdateScoreLabel();
	}

	private void UpdateStopwatchLabel()
	{
		if (stopwatch != null)
		{
			stopwatchLabel.Text = stopwatch.TimeToString(); 
		}
	}

	private void UpdateScoreLabel()
	{
		scoreLabel.Text = "Score: " + GameManager.Instance.GetScore().ToString();
		GD.Print("into updated score fonction");
	}
}
