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
            }
        }
    }

    private void searchAroundForTarget()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, closestObject.transform.position);
        print(distanceToPlayer);
        if (distanceToPlayer < searchRadius)
        {
            targetFound = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (targetFound)
        {
            GameObject otherGO = other.gameObject;
            print(otherGO);
            if (otherGO != null)
            {
                if (otherGO.tag == "Player")
                {
                    explode();
                }
            }
        }
        else
        {
            /*
            GameObject otherGO = other.gameObject;
            print(otherGO);
            if (otherGO != null)
            {
                if (otherGO.tag == "Player")
                {
                    if (targetsBlocking == 0)
                    {
                        attackTarget();
                    }
                    playerInView = true;
                }
                else
                {
                    targetsBlocking++;
                }
            }
            */
        }
    }

    void OnTriggerExit(Collider other)
    {
        /*
        if (!targetFound)
        {
            GameObject otherGO = other.gameObject;
            print(otherGO);
            if (otherGO != null)
            {
                if (otherGO.tag != "Player")
                {
                    targetsBlocking--;
                }
                else
                {
                    
                }
            }
        }
        */
    }

    private void explode()
    {
        Destroy(gameObject);
    }

    private void seeAllInLine()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Renderer rend = hit.transform.GetComponent<Renderer>();

            if (rend)
            {
                // Change the material of all hit colliders
                // to use a transparent shader.
                rend.material.shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = rend.material.color;
                tempColor.a = 0.3F;
                rend.material.color = tempColor;
            }
        }
    }

    private RaycastHit rcPlayer(GameObject player)
    {
        int layerMask = 1 << 10;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        Vector3 playerPos = player.transform.position;
        Vector3 dir = (transform.position - playerPos).normalized;
        if (Physics.Raycast(this.transform.position, dir, out hit, Mathf.Infinity, 100))
        {
            Debug.DrawRay(this.transform.position, dir * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            print(hit.distance);
        }
        else
        {
            //Debug.DrawRay(transform.position, dir * 1000, Color.white);
            //Debug.Log("Did not Hit");
        }
        return hit;
    }

    private void targetPlayer()
    {



        /*
        foreach (GameObject player in players)
        {
            RaycastHit hit = rcPlayer(player);
            if (hit.point != Vector3.zero)
            {
                print(hit.point);
                GameObject objectHit = hit.collider.gameObject;
                if (objectHit.GetInstanceID() == objectHit.GetInstanceID())
                {
                    targetFound = true;
                    targetLocation = hit.point;
                    break;
                }
            }
        }
        */
    }

    private void attackTarget()
    {
        print("RIP target");
        agent.speed += speedIncreaseSight*Time.deltaTime;
    }

    private GameObject getVisibleEnemy()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] != null)
            {
                // Bit shift the index of the layer (8) to get a bit mask
                int layerMask = 1 << LayerMask.NameToLayer("Enemy");

                // This would cast rays only against colliders in layer 8.
                // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
                layerMask = ~layerMask;

                RaycastHit hit;
                if (Physics.Raycast(this.transform.position, players[i].transform.position - transform.position, out hit, layerMask))
                {
                    Debug.DrawLine(this.transform.position, hit.point);
                    if (hit.transform.gameObject == players[i])
                    {
                        return players[i];
                    }
                }
            }
        }
        return null;
    }
}
