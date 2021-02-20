using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleRPGEnemyScript : MonoBehaviour
{
    public int objectHp;
    public bool damage;
    public int inviciblity; //change it to inspector
    public GameObject healthbar;
    private int startingHp;
    public PlayerScript player;

    private void Awake()
    {
        objectHp = Random.Range(5, 15); //make this into enemy level
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
            if (objectHp <= 0)
            {
                Destroy(gameObject);
                player.AddXp(Random.Range(1, 5)); //make this into enemy level
                //make gold drop
            }
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
