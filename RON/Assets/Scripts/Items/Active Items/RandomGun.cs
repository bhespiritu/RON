using UnityEngine;
using System;

public class RandomGun : ActiveItem
{
    public RandomGun() : base(10, false, "Disco Laser", 1, "This powerful light emitter will focus light and channel it through a discoball, shooting it out in a semirandom direction. These bullets reflect.", 100)
    {
        this.accuracy = 0.85f;
        this.shortDescription = this.itemName + ": Rapidly shoots projectiles in random directions.";
        this.autofire = true;
        this.autofireAmount = 0.2f;
        this.pitchVariance = 0.1f;
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
