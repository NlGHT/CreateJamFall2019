using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float damagePerTime;

    private GameObject playerTouching;
    private bool touchingPlayer;
    // Start is called before the first frame update
    void Start()
    {
        damagePerTime = 10;
        touchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (touchingPlayer)
        {
            PlayerController pc = playerTouching.GetComponent<PlayerController>();
            pc.TakeDamage(damagePerTime);
        }
    }

    private void OnTriggerEnter(Collider other) {
        GameObject otherGO = other.GetComponent<GameObject>();
        if (otherGO.layer == 9)
        {
            //Player
            print("Touching player");
            touchingPlayer = true;
            playerTouching = otherGO;
        }
    }

    void OnTriggerExit(Collider other)
    {
        print(other);
        GameObject otherGO = other.GetComponent<GameObject>();
        if (otherGO.layer == 9)
        {
            //Player
            print("Touching player");
            touchingPlayer = false;
            playerTouching = null;
        }
    }
}
