using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardUIController : MonoBehaviour
{
    [SerializeField] public Board boardScript;
    [SerializeField] public GameObject boardObject;
    [SerializeField] public Canvas boardCanvas;
    [SerializeField] public GameObject wallPrefab;
    [SerializeField] public GameObject basePrefab;
    
    [SerializeField] public GameObject hydrogenPrefab;
    [SerializeField] public GameObject oxygenPrefab;
    [SerializeField] public GameObject nitrogenPrefab;
    [SerializeField] public GameObject carbonPrefab;
    [SerializeField] public GameObject heliumPrefab;

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