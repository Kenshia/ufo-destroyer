using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleRPGEnemyScript : MonoBehaviour
{
    public int objectHp;
    public bool damage;
    public int inviciblity;
    public GameObject healthbar;
    private int startingHp;

    private void Awake()
    {
        startingHp = objectHp;
        damage = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //make reference for player damage
            TakeDamage(5);
        }
    }
    private void FixedUpdate()
    {
        if(inviciblity >= 0) inviciblity -= 1;
    }
    public void TakeDamage(int a)
    {
        if (damage && inviciblity <= 0)
        {
            objectHp -= a;
            if (objectHp <= 0) Destroy(gameObject);
            healthbar.transform.localScale = new Vector3(objectHp*100 / startingHp, 5, 1);
            inviciblity = 25;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HitReg"))
        {
            damage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HitReg"))
        {
            damage = false;
        }
    }
}
