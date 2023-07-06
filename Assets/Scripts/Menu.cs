using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Menu : MonoBehaviour
{
    public void StartNew()
    {
        MenuManager.Instance.SaveName();
        //Debug.Log(MenuManager.Instance.SaveName());
        SceneManager.LoadScene(1);
    }

    public void SaveName()
    {
        MenuManager.Instance.SaveName();
    }

    public void LoadName()
    {
        MenuManager.Instance.LoadName();
        //NamePicker.SelectName(MenuManager.Instance.playerName2);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveName();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif    
    }
}
