using Godot;
using System;

public partial class Chat3Couleur : CharacterBody2D
{
	[Export] public int Speed = 100; 
	[Export] public int Points = 25; 

	private Node2D player;
	private AnimatedSprite2D animatedSprite;

		public override void _Ready()
	{
		AddToGroup("Enemy"); 
		 animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	  public override void _PhysicsProcess(double delta)
	{
		if (player == null || !IsInstanceValid(player))
			player = GetTree().GetFirstNodeInGroup("Player") as Node2D;

		if (player == null) return; // Si pas de joueur, ne rien faire

		Vector2 direction = (player.Position - Position).Normalized();
		Velocity = direction * Speed;

		MoveAndSlide();
		 if (direction.X < 0)
		{
			animatedSprite.Scale = new Vector2(-1, 1); // Regarde à gauche
		}
		else if (direction.X > 0)
		{
			animatedSprite.Scale = new Vector2(1, 1); // Regarde à droite
		}
	}

	public void TakeDamage()
	{
		GameManager.Instance.AddPoints(Points); 
		QueueFree(); 
		GD.Print("Destruction ennemy"); 
	}
}
