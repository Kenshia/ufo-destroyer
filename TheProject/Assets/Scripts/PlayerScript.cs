using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
    public GameObject EnemyPrefabTesting;
    public Rigidbody2D playerRb;
    public int speed;
    public int hp;
    public int dmg;
    public GameObject RightHitbox;
    public GameObject LeftHitbox;
    public Slider HPSlider;
    public SimpleRPGMenus menu;
    public Slider xpSlider;
    //make these 3 private
    //add stats (str, agi, health, etc)
    public int level;
    public int xp;
    public int xpNeeded;
    private int invicibility;
    private float sprint;
    private void Awake()
    {
        level = 1; //make it into playerprefs?
        xpNeeded = 10;
        AddXp(0); // for update
        HPSlider.value = hp;
        sprint = 1f;
        RightHitbox.SetActive(true);
        LeftHitbox.SetActive(false);
    }
    private void spawn()
    {
        GameObject a = Instantiate(EnemyPrefabTesting, new Vector3(0, 2, 0), Quaternion.identity) as GameObject;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) spawn();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            sprint = 1.5f;
        }
        else
        {
            sprint = 1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            LeftHitbox.SetActive(true);
            RightHitbox.SetActive(false);
            playerRb.AddForce(Vector2.left * speed * Time.deltaTime * sprint);
            //GetComponent<SpriteRenderer>().flipX = true; jangan getcomponent, ganti pointer langsung
        }
        if (Input.GetKey(KeyCode.D))
        {
            RightHitbox.SetActive(true);
            LeftHitbox.SetActive(false);
            //GetComponent<SpriteRenderer>().flipX = false;
            playerRb.AddForce(Vector2.right * speed * Time.deltaTime * sprint);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            LeftHitbox.GetComponent<SpriteRenderer>().color = Color.red;
            RightHitbox.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            LeftHitbox.GetComponent<SpriteRenderer>().color = Color.cyan;
            RightHitbox.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    private void FixedUpdate()
    {
        if(invicibility >= 0) invicibility -= 1;
        //tp kalo jatoh
        if (playerRb.transform.position.y < -15) playerRb.transform.position = new Vector3(0, 2);
    }

    public void Damage(int a)
    {
        if (invicibility <= 0)
        {
            hp -= a;
            HPSlider.value = hp;
            invicibility = 25;
        }
        if (hp <= 0) menu.DefeatRPG();
    }
    public void UpdateMaxSlider(int a)
    {
        //buat kalo bakal ada upgrades / stats
        HPSlider.maxValue = a;
    }

    public void AddXp(int a)
    {
        xp += a;
        if (xp >= xpNeeded)
        {
            level += 1;
            xp -= xpNeeded;
            xpNeeded = 5 + level * 5;
            hp = 100; //change it to max hp, soonTM
            HPSlider.value = hp; 
        }
        xpSlider.value = xp * 100 / xpNeeded;
    }
}
