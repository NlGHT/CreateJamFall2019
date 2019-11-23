using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float damagePerTime;
    public float timePerDamage;

    private float timeCountdown;
    private GameObject playerTouching;
    private PlayerController pc = null;
    private bool touchingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        timePerDamage = 1;
        timeCountdown = timePerDamage;
        damagePerTime = 20;
        touchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print("... Update Loop ...");
        if (touchingPlayer == true)
        {
            timeCountdown -= Time.deltaTime;

            if (timeCountdown <= 0)
            {
                pc.TakeDamage(damagePerTime);
                timeCountdown = timePerDamage;
                //print("Hurting player");
            }
        }
        else
        {
            timeCountdown = timePerDamage;
        }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject otherGO = other.gameObject;
        print(otherGO);
        if (otherGO.tag == "Player")
        {
            //Player
            print("Touching player");
            playerTouching = otherGO;
            pc = playerTouching.GetComponent<PlayerController>();
            touchingPlayer = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        print(other);
        GameObject otherGO = other.gameObject;
        if (otherGO.tag == "Player")
        {
            //Player
            touchingPlayer = false;
            playerTouching = null;
            pc = null;
        }
    }
}
