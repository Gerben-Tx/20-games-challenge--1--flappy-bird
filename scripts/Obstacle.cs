using System;
using System.Diagnostics;
using gameschallenge1FlappyBird.scripts;
using Godot;

public partial class Obstacle : Node2D {
    public float UpperY = -300.0f;
    public float LowerY = 300.0f;
    [Export] private float _minSpaceBetween = 300.0f;
    [Export] private float _speed = 300.0f;

    private Node2D _upper;
    private Node2D _lower;
    private Node2D _middle;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        _upper = GetNode<Node2D>("upper");
        _lower = GetNode<Node2D>("lower");
        _middle = GetNode<Node2D>("middle");

        float diff = Math.Abs(UpperY - LowerY);
        // Debug.WriteLine("diff: "+diff);
        if (diff < _minSpaceBetween) {
            // Debug.WriteLine("diff - _minSpaceBetween: "+(_minSpaceBetween - diff));
            LowerY += _minSpaceBetween - diff;
        }

        Vector2 newUpperPosition = new(_upper.Position.X, UpperY);
        Vector2 newLowerPosition = new(_lower.Position.X, LowerY);

        float upperBottom = newUpperPosition.Y + (_upper.Scale.Y / 2);
        float lowerUpper = newLowerPosition.Y - (_lower.Scale.Y / 2);
        float newMiddleScale = Math.Abs(upperBottom) + lowerUpper;
        float newMiddleY = (upperBottom + lowerUpper) / 2f;
        Vector2 newMiddlePosition = new(_middle.Position.X, newMiddleY);

        // Debug.WriteLine("_upper.Scale: " + _upper.Scale);
        // Debug.WriteLine("_lower.Scale: " + _lower.Scale);
        // Debug.WriteLine("newScale: " + newMiddleScale);
        // Debug.WriteLine("newUpperPosition: " + newUpperPosition);
        // Debug.WriteLine("newLowerPosition: " + newLowerPosition);
        // Debug.WriteLine("newMiddlePosition: " + newMiddlePosition);

        _upper.SetPosition(newUpperPosition);
        _lower.SetPosition(newLowerPosition);
        _middle.SetPosition(newMiddlePosition);
        _middle.Scale = new Vector2(_middle.Scale.X, newMiddleScale);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) {
        if (GameManager.Instance.GameState != GameState.Playing) {
            return;
        }

        Translate(Vector2.Left * (float)(_speed * delta));
    }
}