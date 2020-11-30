using UnityEngine;

public class DamageBoost : PassiveItem
{
    public float damageScale;
    public DamageBoost() : base("Bigger Bullets", 1, "These bullets will make you do more damage. Bigger is better, right?", 30)
    {
        this.shortDescription = this.itemName + ": Increases damage output."
        this.damageScale = 1.05f;
    }
    public override void ApplyBonus(Player p)
    {
        p.damageMultiplier *= this.damageScale;
    }
}
