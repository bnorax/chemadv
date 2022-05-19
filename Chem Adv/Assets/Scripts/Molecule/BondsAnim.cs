using System;
using System.Collections.Generic;
using UnityEngine;

public class BondsAnim : MonoBehaviour
{
    [SerializeField] public List<GameObject> _bondsList;
    //[SerializeField] public GameObject _bonds;
    // [SerializeField] public GameObject _oneBond;
    // [SerializeField] public GameObject _twoBond;
    // [SerializeField] public GameObject _threeBond;
    // [SerializeField] public GameObject _fourBond;
    //
    private Atom atom;
    private int _childCount;

    private void Start()
    {
        atom = transform.parent.transform.parent.GetComponent<Atom>();
        _childCount = transform.childCount;
    }

    public void ChangeBond(bool add)
    {
        if (add)
        {
            if (atom._availableBonds > _childCount) return;
            foreach (var bond in _bondsList)
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
            if (atom._availableBonds > _childCount) return;
            foreach (var bond in _bondsList)
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
