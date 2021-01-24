using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI HS;
    public EnemyScript enemyScript;
    public TextMeshProUGUI score;
    private int highscoreValue;
    private int actualScore = 0;

    private void Awake()
    {
        HS.text = "Highscore: " + PlayerPrefs.GetInt("Highscore", 0);
    }
    public void CallUpdate(int a)
    {
        actualScore += a;
        enemyScript.SpeedUpdate(actualScore);
        score.text = "x " + actualScore;
    }

    public void UpdateHighscore()
    {
        highscoreValue = PlayerPrefs.GetInt("Highscore", 0);
        if (highscoreValue < actualScore)
        {
            PlayerPrefs.SetInt("Highscore", actualScore);
            HS.text = "Highscore: " + actualScore;
        }
    }
}
