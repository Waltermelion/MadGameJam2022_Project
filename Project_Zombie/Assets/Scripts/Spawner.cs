using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private int waveNumber = 0;
    private int enemySpawnAmmount = 0;
    public int enemiesKilled = 0;
    
    public GameObject[] spawners;
    public GameObject Zombie;

    private bool wavePlaying = false;


    [SerializeField] private GameObject direcLight;
    [SerializeField] private AudioSource congrats;
    [SerializeField] private AudioSource mains;
    [SerializeField] private AudioSource scarys;

    private void Start()
    {
        spawners = new GameObject[15];

        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        if (direcLight.GetComponent<Rotation>().night)
        {
            StartWave();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!direcLight.GetComponent<Rotation>().night)
            {
                wavePlaying = true;
                direcLight.GetComponent<Rotation>().night = true;
                if (waveNumber == 0 && wavePlaying)
                {
                    StartWave();
                }else if (waveNumber > 0 && wavePlaying)
                {
                    NextWave();
                }
            }
        }
        if ((enemiesKilled >= enemySpawnAmmount) && direcLight.GetComponent<Rotation>().night)
        {
            direcLight.GetComponent<Rotation>().night = !direcLight.GetComponent<Rotation>().night;
            mains.enabled = true;
            scarys.Stop();
            congrats.Play();
            wavePlaying = false;
        }
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
        mains.enabled = false;
        scarys.Play();

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
        mains.enabled = false;
        scarys.Play();
        
        for (int i = 0; i < enemySpawnAmmount; i++)
        {
            SpawnEnemy();
        }
    }
}
