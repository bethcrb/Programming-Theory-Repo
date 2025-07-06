using UnityEngine;

public class Car : Enemy // INHERITANCE
{
    public override void DealDamage() // POLYMORPHISM
    {
        playerController.health -= 5;
    }
}
