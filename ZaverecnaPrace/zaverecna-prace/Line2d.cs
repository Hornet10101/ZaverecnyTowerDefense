using Godot;
using System;

public partial class Line2d : Line2D
{
	// Called when the node enters the scene tree for the first time.
	float towerx = 41f;
	float towery = 19f;
	float timer = 100f;
	public override void _Ready()
	{
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		timer--;
		if (timer == 0)
		{
			Visible = false;
		}
	}
	private void OnHit(float towerX, float towerY, float targetX, float targetY)
	{
		var arr = Points;
		arr[0].X = towerx;
		arr[0].Y = towery;
		arr[1].X = targetX-towerX + towerx;
		arr[1].Y = targetY- towerY  +towery;
		//nevim proc to funguje ale funguje to
		Points = arr;
		Visible = true;
		timer = 100;
		
	}
}
