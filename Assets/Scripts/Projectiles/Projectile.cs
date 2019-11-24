using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] float decayTime;
    [SerializeField] float damage;
    float decayTimeCurrent;
    [SerializeField] bool isExplosive;
    [SerializeField] GameObject explosion;

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Translate(gameObject.transform.forward * projectileSpeed * Time.deltaTime);

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            //Do this when projectile collides with enemy
            print("Collision!");
            EnemyController enemy = other.gameObject.GetComponent<EnemyController>();
            enemy.TakeDamage(damage);
        }
        if (isExplosive)
        {
            GameObject boom = Instantiate(explosion);
            boom.transform.position = transform.position;
        }
        //Destroys projectile on collision
        Destroy(this.gameObject);
    }
}
