using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
