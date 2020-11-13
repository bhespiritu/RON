public class JumpBoost : PassiveItem
{
    public float jumpBoost;
    public JumpBoost() : base("Tension Boots", 0, "Extra springs with increased tension and resistance are so strong, they can push against your whole weight and increase your jump height.", 20)
    {
        this.jumpBoost = 1.1f;
    }
    public override void ApplyBonus(Player p)
    {
        p.jumpSpeed *= this.jumpBoost;
    }
}
