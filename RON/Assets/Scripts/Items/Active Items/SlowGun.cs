using UnityEngine;

public class SlowGun : ActiveItem
{
    public SlowGun() : base(12, false, "Freezeray", 0, "This freeze ray fires bits of frost with its bullets, which slows them down.", 75)
    {
        this.effect = "slow";
        this.shortDescription = this.itemName + ": Shoots slightly stronger bullets that slow enemies down.";
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
