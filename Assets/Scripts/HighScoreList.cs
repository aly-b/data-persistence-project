using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

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
public class HighScoreList : MonoBehaviour
{
    public static HighScoreList Instance;
    private MainManager mainManager;
    public static string player;
    public static int score;

    private void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }

        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        player = mainManager.playerName;
        score = mainManager.hs;
    }
    public override string ToString()
    {
        return "Best Score: " + mainManager.hs + "   Name: " + mainManager.playerName;
    }
    public static void HighScoreListFormation()
    {
        List<HighScore> highScores = new List<HighScore>() { };
        highScores.Add( new HighScore() { Name = player, Score = score } );

    }

}
