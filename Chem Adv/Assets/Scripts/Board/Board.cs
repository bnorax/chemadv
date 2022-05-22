using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Board : MonoBehaviour
{
    [SerializeField] public BoardUIController uiController;
    private int sizeX;
    private int sizeY;
    public GameObject[] boardList;
    private GridLayoutGroup _gridLayout;
    void Start()
    {
        _gridLayout = uiController.boardCanvas.GetComponent<GridLayoutGroup>();
        var canvasTransform = uiController.boardCanvas.transform;
        var childCount = canvasTransform.childCount;
        boardList = new GameObject[childCount];
        for (var i = 0; i < childCount; i++)
        {
            boardList[i] = canvasTransform.GetChild(i).gameObject;
        }

        Vector2Int gridSize = _gridLayout.Size();
    }
}
