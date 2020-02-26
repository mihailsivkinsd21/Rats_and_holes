using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Enemy : MonoBehaviour
{

    public event EventHandler OnHealthChanged;

    public int health { get; private set; } = 1;

    [SerializeField]
    protected float Speed = 2f;

    [SerializeField]
    protected int startHealth = 1;

    public bool isDead { get; private set; }

    [SerializeField]
    private Drop dropPrefab;

    [SerializeField]
    private Drop rareHat;

    public void SetDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
        else
        {
            if (health - damage <= 0)
            {
                Death();
            }
            else
            {
                health -= damage;
            }
            if (OnHealthChanged != null) OnHealthChanged(this, EventArgs.Empty);
        }
    }

    protected virtual void Death()
    {
        Drop();
        DropHat();
        isDead = true;
        GetComponent<BoxCollider2D>().enabled = false;
        Destroy(this.gameObject, 10f);
    }

    private void Drop()
    {
        int i = 0;
       
        if (51 - (int)DifficultyManager.GetCurrentDifficulty() > 5)
        {
            i = UnityEngine.Random.Range(0, 101 - (int)DifficultyManager.GetCurrentDifficulty());
        }
        else
        {
            i = UnityEngine.Random.Range(0, 5);
        }    

        if (i == 0)
        {
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }

    private void DropHat()
    {
        int i = UnityEngine.Random.Range(0, 5000);
        if(i == 0)
        {
            Instantiate(rareHat, transform.position, Quaternion.identity);
        }
    }

    private void Start()
    {
        Setup(startHealth);
    }

    private void Update()
    {
        if (isDead)
        {
            return;
        }
        else
        {
            Move();
        }
    }

    protected virtual void Move()
    {
        if (transform.position.x > -15)
        {
            transform.position = transform.position + -transform.right * (Time.deltaTime * Speed);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    protected void Setup(int health)
    {
        Speed = Speed + DifficultyManager.GetCurrentDifficulty();
        //Speed = DifficultyManager.GetCurrentDifficulty();
        this.health = health;
    }

}