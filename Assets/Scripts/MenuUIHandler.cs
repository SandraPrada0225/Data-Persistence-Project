using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public InputField Name;
    public Text BestScoreText;

    public void NewName(string name)
    {
        PersistenceData.Instance.Name = name;
    }

    private void Start()
    {
        if (PersistenceData.Instance != null)
        {
            BestScoreText.text = "Best Score:" + PersistenceData.Instance.BestName + " : " + PersistenceData.Instance.BestScore;
        }
    }
    public void StartNew()
    {
        NewName(Name.text);

        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        PersistenceData.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit(); // original code to quit Unity players
    #endif
    }
}
