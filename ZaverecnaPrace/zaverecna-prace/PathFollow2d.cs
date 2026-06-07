using Godot;
using System;

public partial class PathFollow2d : PathFollow2D
{
	// Called when the node enters the scene tree for the first time.
	private float speed = 0.00f;
	[Signal]
	public delegate void FinishLineEventHandler();
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ProgressRatio += speed;
		if(ProgressRatio >= 0.999)
		{
			EmitSignal(SignalName.FinishLine);
		}
	}
}
