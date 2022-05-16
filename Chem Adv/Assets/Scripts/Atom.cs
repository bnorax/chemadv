using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class Atom : MonoBehaviour
{

    private BoardUIController _uiController;
    public AtomType _atom; 
    public int _availableBonds;
    public int _posX, _posY;

    
    private void Awake()
    {
        _uiController = transform.parent.transform.parent.gameObject.GetComponent<BoardUIController>();
    }

    private void Start()
    {
        _availableBonds = (int)Type+1;
    }

    public void OnValidate()
    {
        if (_uiController == null) return;
        if (gameObject.transform.childCount > 0)
        {
            UnityEditor.EditorApplication.delayCall += () =>
            {
                // Transform transformToDelete = gameObject;
                if (this == null) return;
                DestroyImmediate(gameObject.transform.GetChild(0).gameObject);
            };
        }

        GameObject obj;
        switch (Type)
        {
            case AtomType.Hydrogen:
                obj = _uiController.hydrogenPrefab;
                break;
            case AtomType.Oxygen:
                obj = _uiController.oxygenPrefab;
                break;
            case AtomType.Nitrogen:
                obj = _uiController.nitrogenPrefab;
                break;
            case AtomType.Carbon:
                obj = _uiController.carbonPrefab;
                break;
            default:
                obj = _uiController.hydrogenPrefab;
                break;

        }

        UnityEditor.EditorApplication.delayCall += () =>
        {
            if (this == null) return;
            GameObject newObject = Instantiate(obj, gameObject.transform);
        };
    }

    Atom(int x = 5, int y = 5, AtomType atom = AtomType.Hydrogen)
    { 
        _posX = x;
        _posY = y; 
        _atom = atom;
    }
    public AtomType Type
    {
        get => _atom;
        set => _atom = value;
    }

    public enum AtomType
    {
        Hydrogen,
        Oxygen,
        Nitrogen,
        Carbon,
        Helium,
    }
}
