using Godot;
using System;

public partial class HUD : CanvasLayer
{
	 private Label scoreLabel;
	private int score = 0;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("ScoreLabel");
		UpdateScoreLabel();
	}

	public void AddScore(int amount)
	{
		score += amount;
		UpdateScoreLabel();
	}

	private void UpdateScoreLabel()
	{
		scoreLabel.Text = $"Score: {score}";
	}
}
