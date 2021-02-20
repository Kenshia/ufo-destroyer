using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public ScoreScript score;
    public void CheatScore(int a)
    {
        score.CallUpdate(a);
    }
    public void SelectScene(int a)
    {
        SceneManager.LoadScene(a);
        if (a != 2) Cursor.visible = true;
        Cursor.visible = true;
    }
    
    public void ExitGame()
    {
        Application.Quit();
    }
}
