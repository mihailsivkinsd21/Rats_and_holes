using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public virtual void Take(Player player)
    {
        Destroy(this.gameObject);
    }

}