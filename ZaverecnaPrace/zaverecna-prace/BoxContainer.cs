using Godot;
using System;

public partial class BoxContainer : Godot.BoxContainer
{
	// Called when the node enters the scene tree for the first time.
	private bool visible = false;
	private bool chosen = false;
	[Signal]
	public delegate void TowerChosenEventHandler();
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(visible)
		{
			Visible = true;
		}
		else
		{
			Visible = false;
		}
	}

	private void OnButtonClicked()
	{
		visible = false;
		chosen = true;

	}
    private void HandleInputEvent(Node viewport, InputEvent @event, long shapeIdx)
    {
        if (@event is InputEventMouseButton mb &&
            mb.ButtonIndex == MouseButton.Left &&
            mb.Pressed)
        {
			if (chosen)
			{
                EmitSignal(SignalName.TowerChosen);
            }
            else if (visible)
            {
                visible = false;
            }
            else
            {
                visible = true;
            }
        }
    }
	private void OnSold()
	{
		chosen = false;
	}
}
