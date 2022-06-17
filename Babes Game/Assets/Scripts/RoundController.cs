using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    // controls enemy waves and duration between rounds

    public RoundState state;

    public GameObject BasicEnemy;

    public float timeTweenWaves;
    public float timeBeforeRoundStarts;
    private float timeVariable;

    private bool isRoundGoing;
    private bool isIntermission;
    private bool isStartOfRound;

    public int round;
    public enum RoundState
    {
        isStartOfRound,
        isRoundGoing,
        isIntermission
    }

    public void Start()
    {
        isRoundGoing = false;
        isIntermission = false;
        isStartOfRound = true;

        timeVariable = Time.time + timeBeforeRoundStarts;

        round = 1;

    }

    private void Update()
    {
        stateHandler();
    }

    private void spawnEnemies()
    {
        StartCoroutine("ISpawnEnemy");
    }

    IEnumerator ISpawnEnemy()
    {
        // curently spawns same enemeis as round number
        for (int i = 0;i < round; i++)
        {
            GameObject newEnemy = Instantiate(BasicEnemy, MapGen.startTile.transform.position, Quaternion.identity); ;

            yield return new WaitForSeconds(1f);
        }
    }

    private void stateHandler()
    {
        if (isStartOfRound)
        {
            if(Time.time >= timeVariable)
            {
                isStartOfRound = false;
                isRoundGoing = true;
                state = RoundState.isRoundGoing;
                spawnEnemies();
            }
        }
        else if (isIntermission)
        {
            if (Time.time >= timeVariable)
            {
                isIntermission = false;
                isRoundGoing = true;
                state = RoundState.isRoundGoing;

                spawnEnemies();
            }
        } 
        else if (isRoundGoing)
        {
            if (EnemyList.enemyList.Count > 0)
            {
                state = RoundState.isStartOfRound;
            }
            else
            {
                isIntermission = true;
                isRoundGoing = false;
                state = RoundState.isIntermission;
                timeVariable = Time.time + timeTweenWaves;
                round++;
            }
        }
    }
}
