using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private bool enemy;
    public Health health;
    public Camera targetCamera;
    public GameObject crosshair;
    public ScoreScript scoreScript;
    public AccuracyScript accuracyScript;
    private Vector3 target;
    private GameObject theTarget;
    // Start is called before the first frame update
    void Start()
    {
        enemy = false;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = targetCamera.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (enemy)
            {
                //kills enemy & +hp & +score
                Destroy(theTarget);
                health.Damage(-2);
                scoreScript.CallUpdate(100);
                accuracyScript.CallUpdate(1);
            }
            else
            {
                //-hp & -score
                health.Damage(5);
                scoreScript.CallUpdate(-25);
                accuracyScript.CallUpdate(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) scoreScript.CallUpdate(5000);
     }

    public void CrosshairOnEnemy(bool a, Collision2D collision)
    {
        theTarget = collision.gameObject;
        enemy = a;
    }
}
