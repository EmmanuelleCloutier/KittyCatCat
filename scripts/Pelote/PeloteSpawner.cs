using Godot;
using System;
using System.Collections.Generic;

public partial class PeloteSpawner : Node2D
{
	[Export] public PackedScene PINKpelote;
	[Export] public PackedScene BLUEpelote;
	[Export] public PackedScene YELLOWpelote;
	
	private RandomNumberGenerator rng = new RandomNumberGenerator();
	private Timer spawnTimer;
	
	public override void _Ready()
	{
		rng.Randomize();
	}
	
	private void OnTimerTimeout()
	{
		SpawnCoins(5); 
	}
	
	private void SpawnCoins(int amount)
	{
		for (int i = 0; i < amount; i++)
		{
			SpawnRandomCoin();
		}
	}
	
	private void SpawnRandomCoin()
	{
		PackedScene[] coinsScenes = { PINKpelote, BLUEpelote, YELLOWpelote };
		int randomIndex = rng.RandiRange(0, coinsScenes.Length - 1);
		PackedScene selectedCoin = coinsScenes[randomIndex];
		
		Node2D coin = selectedCoin.Instantiate<Node2D>();
		
		Vector2 randomPosition = new Vector2(rng.RandfRange(25,525), rng.RandfRange(15,230));
		
		coin.Position = randomPosition;
		AddChild(coin);
	}
}
