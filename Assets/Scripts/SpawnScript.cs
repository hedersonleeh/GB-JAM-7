﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] Enemy wave1;
    [SerializeField] Enemy[] wave2;
    [SerializeField] Enemy[] wave3;
    [SerializeField] Enemy[] wave4;
    private static int round = 0;
    private int enemiesPerWave = 5;
    [SerializeField] private float timesPerSpawn;
    private float timer = 0;
    bool canAdd = true;


    private bool roundBegin;

    public static int Round
    {
        get { return round; }
    }

    public int EnemiesPerWave { get { return enemiesPerWave; } }
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Theme");


        round = 1;
        roundBegin = false;
    }

    // Update is called once per frame	
    void Update()
    {
        bool canSpawn = Enemy.ctr != 0 && canAdd || !roundBegin;
        if (timer <= 0)
        {
            switch (round)
            {

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
                case 2:
                    {
                        if (canSpawn)
                        {
                            Spawn(wave1);
                        }
                        else if (Enemy.ctr <= 0)
                        {
                            NextWave();
                        }
                        break;
                    }
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
    private void Spawn(Enemy[] wave)
    {
        if (enemiesPerWave <= Enemy.ctr)
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
    private void Spawn(Enemy wave)
    {
        if (enemiesPerWave <= Enemy.ctr)
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
        FindObjectOfType<AudioManager>().Play("Win");
        enemiesPerWave += round;
        round++;
        roundBegin = false;
        canAdd = true;
    }
}
