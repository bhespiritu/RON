using UnityEngine;

public class SlowGun : ActiveItem
{
    public SlowGun() : base(10, false, "Freezeray", 0, "This freeze ray fires bits of frost with its bullets, which slows them down.", 75)
    {
        this.shortDescription = this.itemName + ": Shoots slightly stronger bullets that slow enemies down.";
        this.autofire = true;
        this.autofireAmount = 0.3f;
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
