using UnityEngine;

public class Car : Enemy
{
    public override void DealDamage()
    {
        playerController.health -= 5;
    }
}
