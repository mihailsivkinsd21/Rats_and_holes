using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousetrap : PlaceableObject
{

    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private bool destroy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if(collision.GetComponent<Enemy>().isDead)
            { 
                return;
            }
            else
            {
                collision.GetComponent<Enemy>().SetDamage(damage);
                if (destroy)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}