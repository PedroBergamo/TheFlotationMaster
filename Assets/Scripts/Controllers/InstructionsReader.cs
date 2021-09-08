using Newtonsoft.Json;

public class InstructionsReader
{
    public SetOfInstructions SetOfInstructions(string Instructions)
    {
        return JsonConvert.DeserializeObject<SetOfInstructions>(Instructions);
    }
}