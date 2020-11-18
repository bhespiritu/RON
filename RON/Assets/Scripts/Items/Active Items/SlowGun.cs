using UnityEngine;

public class SlowGun : ActiveItem
{
    public SlowGun() : base(12, false, "Freezeray", 0, "This freeze ray fires bits of frost with its bullets", 75)
    {
        this.effect = "slow";
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
