﻿using System.Collections;
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
    [SerializeField] public int playerNumber;

    [SerializeField] GameObject TurretOrigin;

    [SerializeField] GameObject StarterTurret;
    [SerializeField] GameObject StarterProjectile;
    [SerializeField] float starterRateOfFire;

    [SerializeField] GameObject LilTimmy;
    [SerializeField] GameObject LilTimmyProjectile;
    [SerializeField] float LilTimmyRateOfFire;

    [SerializeField] GameObject MachineGunTurret;
    [SerializeField] GameObject MachineGunProjectile;
    [SerializeField] float MachineGunRateOfFire;

    [SerializeField] GameObject ActiveTurret;

    [SerializeField] int iActiveTurret;

    [SerializeField] AudioSource lilTimmySound;
    [SerializeField] AudioSource machineGunSound;
    [SerializeField] AudioSource startSound;

    bool timePassed;
    float timeBetweenShots;
    bool hasShot;
    bool isShooting;
    Vector2 rotate;
    float angle;
    IEnumerator _shoot;

    public void ChangeTurret(int turretID)
    {
        if(turretID == 0 && iActiveTurret != 0)
        {
            
            iActiveTurret = 0;
            print("Changing Turret");
            if(ActiveTurret != null) Destroy(ActiveTurret.gameObject);
            projectile = StarterProjectile;
            rateOfFire = starterRateOfFire;

            ActiveTurret = Instantiate(StarterTurret);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            ActiveTurret.transform.parent = transform;
            ActiveTurret.transform.position = transform.position;
            if (playerNumber == 1)
            {
                cannonPoint = GameObject.FindGameObjectWithTag("StarterPP");
            }
            if (playerNumber == 2)
            {
                cannonPoint = GameObject.FindGameObjectWithTag("StarterPP2");
            }


        }
        if (turretID == 1 && iActiveTurret != 1)
        {
            iActiveTurret = 1;
            print("Changing Turret");
            if (ActiveTurret != null) Destroy(ActiveTurret);
            projectile = LilTimmyProjectile;
            rateOfFire = LilTimmyRateOfFire;

            ActiveTurret = Instantiate(LilTimmy);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            ActiveTurret.transform.parent = transform;
            ActiveTurret.transform.position = transform.position;
            if (playerNumber == 1)
            {
                cannonPoint = GameObject.FindGameObjectWithTag("LilTimmyPP");
            }
            if (playerNumber == 2)
            {
                cannonPoint = GameObject.FindGameObjectWithTag("LilTimmyPP2");
            }

        }
        if (turretID == 2)
        {
            iActiveTurret = 2;
            print("Changing Turret");
            if (ActiveTurret != null) Destroy(ActiveTurret);
            projectile = MachineGunProjectile;
            rateOfFire = MachineGunRateOfFire;

            ActiveTurret = Instantiate(MachineGunTurret);
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            ActiveTurret.transform.parent = transform;
            ActiveTurret.transform.position = transform.position;
            if (playerNumber == 1)
            {
                cannonPoint = GameObject.FindGameObjectWithTag("MGPP");
            }
            if (playerNumber == 2)
            {
                cannonPoint = GameObject.FindGameObjectWithTag("MGPP2");
            }
        }
    }

    void Awake()
    {
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

    }
    void iChangeTurret()
    {
        if (iActiveTurret == 0) ChangeTurret(1);
        if (iActiveTurret == 1) ChangeTurret(2);
        if (iActiveTurret == 2) ChangeTurret(0);
    }
    void Update()
    {
        angle = Mathf.Atan2(-rotate.x, rotate.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));



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
        p.transform.parent = transform.parent;
        p.transform.position = cannonPoint.transform.position;
        p.transform.rotation = Quaternion.Euler(new Vector3(90, 0, angle));
        hasShot = true;

        switch (iActiveTurret)
        {
            case 0:
                //Starter
                startSound.Play();
                break;
            case 1:
                //LilTimmy
                lilTimmySound.Play();
                break;
            case 2:
                //MachineGun
                machineGunSound.Play();
                break;
        }
    }

    void OnEnable()
    {
        ChangeTurret(1);
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
