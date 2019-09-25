using System.Collections;
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
        bool Spawning = Enemy.ctr != 0 && canAdd || !roundBegin;
        switch (round)
        {
            case 1:
                if (Spawning)
                {
                    StartCoroutine(Spawn(wave1));
                }
                else if (Enemy.ctr <= 0)
                {
                    NextWave();
                }
                break;
            case 2:
                {
                    if (Spawning)
                    {
                        StartCoroutine(Spawn(wave1));
                    }
                    else if (Enemy.ctr <= 0)
                    {
                        NextWave();
                    }
                    break;
                }
            case 3:
                {
                    if (Spawning)
                    {
                        StartCoroutine(Spawn(wave2));
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
                    if (Spawning)
                    {
                        StartCoroutine(Spawn(wave3));
                    }
                    else if (Enemy.ctr <= 0)
                    {
                        NextWave();
                    }
                    break;
                }
            default:
                {
                    if (Spawning)
                    {
                        StartCoroutine(Spawn(wave4));
                    }
                    else if (Enemy.ctr <= 0)
                    {
                        NextWave();
                    }
                    break;
                }
        }
    }
    IEnumerator Spawn(Enemy enemy)
    {
        roundBegin = true;
         canAdd = false;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Instantiate(enemy, new Vector2(transform.position.x, enemy.transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(timesPerSpawn);
        }
    }
     IEnumerator Spawn(Enemy[] enemy)
    {
        roundBegin = true;
         canAdd = false;
        for (int i = 0; i < enemiesPerWave; i++)
        {
            int rnd = Random.Range(0,enemy.Length);
            Instantiate(enemy[rnd], new Vector2(transform.position.x, enemy[rnd].transform.position.y), Quaternion.identity);
            yield return new WaitForSeconds(timesPerSpawn);
        }
    }
    void NextWave()
    {
        FindObjectOfType<AudioManager>().Play("Win");
        enemiesPerWave += 2;
        round++;
        roundBegin = false;
        canAdd = true;
    }
}
