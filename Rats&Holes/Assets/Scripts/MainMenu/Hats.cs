using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hats : MonoBehaviour
{

    [SerializeField]
    private HatUI hatBtnPrefab;

    [SerializeField]
    private Transform hatBtnsParent;

    private void Start()
    {
        Refresh();
        HatManager.OnHatUpdated += HatManager_OnHatUpdated;
    }

    private void OnDestroy()
    {
        HatManager.OnHatUpdated -= HatManager_OnHatUpdated;
    }

    private void HatManager_OnHatUpdated(Hat newHat)
    {
        Refresh();
    }

    private void Refresh()
    {
        if (hatBtnsParent != null)
        {
            if (hatBtnsParent.GetComponentsInChildren<HatUI>().Length > 0)
            {
                foreach (var item in hatBtnsParent.GetComponentsInChildren<HatUI>())
                {
                    Destroy(item.gameObject);
                }
            }
        }
        foreach (var item in HatManager.GetHats())
        {
            Instantiate(hatBtnPrefab, hatBtnsParent, true).Setup(item);
        }
    }

}