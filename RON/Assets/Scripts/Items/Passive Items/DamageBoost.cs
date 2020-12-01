using UnityEngine;

public class DamageBoost : PassiveItem
{
    public static int count = 0;

    public DamageBoost() : base("Bigger Bullets", 1, "These bullets will make you do more damage. Bigger is better, right?", 30)
    {
        this.shortDescription = this.itemName + ": Increases damage output.";
    }
    public override void ApplyBonus(Player p)
    {
        DamageBoost.count++;
        p.damageMultiplier = p.baseDamageMultiplier + DamageBoost.count / 7f;
    }
}
