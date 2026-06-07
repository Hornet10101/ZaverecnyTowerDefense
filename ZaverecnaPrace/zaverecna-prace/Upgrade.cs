using Godot;
using System;

public partial class Upgrade : Button
{
	// Called when the node enters the scene tree for the first time.
    private int towerType = 0;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (towerType == 1 && MoneyManager.Instance.Money < 100)
        {
            Disabled = true;
        }
        else if(towerType == 2 && MoneyManager.Instance.Money < 200)
        {
            Disabled = true;
        }
        else
        {
            Disabled = false;
        }
	}
    private void OnButton1Pressed()
    {
        towerType = 1;
    }
    private void OnButton2Pressed()
    {
        towerType = 2;
    }
}
