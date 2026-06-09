using Godot;
using System;

public partial class Enemy1 : PathFollow2D
{
	// Called when the node enters the scene tree for the first time.
	[Export]
	public float Speed = 100f;

	[Signal]
	public delegate void DiedEventHandler();

	[Export]
	public bool slowed = false;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Progress += Speed * (float)delta;
		if (ProgressRatio >= 0.99f)
		{
			EmitSignal(SignalName.Died);
			OnDeath();
		}
	}
	public void OnDeath()
	{
		QueueFree();
		MoneyManager.Instance.Money += 2;
	}
}
