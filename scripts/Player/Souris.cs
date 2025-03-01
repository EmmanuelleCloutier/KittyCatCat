using Godot;
using System;

public partial class Souris : CharacterBody2D
{
	[Export] public int Speed = 100;
	private Vector2 targetPosition; // La position vers laquelle la souris va se déplacer
	private RandomNumberGenerator rng = new RandomNumberGenerator(); // Générateur de nombres aléatoires

	public override void _Ready()
	{
		rng.Randomize(); 
		MoveToRandomPosition();
	}

	public override void _PhysicsProcess(double delta)
	{
		
		if (Position.DistanceTo(targetPosition) < 10) 
		{
			MoveToRandomPosition();
		}

		Vector2 direction = (targetPosition - Position).Normalized();
		
		Velocity = direction * Speed;
		
		MoveAndSlide();
	}

	private void MoveToRandomPosition()
	{
		
		targetPosition = new Vector2(rng.RandfRange(100, 500), rng.RandfRange(100, 300));
	}

	public void OnBodyEntered(Node body)
	{
		
		if (body.IsInGroup("Player"))
		{
			GameManager.Instance.AddPoints(15); 
			QueueFree(); 
			GD.Print("La souris a touché le joueur et a été détruite !");
		}
	}
}
