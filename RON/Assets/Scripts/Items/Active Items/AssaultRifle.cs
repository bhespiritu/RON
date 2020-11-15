﻿using UnityEngine;

public class AssaultRifle : ActiveItem
{
    public AssaultRifle() : base(20, true, "Assault Rifle", 3, "This modern gun fires at a rapid pace, dealing serious damage. It's also fully automatic. It will replace your current weapon.", 275)
    {
        this.accuracy = 0.85f;
    }
}