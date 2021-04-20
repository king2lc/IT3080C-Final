using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    private GameObject newEnemy;
    private SpriteRenderer rend;
    private int randomSpawnZone;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;
    private int wait = 1;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 5f);    
    }

    private void SpawnEnemy()
    {
        randomSpawnZone = Random.Range(0, 8);

        switch (randomSpawnZone)
        {
            case 0:
                randomXposition = Random.Range(-60f, -40f);
                randomYposition = Random.Range(0f, 40f);
                break;
            case 1:
                randomXposition = Random.Range(-40f, -20f);
                randomYposition = Random.Range(0f, 40f);
                break;
            case 2:
                randomXposition = Random.Range(20f, 40f);
                randomYposition = Random.Range(0f, 40f);
                break;
            case 3:
                randomXposition = Random.Range(40f, 60f);
                randomYposition = Random.Range(0f, 40f);
                break;
            case 4:
                randomXposition = Random.Range(40f, 60f);
                randomYposition = Random.Range(20f, 40f);
                break;
            case 5:
                randomXposition = Random.Range(-40f, -60f);
                randomYposition = Random.Range(20f, 40f);
                break;
            case 6:
                randomXposition = Random.Range(-40f, -60f);
                randomYposition = Random.Range(0f, 4f);
                break;
            case 7:
                randomXposition = Random.Range(-40f, -60f);
                randomYposition = Random.Range(0f, 4f);
                break;
        }

        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        newEnemy = Instantiate(Enemy, spawnPosition, Quaternion.identity);
        rend = newEnemy.GetComponent<SpriteRenderer>();
    }
}
