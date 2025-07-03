using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    public virtual void DealDamage(int damage)
    {
        player.UpdateHealth(damage);
    }
}
