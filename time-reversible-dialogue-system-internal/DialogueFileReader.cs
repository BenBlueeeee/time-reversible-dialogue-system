using System.IO;
using Godot;

namespace dialogue;

public struct DialogueOption(string text, DialogueOption[] options = null)
{
	string Text = text;
	DialogueOption[] Options = options;
}

public static class DialogueFileReader
{
	// line 0 is defined to be the line which contains START. Therefore dialogue starts on line 1.
	private const string DialogueStartMarker = "START";

	/// <summary> see Example.dialogue to understand the correct overall formatting that is assumed when reading this .dialogue file </summary>
	/// <param name="dialogueFolderPath">relative (?) path to a directory which contains a (single) .dialogue file</param>
	public static string GetLine(string dialogueFolderPath, int desiredLineNumber)
	{
		string[] files = Directory.GetFiles(dialogueFolderPath, "*.dialogue*");
		
		string dialogueFile = files[0];
		
		// for now I'll just be lazy and assume there's only 1 dialogue file 
		string dialogue = File.ReadAllText(dialogueFile);
		
		// goto start
		GD.Print(dialogue);

		using StreamReader reader = File.OpenText(dialogueFile);
		int? lineNumber = null;
		string line;
		bool readAsDialogue = false;
		while ((line = reader.ReadLine()) is not null)
		{
			if (readAsDialogue)
			{
				lineNumber++;
			}
			
			if (line == DialogueStartMarker)
			{
				// we now know the next line is the first option
				readAsDialogue = true;
				lineNumber = 0;
				continue;
			}
			
			if (lineNumber == desiredLineNumber)
			{
				return line;
			}
		}
		
		if (readAsDialogue == false)
		{
			GD.PushError($"[DialogueFileReader] : no START line found; {System.Reflection.MethodBase.GetCurrentMethod().Name} will return an empty string");
		}
		else
		{
			GD.PushError($"[DialogueFileReader] : line not found (check if the requested line number is larger than the number of lines the dialogue file contains). {System.Reflection.MethodBase.GetCurrentMethod().Name} will return an empty string");
		}
		
		return "";
	}
	
	// we need to read in the whole file s.t. we have some DialogueOption's in memory that all point to each other in the desired way
	// perhaps we can put these all into a bigger class / struct that can be used to more neatly show a graph of the dialogue / the dialogue tree / whatever other name it could be called
}