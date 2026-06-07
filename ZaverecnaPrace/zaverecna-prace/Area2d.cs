using Godot;
using System;

public partial class Area2d : Area2D
{
    // Called when the node enters the scene tree for the first time.
    private float speedX = 20f;
    private float speedY = 0f; 
	public override void _Ready()
	{
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position = Position with { X = Position.X + speedX * (float)delta };
        Position = Position with { Y = Position.Y + speedY * (float)delta };
    }
    
    private void OnMouseEntered()
    {
        GD.Print("aaa");
        speedX = 0;
        //this.QueueFree();
    }
    private void OnMouseExited()
    {
        speedX = 20f;
    }
    public void OnArea2d2AreaEntered(Area2d area)
    {
        GD.Print("cc");
        speedX = 0f;
        speedY = 20f;
    }
}
