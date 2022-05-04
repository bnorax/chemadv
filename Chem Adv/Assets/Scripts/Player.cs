using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Molecule _mainMolecule;

    private void Awake()
    {
        _mainMolecule = GetComponent<Molecule>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            
        }
    }
}
