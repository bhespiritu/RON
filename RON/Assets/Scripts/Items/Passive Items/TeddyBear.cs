public class TeddyBear : PassiveItem
{
    public float blockBoost;
    public TeddyBear() : base("Anti-projectile Droid", 6, "This high-speed drone orbits around you, zapping projectiles out of the area, eliminating some damage.", 75)
    {
        this.blockBoost = 1.1f;
    }
    public override void ApplyBonus(Player p)
    {
        if (p.blockChance == 0)
        {
            p.blockChance = 0.05f;
        }
        else
        {
            p.blockChance *= this.blockBoost;
        }
    }
}
