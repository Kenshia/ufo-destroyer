using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    private bool enemy;
    public Health health;
    public Camera targetCamera;
    public GameObject crosshair;
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
                //kills enemy & +hp
                Destroy(theTarget);
                health.Damage(-2);
            }
            else
            {
                //reduce score instead of damage
                health.Damage(10);
            }
        }
     }

    public void CrosshairOnEnemy(bool a, Collision2D collision)
    {
        theTarget = collision.gameObject;
        enemy = a;
    }
}
