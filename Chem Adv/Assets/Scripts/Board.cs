using System;
using UnityEngine;

[ExecuteInEditMode]
public class Board : MonoBehaviour
{
    public static int sizeX = 20;
    public static int sizeY = 20;
    public BoardSegment[,] board = new BoardSegment[sizeX, sizeY];
    void Start()
    {
    }
}
