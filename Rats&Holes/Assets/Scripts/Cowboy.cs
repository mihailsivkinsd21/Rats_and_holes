using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Cowboy : MonoBehaviour
{

    [SerializeField]
    private SpriteRenderer hatSprite;

    [SerializeField]
    private Transform arm;

    [SerializeField]
    private GameObject muzzleFlash;

    private float timer;

    private bool isFacingRight = true;

    public void EquipHat(Hat hat)
    {
        if (hat != null)
        {
            hatSprite.sprite = hat.sprite;
        }
    }

    public void Shoot()
    {
        muzzleFlash.SetActive(true);
        timer = Time.time + 0.1f;
    }

    private void Start()
    {
        EquipHat(HatManager.GetCurrentHat());
        HatManager.OnHatUpdated += HatManager_OnHatUpdated;
    }

    private void OnDestroy()
    {
        HatManager.OnHatUpdated -= HatManager_OnHatUpdated;
    }

    private void HatManager_OnHatUpdated(Hat newHat)
    {
        EquipHat(newHat);
    }

    private void Update()
    {
        var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        if(direction.x > 0)
        {
            TurnRight(true);
        }
        else
        {
            TurnRight(false);
        }

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (isFacingRight)
        {
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        else
        {
            angle = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        }

        arm.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Time.time >= timer)
        {
            muzzleFlash.SetActive(false);
        }
    }

    private void TurnRight(bool b)
    {
        if(!isFacingRight == b)
        {
            if(b == true)
            {
                transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                isFacingRight = true;
            }
            else
            {
                transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                isFacingRight = false;
            }
        }
    }

}