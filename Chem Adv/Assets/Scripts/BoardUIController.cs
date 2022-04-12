using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardUIController : MonoBehaviour
{
    [SerializeField] public Board _boardScript;
    [SerializeField] public GameObject _boardObject;
    [SerializeField] public Canvas _boardCanvas;
    private GameObject _wallPrefab;
    private GameObject _basePrefab;
    private GameObject _playerPrefab;

    private string level1 = "4_8" +
        "00W0W0W0W0W0W0W00" +
        "00000000000000000" +
        "00W00000W00000W00" +
        "00000-00000.00000" +
        "00W00000000000W00" +
        "00000000000000000" +
        "W0W0W0000000W0W0W" +
        "00000000000000000" +
        "W000N000000000O0W" +
        "00000000000000000" +
        "W0000000W0000000W" +
        "00000000000000000" +
        "W000H000W0O00000W" +
        "00000000000000000" +
        "W0W0W0W0W0W0W0W0W";    
    public void Awake()
    {
        _wallPrefab = Resources.Load("Board/Wall") as GameObject;
        _basePrefab = Resources.Load("Board/Base") as GameObject;
        //_playerPrefab = Resources.Load("Board/Wall") as GameObject;
    }

    public void Start()
    {
        for (int i = 0; i < 1000; i++)
        {
            var segment = Instantiate(_wallPrefab, _boardCanvas.transform);
           // segment.transform.SetParent(_boardCanvas.transform);
            segment.transform.localScale = Vector3.one;
            segment.transform.localRotation = Quaternion.Euler(Vector3.zero);
            segment.GetComponent<RectTransform>().anchoredPosition = new Vector2(i, i);
        }
}
}
