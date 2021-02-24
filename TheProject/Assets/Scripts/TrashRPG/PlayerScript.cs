using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public int speed;
    public int hp;
    public int dmg;
    public GameObject hitboxRotation;
    public GameObject actualHitbox;
    public Slider HPSlider;
    public SimpleRPGMenus menu;
    public Slider xpSlider;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI goldText;
    //make these 3 private
    //add stats (str, agi, health, etc)
    public int level;
    public int xp;
    public int xpNeeded;
    public Camera cameraRefernce;
    private int invicibility;
    private float sprint;
    private Vector3 mousePos;
    private int maxHp;
    private void Awake()
    {
        level = 1; //make it into playerprefs?
        xpNeeded = 10;
        AddXp(0); // for update
        HPSlider.value = hp;
        sprint = 1f;
        maxHp = hp;
    }
    void Update()
    {
        mousePos = cameraRefernce.transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        Vector3 difference = mousePos - hitboxRotation.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        hitboxRotation.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
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
            playerRb.AddForce(Vector2.left * speed * Time.deltaTime * sprint);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(Vector2.right * speed * Time.deltaTime * sprint);
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            actualHitbox.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            actualHitbox.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    private void FixedUpdate()
    {
        AddXp(0);
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
            UpdateLevel();
            xp -= xpNeeded;
            xpNeeded = 5 + level * 5;
            hp = maxHp; //change it to max hp, soonTM (done?)
            HPSlider.value = hp; 
        }
        xpSlider.value = xp * 100 / xpNeeded;
    }

    public void UpdateLevel()
    {
        dmg += 2;
        maxHp += 10;
        HPSlider.maxValue = maxHp;
        levelText.text = "Level\n" + level;
    }
}
