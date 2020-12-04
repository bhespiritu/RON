using UnityEngine;

public class Dash : SecondaryItem
{
    public float dashSpeed = 50f;
    public float dashTimer = 0f;
    public float dashDelay = 0.1f;
    public bool dashing = false;

    public Dash(Player p) : base(p, "Rocket Boots", 0, "These rockets you affix to your boots allow you to jump around with impressive speed.", 150)
    {
        this.coolDownAmount = 1f;
    }

    public override void Effect(bool click)
    {
        if (!dashing && click && this.canUse)
        {
            this.thingy.RightHit(this.coolDownAmount);
            this.canUse = false;
            this.dashing = true;
        } 
        else if (!dashing && !this.canUse)
        {
            base.CoolDown();
        }
        else if (!dashing)
        {
            return;
        }

        if (this.dashTimer < this.dashDelay && dashing)
        {
            this.dashTimer += Time.deltaTime;
            this.player.rb.velocity = (Vector2) (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.player.gameObject.transform.position).normalized * dashSpeed;
        }
        else
        {
            this.dashTimer = 0f;
            this.dashing = false;
        }
    }
}
