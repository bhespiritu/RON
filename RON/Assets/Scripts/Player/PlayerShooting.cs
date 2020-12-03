using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public Player player;

    public GameObject[] projectiles;

    private GameObject getProjectile(int id)
    {
        switch(id)
        {
            case 4:
                return projectiles[1];
            case 0:
                return projectiles[0];
            case 1:
                return projectiles[1];
            case 2:
                return projectiles[2];
            case 3:
                return projectiles[1];
        }
        return null;
    }

    private void Start()
    {
        player = GetComponent<Player>();
    }


    public void Shoot(ActiveItem weapon, Vector2 direction)
    {
        direction = Vector3.Slerp(Random.onUnitSphere, direction, weapon.accuracy);

        player.muzzleFlash.transform.right = direction;
        player.muzzleFlash.Replay();

        float crit = Random.value;
        var bullet = Instantiate(getProjectile(weapon.id), (player.firePos.position + (Vector3)direction), Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * weapon.projectileSpeed;
        bullet.GetComponent<PlayerBullet>().damage = (int)(weapon.damage * player.damageMultiplier * (crit < player.critChance ? 3 : 1));
        bullet.GetComponent<PlayerBullet>().effect = weapon.effect;
        if (crit < player.critChance)
        {
            bullet.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if(weapon.id == 2)//hand cannon special behaviour
        {
            player.rb.AddForce(-direction * 1000);
        }
        if (weapon.id == 0)
        {
            player.speed *= 0.85f;
            player.activeItems[0].damage = (int) (player.activeItems[0].damage * 1.25);
        }
        
    }
}
