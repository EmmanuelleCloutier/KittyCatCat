using Godot;
using System;
using System.Collections.Generic;

public partial class EnnemySpawner : Node2D
{
	[Export] public PackedScene Enemy1;
	[Export] public PackedScene Enemy2;
	[Export] public PackedScene Enemy3;
	[Export] public PackedScene Enemy4;
	[Export] public PackedScene Enemy5;
	[Export] public PackedScene Enemy6;
	[Export] public PackedScene Enemy7;
	
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Timer spawnTimer; 
	
	public override void _Ready()
	{
		rng.Randomize();
	}
	
	 private void OnTimerTimeout()
	{
		SpawnEnemies(1); 
	}

	private void SpawnEnemies(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			SpawnRandomEnemy();
		}
	}

	private void SpawnRandomEnemy()
	{
		PackedScene[] enemyScenes = { Enemy1, Enemy2, Enemy3, Enemy4, Enemy5, Enemy6, Enemy7 };
		int randomIndex = rng.RandiRange(0, enemyScenes.Length - 1);
		PackedScene selectedEnemy = enemyScenes[randomIndex];

		Node2D enemy = selectedEnemy.Instantiate<Node2D>();

		Vector2 randomPosition = new Vector2(rng.RandfRange(25,525), rng.RandfRange(15,230));
		enemy.Position = randomPosition;

		AddChild(enemy);
		
	}
}
