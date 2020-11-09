using UnityEngine;

public class SlowGun : ActiveItem
{
    public float slowAmount;

    public SlowGun() : base(6, false, "Freezeray", 0, "This does extra damage but builds up copious amounts of ice. The ice will slow you down but also make you more damage resistent. The ice slowly melts.", 75)
    {
        this.slowAmount = 0.99f;
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
                enemy.attackSpeed *= .92f;
            }
        }
    }
}
