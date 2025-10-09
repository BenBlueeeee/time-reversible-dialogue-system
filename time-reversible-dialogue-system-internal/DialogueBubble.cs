using Godot;
using System;
using System.Linq;
using System.Text;

namespace dialogue;

public partial class DialogueBubble : Node3D
{
	[Export] private Label label;
	
	public TemporaryTimeDirection temporaryTimeDirection = TemporaryTimeDirection.Forwards;
	
	public string GetReversedText()
	{
		StringBuilder sb = new(label.Text);
		return new string(sb.ToString().Reverse().ToArray());
	}
	
	public override void _Ready()
	{
		base._Ready();
		
		GD.Print($"text: {label.Text}");
		GD.Print("---");		
		GD.Print($"reversed text: {GetReversedText()}");
	}
	
	public override void _UnhandledInput(InputEvent @event)
	{
		base._UnhandledInput(@event);
		
		if (Input.IsActionJustPressed("debug_start_dialogue"))
		{
			OnDialogueStart();
		}
	}
	
	public void OnDialogueStart()
	{
		// read in from dialogue file
		string rootPath = ".";
		string firstLine = DialogueFileReader.GetLine(rootPath, 1);
		
		GD.Print($"firstLine = {firstLine}");
		
		label.Text = firstLine;
	}
}
