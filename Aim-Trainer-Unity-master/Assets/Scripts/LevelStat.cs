using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelStat : MonoBehaviour
{
    public TextMeshProUGUI levelName;
    public TextMeshProUGUI score;
    public TextMeshProUGUI misses;
    public TextMeshProUGUI accuracy;

    public void SetData(string level, string scoreText, string missesText,string accuracyText)
    {
        levelName.text = level;
        score.text = "Score: " + scoreText;
        misses.text = "Misses: " + missesText;
        accuracy.text = "Accuracy: " + accuracyText + "%";
    }
}
