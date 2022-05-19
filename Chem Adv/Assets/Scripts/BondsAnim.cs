using System;
using System.Collections.Generic;
using UnityEngine;

public class BondsAnim : MonoBehaviour
{
    //[SerializeField] public List<GameObject> _bondsLsit;

    private void Start()
    {
        
    }

    private void Update()
    {
        transform.RotateAround(transform.position, Vector3.forward, 60*Time.deltaTime);
    }
}
