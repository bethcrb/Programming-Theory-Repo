using UnityEngine;

public class Bus : Enemy // INHERITANCE
{
    public override void DealDamage() // POLYMORPHISM
    {
        playerController.health -= 20;
    }
}
