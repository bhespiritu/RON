using UnityEngine;

public class SecondaryItem : Item
{
    public Player player;
    public bool canUse = true;
    public float coolDownAmount = 0f;
    public float coolDownTimer = 0f;
    public ItemUI thingy = GameObject.Find("ActiveImage").GetComponent<ItemUI>();


    public SecondaryItem(Player p, string name = "", int id = 0, string description = "This item doesn't do much. It's just a paper weight.", int cost = 0) : base(name, id, description, cost)
    {
        this.player = p;
    }

    public virtual void Effect(bool click)
    {
        
    }

    public void CoolDown()
    {
        if (this.coolDownTimer < this.coolDownAmount)
        {
            this.coolDownTimer += Time.deltaTime;
        } 
        else
        {
            this.coolDownTimer = 0f;
            this.canUse = true;
        }

    }
}