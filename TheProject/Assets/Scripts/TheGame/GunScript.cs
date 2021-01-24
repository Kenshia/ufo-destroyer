using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private Vector3 target;
    private GameObject theTarget;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        enemy = false;
        Cursor.visible = false;
        pausemenu.SetActive(false);
        settingsmenu.SetActive(false);
        defeatmenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
                    Destroy(theTarget);
                    health.Damage(-2);
                    scoreScript.CallUpdate(1);
                    accuracyScript.CallUpdate(1);
                }
                else
                {
                    scoreScript.CallUpdate(0);
                }
            }
            else
            {
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
}
