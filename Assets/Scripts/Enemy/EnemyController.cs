using System.Collections;
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
    public GameObject partPowerUp;
    public GameObject towerPowerUp;
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
                print(gameObject + "Enemy outside target");
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
        print(bothAlive);
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

    private void death()
    {
        Transform powerUpSpawn = this.transform;
        int powerUpStyle = Random.Range(1, 6);
        if(powerUpStyle <= 5)
        {
            GameObject thePowerUp = Instantiate(partPowerUp) as GameObject;
            thePowerUp.transform.position = powerUpSpawn.transform.position;
            Destroy(gameObject);
        }
        else if(powerUpStyle == 6)
        {
            GameObject thePowerUp = Instantiate(towerPowerUp) as GameObject;
            thePowerUp.transform.position = powerUpSpawn.transform.position;
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        print("Enemy taking damage!");
        health -= damage;
        if (health <= 0)
        {
            death();
        }
    }
}

