﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    public bool debugPathFinding;
    public GameObject targetObject;
    public float shortestNavDistance;
    [SerializeField] GameObject partPowerUp;
    [SerializeField] GameObject towerPowerUp;
    [SerializeField] GameObject explosion;
    public float navInitSpeed = 3.5f;

    public int hitpoints;
    public int damage;
    public float health = 100;

    public NavMeshAgent Agent;
    public GameObject[] playerObjects;

    public GameObject closestPlayer;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        playerObjects = getPlayerObjects();
        closestPlayer = getClosestPlayerObject(playerObjects);
        Agent.SetDestination(closestPlayer.transform.position);
        Agent.speed = navInitSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        killCheck();
        if (debugPathFinding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Agent.SetDestination(hit.point);
                }
            }
        }
        else
        {
            closestPlayer = getClosestPlayerObject(playerObjects);
            //print("Closest player: " + closestPlayer);
            //print("Navmesh distance: " + Mathf.Abs(GetDistanceNavMesh(this.transform.position, closestPlayer.transform.position)));
            //print("Shortest nav distance: " + shortestNavDistance);
            if (GetDistanceNavMesh(this.transform.position, closestPlayer.transform.position) > shortestNavDistance)
            {
                //print("Heyyyyyyyyyyyyyyy");
                Agent.SetDestination(closestPlayer.transform.position);
            }
            else
            {
                //print(gameObject + "Enemy outside target");
                Agent.ResetPath();
                Agent.SetDestination(this.transform.position);
            }
        }
    }

    private GameObject[] getPlayerObjects()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }

    public GameObject getClosestPlayerObject(GameObject[] playerObjects)
    {
        GameObject closest = playerObjects[0];
        bool bothAlive = true;
        foreach (GameObject player in playerObjects)
        {
            if (GetDistanceNavMesh(this.transform.position, player.transform.position) == -1)
            {
                bothAlive = false;
                break;
            }
        }
        //print(bothAlive);
        if (bothAlive)
        {
            float distance = -1;
            foreach (GameObject player in playerObjects)
            {
                if (distance < 0)
                {
                    distance = GetDistanceNavMesh(this.transform.position, player.transform.position);
                    closest = player;
                }
                else
                {
                    float tempDistance = GetDistanceNavMesh(this.transform.position, player.transform.position);
                    if (tempDistance < distance)
                    {
                        closest = player;
                        distance = tempDistance;
                    }
                }
            }
        }
        else
        {
            if (GetDistanceNavMesh(this.transform.position, playerObjects[0].transform.position) == -1)
            {
                closest = playerObjects[1];
            }
            else if (GetDistanceNavMesh(this.transform.position, playerObjects[1].transform.position) == -1)
            {
                closest = playerObjects[0];
            }
        }
        return closest;
    }

    public static bool GetPath(NavMeshPath path, Vector3 fromPos, Vector3 toPos)
    {
        path.ClearCorners();
        if (NavMesh.CalculatePath(fromPos, toPos, NavMesh.AllAreas, path) == false )
            return false;
        return true;
    }

    public static float GetPathLength(NavMeshPath path)
    {
        float lng = 0.0f;
        if (path.status != NavMeshPathStatus.PathInvalid)
        {
            for (int i = 1; i < path.corners.Length; ++i)
            {
                lng += Vector3.Distance(path.corners[i-1], path.corners[i]);
            }
        }
        return lng;
    }

    public static float GetDistanceNavMesh(Vector3 start, Vector3 end)
    {
        float distance = -1;
        NavMeshPath path = new NavMeshPath();
        if (GetPath(path, start, end))
        {
            distance = GetPathLength(path);
        }
        return distance;
    }


    public void TakeDamage(float damage)
    {
        //print("Enemy taking damage!");
        health -= damage;
    }

    public void killCheck()
    {
        if (health <= 0)
        {
            int r = Random.Range(0, 6);
            if (r <= 4)
            {
                GameObject gObj = Instantiate(partPowerUp);
                gObj.transform.position = transform.position;

            }
            else if (r == 5)
            {
                GameObject gObj = Instantiate(towerPowerUp);
                gObj.transform.position = transform.position;
            }
            GameObject boom = Instantiate(explosion);
            boom.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}

