using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Label : Godot.Label
{
	// Called when the node enters the scene tree for the first time.
	private string text = "zivoty: ";
	private int lives = 10;
	private string text2 = string.Empty;
	[Signal]
	public delegate void GameOverEventHandler();
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		text2 = text + lives.ToString();
		Text = text2;
		if(lives == 0)
		{
			EmitSignal(SignalName.GameOver);
		}
	}
	private void OnEnemySpawnerFinishLine()
	{
		lives--;
	}
}
