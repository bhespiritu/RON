public class CritBoost : PassiveItem
{
    public float critBoost;
    public CritBoost() : base("Thermal Radar", 4, "This thermal apparatus allows you to better aim your shots, increasing your chance to do critical damage.", 50)
    {
        this.critBoost = 0.05f;
    }
    public override void ApplyBonus(Player p)
    {
        p.critChance += this.critBoost;
    }
}
