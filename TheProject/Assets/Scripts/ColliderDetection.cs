using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    public GunScript main;

    private void OnCollisionStay2D(Collision2D collision)
    {
        main.CrosshairOnEnemy(true, collision);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        main.CrosshairOnEnemy(false, collision);
    }

}
