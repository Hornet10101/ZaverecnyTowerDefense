using Godot;
using System;

public partial class Moneh : Label
{
	// Called when the node enters the scene tree for the first time.
	private string txt = "Coins: ";
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = txt + MoneyManager.Instance.Money.ToString();
    }
}
