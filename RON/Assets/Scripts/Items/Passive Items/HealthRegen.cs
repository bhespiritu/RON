public class HealthRegen : PassiveItem
{
    public float healthBoost;
    public HealthRegen() : base("Nanobots", 2, "State of the art nanobots rapidly rearrange to reapir your wounds, increasing your healing.", 30)
    {
        this.healthBoost = 1.2f;
    }
    public override void ApplyBonus(Player p)
    {
        p.healMultiplier *= this.healthBoost;
    }
}