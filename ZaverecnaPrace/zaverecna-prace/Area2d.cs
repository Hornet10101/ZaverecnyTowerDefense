using Godot;
using System;

public partial class Area2d : Area2D
{
    // Called when the node enters the scene tree for the first time.
    private float speed = 10f;
	public override void _Ready()
	{
	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position = Position with { X = Position.X + speed * (float)delta };
    }
    
    private void OnMouseEntered()
    {
        GD.Print("aaa");
        speed = 0;
        this.QueueFree();
    }
}
