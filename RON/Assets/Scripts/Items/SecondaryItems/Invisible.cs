using UnityEngine;

public class Invisible : SecondaryItem
{
    public float invisibleTimer = 0f;
    public float invisibleDelay = 3f;
    public SpriteRenderer playerSprite;

    public Invisible(Player p) : base(p, "Anti-light Emitter", 2, "This complicated array scans surrounding lightwaves surrounding you and emits light at the opposite frequency, cloaking you from your enemies. This is a secondary item, which you use with right click.", 150)
    {
        this.coolDownAmount = 5f;
        this.playerSprite = this.player.GetComponent<SpriteRenderer>();
    }

    public override void Effect(bool click)
    {
        if (!this.player.invisible && click && this.canUse)
        {
            this.canUse = false;
            this.player.invisible = true;
            this.playerSprite.color = new Color(this.playerSprite.color.r, this.playerSprite.color.g, this.playerSprite.color.b, 0.25f);
        }
        else if (!this.player.invisible && !this.canUse)
        {
            base.CoolDown();
        }
        else if (!this.player.invisible)
        {
            return;
        }

        if (this.invisibleTimer < this.invisibleDelay && this.player.invisible)
        {
            Debug.Log(invisibleTimer);
            this.invisibleTimer += Time.deltaTime;
        }
        else
        {
            if (this.player.invisible)
            {
                this.thingy.RightHit(this.coolDownAmount);
            }
            this.invisibleTimer = 0f;
            this.player.invisible = false;
            this.playerSprite.color = new Color(this.playerSprite.color.r, this.playerSprite.color.g, this.playerSprite.color.b, 255);
        }
    }
}
