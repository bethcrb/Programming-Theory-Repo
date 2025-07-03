using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int health = 100;

    public float speed = 10.0f;

    public Vector3 startPos = new Vector3(-8.0f, 0.0f, 0.0f);

    private int maxHealth = 100;
    private int powerupHealth = 10;

    private float zBound = 8.0f;

    private Rigidbody playerRb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Moves the player based on arrow key input
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
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

            Debug.Log("Player has collided with " + enemyName);
        }
    }

    private void AddHealth(int addHealth = 0)
    {
        health += addHealth;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
}
