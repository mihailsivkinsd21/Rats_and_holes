using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{

    [SerializeField]
    private Player player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            if (!collision.GetComponent<Enemy>().isDead)
            {
                Destroy(collision.gameObject);
                player.SetDamage(1);
            }
        }
    }

}