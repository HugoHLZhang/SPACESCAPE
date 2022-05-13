using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public enum SpawnState {SPAWNING, WAITING, COUNTING};

    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBtwWaves = 3f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    [SerializeField] private Transform[] Spawners;
    [SerializeField] private List<CharacterStats> enemyList;
    private int currentWave;

    private void Start()
    {
        waveCountdown = timeBtwWaves;
        currentWave = 0;
    }



    private void Update()
    {
        if(state == SpawnState.WAITING)
        {
            if (!EnemiesAreDead())
                return;
            else
            {
                CompleteWave();
            }
        }

        if (waveCountdown <= 0)
        {
            if(state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;
        for(int i = 0;  i < wave.enemiesAmount; i++)
        {
            SpawnAlien(wave.enemy);
            yield return new WaitForSeconds(wave.delay);
        }
        state = SpawnState.WAITING;
        yield break;
    }

    private void SpawnAlien(GameObject enemy)
    {
        int randomInt = Random.RandomRange(1, Spawners.Length);
        GameObject newEnemy = Instantiate(enemy, Spawners[randomInt].position, Spawners[randomInt].rotation);
        CharacterStats newEnemyStats = newEnemy.GetComponent<CharacterStats>();

        enemyList.Add(newEnemyStats);
    }

    private bool EnemiesAreDead()
    {
        int i = 0;
        foreach(CharacterStats enemy in enemyList)
        {
            if (enemy.IsDead())
            {
                i++;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    private void CompleteWave()
    {
        Debug.Log("WaveCompleted");
        state = SpawnState.COUNTING;
        waveCountdown = timeBtwWaves;

        if(currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
            //all waves completed
        }
        else
        {
            currentWave++;
        }
    }
}
