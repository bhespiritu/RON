using System;
public class SpeedBoost : PassiveItem
{
    public static int count = 0;
    public SpeedBoost() : base("Knee Grease", 5, "Your robotic legs sometimes need to get slicked up. This grease will speed you up.", 30)
    {
        this.shortDescription = this.itemName + ": Increases speed.";
    }
    public override void ApplyBonus(Player p)
    {
        SpeedBoost.count++;
        
        if (SpeedBoost.count == 1)
        {
            p.speed = 12f;
        }
        else
        {
            p.speed = p.baseSpeed + 5f * (float) Math.Log(SpeedBoost.count);
            p.oldSpeed = p.baseSpeed + 5f * (float)Math.Log(SpeedBoost.count);
        }
    }
}
