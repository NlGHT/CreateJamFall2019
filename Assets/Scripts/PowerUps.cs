using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    // Start is called before the first frame update
    private int powerUpType;

    void Start()
    {
        setType();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, Time.deltaTime*50, 0));
    }

    private int setType()
    {
        powerUpType = Random.Range(1, 6);
        print(powerUpType);

        return powerUpType;
    }

    private void part()
    {
        // On collision this should increase strength of the character which picks it up
    } 
}
