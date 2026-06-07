using Godot;
using System;

public partial class TowerHitbox : CollisionShape2D
{
    // Called when the node enters the scene tree for the first time.
    private CollisionShape2D _collisionShape;
    private float radiusChange = 15f;
    public override void _Ready()
	{
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
    private void OnCoreAreaMouseEntered()
    {
        Visible = true;
    }
	private void OnCoreAreaMouseExited()
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
