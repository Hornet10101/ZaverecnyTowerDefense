using Godot;
using System;

public partial class TowerDesc : Label
{
	// Called when the node enters the scene tree for the first time.
	private string tower1Desc = "Basic tower.\nCooldown: 1s\nDamage: 1 \nCost: 100C";
	private string tower2Desc = "Does AoE damage.\nCooldown: 8s\nDamage: 1\nCost: 200C";


    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnButton1MouseEntered()
	{
		Text = tower1Desc;
	}
    private void OnButton2MouseEntered()
    {
		Text = tower2Desc;
    }
    private void OnMouseExited()
    {
        Text = "";
    }
}
