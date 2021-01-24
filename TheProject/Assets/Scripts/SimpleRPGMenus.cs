using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SimpleRPGMenus : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject defeatMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PauseRPG();
        }
    }
    private void Awake()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        defeatMenu.SetActive(false);
    }
    public void PauseRPG()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    public void ResumeRPG()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void DefeatRPG()
    {
        Time.timeScale = 0f;
        defeatMenu.SetActive(true);
    }
}
