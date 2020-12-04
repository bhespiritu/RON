using System.Collections.Generic;
using UnityEngine;

public class Knockback : SecondaryItem
{
    public Knockback(Player p) : base(p, "Sonic Boom", 3, "This loud portable speaker creates unique sounds that are difficult to hear for humans, but create a large force that can knock your enemies back.", 150)
    {
        this.coolDownAmount = 3f;
    }

    public override void Effect(bool click)
    {
        if (this.canUse && click)
        {
            this.thingy.RightHit(this.coolDownAmount);
            Vector2 direction = (Vector2) (Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.player.gameObject.transform.position).normalized;

            RaycastHit2D[] collisions = Physics2D.BoxCastAll(this.player.transform.position, new Vector2(6, 12), 0f, direction, 10f);
            
            for (int i = 0; i < collisions.Length; i++)
            {
                RaycastHit2D collision = collisions[i];

                if (collision.collider.tag == "Enemy")
                {
                    collision.collider.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 25f;
                }
            }

            this.canUse = false;
        }
        else if (!this.canUse)
        {
            base.CoolDown();
        }
    }
}
