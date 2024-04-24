using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextTrial : MonoBehaviour
{
    public string nextScene;
    public bool finalTrial;
    public GameObject allStats;
    public GameObject returnToMenu;
    public TextMeshProUGUI experienceText;
    public static NextTrial instance;

    //this will be used only if finalTrial is enabled
    [Header("Scene Names")]
    public string []levelName;

    [Header("Level Stats")]
    public LevelStat []statNode;
    private int currentIndex;

    private void Start()
    {
        instance = this;
    }

    public void EndTrial()
    {
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Score", ScoreCounter.Score);
        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "Misses", MissCounter.Misses);

        float accuracy = (float)ScoreCounter.Score / (float)(ScoreCounter.Score + MissCounter.Misses);
        accuracy *= 100f;

        PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "Accuracy", accuracy);

        if (!finalTrial)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            //display UI with all scores
            allStats.SetActive(true);
            returnToMenu.SetActive(true);
            experienceText.text = "All levels Stats, " + PlayerPrefs.GetString("experience");

            foreach (string level in levelName)
            {
                statNode[currentIndex].SetData(level, PlayerPrefs.GetInt(level + "Score").ToString(), PlayerPrefs.GetInt(level + "Misses").ToString(), ((int)PlayerPrefs.GetFloat(level + "Accuracy")).ToString());
                currentIndex++;
            }
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
