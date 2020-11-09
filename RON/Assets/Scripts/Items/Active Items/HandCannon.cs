using UnityEngine;

public class HandCannon : ActiveItem
{
    public HandCannon() : base(25, false, "Handcannon", 2, "In our modern world, with all of its fancies, sometimes its nice to just have a portable cannon. It replaces your current weapon.", 175)
    {
        this.projectileSpeed = 50f;
    }
}
