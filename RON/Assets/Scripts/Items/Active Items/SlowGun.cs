﻿using UnityEngine;

public class SlowGun : ActiveItem
{
    public SlowGun() : base(10, false, "Low Temp Blaster", 0, "This gun charges up the longer you hold down the trigger, slowly doing more damage. However, the gun must be kept at a low temperature to counteract the heat generated by this increased damage, slowing you down the longer you use it.", 250)
    {
        this.shortDescription = this.itemName + ": Shoots slightly stronger bullets that slow enemies down.";
        this.autofire = true;
        this.autofireAmount = 0.3f;
        this.pitchVariance = .1f;
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
