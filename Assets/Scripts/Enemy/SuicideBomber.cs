using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideBomber : MonoBehaviour
{
    EnemyController enemyController;

    public float searchRadius;
    public float speedIncreaseSight;

    GameObject closestObject;

    private bool targetFound = false;
    private int targetsBlocking = 0;
    GameObject[] players;
    private Vector3 targetLocation;
    private GameObject eye;
    private UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        enemyController = GetComponent<EnemyController>();
        players = enemyController.playerObjects;
        print(players.Length);
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (players.Length == 0)
        {
            players = enemyController.playerObjects;
            closestObject = enemyController.closestPlayer;
        }
        else
        {
            if (!targetFound)
            {
                closestObject = enemyController.closestPlayer;
                //print(players.Length);
                searchAroundForTarget();

                /*
                GameObject target = getVisibleEnemy();
                print(target);
                if (target != null)
                {
                    targetLocation = target.transform.position;
                    targetFound = true;
                    print(target);
                }
                */
            }
            else
            {
                attackTarget();
                if (EnemyController.GetDistanceNavMesh(this.transform.position, closestObject.transform.position) > searchRadius)
                {
                    enemyController.Agent.speed = enemyController.navInitSpeed;
                }
            }
        }
    }

    private void searchAroundForTarget()
    {
        if (closestObject)
        {
            float distanceToPlayer = Vector3.Distance(this.transform.position, closestObject.transform.position);
            //print(distanceToPlayer);
            if (distanceToPlayer < searchRadius)
            {
                targetFound = true;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        if (targetFound)
        {
            GameObject otherGO = other.gameObject;
            if (otherGO != null)
            {
                //print(otherGO);
                if (otherGO.tag == "Player")
                {
                    explode();
                }
            }
        }
    }

    private void explode()
    {
        Destroy(gameObject);
    }

    private void attackTarget()
    {
        //print("RIP target");
        agent.speed += speedIncreaseSight*Time.deltaTime;
    }
}
