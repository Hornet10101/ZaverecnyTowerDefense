using Godot;
using System;

public partial class EnemySpawner : Node2D
{
    // Called when the node enters the scene tree for the first time.
    [Export]
    public PackedScene EnemyScene;

    [Export]
    public Path2D EnemyPath;
    [Signal]
    public delegate void FinishLineEventHandler();
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (GD.Randf() > 0.98)
        {
            SpawnEnemy();
        }

	}
    private void SpawnEnemy()
    {
        var enemy = EnemyScene.Instantiate<Enemy1>();

        enemy.Died += OnEnemyDied;

        EnemyPath.AddChild(enemy);
    }
    private void OnEnemyDied()
    {
        EmitSignal(SignalName.FinishLine);
    }
}
