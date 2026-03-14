using Godot;
using System;
using gameschallenge1FlappyBird.scripts;

public partial class GameManager : Node {
	public GameState GameState { get; private set; }
	public static GameManager Instance { get; private set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Instance = this;
		GameState = GameState.Playing;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void EndGame() {
		GameState = GameState.End;
	}
}
