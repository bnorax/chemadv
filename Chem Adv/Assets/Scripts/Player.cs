using System;
using System.Collections.Generic;
using Doublsb.Dialog;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] public Molecule mainMolecule;
    [SerializeField] public Atom mainAtom;
    private List<Atom> _moleculesToMove;
    
    [SerializeField] public Board board;
   // private int _tempMovesMade;
    [SerializeField] public DialogManager dialogManager;
    [HideInInspector]
    public bool blockedInput;

    private void OnEnable()
    {
        _moleculesToMove?.Clear();
        mainMolecule._molecule.Clear();
        mainMolecule._molecule.Add(mainAtom);
    }

    private void Awake()
    {
        mainMolecule = GetComponent<Molecule>();
    }

    int VectorToInt(Vector2Int direction)
    {
        if (direction == Vector2Int.right) return 1;
        if (direction == Vector2Int.left) return -1;
        if (direction == Vector2Int.up) return -18;
        if (direction == Vector2Int.down) return 18;
        return 0;
    }

    void MoveMolecule(Vector2Int direction)
    { 
        _moleculesToMove= new List<Atom>(mainMolecule._molecule);
        var difPosition = VectorToInt(direction);
        
        for (var i = 0; i < _moleculesToMove.Count; i++)
        {
            var atomPosition = Array.IndexOf(board._boardList, _moleculesToMove[i].gameObject);
            
            if(!CheckNextAtomMove(atomPosition, difPosition)) return;
        }
        while(_moleculesToMove.Count != 0)
        {
            var atomPosition = Array.IndexOf(board._boardList, _moleculesToMove[0].gameObject);
            var nextPosition = atomPosition+difPosition;
            
            AvailableAtomMove(_moleculesToMove[0], atomPosition, nextPosition);
            //if (!AvailableMove(maxXAtom[i], 1)) return;
        }

        List<Atom> atomsToAddToMoleculeAfterCheck = new List<Atom>();
        for (var i = 0; i < mainMolecule._molecule.Count; i++)
        {
            var curAtom = mainMolecule._molecule[i];
            var atomPosition = Array.IndexOf(board._boardList, curAtom.gameObject);
            CheckAvailableBonds(curAtom, atomPosition, atomsToAddToMoleculeAfterCheck);
        }

        foreach (var atom in atomsToAddToMoleculeAfterCheck)
        {
            mainMolecule._molecule.Add(atom);
        }
    }

    bool CheckNextAtomMove(int atomPosition, int difPosition)
    {
        BoardSegment nextPosSegment = board._boardList[atomPosition+difPosition].GetComponent<BoardSegment>();

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

    void CheckAvailableBonds(Atom curAtom, int atomPosition, List<Atom> atomsToAddToMoleculeAfterCheck)
    {
        if(mainMolecule._molecule.Contains(curAtom)) 
            CheckNearAtomsForAvailableBond(curAtom, atomPosition, atomsToAddToMoleculeAfterCheck);
    }
    
    void AvailableAtomMove(Atom curAtom, int atomPosition, int nextPosition)
    {
        if (_moleculesToMove.Count == 0) return;
        BoardSegment nextPosSegment = board._boardList[nextPosition].GetComponent<BoardSegment>();

        if (nextPosSegment.Type == BoardSegment.BoardSegmentType.Available)
        {
            MoveAtom(atomPosition, nextPosition);
            _moleculesToMove.Remove(board._boardList[nextPosition].GetComponent<Atom>());
        }
        else if (nextPosSegment.Type == BoardSegment.BoardSegmentType.AtomNode)
        {
            var nextAtom = board._boardList[nextPosition].GetComponent<Atom>();
            
            AvailableAtomMove(nextAtom, atomPosition + (nextPosition - atomPosition),
                nextPosition + (nextPosition - atomPosition));
        }
        else
        {
            _moleculesToMove.Remove(board._boardList[nextPosition].GetComponent<Atom>());
        }
    }

    void CheckNearAtomsForAvailableBond(Atom curAtom, int atomPosition, List<Atom> atomsToAddToMoleculeAfterCheck)
    {
        List<Atom> closeAtoms = new List<Atom>();
        
        var up = board._boardList[atomPosition - 18].GetComponent<Atom>();
        if(up) closeAtoms.Add(up);
        var down = board._boardList[atomPosition + 18].GetComponent<Atom>();
        if(down) closeAtoms.Add(down);
        var left = board._boardList[atomPosition - 1].GetComponent<Atom>();
        if(left) closeAtoms.Add(left);
        var right = board._boardList[atomPosition + 1].GetComponent<Atom>();
        if(right) closeAtoms.Add(right);

        var curBondAnim = curAtom.GetComponentInChildren<BondsAnim>();
        
        foreach (var closeAtom in closeAtoms)
        {
            if (closeAtom._availableBonds > 0
                && curAtom._availableBonds > 0
                && !mainMolecule._molecule.Contains(closeAtom))
            {
                var closeBondAnim = closeAtom.GetComponentInChildren<BondsAnim>();
                curBondAnim.ChangeBond(false);
                closeBondAnim.ChangeBond(false);
                closeAtom._availableBonds--;
                curAtom._availableBonds--;
                if(!atomsToAddToMoleculeAfterCheck.Contains(closeAtom)) atomsToAddToMoleculeAfterCheck.Add(closeAtom);
            }
        }
    }

    void MoveAtom(int atomPosition, int nextPosition)
    {
        var transform1 = board._boardList[atomPosition].transform;
        var transformNext = board._boardList[nextPosition].transform;
        (transform1.position, transformNext.position) = (
            transformNext.position, transform1.position);
            
        (board._boardList[atomPosition], board._boardList[nextPosition]) = (
            board._boardList[nextPosition], board._boardList[atomPosition]);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            
        }
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // }
    }

    private void Update()
    {
        if(!blockedInput) InputUpdate();
    }
}
