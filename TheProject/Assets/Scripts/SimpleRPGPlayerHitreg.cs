using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRPGPlayerHitreg : MonoBehaviour
{
    public PlayerScript player;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            player.Damage(10);
        }
    }
}
