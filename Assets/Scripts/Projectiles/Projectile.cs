using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] Rigidbody rb;
    [SerializeField] float decayTime;
    [SerializeField] float damage;
    float decayTimeCurrent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.Translate(rb.transform.forward * projectileSpeed * Time.deltaTime);

        if(decayTimeCurrent >= decayTime)
        {
            Destroy(gameObject);
            decayTimeCurrent = 0;
        }
        else
        {
            decayTimeCurrent += Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        GameObject GO = this.GetComponent<GameObject>();
        Destroy(GO);

        if (other.tag == "Enemy")
        {
            //Do this when projectile collides with enemy
            print("Collision!");
            EnemyController enemy = other.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
            GameObject.Destroy(gameObject);
        }

        //Destroys projectile on collision.
        Destroy(gameObject);
        
    }
}
