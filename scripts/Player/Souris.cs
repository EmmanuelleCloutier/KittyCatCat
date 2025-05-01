using Godot;
using System;

public partial class Souris : CharacterBody2D
{
	[Export] public int Speed = 100;
	private Vector2 targetPosition; // La position vers laquelle la souris va se déplacer
	private RandomNumberGenerator rng = new RandomNumberGenerator(); // Générateur de nombres aléatoires
	private AnimatedSprite2D animatedSprite;

	public override void _Ready()
	{
		animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
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
		
			// Retourne l'ennemi si nécessaire
		if (direction.X < 0)
		{
			animatedSprite.Scale = new Vector2(-1, 1); // Retourne l'ennemi à gauche
		}
		else if (direction.X > 0)
		{
			animatedSprite.Scale = new Vector2(1, 1); // Retourne l'ennemi à droite
		}
	}

	private void MoveToRandomPosition()
	{
		
		targetPosition = new Vector2(rng.RandfRange(25,525), rng.RandfRange(15, 230));
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
