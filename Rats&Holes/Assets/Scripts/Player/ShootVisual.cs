using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootVisual : MonoBehaviour
{

    [SerializeField]
    private LineRenderer line;

    public void Setup(Vector3 firstPos, Vector3 secondPos)
    {
        line.SetPosition(0, firstPos);
        line.SetPosition(1, secondPos);
        Destroy(this.gameObject, 1f);
    }

    private void Update()
    {
        line.startColor = new Color(line.startColor.r, line.startColor.g, line.startColor.b, line.startColor.a - 4f * Time.deltaTime);
        line.endColor = new Color(line.endColor.r, line.endColor.g, line.endColor.b, line.endColor.a - 4f * Time.deltaTime);
    }

}