using System;
using System.Collections.Generic;
using UnityEngine;

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
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject atom = _mainAtom.gameObject;
            var playerPosition = Array.IndexOf(_board._boardList, atom);
            if (playerPosition + 1 > _board._boardList.Length) return;
            if (_board._boardList[playerPosition + 1].GetComponent<BoardSegment>().Type !=
                BoardSegment.BoardSegmentType.Wall)
            {
                (atom.transform.position, _board._boardList[playerPosition + 1].transform.position) = (_board._boardList[playerPosition + 1].transform.position, atom.transform.position);
                (_board._boardList[playerPosition], _board._boardList[playerPosition + 1]) = (_board._boardList[playerPosition + 1], _board._boardList[playerPosition]);
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject atom = _mainAtom.gameObject;
            var playerPosition = Array.IndexOf(_board._boardList, atom);
            if (playerPosition - 1 < 0) return;
            if (_board._boardList[playerPosition - 1].GetComponent<BoardSegment>().Type !=
                BoardSegment.BoardSegmentType.Wall)
            {
                (atom.transform.position, _board._boardList[playerPosition - 1].transform.position) = (_board._boardList[playerPosition - 1].transform.position, atom.transform.position);
                (_board._boardList[playerPosition], _board._boardList[playerPosition - 1]) = (_board._boardList[playerPosition - 1], _board._boardList[playerPosition]);
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            GameObject atom = _mainAtom.gameObject;
            var playerPosition = Array.IndexOf(_board._boardList, atom);
            if (playerPosition - 18 < 0) return;
            if (_board._boardList[playerPosition - 18].GetComponent<BoardSegment>().Type !=
                BoardSegment.BoardSegmentType.Wall)
            {
                (atom.transform.position, _board._boardList[playerPosition - 18].transform.position) = (_board._boardList[playerPosition - 18].transform.position, atom.transform.position);
                (_board._boardList[playerPosition], _board._boardList[playerPosition - 18]) = (_board._boardList[playerPosition - 18], _board._boardList[playerPosition]);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject atom = _mainAtom.gameObject;
            var playerPosition = Array.IndexOf(_board._boardList, atom);
            if (playerPosition + 18 > _board._boardList.Length) return;
            if (_board._boardList[playerPosition + 18].GetComponent<BoardSegment>().Type !=
                BoardSegment.BoardSegmentType.Wall)
            {
                (atom.transform.position, _board._boardList[playerPosition + 18].transform.position) = (_board._boardList[playerPosition + 18].transform.position, atom.transform.position);
                (_board._boardList[playerPosition], _board._boardList[playerPosition + 18]) = (_board._boardList[playerPosition + 18], _board._boardList[playerPosition]);
            }
        }
    }
}
