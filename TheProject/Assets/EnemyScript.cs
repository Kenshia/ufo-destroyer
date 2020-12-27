using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float EnemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
       {
            spawnEnemy(new Vector3(192f, Random.Range(-40, 75), 0f), Random.Range(0,10));
       }
    }

    void spawnEnemy(Vector3 Location, int side)
    {
        if (side <= 5)
        {
            //dari kanan
            GameObject b = Instantiate(EnemyPrefab, Location, Quaternion.identity) as GameObject;
            b.GetComponent<Rigidbody2D>().velocity = Vector2.left * EnemySpeed;
        } else
        {
            //dari kiri
            GameObject b = Instantiate(EnemyPrefab, new Vector3(-Location.x, Location.y, Location.z) , Quaternion.identity) as GameObject;
            b.GetComponent<Rigidbody2D>().velocity = Vector2.right * EnemySpeed;
        }
    }
}
