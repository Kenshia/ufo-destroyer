using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimationScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int EnemySpeed;
    public int EnemySpeed2;
    public int timer;
    public int timerSpeed;
    private int timerReference;
    private void Start()
    {
        timerReference = timer;;
    }
    private void FixedUpdate()
    {

        timer -= timerSpeed;
        if (timer <= 0)
        {
            spawnEnemy(new Vector3(10f, Random.Range(-4f, 4f), 0f), Random.Range(0, 10));
            timer = timerReference;
        }
    }
    void spawnEnemy(Vector3 Location, int side)
    {
        if (side <= 5)
        {
            //dari kanan
            GameObject b = Instantiate(EnemyPrefab, Location, Quaternion.identity) as GameObject;
            b.GetComponent<Rigidbody2D>().velocity = Vector2.left * Random.Range(EnemySpeed, EnemySpeed2);
            b.GetComponent<Renderer>().sortingOrder = Random.Range(0, 100);
        }
        else
        {
            //dari kiri
            GameObject b = Instantiate(EnemyPrefab, new Vector3(-Location.x, Location.y, Location.z), Quaternion.identity) as GameObject;
            b.GetComponent<Rigidbody2D>().velocity = Vector2.right * Random.Range(EnemySpeed, EnemySpeed2);
            b.GetComponent<Renderer>().sortingOrder = Random.Range(0, 100);
        }
    }
}
