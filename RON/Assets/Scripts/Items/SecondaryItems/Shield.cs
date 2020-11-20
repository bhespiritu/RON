using UnityEngine;

public class Shield : SecondaryItem
{
    public float shieldTimer = 0f;
    public float shieldDelay = 1f;
    public bool shieldUp = false;

    public Shield(Player p) : base(p, "Air Shield", 1, "This portable shield generator compresses the air around you and electrifies it, blocking all incoming projectiles for a short moment.", 300)
    {
        this.coolDownAmount = 1f;
    }

    public override void Effect(bool click)
    {
        if (!shieldUp && click && this.canUse)
        {
            this.canUse = false;
            this.shieldUp = true;
            this.player.shield.SetActive(true);
            Vector3 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.player.gameObject.transform.position).normalized;
            this.player.shield.transform.up = (Vector2) direction;
            this.player.shield.transform.position += new Vector3(2 * direction.x, 2 * direction.y, 0);
            this.player.canShoot = false;
        }
        else if (!shieldUp && !this.canUse)
        {
            base.CoolDown();
        }
        else if (!shieldUp)
        {
            return;
        }

        if (this.shieldTimer < this.shieldDelay && shieldUp)
        {
            this.shieldTimer += Time.deltaTime;
        }
        else
        {
            this.shieldTimer = 0f;
            this.shieldUp = false;
            this.player.shield.SetActive(false);
            this.player.shield.gameObject.transform.position = this.player.transform.position;
            this.player.canShoot = true;
        }
    }
}
