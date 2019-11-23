using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartUp : MonoBehaviour
{
    // Pick up parts to increase damage and hitpoints 

    int damageIncrease = 1;
    int hpIncrease = 1;

    // Update is called once per frame
    void Update()
    {
        // Rotate the object to make it look like a pick-upable item
        transform.Rotate(new Vector3(0, Time.deltaTime * 50, 0));
    }

    // When something enters the collider and has trigger, activate code
    private void OnTriggerEnter(Collider other)
    {
        GameObject otherGO = other.gameObject;
        print(otherGO);
        if (other.gameObject.tag == "Player" && gameObject != null) // only do for type 5 or below
        {
            print("Picked up a part");
            PlayerController playerScript = other.GetComponent<PlayerController>();
            playerScript.damage = playerScript.damage + damageIncrease;
            playerScript.hp = playerScript.hp + hpIncrease;
            playerScript.points += 1;

            //print("Damage is; " + playerScript.damage + " and hp is; " + playerScript.hp);
            Destroy(gameObject);
        }
    }
}
