using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BoardSegment : MonoBehaviour
{
    private int _x = 0, _y = 0;//position on board
    [SerializeField] BoardSegmentType _type = BoardSegmentType.Unavailable;

    private BoardUIController _uiController;
    private void Start()
    {
        _uiController = transform.parent.transform.parent.gameObject.GetComponent<BoardUIController>();
    }
    
    #if UNITY_EDITOR
    private void OnValidate()
    {
        if (_uiController == null) return;
        GameObject obj;
        switch (Type)
        {
            case BoardSegmentType.Wall:
                obj = _uiController._wallPrefab;
                break;
            case BoardSegmentType.Available:
                obj = _uiController._basePrefab;
                break;
            case BoardSegmentType.AtomNode:
                Atom atomComponent;
                if (!TryGetComponent(out atomComponent))
                    UnityEditor.EditorApplication.delayCall+=()=>
                    {
                        atomComponent = gameObject.AddComponent<Atom>();
                    };
                //gameObject.GetComponent<Image>().enabled = false;
                return;
            default:
                obj = _uiController._basePrefab;
                break;
        }

        //gameObject = obj;
        Image image = GetComponent<Image>();
        if(image.isActiveAndEnabled) image.color = obj.GetComponent<Image>().color;
        PrefabUtility.RecordPrefabInstancePropertyModifications(image);
    }
    #endif

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

    public enum BoardSegmentType
    {
        Unavailable,
        Available,
        Wall,
        AtomNode,
        BondPlus,
        BondMinus,
        Rotate
    }
}
