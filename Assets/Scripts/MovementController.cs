using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = 10.0f;
    private Rigidbody objectRb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveObjectPosition();
        DestroyOutOfBounds();
    }

    void MoveObjectPosition()
    {
        if (transform.position.x > 0)
        {
            objectRb.AddForce(Vector3.forward * speed);
        }
        else
        {
            objectRb.AddForce(Vector3.forward * -speed);
        }
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.z > zDestroy || transform.position.z < -zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
