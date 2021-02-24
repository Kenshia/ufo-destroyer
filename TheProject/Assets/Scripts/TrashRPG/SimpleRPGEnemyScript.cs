using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimpleRPGEnemyScript : MonoBehaviour
{
    [SerializeField] private int level;
    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public int objectHp;
    public bool damage;
    public int inviciblity; //change it to inspector
    public GameObject healthbar;
    private int startingHp;
    public PlayerScript player;

    private void Awake()
    {
        if (level <= 0) level = 1;
        objectHp = Random.Range((level+1)*5, (level+3)*5); //make this into enemy level
        startingHp = objectHp;
        damage = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //make reference for player damage
            TakeDamage(player.dmg);
        }
    }
    private void FixedUpdate()
    {
        if(inviciblity >= 0) inviciblity -= 1;
        if (this.transform.position.y < -15) this.transform.position = new Vector3(0, 2);
    }
    public void TakeDamage(int a)
    {
        if (damage && inviciblity <= 0)
        {
            objectHp -= a;
            if (objectHp <= 0)
            {
                Destroy(gameObject);
                player.AddXp(Random.Range((level+1), (level+1)*5)); //make this into enemy level
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
