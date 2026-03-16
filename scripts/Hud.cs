using Godot;
using System;
using System.Diagnostics;

public partial class Hud : Control
{
	private Label _scoreLabel;
	private Label _bestScoreLabel;
	private Label _endScreenScoreLabel;
	private Label _endScreenBestScoreLabel;
	private Control _endScreen;
	private Control _pauseScreen;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		// TODO: Better replacement for this is letting a HUD script register the Score label to the Game Manager
		//  Like `GameManager.Instance.RegisterScoreLabel(_scoreLabel);`
		_scoreLabel = GetNode<Label>("/root/main/HUD/VBoxContainer/HBoxContainer/Score");
		_bestScoreLabel = GetNode<Label>("/root/main/HUD/VBoxContainer/HBoxContainer2/BestScore");
		_endScreenScoreLabel = GetNode<Label>("/root/main/END_GAME/Panel/VBoxContainer/HBoxContainer/Score");
		_endScreenBestScoreLabel = GetNode<Label>("/root/main/END_GAME/Panel/VBoxContainer/HBoxContainer2/BestScore");
		_endScreen = GetNode<Control>("/root/main/END_GAME");
		_pauseScreen = GetNode<Control>("/root/main/PAUSE");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// TODO: use something like events to only update when there is a change
		_scoreLabel.Text = GameManager.Instance.Score.ToString();
		_bestScoreLabel.Text = GameManager.Instance.BestScore.ToString();
	}

	public void ShowEndScreen() {
		_endScreenScoreLabel.Text = GameManager.Instance.Score.ToString();
		_endScreenBestScoreLabel.Text = GameManager.Instance.BestScore.ToString();
		
		_endScreen.Visible = true;
	}

	public void ShowPauseScreen() {
		_pauseScreen.Visible = true;
	}
	
	public void HidePauseScreen() {
		_pauseScreen.Visible = false;
	}
}
