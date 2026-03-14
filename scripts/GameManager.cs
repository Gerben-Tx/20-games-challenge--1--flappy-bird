using Godot;
using System;
using System.Diagnostics;
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

	public void IncreaseScore() {
		// TODO: Better replacement for this is letting a HUD script register the Score label to the Game Manager
		//  Like `GameManager.Instance.RegisterScoreLabel(_scoreLabel);`
		Label scoreLabel = GetNode<Label>("/root/main/HUD/VBoxContainer/HBoxContainer/Score");
		Debug.WriteLine(scoreLabel);
		int score = int.Parse(scoreLabel.Text);
		score += 1;
		scoreLabel.Text = score.ToString();
		
		Debug.WriteLine("Increased Score: " + score);
	}
}
