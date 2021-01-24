using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public ScoreScript scoreScript;
    public GameObject defeatmenu;
    public float HP;
    public Slider HealthBar;

    private void Start()
    {
        HealthBar.value = HP;
    }

    public void Damage(int i)
    {
        if (HP - i > 100) HP = 100;
        else HP -= i;
        HealthBar.value = HP;
        if (HP <= 0)
        {
            Time.timeScale = 0;
            scoreScript.UpdateHighscore();
            defeatmenu.SetActive(true);
        }
    }

}
