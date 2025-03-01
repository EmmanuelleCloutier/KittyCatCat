using Godot;
using System;

public partial class Points : Node
{
	[Export] private Label scoreLabel; 
	
	public override void _Process(double delta)
	{
		if (scoreLabel != null && GameManager.Instance != null)
			{
				scoreLabel.Text = "Score: " + GameManager.Instance.GetScore().ToString();
			}
	}
}
