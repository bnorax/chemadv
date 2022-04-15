using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUIController : MonoBehaviour
{
    [SerializeField] public Board _boardScript;
    [SerializeField] public GameObject _boardObject;
    [SerializeField] public Canvas _boardCanvas;
    [SerializeField] public GameObject _wallPrefab;
    [SerializeField] public GameObject _basePrefab;
    [SerializeField] public GameObject _playerPrefab;

    public void ReloadSegmentUI(BoardSegment segment)
    {
        
    }

    public void Update()
    {

        //     for (var i = 0; i < _boardCanvas.transform.childCount; i++)
        //     {
        //         GameObject boardChild = _boardCanvas.transform.GetChild(i).gameObject; 
        //         //Debug.Log(boardChild.name);
        //         BoardSegment segment = boardChild.GetComponent<BoardSegment>();
        //         if(segment == null) continue;
        //         GameObject obj;
        //         switch (segment.Type)
        //         {
        //             case BoardSegment.BoardSegmentType.Wall:
        //                 obj =_wallPrefab;
        //                 break;
        //             case BoardSegment.BoardSegmentType.Available:
        //                 obj = _basePrefab;
        //                 break;
        //             default:
        //                 obj = _basePrefab;
        //                 break;
        //         }
        //
        //         Image image = boardChild.GetComponent<Image>();
        //         image.color = obj.GetComponent<Image>().color;
        //     }
        // }
    }
}