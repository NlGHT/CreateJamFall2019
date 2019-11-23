using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    

    public GameObject SpikerPrefab;
    public GameObject SploderPrefab;

    public List<GameObject> spawnPoints;

    public int numEnemiesLeft;
    public int amountSpawnedPerWave;

    public GameObject gate;
    public GameObject finishLine;

    private FinishLine fl;


    public float timer;
    public float spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;
        fl = finishLine.GetComponent<FinishLine>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;

        if (fl.getPlayerCount() == 2)
        {
            nextScene();
        }


        if (timer < 0)
        {
            spawnInterval -= (spawnInterval / 5);
            timer = spawnInterval;





        }

    }


    private void nextScene()
    {

    }

}
