using Godot;
using System;
using System.Collections.Generic;

public partial class EnemySpawner : Node2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public PackedScene EnemyScene;

    [Export]
    public Path2D EnemyPath;
    [Signal]
    public delegate void FinishLineEventHandler();
    private List<Enemy1> enemies = new();
    private int time = 0;
    public float difficulty = 0f;
    
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        time++;
        if(time == 1000)
        {
            time = 0;
            difficulty += 0.0005f;
            foreach (Enemy1 enemy in enemies)
            {
                enemy.Speed += 3;
            }
            //GD.Print("time");
        }
        if (GD.Randf() > 0.995-difficulty)
        {
            SpawnEnemy();
        }

	}
    private void SpawnEnemy()
    {
        var enemy = EnemyScene.Instantiate<Enemy1>();

        enemy.Died += OnEnemyDied;

        EnemyPath.AddChild(enemy);

        enemies.Add(enemy);
    }
    private void OnEnemyDied()
    {
        EmitSignal(SignalName.FinishLine);
    }
}
