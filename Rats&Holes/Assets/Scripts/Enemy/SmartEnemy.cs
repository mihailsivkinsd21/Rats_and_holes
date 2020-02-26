using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartEnemy : Enemy
{

    private EnemyDirection currDirection;

    private float nextDirectionChange;

    private void Start()
    {
        ChangeDirection();
        Setup(startHealth);
    }

    private void Update()
    {
        if(Time.time >= nextDirectionChange)
        {
            ChangeDirection();
        }
        Move();
    }

    private void ChangeDirection()
    {
        int r = Random.Range(0, 3);
        if (r == 0)
        {
            currDirection = EnemyDirection.none;
        }
        else if (r == 1)
        {
            currDirection = EnemyDirection.down;
        }
        else if (r == 2)
        {
            currDirection = EnemyDirection.up;
        }
        nextDirectionChange = Time.time + Random.Range(0.1f, 0.75f);
    }

    protected override void Move()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            base.Move();
            if (currDirection == EnemyDirection.none)
            {
                return;
            }
            else if (currDirection == EnemyDirection.up)
            {
                if (transform.position.y <= 3)
                {
                    transform.position = transform.position + transform.up * (Time.deltaTime * Speed);
                }
            }
            else if (currDirection == EnemyDirection.down)
            {
                if (transform.position.y >= -3)
                {
                    transform.position = transform.position + -transform.up * (Time.deltaTime * Speed);
                }
            }
        }
    }

}

enum EnemyDirection
{
    none,
    up,
    down
}