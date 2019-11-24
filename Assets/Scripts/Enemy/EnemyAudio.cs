using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAudio : MonoBehaviour
{
    public AudioSource engineMoving;
    // Start is called before the first frame update
    void Start()
    {
        engineMoving.loop = true;
        engineMoving.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
