using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Player : MonoBehaviour
{

    public delegate void PlayerShooted(RaycastHit2D hit);
    public delegate void HealthChanged(bool isBad, int health);
    public delegate void DeadeyeStarted(bool started);

    public event HealthChanged OnHealthChanged;
    public event PlayerShooted OnPlayerShooted;
    public event DeadeyeStarted OnDeadeyeStart;

    public float deadeye { get; private set; } = 0;
    public float deadeyeTreashold { get; private set; } = 20;
    public int health { get; private set; } = 3;
    public int ratsKilled { get; private set; } = 0;
    public bool isDeadeye { get; private set; } = false;

    [SerializeField]
    private test game;

    [SerializeField]
    private float shootCooldown = 0.1f;

    private float nextShootTime;

    private bool godmode = false;

    private bool isCheats = true;

    public void SetDamage(int damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            if (!godmode)
            {
                health = 0;
            }
        }
        if (OnHealthChanged != null) OnHealthChanged(true, health);
    }

    public void Heal(int heal)
    {
        health += heal;
        if (OnHealthChanged != null) OnHealthChanged(false, health);
    }

    public void AddDeadeye(float amount)
    {
        if(deadeye + amount > 100)
        {
            deadeye = 100;
        }
        else
        {
            deadeye += amount;
        }
    }
    public void EnableDeadeye(bool b)
    {    
        if (b)
        {
            if (deadeye >= deadeyeTreashold)
            {
                shootCooldown = 0.02f;
                Time.timeScale = 0.2f;
                isDeadeye = true;
                if (OnDeadeyeStart != null) OnDeadeyeStart(b);
            }
        }
        else
        {
            shootCooldown = 0.1f;
            Time.timeScale = 1f;
            isDeadeye = false;
            if (OnDeadeyeStart != null) OnDeadeyeStart(b);
        }
    }

    private void Update()
    {
        PlayerInput();       
        if(isDeadeye)
        {
            if(deadeye > 0)
            {
                deadeye -= Time.deltaTime * 100;
            }
            else
            {
                deadeye = 0;
                EnableDeadeye(false);
            }
        }
    }

    private void PlayerInput()
    {
        //Deadeye
        if (Input.GetMouseButtonDown(1))
        {
            EnableDeadeye(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            EnableDeadeye(false);
        }

        //Shoot
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time >= nextShootTime)
            {
                Shoot();
            }
        }

        if (isCheats)
        {
            //Cheats
            if (Input.GetKeyDown(KeyCode.Z))
            {
                godmode = !godmode;
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                if (Time.timeScale < 16f)
                {
                    Time.timeScale = Time.timeScale + 4f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                AddDeadeye(100);
            }
        }
    }

    private void Shoot()
    {
        nextShootTime = Time.time + shootCooldown;
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.GetComponent<Enemy>())
            {
                Enemy hitEnemy = hit.transform.GetComponent<Enemy>();
                hitEnemy.SetDamage(1);
                if (hitEnemy.isDead)
                {
                    AddDeadeye(1.7f);
                    ratsKilled++;
                }
            }
            else if (hit.transform.GetComponent<Drop>())
            {
                hit.transform.GetComponent<Drop>().Take(this);
            }
        }
        if (OnPlayerShooted != null) OnPlayerShooted(hit);
    }

}