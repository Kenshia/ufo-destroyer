using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreativeMenuScript : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI levelText;
    public GameObject enemyPrefab;
    public SimpleRPGEnemyScript forLevel;
    [SerializeField] private int levelCount;
    [SerializeField] private int enemyCount;

    private void Start()
    {
        countText.text = "" + enemyCount;
        levelText.text = "" + levelCount;
    }
    public void StartSpawn()
    {
        forLevel.Level = levelCount;
        for (int i = 0; i < enemyCount; ++i) Spawn();
    }

    private void Spawn()
    {
        GameObject a = Instantiate(enemyPrefab, new Vector3(Random.Range(-20f,20f), 2, 0), Quaternion.identity) as GameObject;    
    }
    public void AddEnemyCount()
    {
        enemyCount++;
        countText.text = "" + enemyCount;
    }

    public void RemoveEnemyCount()
    {
        enemyCount--;
        countText.text = "" + enemyCount;
    }

    public void AddEnemyLevel()
    {
        levelCount++;
        levelText.text = "" + levelCount;
    }
    public void RemoveEnemyLevel()
    {
        levelCount--;
        levelText.text = "" + levelCount;
    }
}
