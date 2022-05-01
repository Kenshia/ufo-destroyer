using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMScript : MonoBehaviour
{
    public AudioSource bgm;
    private static BGMScript instance = null;
    public static BGMScript Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        this.bgm.volume = PlayerPrefs.GetFloat("bgmVolume", 1f) * 0.2f;
    }
}
