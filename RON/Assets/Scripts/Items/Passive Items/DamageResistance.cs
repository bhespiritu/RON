public class DamageResistance : PassiveItem
{
    public float defenseBoost;
    public DamageResistance() : base("Reinforced Titanium", 6, "You can use this metal to strengthen your armor and boost your resistance to damage.", 45)
    {
        this.defenseBoost = 1f;
    }
    public override void ApplyBonus(Player p)
    {
        p.defense++;
    }
}
