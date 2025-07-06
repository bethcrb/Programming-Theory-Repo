using System;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;

    public float speed = 10.0f;

    public Vector3 startPos = new Vector3(-8.0f, 0.0f, 0.0f);

    private int maxHealth = 100;
    private int powerupHealth = 10;

    private float zBound = 5.0f;

    private GameManager gameManager;
    private Animator playerAnim;
    private Rigidbody playerRb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<Animator>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MovePlayer();
        }
        ConstrainPlayerPosition();
    }

    // Moves the player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
        if (horizontalInput > 0 || verticalInput > 0)
        {
            gameManager.UpdateScore();
        }
    }

    // Prevent the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            AddHealth(powerupHealth);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            String enemyName = collision.gameObject.name.ToString();
            if (enemyName == "Enemy 1(Clone)")
            {
                Car car = collision.gameObject.GetComponent<Car>();
                car.DealDamage();
            }
            else if (enemyName == "Enemy 2(Clone)")
            {
                Van van = collision.gameObject.GetComponent<Van>();
                van.DealDamage();
            }
            else if (enemyName == "Enemy 3(Clone)")
            {
                Bus bus = collision.gameObject.GetComponent<Bus>();
                bus.DealDamage();
            }
        }
    }

    private void AddHealth(int addHealth = 0)
    {
        if (gameManager.isGameActive)
        {
            health += addHealth;
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
    }

    public void SitDown()
    {
        playerAnim.SetBool("Sit_b", true);
    }
}
