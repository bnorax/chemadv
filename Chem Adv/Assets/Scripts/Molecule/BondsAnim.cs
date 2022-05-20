using System;
using System.Collections.Generic;
using UnityEngine;

public class BondsAnim : MonoBehaviour
{
    [SerializeField] public List<GameObject> bondsList;

    private Atom _atom;
    private int _childCount;

    private void Start()
    {
        _atom = transform.parent.transform.parent.GetComponent<Atom>();
        _childCount = transform.childCount;
    }

    public void ChangeBond(bool add)
    {
        if (add)
        {
            if (_atom._availableBonds > _childCount) return;
            foreach (var bond in bondsList)
            {
                if (!bond.activeSelf)
                {
                    bond.SetActive(true);
                    return;
                }
            }
        }
        else
        {
            if (_atom._availableBonds > _childCount) return;
            foreach (var bond in bondsList)
            {
                if (bond.activeSelf)
                {
                    bond.SetActive(false);
                    return;
                }
            }
        }
    }
    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, 60*Time.deltaTime);
    }
}
