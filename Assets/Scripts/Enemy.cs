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
}
