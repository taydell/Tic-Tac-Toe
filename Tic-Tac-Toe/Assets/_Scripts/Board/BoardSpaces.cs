using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpaces : MonoBehaviour
{
    [SerializeField]
    int _row, _column;

    BoardManager _boardManager;
    GamePieceManager _gamePieceManager;

    private void Start()
    {
       var _gameManager = GameManager.Instance;
        _boardManager = _gameManager.GetComponent<BoardManager>();
        _gamePieceManager = _gameManager.GetComponent<GamePieceManager>();
    }

    private void OnMouseOver()
    {
        _boardManager.OutlineBoardSpaceOnEnter(gameObject,_row,_column);
    }
    private void OnMouseExit()
    {
        _boardManager.OutlineBoardSpaceOnExit(gameObject);
    }

    private void OnMouseDown()
    {
        _gamePieceManager.MovePiece(gameObject);
    }

    public int GetBoardSpaceRow()
    {
        return _row;
    }
    public int GetBoardSpaceColumn()
    {
        return _column;
    }
}
