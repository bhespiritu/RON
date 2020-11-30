public class HealthBoost : PassiveItem
{
    public float healthBoost;
    public HealthBoost(): base("Armor Plating", 0, "Makeshift scraps of metal allow you to patch up your cybernetic apendages, increasing the damage you can talk from impacts.", 15)
    {
        this.shortDescription = this.itemName + ": Boosts health.";
        this.healthBoost = 10f;
    }
    public override void ApplyBonus(Player p)
    {
        p.health += this.healthBoost;
        p.maxHealth += this.healthBoost;
    }
}
