using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected PlayerController playerController;

    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public virtual void DealDamage()
    {
        playerController.health -= 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            playerController.gameObject.transform.position = playerController.startPos;
        }
    }
}
