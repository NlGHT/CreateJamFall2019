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
            decayTime += Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        print("Collision!");
        if(col.gameObject.tag == "Enemy")
        {
            //Do this when projectile collides with enemy
            EnemyController enemy = col.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
        }

        //Destroys projectile on collision.
        Destroy(gameObject);
        
    }
}
