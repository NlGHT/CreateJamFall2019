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

    NavMeshAgent Agent;
    private GameObject[] playerObjects;

    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        playerObjects = getPlayerObjects();
        GameObject closestPlayer = getClosestPlayerObject(playerObjects);
        Agent.SetDestination(closestPlayer.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        print("YOOOOOOOOOOOOOOOOO");
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
            GameObject closestPlayer = getClosestPlayerObject(playerObjects);
            print(GetDistanceNavMesh(this.transform.position, closestPlayer.transform.position));
            if (GetDistanceNavMesh(this.transform.position, closestPlayer.transform.position) > shortestNavDistance)
            {
                Agent.isStopped = false;
                Agent.SetDestination(closestPlayer.transform.position);
            }
            else
            {
                Agent.isStopped = true;
                Agent.ResetPath();
            }
        }
    }

    private GameObject[] getPlayerObjects()
    {
        return GameObject.FindGameObjectsWithTag("Player");
    }

    private GameObject getClosestPlayerObject(GameObject[] playerObjects)
    {
        float distance = -1;
        GameObject closest = playerObjects[0];
        foreach (GameObject player in playerObjects)
        {
            if (distance < 0)
            {
                distance = GetDistanceNavMesh(this.transform.position, player.transform.position);
                closest = player;
            } else
            {
                float tempDistance = GetDistanceNavMesh(this.transform.position, player.transform.position);
                if (tempDistance < distance)
                {
                    closest = player;
                    distance = tempDistance;
                }
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

    private static float GetDistanceNavMesh(Vector3 start, Vector3 end)
    {
        float distance = -1;
        NavMeshPath path = new NavMeshPath();
        if (GetPath(path, start, end))
        {
            distance = GetPathLength(path);
        }
        return distance;
    }
}
