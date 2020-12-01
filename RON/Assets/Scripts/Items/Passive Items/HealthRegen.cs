using System;
public class HealthRegen : PassiveItem
{
    public float healthBoost;
    public static int count;
    public HealthRegen() : base("Nanobots", 2, "State of the art nanobots rapidly rearrange to reapir your wounds, increasing your healing.", 30)
    {
        this.shortDescription = this.itemName + ": Increases the speed health regenerates.";
    }
    public override void ApplyBonus(Player p)
    {
        HealthRegen.count++;
        p.healMultiplier = p.baseHealMultiplier + (float) Math.Pow(HealthRegen.count, 1.6f) / 2f;
    }
}