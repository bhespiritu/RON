public class TeddyBear : PassiveItem
{
    public static int count = 0;
    public TeddyBear() : base("Anti-projectile Droid", 6, "This high-speed drone orbits around you, zapping projectiles out of the area, eliminating some damage.", 75)
    {
        this.shortDescription = this.itemName + ": Gives small chance to block all damage on given hit.";
    }
    public override void ApplyBonus(Player p)
    {
        TeddyBear.count++;
        p.blockChance = (1 - (1 / (0.15f * TeddyBear.count + 1)));
    }
}
