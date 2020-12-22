using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetection : MonoBehaviour
{
    public GunScript main;

    private void OnCollisionStay2D(Collision2D collision)
    {
        main.CrosshairOnEnemy(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        main.CrosshairOnEnemy(false);
    }
}
