using Godot;
using System;

public partial class BoxContainer2 : BoxContainer
{
    private bool visible = false;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (visible)
        {
            Visible = true;
        }
        else
        {
            Visible = false;
        }
    }
	private void ShowYourself()
	{
        if (visible)
        {
            visible = false;
        }
        else
        {
            visible = true;
        }
    }
    private void OnButtonClicked()
    {
        visible = false;
    }
}
