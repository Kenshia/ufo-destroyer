using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public ScoreScript scoreScript;
    public float HP;
    public Slider HealthBar;
    private void FixedUpdate()
    {
        HealthBar.value = HP;
    }

    public void Damage(int i)
    {
        if (HP - i > 100) HP = 100;
        else if (HP <= 0)
        {
            Time.timeScale = 0;
            scoreScript.UpdateHighscore();
        }
        else HP -= i;
    }

}
