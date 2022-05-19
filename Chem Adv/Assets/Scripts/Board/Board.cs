using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Board : MonoBehaviour
{
    [SerializeField] private BoardUIController _uiController;
    private int sizeX;
    private int sizeY;
    public GameObject[] _boardList;
    private GridLayoutGroup _gridLayout;
    void Start()
    {
        _gridLayout = _uiController._boardCanvas.GetComponent<GridLayoutGroup>();
        var canvasTransform = _uiController._boardCanvas.transform;
        var childCount = canvasTransform.childCount;
        _boardList = new GameObject[childCount];
        for (var i = 0; i < childCount; i++)
        {
            _boardList[i] = canvasTransform.GetChild(i).gameObject;
        }

        Vector2Int gridSize = _gridLayout.Size();
    }
}
