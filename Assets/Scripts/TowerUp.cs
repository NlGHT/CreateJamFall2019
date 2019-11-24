using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUp : MonoBehaviour
{
    // Change the tower type of the tank that picks this up
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate object to make it look pickupable
        transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerScript = other.GetComponent<PlayerController>();
        playerScript.points += 1;
        playerScript.damage = playerScript.damage + 10;
        playerScript.hp = playerScript.hp + 10;

        int r = Random.Range(0, 2);
        other.gameObject.GetComponentInChildren<TurretController>().ChangeTurret(r);
        GameObject otherGO = other.gameObject;
        print(otherGO);
        Destroy(gameObject);
    }
}
