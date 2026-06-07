using Godot;
using System;

public partial class MoneyManager : Node
{
	// Called when the node enters the scene tree for the first time.
	public static MoneyManager Instance { get; private set; }
	public double Money = 250;
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
