using System.Collections;
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


    public int points = 0;

    //Player Stats
        [SerializeField] public int playerNumber;

        //HP and Energy
        [SerializeField] public float hp;
        // On awake maxHP is set to hp
        [SerializeField] public float maxHP;
        [SerializeField] public float energy;
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

    // Audio
    [SerializeField] AudioSource idleSound;
    [SerializeField] AudioSource movingSound;
    [SerializeField] bool movingSoundOn = false;

    // Respawn
    [SerializeField] float respawnTime;
    private float respawnCountdown;

    private bool isDead;

    private Vector3 deathLocation;


    void Awake()
    {
        gameObject.tag = "Player";
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
        //Right Thumbstick
        speed = baseSpeed * movementModifier;

        if (playerNumber == 1)
        {
            controls.Movement_p1.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Movement_p1.Move.performed += ctx => goMovingSound();

            controls.Movement_p1.Move.canceled += ctx => move = Vector2.zero;
            controls.Movement_p1.Move.canceled += ctx => goIdleSound();

            controls.Movement_p1.Turn.performed += ctx => turn = ctx.ReadValue<Vector2>();



            //Left Thumbstick
            //See TurretController

            //Button South (X On PS4 Controller)
            controls.Movement_p1.Jump.performed += ctx => Jump();

            //Left Trigger
            controls.Movement_p1.Boost.performed += ctx => Boost(true);
            controls.Movement_p1.Boost.canceled += ctx => Boost(false);

        }
        if (playerNumber == 2)
        {
            controls.Movement_p2.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.Movement_p2.Move.canceled += ctx => move = Vector2.zero;
            controls.Movement_p2.Turn.performed += ctx => turn = ctx.ReadValue<Vector2>();

            //Left Thumbstick
            //See TurretController

            //Button South (X On PS4 Controller)
            controls.Movement_p2.Jump.performed += ctx => Jump();

            //Left Trigger
            controls.Movement_p2.Boost.performed += ctx => Boost(true);
            controls.Movement_p2.Boost.canceled += ctx => Boost(false);

        }

        //Left Trigger
        isDead = false;
        deathLocation = new Vector3(8000, 8000, 8000);
        respawnCountdown = respawnTime;
        maxHP = hp;

        //Sound stuff
        if (idleSound)
        {
            idleSound.loop = true;
        }
        
        movingSound.loop = true;
        idleSound.Play();
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
        if(transform.position.y <= 0)
        {
            Vector3 v = new Vector3(0, 2, 0);
            transform.position += v;
        }
        Vector3 m = new Vector3(-move.x, 0, -move.y) * Time.deltaTime;
        transform.Translate(m * speed, Space.World);
       
        angle = Mathf.Atan2(-turn.y, -turn.x) * Mathf.Rad2Deg;
        //float lAngle = Mathf.Lerp(angle, transform.rotation.y, t);
        transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));

        // For respawns
        if (isDead)
        {
            if (respawnCountdown > 0)
            {
                respawnCountdown -= Time.deltaTime;
            }
            else
            {
                respawn();
                respawnCountdown = respawnTime;
            }
        }
    }

    void OnEnable()
    {
        if(playerNumber == 1)
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

    void death()
    {
        print("Teleported away!");
        isDead = true;
        this.transform.position = deathLocation;
        if (idleSound.isPlaying)
            idleSound.Stop();
        if (movingSound.isPlaying)
            movingSound.Stop();
    }

    void respawn()
    {
        idleSound.Play();
        GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("PlayerSpawnPoint");
        Vector3 spawnLocation = spawnPoints[Mathf.RoundToInt(Random.Range(0, spawnPoints.Length-1))].transform.position;
        transform.position = spawnLocation;
        hp = maxHP;
        isDead = false;
    }

    private void goMovingSound()
    {
        if (movingSoundOn)
        {
            if (idleSound.isPlaying)
            {
                idleSound.Stop();
                movingSound.Play();
            }
        }
    }

    private void goIdleSound()
    {
        if (movingSoundOn)
        {
            if (movingSound.isPlaying)
            {
                movingSound.Stop();
                idleSound.Play();
            }
        }
    }
}
