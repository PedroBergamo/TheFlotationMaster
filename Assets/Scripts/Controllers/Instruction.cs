using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

public class Instruction
{
    [JsonProperty("text")]
    public string Text;

    public Animator[] Animators;

    [JsonProperty("options")]
    public string[] Options;

    [JsonProperty("correctOptionIndex")]
    public int? CorrectOption;

    public Instruction(string text, Animator[] animators = null, string[] options = null, int? correctOption = null)
    {
        Text = text;
        Animators = animators ?? new Animator[0];
        Options = CheckForNullOrEmptyStringArray(options);
        CorrectOption = correctOption ?? 1;
        var jsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }

    public string[] CheckForNullOrEmptyStringArray(string[] options) {
        if (options == null || options == new string[] { })
        {
            return new string[] { "" };
        }
        else {
            return options;
        }
    }
}

public class SetOfInstructions {
    [JsonProperty("Instructions")]
    public List<Instruction> InstructionsList;    
}
