public class SpeedBoost : PassiveItem
{
    public float speedBoost;
    public SpeedBoost() : base("Knee Grease", 5, "Your robotic legs sometimes need to get slicked up. This grease will speed you up.", 30)
    {
        this.speedBoost = 2f;
    }
    public override void ApplyBonus(Player p)
    {
        p.speed += this.speedBoost;
    }
}
