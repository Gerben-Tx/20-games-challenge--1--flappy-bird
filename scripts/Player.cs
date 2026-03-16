using Godot;
using System;
using System.Diagnostics;
using gameschallenge1FlappyBird.scripts;

public partial class Player : Node
{
	[Export] private float jumpForce = 500; 

	private RigidBody2D playerBody;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		playerBody = GetNode<RigidBody2D>("RigidBody2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GameManager.Instance.GameState != GameState.Playing) {
			return;
		}
		
		if (Input.IsActionJustPressed("Jump")) {
			playerBody.ApplyForce(Vector2.Up * jumpForce);
		}
	}

	public void OnAreaEntered(
		Area2D area
	) {
		Debug.WriteLine("OnAreaEntered: " + area.GetParent().Name);
		
		if (area.GetParent().Name == "upper" || area.GetParent().Name == "lower") {
			GameManager.Instance.EndGame();
		} else if (area.GetParent().Name == "middle") {
			GameManager.Instance.IncreaseScore();
		} else if (area.GetParent().Name == "ground") {
			GameManager.Instance.EndGame();
		}
	}
}
