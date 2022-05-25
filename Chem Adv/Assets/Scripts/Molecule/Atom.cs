using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class Atom : MonoBehaviour
{

    private BoardUIController _uiController;
    public AtomType _atom; 
    public int _availableBonds;


    private void Awake()
    {
        _uiController = transform.parent.transform.parent.gameObject.GetComponent<BoardUIController>();
    }

    private void Start()
    {
        _availableBonds = (int)Type+1;
    }
    
    
    #if UNITY_EDITOR
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
                _availableBonds = 1;
                break;
            case AtomType.Oxygen:
                obj = _uiController.oxygenPrefab;
                _availableBonds = 2;
                break;
            case AtomType.Nitrogen:
                obj = _uiController.nitrogenPrefab;
                _availableBonds = 3;
                break;
            case AtomType.Carbon:
                obj = _uiController.carbonPrefab;
                _availableBonds = 4;
                break;
            default:
                obj = _uiController.hydrogenPrefab;
                _availableBonds = 1;
                break;

        }

        UnityEditor.EditorApplication.delayCall += () =>
        {
            if (this == null) return;
            GameObject newObject = Instantiate(obj, gameObject.transform);
        };
    }
    #endif

    Atom(AtomType atom = AtomType.Hydrogen)
    {
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
