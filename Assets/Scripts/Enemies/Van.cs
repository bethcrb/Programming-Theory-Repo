using UnityEngine;

public class Van : Enemy // INHERITANCE
{
    public override void DealDamage() // POLYMORPHISM
    {
        playerController.health -= 10;
    }
}
