using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] GameObject wave1;
    [SerializeField] GameObject[] wave2;
    [SerializeField] GameObject[] wave3;
    [SerializeField] GameObject[] wave4;
    private static int round = 0;
    private int EnemiesPerWave = 5;
    [SerializeField] private float timesPerSpawn;
    private float timer = 0;
    bool canAdd = true;


    private bool roundBegin;

    public static int Round
    {
        get { return round; }
    }

    void Start()
    {
        round = 1;
        roundBegin = false;
    }

    // Update is called once per frame	
    void Update()
    {
        Debug.Log(string.Concat("\t", EnemiesPerWave, "=PERWAVE\t", Enemy.ctr, "=ENEMIES\t", round, "=ROUND"));
        bool canSpawn = Enemy.ctr != 0 && canAdd || !roundBegin;
        if (timer <= 0)
        {
            switch (round)
            {
                case 2:
                case 1:
                    if (canSpawn)
                    {
                        Spawn(wave1);
                    }
                    else if (Enemy.ctr <= 0)
                    {
                        NextWave();
                    }
                    break;
                case 3:
                    {
                        if (canSpawn)
                        {
                            Spawn(wave2);
                        }
                        else if (Enemy.ctr <= 0)
                        {
                            NextWave();
                        }
                        break;
                    }
                case 5:
                case 4:
                    {
                        if (canSpawn)
                        {
                            Spawn(wave3);
                        }
                        else if (Enemy.ctr <= 0)
                        {
                            NextWave();
                        }
                        break;
                    }
                default:
                    {
                        if (canSpawn)
                        {
                            Spawn(wave4);
                        }
                        else if (Enemy.ctr <= 0)
                        {
                            NextWave();
                        }
                        break;
                    }
            }
            timer = timesPerSpawn;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    private void Spawn(GameObject[] wave)
    {
        if (EnemiesPerWave <= Enemy.ctr)
        {
            canAdd = false;
        }
        else
        {
            int rnd = Random.Range(0, wave.Length);
            Instantiate(wave[rnd], new Vector2(transform.position.x, wave[rnd].transform.position.y), Quaternion.identity);
            roundBegin = true;
        }
    }
    private void Spawn(GameObject wave)
    {
        if (EnemiesPerWave <= Enemy.ctr)
        {
            canAdd = false;
        }
        else
        {
            Instantiate(wave, new Vector2(transform.position.x, wave.transform.position.y), Quaternion.identity);
            roundBegin = true;
        }

    }

    void NextWave()
    {
        EnemiesPerWave += 5;
        round++;
        roundBegin = false;
        canAdd = true;

    }
}
