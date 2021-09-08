using System;


[Serializable]
public class PlayerScore
{
    public string PlayerName { get; set; }
    public float Score { get; set; }

    public PlayerScore()
    {
        PlayerName = "Anon";
        Score = 0;
    }

    public PlayerScore(string name, float score)
    {
        PlayerName = CheckForEmptyName(name);
        Score = score;
    }
    private string CheckForEmptyName(string name)
    {
        if (name == "")
        {
            name = "Anon";
        }
        if (name.Length > 20)
        {
            return name.Remove(20);
        }
        return name;
    }
}
