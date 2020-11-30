using UnityEngine;
using System;

public class RandomGun : ActiveItem
{
    public RandomGun() : base(15, false, "Disco Laser", 1, "This gun affixes a complicated laser pulse gun through a... well... disco ball. The reflected beams deal increased damage but fire rather haphazardously, not always shooting where you aim. Use with caution. It replaces your current weapon.", 100)
    {
        this.accuracy = 0.75f;
        this.shortDescription = this.itemName + ": Rapidly shoots projectiles in random directions.";
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
