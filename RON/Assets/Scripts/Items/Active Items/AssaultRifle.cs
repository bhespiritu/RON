using UnityEngine;

public class AssaultRifle : ActiveItem
{
    public AssaultRifle() : base(20, true, "Assault Rifle", 3, "This modern gun fires at a rapid pace, dealing serious damage.", 275)
    {
        this.accuracy = 0.95f;
        this.autofireAmount = 0.09f;
    }
}
