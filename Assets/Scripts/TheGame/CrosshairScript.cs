using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CrosshairScript : MonoBehaviour
{
    public SpriteRenderer crosshairSprite;
    public Slider size;
    private void Awake()
    {
        size.value = PlayerPrefs.GetFloat("CrosshairSize", 1f);
        crosshairSprite.transform.localScale = (new Vector3(size.value * 10, size.value* 10, 1));
        switch (PlayerPrefs.GetInt("CrosshairColor", 0))
        {
            case 0:
                crosshairSprite.color = Color.white;
                break;
            case 1:
                crosshairSprite.color = Color.black;
                break;
            case 2:
                crosshairSprite.color = Color.red;
                break;
            case 3:
                crosshairSprite.color = Color.green;
                break;
            case 4:
                crosshairSprite.color = Color.blue;
                break;
            case 5:
                crosshairSprite.color = Color.yellow;
                break;
            case 6:
                crosshairSprite.color = Color.magenta;
                break;
            case 7:
                crosshairSprite.color = Color.cyan;
                break;

        }

    }
    public void ChangeColor(int a)
    {
        switch (a)
        {
            case 0:
                crosshairSprite.color = Color.white;
                break;
            case 1:
                crosshairSprite.color = Color.black;
                break;
            case 2:
                crosshairSprite.color = Color.red;
                break;
            case 3:
                crosshairSprite.color = Color.green;
                break;
            case 4:
                crosshairSprite.color = Color.blue;
                break;
            case 5:
                crosshairSprite.color = Color.yellow;
                break;
            case 6:
                crosshairSprite.color = Color.magenta;
                break;
            case 7:
                crosshairSprite.color = Color.cyan;
                break;

        }
        PlayerPrefs.SetInt("CrosshairColor", a);
    }
    public void ChangeSize()
    {
        float b = size.value;
        crosshairSprite.transform.localScale = (new Vector3(b*10, b*10, 1));
        PlayerPrefs.SetFloat("CrosshairSize", b);
    }
}
