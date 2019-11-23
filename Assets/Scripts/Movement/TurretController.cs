using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] PlayerControls controls;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject cannonPoint;
    [SerializeField] GameObject projectile;

    bool isShooting;
    Vector2 rotate;
    float angle;


    void Awake()
    {
        controls = new PlayerControls();

        //Left Thumbstick
        controls.Movement.Aim.performed += ctx => rotate = ctx.ReadValue<Vector2>();

        //Right Trigger
        controls.Movement.Shoot.performed += ctx => isShooting = true;
        controls.Movement.Shoot.canceled += ctx => isShooting = false;
    }

    void Update()
    {
        angle = Mathf.Atan2(rotate.y, rotate.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(90, 0 , angle-180));
        if (isShooting)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        GameObject p = Instantiate(projectile) as GameObject;
        p.transform.position = cannonPoint.transform.position;
        p.transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle + 90));
    }

    void OnEnable()
    {
        controls.Movement.Enable();
    }

    void OnDisable()
    {
        controls.Movement.Disable();
    }
}
