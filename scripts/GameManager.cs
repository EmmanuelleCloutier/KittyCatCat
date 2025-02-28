using Godot;
using System;

public partial class GameManager : Node
{
	private HUD hud;
	public static GameManager Instance;
	
	public override void _Ready()
	{
		Instance = this;
		hud = GetNode<HUD>("/root/Game/HUD");
	}
	
	public void PrintMessage(string message)
	{
		GD.Print(message);
	}
	
	public void AddPoints(int amount)
	{
		hud.AddScore(amount);
	}
}
