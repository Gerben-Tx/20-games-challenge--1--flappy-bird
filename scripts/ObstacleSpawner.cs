using Godot;
using System;
using System.Data;
using System.Diagnostics;

public partial class ObstacleSpawner : Node {
	[Export] private PackedScene _obstacleScene; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// for (int i = 0; i < 5; i++) {
		// 	SpawnObstacle(new Vector2(screenWidth + (i * 200), 300));
		// }
		
		SpawnObstacle();
	}

	private void SpawnObstacle() {
		Vector2 viewportSize = GetViewport().GetVisibleRect().Size;
		float screenWidth = viewportSize.X;
		float screenHeight = viewportSize.Y;
		
		Node2D node2d = _obstacleScene.Instantiate<Node2D>();
		node2d.SetPosition(new Vector2(screenWidth + 100, screenHeight / 2)); // +100 so it starts of screen
		
		Obstacle obstacle = node2d as Obstacle;
		Random rand = new();
		obstacle.LowerY = rand.Next(250, 470);
		obstacle.UpperY = rand.Next(350, 600) * -1;
		// obstacle.LowerY = 400;
		// obstacle.UpperY = -400;
		
		AddChild(node2d);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnDetectorObstacleEntered(
		Area2D area2D
	) {
		Debug.WriteLine("Obstacle entered: "+area2D.Name);

		if (area2D.GetParent().Name == "middle") {
			SpawnObstacle();
		}
	}

	private void OnDetectorObstacleExited(
		Area2D area2D
	) {
		// Debug.WriteLine("Obstacle exited: "+area2D.Name);

		if (area2D.GetParent().Name == "middle") {
			area2D.GetParent().QueueFree();
		}
	}
}
