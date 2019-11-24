using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{

    public int currentSceneNumber;

    public GameObject SpikerPrefab;
    public GameObject SploderPrefab;

    public List<GameObject> spawnPoints;
    public List<GameObject> activeEnemies;

    public int numEnemiesLeft;
    private int amountSpawnedPerWave;
    public int numberOfWaves;

    public float waveMultiplier;
    public int sploderRatio;
    public bool spawnsSploders = true;

    public GameObject gate;
    public GameObject finishLine;

    private Gate g;
    private FinishLine fl;


    public float timer;
    public float spawnInterval;


    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;

        g = gate.GetComponent<Gate>();
        fl = finishLine.GetComponent<FinishLine>();

        amountSpawnedPerWave = numEnemiesLeft / numberOfWaves;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

        timer -= Time.deltaTime;

        if (fl.getPlayerCount() == 1) // Check if nboth players are in the goal
        {
            Debug.Log("NEXT MAP");
            nextScene();
        }


        if (timer < 0)
        {
            spawnInterval -= (spawnInterval / 5);
            timer = spawnInterval;

            for (int i = 0; i < amountSpawnedPerWave; i++)
            {
                numEnemiesLeft -= 1;

                int randomOffset = Random.Range(0, 1);
                Vector3 offset = new Vector3(randomOffset, 0, randomOffset);

                if (spawnsSploders)
                {
                    int rand = Random.Range(0, spawnPoints.Count);

                    int rand2 = Random.Range(0, sploderRatio);
                    if (rand2 >= sploderRatio -1)
                    {
                        GameObject enemy = Instantiate(SploderPrefab);
                        enemy.transform.position = spawnPoints[rand].transform.position + offset;
                        activeEnemies.Add(enemy);
                    }
                    else
                    {
                        GameObject enemy = Instantiate(SpikerPrefab);
                        enemy.transform.position = spawnPoints[rand].transform.position + offset;
                        activeEnemies.Add(enemy);
                    }
                } else
                {
                    int rand = Random.Range(0, spawnPoints.Count);

                    

                    GameObject enemy = Instantiate(SpikerPrefab);
                    enemy.transform.position = spawnPoints[rand].transform.position + offset;
                    activeEnemies.Add(enemy);
                }
                
                
            }

            amountSpawnedPerWave = (int)(amountSpawnedPerWave * waveMultiplier); // Increase wave count;
            if (amountSpawnedPerWave >= numEnemiesLeft)
            {
                amountSpawnedPerWave = numEnemiesLeft;
            }

        }

        for (int i = 0; i < activeEnemies.Count; i++)
        {
            if (activeEnemies[i] == null)
            {
                activeEnemies.RemoveAt(i);
                i -= 1;
            }
        }

        if (numEnemiesLeft <= 0 && activeEnemies.Count == 0)
        {
            lowerGate();
        }


    }


    private void lowerGate()
    {
        g.lowerGate();
    }

    private void nextScene()
    {

        //SaveFile();

        SceneManager.LoadScene(currentSceneNumber += 1);
    }

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        UIManager um = GetComponent<UIManager>();

        string points = "Player 1: " + um.points1 + "         Player 2: " + um.points2;

        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, points);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        string scores = (string)bf.Deserialize(file);
        file.Close();

        Debug.Log(scores);
    }


}
