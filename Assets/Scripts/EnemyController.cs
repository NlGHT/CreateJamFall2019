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
            Agent.SetDestination(getClosestPlayerObject(playerObjects).transform.position);
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
                distance = Vector3.Distance(player.transform.position, this.transform.position);
                closest = player;
            } else
            {
                if (Vector3.Distance(player.transform.position, this.transform.position) < distance)
                    closest = player;
            }
        }
        return closest;
    }
}
