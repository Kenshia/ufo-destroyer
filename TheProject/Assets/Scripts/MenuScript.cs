using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public Slider bgmSlider;
    public ScoreScript score;
    private void Awake()
    {
        Time.timeScale = 1f;
        bgmSlider.value = PlayerPrefs.GetFloat("bgmVolume", 1f);
    }
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

    public void UpdateBgmVolume()
    {
        float a = bgmSlider.value;
        PlayerPrefs.SetFloat("bgmVolume", a);
    }
}
