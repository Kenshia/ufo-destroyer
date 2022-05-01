using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    //main script

    private bool enemy;
    public Health health;
    public Camera targetCamera;
    public GameObject crosshair;
    public GameObject crosshairSprite;
    public ScoreScript scoreScript;
    public AccuracyScript accuracyScript;
    public GameObject pausemenu;
    public GameObject settingsmenu;
    public GameObject defeatmenu;
    public GameObject tutorialMenu;
    private Vector3 target;
    private GameObject theTarget;
    public AudioSource laserSfx;
    public AudioSource boomSfx;
    public GameObject cheats;
    public Toggle cheatsToggle;
    public Toggle godModeToggle;
    public ParticleSystem explodeEffect;
    private bool godMode;
    // Start is called before the first frame update
    void Start()
    {
        //cheats
        if (PlayerPrefs.GetInt("cheats", 0) == 1)
        {
            cheatsToggle.isOn = true;
            cheats.SetActive(true);
        }
        else 
        {
            cheatsToggle.isOn = false;
            cheats.SetActive(false); 
        }
        godModeToggle.isOn = false;

        Time.timeScale = 0f;
        tutorialMenu.SetActive(true);
        enemy = false;
        Cursor.visible = false;
        pausemenu.SetActive(false);
        settingsmenu.SetActive(false);
        defeatmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (godMode) health.Damage(-1);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale==1)
            {
                Time.timeScale = 0;
                pausemenu.SetActive(true);
            }
        }

        //crosshair follows mouse
        target = targetCamera.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
        crosshairSprite.transform.position = new Vector2(target.x, target.y);
        
        //hitreg
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.timeScale != 0)
        {
            if (enemy)
            {
                if (theTarget.CompareTag("Enemy"))
                {
                    //kills enemy & +hp & +score
                    explodeEffect.transform.position = theTarget.transform.position;
                    explodeEffect.Play();
                    Destroy(theTarget);
                    health.Damage(-2);
                    scoreScript.CallUpdate(1);
                    accuracyScript.CallUpdate(1);
                    laserSfx.Play();
                    boomSfx.Play();
                }
                else
                {
                    //what is this for? just delete it if its useless
                    scoreScript.CallUpdate(0);
                }
            }
            else
            {
                laserSfx.Play();
                //-hp & -score
                health.Damage(5);
                //change to miss count? or just remove it totally
                //scoreScript.CallUpdate(-25);
                accuracyScript.CallUpdate(0);
            }
        }
     }
    public void SettingsMenu()
    {
        pausemenu.SetActive(false);
        settingsmenu.SetActive(true);
    }
    public void BackToPauseMenu()
    {
        pausemenu.SetActive(true);
        settingsmenu.SetActive(false);
    }
    public void BackToGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void CrosshairOnEnemy(bool a, Collision2D collision)
    {
        theTarget = collision.gameObject;
        enemy = a;
    }

    public void StartTheGame()
    {
        tutorialMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ToggleCheats()
    {
        if (cheatsToggle.isOn)
        {
            cheats.SetActive(true);
            PlayerPrefs.SetInt("cheats", 1);
        }
        else
        {
            cheats.SetActive(false);
            PlayerPrefs.SetInt("cheats", 0);
        }
    }

    public void ToggleGodMode()
    {
        if (godModeToggle.isOn) godMode = true;
        else godMode = false;
    }
}
