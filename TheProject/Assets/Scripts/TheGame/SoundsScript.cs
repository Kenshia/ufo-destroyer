using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundsScript : MonoBehaviour
{
    public Slider sfxSlider;
    public AudioSource explodeSfx;
    public AudioSource laserSfx;
    private void Start()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("sfx", 1f);
        explodeSfx.volume = PlayerPrefs.GetFloat("sfx", 1f) * 0.3f;
        laserSfx.volume = PlayerPrefs.GetFloat("sfx", 1f) * 0.3f;
    }

    public void UpdateSfx()
    {
        float a = sfxSlider.value;
        explodeSfx.volume = a * 0.3f;
        laserSfx.volume = a * 0.3f;
        PlayerPrefs.SetFloat("sfx", a);
    }
}
