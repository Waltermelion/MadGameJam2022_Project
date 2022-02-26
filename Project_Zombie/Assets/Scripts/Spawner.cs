using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int waveNumber = 0;
    private int enemySpawnAmmount = 0;
    private int enemiesKilled = 0;
    
    public GameObject[] spawners;
    public GameObject Zombie;

    [SerializeField] private GameObject direcLight;

    private void Start()
    {
        spawners = new GameObject[5];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        
        StartWave();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SpawnEnemy();
        }
        //if(direcLight.GetComponent(Rotation))
    }

    private void SpawnEnemy()
    {
        int spawnerId = Random.Range(0, spawners.Length);
        Instantiate(Zombie, spawners[spawnerId].transform.position, spawners[spawnerId].transform.rotation);
    }

    private void StartWave()
    {
        waveNumber = 1;
        enemySpawnAmmount = 2;
        enemiesKilled = 0;

        for (int i = 0; i < enemySpawnAmmount; i++)
        {
            SpawnEnemy();
        }
    }

    private void NextWave()
    {
        waveNumber++;
        enemySpawnAmmount += 2;
        enemiesKilled = 0;
        
        for (int i = 0; i < enemySpawnAmmount; i++)
        {
            SpawnEnemy();
        }
    }
}
