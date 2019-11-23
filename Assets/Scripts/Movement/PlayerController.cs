﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //X and Y Movement
    float speed;
    float angle;
    Vector2 turn;
    Vector2 move;
    float t;

    //Player Stats
        //HP and Energy
        [SerializeField] public float hp;
        [SerializeField] float energy;
        [SerializeField] public float damage;

        //Movement
        [SerializeField] float baseSpeed;
        [SerializeField] float boostSpeed;
        [SerializeField] float movementModifier;

        //Jumping
        [SerializeField] float force;
    
    //Control objects
    [SerializeField] Rigidbody rb;
    [SerializeField] PlayerControls controls;

    private bool isDead;

    private Vector3 deathLocation;

    void Awake()
    {
        gameObject.tag = "Player";
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
        //Right Thumbstick
        speed = baseSpeed * movementModifier;
        controls.Movement.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Movement.Move.canceled += ctx => move = Vector2.zero;

        controls.Movement.Turn.performed += ctx => turn = ctx.ReadValue<Vector2>();

        //Left Thumbstick
        //See TurretController

        //Button South (X On PS4 Controller)
        controls.Movement.Jump.performed += ctx => Jump();

        //Left Trigger
        controls.Movement.Boost.performed += ctx => Boost(true);
        controls.Movement.Boost.canceled += ctx => Boost(false);
        isDead = false;
        deathLocation = new Vector3(8000, 8000, 8000);
    }

    void Jump()
    {
        rb.AddForce(transform.up * force);
    }

    void Boost(bool isBoosting)
    {
        if (isBoosting)
        {
            speed = boostSpeed * movementModifier;
        }
        if (!isBoosting)
        {
            speed = baseSpeed * movementModifier;
        }
    }

    public float TakeDamage(float damage)
    {
        hp -= damage;
        print(hp);
        if (hp <= 0)
        {
            death();
        }
        return hp;
    }

    void Update()
    {
        Vector3 m = new Vector3(move.x, 0, move.y) * Time.deltaTime;
        transform.Translate(m * speed, Space.World);

        angle = Mathf.Atan2(turn.x, turn.y) * Mathf.Rad2Deg;
        //float lAngle = Mathf.Lerp(angle, transform.rotation.y, t);
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

    }

    void OnEnable()
    {
        controls.Movement.Enable();
    }

    void OnDisable()
    {
        controls.Movement.Disable();
    }

    void death()
    {
        isDead = true;
        this.transform.position = deathLocation;
    }
}
