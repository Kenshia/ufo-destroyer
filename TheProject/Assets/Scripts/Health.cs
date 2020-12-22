using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HP;
    public Slider HealthBar;
    private void FixedUpdate()
    {
        HealthBar.value = HP;
    }

    public void Damage(int i)
    {
        if (HP - i > 100) HP = 100;
        else HP -= i;
    }

}
