﻿using System;

public class JumpBoost : PassiveItem
{
    public float jumpBoost;
    public static int count;
    public JumpBoost() : base("Tension Boots", 0, "Extra springs with increased tension and resistance are so strong, they can push against your whole weight and increase your jump height.", 20)
    {
        this.shortDescription = this.itemName + ": Increases jump height.";
        this.jumpBoost = 1.025f;
    }
    public override void ApplyBonus(Player p)
    {
        JumpBoost.count++;

        if (JumpBoost.count == 1)
        {
            p.jumpSpeed = p.baseJumpSpeed + 2f;
        }
        else
        {
            p.jumpSpeed = p.baseJumpSpeed + (float) (Math.Log((float) JumpBoost.count / 1.4f) / Math.Log(1.15));
        }
    }
}
