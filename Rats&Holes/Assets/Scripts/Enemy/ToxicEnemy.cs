using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicEnemy : Enemy
{

    public event EventHandler OnExplode;

    private void Start()
    {
        Setup(startHealth);
    }

    protected override void Death()
    {
        base.Death();
        Explosion();
    }

    private void Explosion()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 1.75f, Vector2.zero);
        foreach (var item in hits)
        {
            Enemy target = item.transform.GetComponent<Enemy>();
            if(target != null && target != this && !target.isDead)
            {
                target.SetDamage(1);
            }
        }
        if (OnExplode != null) OnExplode(this, EventArgs.Empty);
    }

}