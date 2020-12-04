public class CritBoost : PassiveItem
{
    public float critBoost;
    public CritBoost() : base("Thermal Radar", 4, "This thermal apparatus allows you to better aim your shots, increasing your chance to do critical damage.", 50)
    {
        this.critBoost = 0.05f;
        this.shortDescription = this.itemName + ": Increases chance of doing critical damage on a shot.";
    }
    public override void ApplyBonus(Player p)
    {
        if (p.critChance <= 1)
        {
            p.critChance += this.critBoost;
        } else
        {
            p.critMultiplier += 0.3f;
        }
        
    }
}
