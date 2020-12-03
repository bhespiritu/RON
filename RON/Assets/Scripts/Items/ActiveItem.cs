using System;
using UnityEngine;

public class ActiveItem : Item
{

	public int damage;
    public bool autofire;
    public float projectileSpeed = 100f;
    public float accuracy = 1f;
    public string effect = "";
    public float autofireAmount = 0;
    public float pitchVariance = 0f;

	public ActiveItem(int damage, bool autofire = false, string name = "", int id = 0, string description = "This simple gun takes basic ammo.", int cost = 1) : base(name, id, description, cost)
	{
        this.damage = damage;
        this.autofire = autofire;
	}

    public virtual void Fire(Vector3 position, Vector2 direction, float damageMultiplier)
    {
    }
}
