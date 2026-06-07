using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class UpgrSell : Label
{
    // Called when the node enters the scene tree for the first time.
    
    private string UpgradeDesc1 = "Upgrades the tower.\nRange increased by 15 pixels\nCooldown decreased by 0.15s\nCost: 100C";
    private string UpgradeDesc2 = "Upgrades the tower.\nRange increased by 15 pixels\r\nCooldown decreased by 0.8s\nCost: 200C";
    private string SellDesc1 = "Sells the tower.\nRefund: 80C";
    private string SellDesc2 = "Sells the tower.\nRefund: 160C";
    private int towerType = 0;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
    private void OnButton1MouseEntered()
    {
        if(towerType == 1)
        {
            Text = UpgradeDesc1;
        }
        else if(towerType == 2)
        {
            Text = UpgradeDesc2;
        }
    }
    private void OnButton2MouseEntered()
    {
        if (towerType == 1)
        {
            Text = SellDesc1;
        }
        else if (towerType == 2)
        {
            Text = SellDesc2;
        }
    }
    private void OnMouseExited()
    {
        Text = "";
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
