using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScoresManager
{
    public static List<PlayerScore> playerScores;
    private string DataBase;

    public PlayerPrefsScoresManager(string DataBaseName) {
        DataBase = DataBaseName + "LevelName" + "Score";
    }

    public List<PlayerScore> Scores()
    {
        AddScoresFromPlayerPrefs();
        return playerScores;
    }

    public void SaveNewPlayerInPrefs(PlayerScore playerScore) {
        PlayerPrefs.SetString(DataBase + ScoreCount(), playerScore.PlayerName + "~" + playerScore.Score);
        PlayerPrefs.SetInt(DataBase + "ScoreCount", ScoreCount() + 1);
    }

    public int ScoreCount(){
        if (PlayerPrefs.HasKey(DataBase + "ScoreCount")) {
            return PlayerPrefs.GetInt(DataBase + "ScoreCount");
        }
        return 0;
    }

    public void SaveToLocalScores(List<PlayerScore> newLocalplayerScores)
    {
        DeleteScores();
        foreach (PlayerScore score in newLocalplayerScores)
        {
            SaveNewPlayerInPrefs(score);
        }
    }

    private void AddScoresFromPlayerPrefs()
    {
        playerScores = new List<PlayerScore>();
        for (int scoreIndex = 0; scoreIndex < ScoreCount(); scoreIndex++)
        {
            AddScoreFromPlayerPrefs(scoreIndex);
        }
    }

    private void AddScoreFromPlayerPrefs(int scoreIndex)
    {
        string key = PlayerPrefs.GetString(DataBase + scoreIndex);
        string[] ScoreText = key.Split('~');
        int playerNameIndex = 0;
        int playerScoreIndex = 1;
        playerScores.Add(new PlayerScore(ScoreText[playerNameIndex], float.Parse(ScoreText[playerScoreIndex])));
    }

    public void DeleteScores() {
        for (int i = 0; i < ScoreCount(); i++)
        {
            PlayerPrefs.DeleteKey(DataBase + i);
        }
        PlayerPrefs.DeleteKey(DataBase + "ScoreCount");
    }
}