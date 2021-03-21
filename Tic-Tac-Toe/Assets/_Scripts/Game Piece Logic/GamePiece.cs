using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private string _id { get; set; }
    private int _size { get;set; }
    private bool _isPlayer1 { get; set; }
    private bool _isInPlay { get; set; } = false;

    public void SetId(string id)
    {
        _id = id;
    }

    public void SetSize(int size) 
    {
        _size = size;
    }

    public void SetIsPlayer1(bool isPlayer1)
    {
        _isPlayer1 = isPlayer1;
    }

    public void SetIsInPlaye(bool isInPlay)
    {
        _isInPlay = isInPlay;
    }

    public string GetId()
    {
        return _id;
    }

    public int GetSize()
    {
        return _size;
    }

    public bool GetIsPlayer1()
    {
        return _isPlayer1;
    }

    public bool GetIsInPlay()
    {
        return _isInPlay;
    }

    private void OnMouseDown()
    {
        Debug.Log("Is In Play: " + _isInPlay);
        Debug.Log("Size: " + _size);
        Debug.Log("Is Player 1: " + _isPlayer1);
        var gameManager = GameManager.Instance;
        gameManager.OutlinePiece(gameObject);
    }
}
