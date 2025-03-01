using Godot;
using System;

public partial class SourisSpawner : Node2D
{
	[Export] public PackedScene MouseScene;
	
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Timer spawnTimer; 
	
	public override void _Ready()
	{
		rng.Randomize();
	}
	
	private void OnTimerTimeout()
	{
		SpawnMouse(); 
	}
	
	private void SpawnMouse()
	{
		Node2D mouse = MouseScene.Instantiate<Node2D>();
		Vector2 randomPosition = new Vector2(rng.RandfRange(100, 500), rng.RandfRange(100, 300));
		mouse.Position = randomPosition;

		GD.Print("Mouse is running around"); 
		AddChild(mouse);
	}
}
