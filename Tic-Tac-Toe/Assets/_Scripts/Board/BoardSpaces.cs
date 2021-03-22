using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpaces : MonoBehaviour
{
    [SerializeField]
    int _row, _column;

    GameManager _gameManager;
    BoardManager _boardManager;
    GamePieceManager _gamePieceManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _boardManager = _gameManager.GetComponent<BoardManager>();
        _gamePieceManager = _gameManager.GetComponent<GamePieceManager>();
    }

    private void OnMouseOver()
    {
        if(!_gameManager.IsGameOver())
            _boardManager.OutlineBoardSpaceOnEnter(gameObject,_row,_column);
    }
    private void OnMouseExit()
    {
        if (!_gameManager.IsGameOver())
            _boardManager.OutlineBoardSpaceOnExit(gameObject);
    }

    private void OnMouseDown()
    {
        if (!_gameManager.IsGameOver())
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
