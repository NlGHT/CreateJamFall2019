using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] PlayerControls controls;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject cannonPoint;
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire;

    bool timePassed;
    float timeBetweenShots;
    bool hasShot;
    bool isShooting;
    Vector2 rotate;
    float angle;
    IEnumerator _shoot;

    void Awake()
    {

        controls = new PlayerControls();

        //Left Thumbstick
        controls.Movement_p1.Aim.performed += ctx => rotate = ctx.ReadValue<Vector2>();

        //Right Trigger
        controls.Movement_p1.Shoot.performed += ctx => isShooting = true;
        controls.Movement_p1.Shoot.canceled += ctx => isShooting = false;
    }

    void Update()
    {
        angle = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(90, 0 , angle-90));

        if (!hasShot)
        {
            if (isShooting)
            {
                Shoot();
                TimeBetweenShots();
            }

        }

    }
    public void TimeBetweenShots()
    {
        timeBetweenShots = 60 / rateOfFire;
        _shoot = WaitTime(timeBetweenShots);
        StartCoroutine(_shoot);
        if (!hasShot) StopCoroutine(_shoot);

    }
    private IEnumerator WaitTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        hasShot = false;
    }

    void Shoot()
    {
        GameObject p = Instantiate(projectile) as GameObject;
        p.transform.position = cannonPoint.transform.position;
        p.transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle+180));
        hasShot = true;
    }

    void OnEnable()
    {
        controls.Movement_p1.Enable();
    }

    void OnDisable()
    {
        controls.Movement_p1.Disable();
    }
}
