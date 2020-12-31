using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public EnemyScript enemyScript;
    public TextMeshProUGUI score;
//    private int scoreValue = 0;
    private int actualScore = 0;
    public void CallUpdate(int a)
    {
        actualScore += a;
        enemyScript.SpeedUpdate(actualScore);
        score.text = "Score: " + actualScore;
    }
}
