using Godot;
using System;
using System.Collections.Generic;

public partial class Towerspot : Area2D
{
	// Called when the node enters the scene tree for the first time.
	[Signal]
	public delegate void Tower1ChosenEventHandler();
	[Signal] 
	public delegate void Tower2ChosenEventHandler();
	[Signal]
	public delegate void LineCoordEventHandler(float selfX, float selfY, float targetX, float targetY);
	[Signal]
	public delegate void SoldEventHandler();

    private List<Enemy1> targets = new();
	private int tower1Cost = 100;
	private int tower2Cost = 200;
	private double refund = 0.8;
	private float tower1Cooldown = 150f;
	private float tower2Cooldown = 800f;
    private float cooldown = 0;

	private int towerLevel = 0;
	private int towerType = 0; //0 - tower not built, 1 - regular,
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		cooldown--;
		//GD.Print(cooldown);
		//GD.Print(targets.Count);
		if (towerType == 1) { Tower1Shooting(); }
		if (towerType == 2) { Tower2Shooting(); }

	}
	private void Tower1Shooting()
	{
        if (cooldown <= 0 && targets.Count != 0)
        {
            Enemy1 target = targets[0];
            EmitSignal(SignalName.LineCoord, Position.X, Position.Y, target.Position.X, target.Position.Y);
            target.OnDeath();
            targets.Remove(target);
            cooldown = tower1Cooldown;
        }
    }
	private void Tower2Shooting()
	{
		if (cooldown <= 0 && targets.Count != 0)
		{
            Enemy1 target = targets[0];
			EmitSignal(SignalName.LineCoord,this.Position.X, this.Position.Y, target.Position.X, target.Position.Y);
			float location = target.ProgressRatio;
			var enemies = target.GetParent().GetChildren();
			foreach(Enemy1 enemy in enemies)
			{
				if(Math.Abs(location - enemy.ProgressRatio) < 0.1)
				{
					enemy.OnDeath();
					if (targets.Contains(enemy))
					{
						targets.Remove(enemy);
					}
				}
			}
			cooldown = tower2Cooldown;
        }
	}

    private void OnButton1Pressed()
	{
		EmitSignal(SignalName.Tower1Chosen);
		towerType = 1;
		towerLevel++;
		MoneyManager.Instance.Money -= tower1Cost;
    }
	private void OnButton2Pressed()
	{
		EmitSignal(SignalName.Tower2Chosen);
		towerType = 2;
        towerLevel++;
        MoneyManager.Instance.Money -= tower2Cost;
    }

	private void OnAreaEntered(Area2D area)
	{
		if(area.GetParent() is Enemy1 enemy) 
		{
			targets.Add((Enemy1)enemy);
		}
	}
	private void OnAreaExited(Area2D area)
	{
        if (area.GetParent() is Enemy1 enemy)
        {
            targets.Remove(enemy);
        }
    }
	private void OnSold()
	{
        if (towerType == 1)
        {

			MoneyManager.Instance.Money += tower1Cost * refund;
        }
		else if (towerType == 2)
		{
			MoneyManager.Instance.Money += tower2Cost * refund;
		}
		towerType = 0;
		EmitSignal(SignalName.Sold);
        towerLevel = 0;
    }
	private void OnUpgrade()
	{
		tower1Cooldown -= 15;
		tower2Cooldown -= 80;
        towerLevel++;
		if(towerType == 1)
		{
            MoneyManager.Instance.Money -= tower1Cost;
        }
		else if (towerType == 2)
		{
            MoneyManager.Instance.Money -= tower2Cost;
        }
    }

}
