using UnityEngine;

public class PassiveItem : Item
{
	public PassiveItem(string name = "", int id = 0, string description = "This item doesn't do much. It's just a paper weight.", int cost = 0) : base(name, id, description, cost)
    {
    }

    public virtual void ApplyBonus(Player p)
    {
    }

    public virtual void Effect()
    {
    }
}