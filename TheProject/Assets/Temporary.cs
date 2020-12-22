using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Temporary : MonoBehaviour
{

    public TextMeshProUGUI temp;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            temp.color = Color.blue;
        }
        else
        {
            temp.color = Color.white;
        }
    }

}
