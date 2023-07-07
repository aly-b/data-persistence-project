using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public string playerName;
    public TMP_InputField nameField;

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

        LoadName();
    }

    private void Update()
    {
        LoadName();
    }

    public void LoadName()
    {
        PlayerPrefs.GetString("playerName");
        PlayerPrefs.Save();
    }

    public void ResetTime()
    {
        PlayerPrefs.SetString("playerName", nameField.text);
        PlayerPrefs.Save();
    }
}
