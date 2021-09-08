using UnityEngine;
using NUnit.Framework;

public class PlayerPrefScoresManagerTests
{
    private PlayerScore ScoreExample() {
        return new PlayerScore("Operator", 100);
    }

    [Test]
    public void SaveInPrefs()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefsScoresManager playerPrefsScoresManager = new PlayerPrefsScoresManager("Test");
        playerPrefsScoresManager.SaveNewPlayerInPrefs(ScoreExample());
        string Expected = "Operator~100";
        string Actual = PlayerPrefs.GetString("TestAirFlowScore0");
        PlayerPrefs.DeleteKey("TestTheAirBenderScore0");
        Assert.AreEqual(Expected, Actual);
    }

    [Test]
    public void DestructorTest()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefsScoresManager playerPrefsScoresManager = new PlayerPrefsScoresManager("Score");
        playerPrefsScoresManager.SaveNewPlayerInPrefs(ScoreExample());
        string Expected = "Operator~100";
        PlayerPrefs.DeleteKey("TheAirBenderScore0");
        string Actual = PlayerPrefs.GetString("TheAirBenderScore0");
        Assert.AreNotEqual(Expected, Actual);
    }

    [Test]
    public void DeleteEntriesTest()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefsScoresManager playerPrefsScoresManager = new PlayerPrefsScoresManager("Score");
        playerPrefsScoresManager.SaveNewPlayerInPrefs(ScoreExample());
        playerPrefsScoresManager.DeleteScores();
        string Expected = "";
        string Actual = PlayerPrefs.GetString("TheAirBenderScore0");
        Assert.AreEqual(Expected, Actual);
    }
}
