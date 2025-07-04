using UnityEngine;

public class Van : Enemy
{
    public override void DealDamage()
    {
        playerController.health -= 10;
    }
}
