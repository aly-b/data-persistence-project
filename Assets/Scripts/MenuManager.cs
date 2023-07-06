using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;
    public string playerName2 = "Player 2";

    private void Awake()
    {
        if (Instance == null) // If there is no instance already -thx, user
        {
            DontDestroyOnLoad(gameObject); // Keep the GameObject, this component is attached to, across different scenes
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }

        LoadName();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName1 = "Player 1";
    }

    public void SaveName()
    {
        SaveData data = new();
        data.playerName1 = playerName2;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName2 = data.playerName1;
        }
    }
}
