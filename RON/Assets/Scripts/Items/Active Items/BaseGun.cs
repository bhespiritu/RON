using UnityEngine;

public class BaseGun : ActiveItem
{
    public BaseGun(string name = "Base Gun") : base(10, false, name, 4)
    {
    }

    public override void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, direction);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                EnemyInfo enemy = hit.collider.gameObject.GetComponent<EnemyInfo>();
                enemy.Hurt(this.damage * damageMultiplier);
            }
        }
    }
}
