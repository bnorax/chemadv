using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{

    public AtomType _atom; 
    private int _posX, _posY;

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
