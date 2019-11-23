using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{

    private bool gateShouldLower = false;

    public GameObject endingPosition;
    public float loweringTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gateShouldLower)
        {
            transform.position = Vector3.Lerp(transform.position, endingPosition.transform.position, loweringTime);
        }
    }


    public void lowerGate()
    {
        gateShouldLower = true;
    }


}
