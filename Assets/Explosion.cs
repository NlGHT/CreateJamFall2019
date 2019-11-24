using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    bool hasExploded = false;
    public float force = 1;
    public float radius = 1;
    [SerializeField] float damage;
    
    public List<Rigidbody> collidingBodies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasExploded)
        {
            hasExploded = true;
            for (int i = 0; i < collidingBodies.Count; i++)
            {
                //Vector3 dir = collidingBodies[i].transform.position - gameObject.transform.position;
                collidingBodies[i].AddExplosionForce(1, transform.position, radius);
                collidingBodies[i].gameObject.GetComponent<EnemyController>().TakeDamage(damage);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        collidingBodies.Add(other.gameObject.GetComponent<Rigidbody>());
    }


}
