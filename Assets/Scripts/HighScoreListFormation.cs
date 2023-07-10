using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

public class HighScoreListFormation : MonoBehaviour, IComparable<int>
{
    private MainManager mainManager;
    int score;
    string player;
    public Text LegacyHighScores;
    public HighScoreListFormation HighScores;

    void Start()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
    }

    public override string ToString()
    {
        return "Best Score: " + score + "   Name: " + player;
    }

    void Update()
    {
        score = mainManager.hs;
        player = mainManager.playerName;

        List<HighScore> highScores = new() { };
        highScores.Add(new HighScore() { Name = player, Score = score });
        highScores.Add(new HighScore() { Name = player, Score = score });
        SaveHighScores();

        IComparable<HighScore> scores =
            (from highScoreRank in highScores
             orderby highScoreRank.Score descending
             select highScoreRank) as IComparable<HighScore>;

        foreach (HighScore aHighScore in highScores)
        {
            LoadHighScores();
            LegacyHighScores.text = "Top Score: " + score + "   Name: " + player;
        }
        return;
    }

    public int CompareTo(int other)
    {
        return score.CompareTo(other);
    }

    [Serializable]
    class SaveData
    {
        public HighScoreListFormation HighScores;
    }

    public void SaveHighScores()
    {
        SaveData data = new();
        data.HighScores = HighScores;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScores = data.HighScores;
        }
    }
}

public class HighScore : IEquatable<HighScore>
{
    public string Name { get; set; }
    public int Score { get; set; }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        HighScore objAsHighScore = obj as HighScore;
        if (objAsHighScore == null) return false;
        else return Equals(objAsHighScore);
    }
    public override int GetHashCode()
    {
        return Score;
    }
    public bool Equals(HighScore other)
    {
        if (other == null) return false;
        return (this.Score.Equals(other.Score));
    }

}
