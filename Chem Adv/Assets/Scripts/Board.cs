using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int sizeX = 20;
    public static int sizeY = 20;
    private BoardSegment[,] board = new BoardSegment[sizeX, sizeY];
    void Start()
    {
        for (var i = 0; i < sizeX; i++)
        {
            for (var j = 0; j < sizeY; j++)
            {
                board[i, j] = new BoardSegment(i , j, BoardSegmentType.Unavailable);
            }
        }
        
        board[2, 2].Type = BoardSegmentType.Wall;
    }
}

class BoardSegment
{
    private int _x = 0, _y = 0; //position on board
    private BoardSegmentType _type = BoardSegmentType.Unavailable;

    public BoardSegment(int posX, int posY, BoardSegmentType type)
    {
        _x = posX;
        _y = posY;
        _type = type;
    }
    public int X
    {
        get => _x;
        set => _x = value;
    }

    public int Y
    {
        get => _y;
        set => _y = value;
    }
    public BoardSegmentType Type
    {
        get => _type;
        set => _type = value;
    }
}

enum BoardSegmentType
{
    Unavailable,
    Available,
    Wall,
    BondPlus,
    BondMinus,
    Rotate
}
