using UnityEngine;

public class Heal : SecondaryItem
{
    public float greenTime;
    public float greenTimer;
    public bool green;

    public Heal(Player p) : base(p, "H-PAC +", 4, "This pack of healing goo is used by high tech soldiers. It contains a combination of modern medicine, stimulants, and nanobots which can quickly revitalize you.", 200)
    {
        this.coolDownAmount = 10f;
        this.greenTime = 0.75f;
        this.greenTimer = 0f;
        this.green = false;
    }

    public override void Effect(bool click)
    {
        if (this.canUse)
        {
            this.green = false;
            this.greenTimer = 0f;
        }   
        if (this.canUse && click)
        {
            this.thingy.RightHit(this.coolDownAmount);
            this.player.Heal((this.player.maxHealth - this.player.health) / 2f);
            this.player.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
            this.green = true;
            this.canUse = false;
        }
        if (!this.canUse && this.green)
        {
            this.player.GetComponent<SpriteRenderer>().color = new Color(this.greenTimer / this.greenTime, 1, this.greenTimer / this.greenTime);
            this.greenTimer += Time.deltaTime;
        }
        if (!this.canUse)
        {
            base.CoolDown();
        }
    }
}
