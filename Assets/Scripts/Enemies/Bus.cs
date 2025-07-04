using UnityEngine;

public class Bus : Enemy
{
    public override void DealDamage()
    {
        playerController.health -= 20;
    }
}
