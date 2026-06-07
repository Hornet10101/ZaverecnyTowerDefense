using Godot;
using System;
using System.Xml.Serialization;

public partial class TowerSprite1 : Sprite2D
{
    // Called when the node enters the scene tree for the first time.
    //private Texture2D img = (Texture2D)GD.Load("res://.godot/imported/Rook.png-5bd3b5bbc319f048769c687e7c839e46.ctex");
    public override void _Ready()
	{
		Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	private void OnTower1Chosen()
	{
		Visible = true;
    }
	private void OnTowerSold()
	{
		Visible = false;
	}
}
