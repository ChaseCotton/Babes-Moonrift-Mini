using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public TextMeshProUGUI roundText;

    public int roundOld;
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

        round = 0;
        roundOld = 0;

    }

    private void Update()
    {
        stateHandler();
        roundText.text = round.ToString();

        if (round != roundOld)
        {
            SoundManager.PlaySound("start");
            roundOld = round;
        }

    }

    private void spawnEnemies()
    {
        StartCoroutine("ISpawnEnemy");
    }

    IEnumerator ISpawnEnemy()
    {
        // curently spawns same enemeis as round number times two
        for (int i = 0;i < round * 2; i++)
        {
            GameObject newEnemy = Instantiate(BasicEnemy, MapGen.startTile.transform.position, Quaternion.identity); ;

            // change value to mess with spawn times 
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void stateHandler()
    {
        if (isStartOfRound)
        {

            if (Time.time >= timeVariable)
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
                round++;
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
            }
        }
    }
}
