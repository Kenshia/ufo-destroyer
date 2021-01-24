using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AccuracyScript : MonoBehaviour
{
    public TextMeshProUGUI acc;
    private int hit=0;
    private int totalHit=0;

    public void CallUpdate(int input)
    {
        hit += input;
        totalHit += 1;
        acc.text = "Acc: " + hit * 100 / totalHit + "%";
    }
}
