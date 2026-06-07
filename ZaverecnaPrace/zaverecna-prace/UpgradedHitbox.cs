using Godot;
using System;

public partial class UpgradedHitbox : CollisionShape2D
{
    // Called when the node enters the scene tree for the first time.
    private CollisionShape2D _collisionShape;
    private int radiusChange = 15;
    public override void _Ready()
	{

    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    private void OnMouseEntered()
    {
        Visible = true;
    }
    private void OnMouseExited()
    {
        Visible = false;
    }
    private void OnUpgrade()
    {
        if (Shape is CircleShape2D circleShape)
        {
            circleShape.Radius += radiusChange;
        }
    }
}
