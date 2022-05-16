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
    private int tempMovesMade;
    private void Awake()
    {
        _mainMolecule = GetComponent<Molecule>();
    }

    private void Start()
    {
    }

    void MoveMolecule(Vector2Int direction)
    {
        var moleculesToMove= new List<Atom>(_mainMolecule._molecule);
        var moleculesToMoveSize = moleculesToMove.Count;
        for (var i = 0; i < moleculesToMove.Count; i++)
        {
            var atomPosition = Array.IndexOf(_board._boardList, moleculesToMove[i].gameObject);
            var difPosition = 0;
            if (direction == Vector2Int.right) difPosition = 1;
            else if (direction == Vector2Int.left) difPosition = -1;
            else if (direction == Vector2Int.up) difPosition = -18;
            else if (direction == Vector2Int.down) difPosition = 18;
            var nextPosition = atomPosition + difPosition;
            if(!CheckNextAtomMove(atomPosition, difPosition)) return;
        }
        while(moleculesToMove.Count != 0)
        {
            var atomPosition = Array.IndexOf(_board._boardList, moleculesToMove[0].gameObject);
            var nextPosition = atomPosition;
            if (direction == Vector2Int.right) nextPosition += 1;
            else if (direction == Vector2Int.left) nextPosition -= 1;
            else if (direction == Vector2Int.up) nextPosition -= 18;
            else if (direction == Vector2Int.down) nextPosition += 18;
            AvailableAtomMove(moleculesToMove, moleculesToMove[0], atomPosition, nextPosition);
            //if (!AvailableMove(maxXAtom[i], 1)) return;
        }
    }

    bool CheckNextAtomMove(int atomPosition, int difPosition)
    {
        BoardSegment nextPosSegment = _board._boardList[atomPosition+difPosition].GetComponent<BoardSegment>();

        if (nextPosSegment.Type == BoardSegment.BoardSegmentType.Available)
        {
            return true;
        }
        if (nextPosSegment.Type == BoardSegment.BoardSegmentType.AtomNode)
        {
            if (!CheckNextAtomMove(atomPosition + difPosition, difPosition)) return false;
            return true;
        }
        if (nextPosSegment.Type == BoardSegment.BoardSegmentType.Wall)
        {
            return false;
        }

        return false;
    }
    
    void AvailableAtomMove(List<Atom> moleculesToMove, Atom curAtom, int atomPosition, int nextPosition)
    {
        if (moleculesToMove.Count == 0) return;
        BoardSegment nextPosSegment = _board._boardList[nextPosition].GetComponent<BoardSegment>();

        if (nextPosSegment.Type == BoardSegment.BoardSegmentType.Available)
        {
            MoveAtom(atomPosition, nextPosition);
            moleculesToMove.Remove(_board._boardList[nextPosition].GetComponent<Atom>());
        }
        else if (nextPosSegment.Type == BoardSegment.BoardSegmentType.AtomNode)
        {
            AvailableAtomMove(moleculesToMove, _board._boardList[nextPosition].GetComponent<Atom>(), atomPosition+(nextPosition-atomPosition), nextPosition+(nextPosition-atomPosition));
        }
        else
        {
            moleculesToMove.Remove(_board._boardList[nextPosition].GetComponent<Atom>());
            return;
        }
       // moleculesToMove.Remove(_board._boardList[nextPosition].GetComponent<Atom>());
        ///ВАЖНО: копия _молекула и удалить оттуда при муве
    }

    void MoveAtom(int atomPosition, int nextPosition)
    {
        var transform1 = _board._boardList[atomPosition].transform;
        var transformNext = _board._boardList[nextPosition].transform;
        (transform1.position, transformNext.position) = (
            transformNext.position, transform1.position);
            
        (_board._boardList[atomPosition], _board._boardList[nextPosition]) = (
            _board._boardList[nextPosition], _board._boardList[atomPosition]);
    }
        
    
    void InputUpdate()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveMolecule(Vector2Int.right);
            return;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveMolecule(Vector2Int.left);
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveMolecule(Vector2Int.down);
            return;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveMolecule(Vector2Int.up);
        }
    }

    private void Update()
    {
        if(Input.anyKeyDown) InputUpdate();
    }
}
