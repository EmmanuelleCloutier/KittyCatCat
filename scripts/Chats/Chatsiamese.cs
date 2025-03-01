using Godot;
using System;

public partial class Chatsiamese : CharacterBody2D
{
	[Export] public int Speed = 100; 

	private Node2D player;
	private AnimatedSprite2D animatedSprite;

		public override void _Ready()
	{
		AddToGroup("Enemy"); 
		 animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		CallDeferred(nameof(FindPlayer));
	}

	private void FindPlayer()
	{
		player = GetTree().GetFirstNodeInGroup("Player") as CharacterBody2D;
		 if (player != null)
		{
			GD.Print("Joueur trouvé à : " + player.Position);
		}
	}

	public override void _PhysicsProcess(double delta)
{
	if (player == null || !IsInstanceValid(player))
	{
		player = GetTree().GetFirstNodeInGroup("Player") as CharacterBody2D;
	}

	if (player == null) return;

	// Calcule la direction
	Vector2 direction = (player.Position - Position).Normalized();
	
	// Mets à jour la vélocité de l'ennemi
	Velocity = direction * Speed;

	// Applique le mouvement
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

	
	public void OnBodyEntered(Node body)
	{
		if(body.IsInGroup("Player"))
		{
			QueueFree(); 
			GD.Print("L'ennemi a touché le joueur et a été détruit !");
		}
	}

	public void TakeDamage()
	{
		GameManager.Instance.AddPoints(10); 
		QueueFree(); 
		GD.Print("Destruction ennemy"); 
	}
}
