using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Player : MonoBehaviour
{
    [SerializeField] private Molecule _mainMolecule;
    [SerializeField] private Atom _mainAtom;
    [SerializeField] private Board _board;

    private void Awake()
    {
        _mainMolecule = GetComponent<Molecule>();
    }

    private void Start()
    {
        _mainMolecule._molecule.Add(_mainAtom);
        _mainMolecule._molecule.Add(_mainAtom);
    }

    void MoveMolecule(Vector2Int direction)
    {
        var moleculeSize = _mainMolecule._molecule.Count;
        var molecule = _mainMolecule._molecule;
        if (direction == Vector2Int.right)
        {
            var maxXAtom = molecule.Where(a => a.transform.position.x == molecule.Max(a=>a.transform.position.x)).ToList();
            for (var i = 0; i < maxXAtom.Count; i++)
            {
                if (!AvailableMove(maxXAtom[i], 1)) return;

            }
        }
        if (direction == Vector2Int.left)
        {
            
        }
        if (direction == Vector2Int.up)
        {
            
        }
        if (direction == Vector2Int.down)
        {
            
        }
        //var maxXAtom = molecule.Where(a => a.transform.position.x == molecule.Max(a=>a.transform.position.x)).ToList();
        var xMax = molecule.Max(atom => atom.transform.position.x);
        var yMax = molecule.Max(atom => atom.transform.position.y);
        var xMin = molecule.Min(atom => atom.transform.position.x);
        var yMin = molecule.Min(atom => atom.transform.position.y);
        
        for (var i = 0; i < moleculeSize; i++)
        {
        }
    }

    bool AvailableMove(Atom atom, int difPosition)
    {
        
        var playerPosition = Array.IndexOf(_board._boardList, atom.gameObject);
        var nextPosition = playerPosition + difPosition;
        BoardSegment nextPosSegment = _board._boardList[nextPosition].GetComponent<BoardSegment>();
        if (nextPosSegment.Type == BoardSegment.BoardSegmentType.Available)
        {
            var transform1 = transform;
            (transform1.position, _board._boardList[nextPosition].transform.position) = (
                _board._boardList[nextPosition].transform.position, transform1.position);
            (_board._boardList[playerPosition], _board._boardList[nextPosition]) = (
                _board._boardList[nextPosition], _board._boardList[playerPosition]);
            return true;
        }

        return false;
        // if (nextPosSegment.Type == BoardSegment.BoardSegmentType.AtomNode)
        // {
        //     if (atom._availableBonds > 0)
        //     {
        //         atom._availableBonds--;
        //         _mainMolecule._molecule.Add(_board._boardList[nextPosition].GetComponent<Atom>());
        //     }
        // }
    }
    
    void InputUpdate()
    {
        GameObject atom = _mainAtom.gameObject;
        var playerPosition = Array.IndexOf(_board._boardList, atom);
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveMolecule(new Vector2Int(1, 0));
            //AvailableSegmentMove(1);
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (var moleculeAtom in _mainMolecule._molecule)
            {
                //AvailableSegmentMove(moleculeAtom, -1);   
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            foreach (var moleculeAtom in _mainMolecule._molecule)
            {
               // AvailableSegmentMove(moleculeAtom, 18);   
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            foreach (var moleculeAtom in _mainMolecule._molecule)
            {
               // AvailableSegmentMove(moleculeAtom, -18);   
            }
        }
    }

    private void Update()
    {
        if(Input.anyKeyDown) InputUpdate();
    }
}
