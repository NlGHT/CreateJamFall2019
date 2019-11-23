using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] PlayerControls controls;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject cannonPoint;
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject turret;
    [SerializeField] float rateOfFire;
    [SerializeField] int playerNumber;

    [SerializeField] GameObject TurretOrigin;
    [SerializeField] GameObject StarterTurret;
    [SerializeField] GameObject LilTimmy;
    [SerializeField] GameObject MachineGunTurret;
    [SerializeField] GameObject ActiveTurret;

    bool timePassed;
    float timeBetweenShots;
    bool hasShot;
    bool isShooting;
    Vector2 rotate;
    float angle;
    IEnumerator _shoot;

    void ChangeTurret(int turretID)
    {
        if(turretID == 0)
        {
            print("Changing Turret");
            if(ActiveTurret) Destroy(ActiveTurret);
            ActiveTurret = Instantiate(StarterTurret);
            ActiveTurret.transform.parent = TurretOrigin.transform;
            ActiveTurret.transform.position = TurretOrigin.transform.position;
            ActiveTurret.transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle-180));
        }
    }

    void Awake()
    {
        ChangeTurret(0);
        playerNumber = GetComponentInParent<PlayerController>().playerNumber;
        controls = new PlayerControls();

        if (playerNumber == 1)
        {
            //Left Thumbstick
            controls.Movement_p1.Aim.performed += ctx => rotate = ctx.ReadValue<Vector2>();

            //Right Trigger
            controls.Movement_p1.Shoot.performed += ctx => isShooting = true;
            controls.Movement_p1.Shoot.canceled += ctx => isShooting = false;

        }
        if (playerNumber == 2)
        {
            //Left Thumbstick
            controls.Movement_p2.Aim.performed += ctx => rotate = ctx.ReadValue<Vector2>();

            //Right Trigger
            controls.Movement_p2.Shoot.performed += ctx => isShooting = true;
            controls.Movement_p2.Shoot.canceled += ctx => isShooting = false;

        }


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
        if (playerNumber == 1)
        {
            controls.Movement_p1.Enable();
        }
        if (playerNumber == 2)
        {
            controls.Movement_p2.Enable();
        }

    }

    void OnDisable()
    {
        if (playerNumber == 1)
        {
            controls.Movement_p1.Disable();
        }
        if (playerNumber == 2)
        {
            controls.Movement_p2.Disable();
        }
    }
}
