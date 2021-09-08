using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class FileReaderTests
{
    private List<Instruction> InstructionsExample(){
        return new InstructionsReader().SetOfInstructions(Resources.Load<TextAsset>("Instructions/ConcentrationRatio").text).InstructionsList;
    }

    private List<PlayerScore> ScoresExample()
    {
        List<PlayerScore> List = new List<PlayerScore>();
        List.Add(new PlayerScore("TestOperator", (1000)));
        List.Add(new PlayerScore("TestOperator2", (2000)));
        return List;
    }

    [Test]
    public void PlayerScoreToXml()
    {
        string XmlOperatorScore = FileReader.Serialize(ScoresExample());
        List<PlayerScore> Actual = FileReader.Deserialize(XmlOperatorScore);
        Assert.AreEqual(ScoresExample()[0].PlayerName, Actual[0].PlayerName);
    }

    [Test]
    public void PlayerScoreClassTest()
    {
        PlayerScore playerScore = new PlayerScore("", 100);
        string Expected = "Anon 100";
        string Actual = playerScore.PlayerName + " " + playerScore.Score;
        Assert.AreEqual(Expected, Actual);
    }

    [Test]
    public void NameLengthTest()
    {
        PlayerScore playerScore = new PlayerScore("123456789012345678901", 100);
        string Expected = "12345678901234567890";
        string Actual = playerScore.PlayerName;
        Assert.AreEqual(Expected, Actual);
    }

    [Test]
    public void InstructionsReaderTextTest()
    {
        string Expected = "Hi, welcome to your first day in a flotation plant. I am Pete, the chemist, and I am here to give you some tips to check how your flotation process is doing.";
        string Actual = InstructionsExample()[0].Text;
        Assert.AreEqual(Expected, Actual);
    }

    [Test]
    public void InstructionsReaderOptionsTest()
    {
        string[] Actual = InstructionsExample()[0].Options;
        Assert.AreEqual(new string[]{"Next"}, Actual);
    }

    [Test]
    public void InstructionsReaderCorrectOptionTest()
    {
        int? Actual = InstructionsExample()[0].CorrectOption;
        Assert.AreEqual(1 , Actual);
    }
}
