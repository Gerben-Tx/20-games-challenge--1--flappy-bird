using Godot;
using System;
using System.Diagnostics;
using gameschallenge1FlappyBird.scripts;

public partial class GameManager : Node {
	public GameState GameState { get; private set; }
	public static GameManager Instance { get; private set; }
	public int Score { get; private set; } = 0;
	public int BestScore { get; private set; } = 0;
	private AudioStream _lose;
	private AudioStream _point;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		Instance = this;
		ProcessMode = ProcessModeEnum.Always; // Ignore pause, so we can handle inputs to unpause the game
		
		_lose = GD.Load<AudioStream>("res://sounds/lose.mp3");
		_point = GD.Load<AudioStream>("res://sounds/point.mp3");
		
		StartGame();
	}

	private Hud FindHud() {
		return (Hud)GetNode<Control>("/root/main/HUD");
	}

	private AudioStreamPlayer GetAudioStreamPlayer() {
		return GetNode<AudioStreamPlayer>("/root/main/AudioStreamPlayer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GameState == GameState.End) {
			if (Input.IsActionJustPressed("Restart")) {
				GetTree().ReloadCurrentScene();
				
				StartGame();
			}
		} else if (GameState == GameState.Playing) {
			if (Input.IsActionJustPressed("Pause")) {
				PauseGame();
			}
		} else if (GameState == GameState.Paused) {
			if (Input.IsActionJustPressed("Pause")) {
				UnPauseGame();
			}
		}
	}

	private void UnPauseGame() {
		FindHud().HidePauseScreen();
		GetTree().Paused = false;
		
		GameState = GameState.Playing;
	}

	private void PauseGame() {
		GameState = GameState.Paused;
		
		GetTree().Paused = true;
		FindHud().ShowPauseScreen();
	}

	private void StartGame() {
		Debug.WriteLine("StartGame");
		
		Score = 0;
		GameState = GameState.Playing;
	}
	
	public void EndGame() {
		Debug.WriteLine("EndGame");
		
		// TODO: Replacing this with some sort of state machine would allow me to bind action to changing the game state
		//  for example: when the gamestate ends, show the end screen
		//  when the gamestate goes to playing, update the bestScore label once
		//  etc...
		GameState = GameState.End;
		
		// Update best score
		BestScore = Score > BestScore  ? Score : BestScore;

		GetAudioStreamPlayer().Stream = _lose;
		GetAudioStreamPlayer().Play();
		
		FindHud().ShowEndScreen();
	}

	public void IncreaseScore() {
		Score += 1;
		GetAudioStreamPlayer().Stream = _point;
		GetAudioStreamPlayer().Play();
		Debug.WriteLine("Increased Score: " + Score);
	}
}
