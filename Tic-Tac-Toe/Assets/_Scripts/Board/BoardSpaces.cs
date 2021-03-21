using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpaces : MonoBehaviour
{
    [SerializeField]
    int x, y;

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
        _boardManager.OutlineBoardSpaceOnEnter(gameObject);
    }
    private void OnMouseExit()
    {
        _boardManager.OutlineBoardSpaceOnExit(gameObject);
    }

    private void OnMouseDown()
    {
        _gamePieceManager.MovePiece(gameObject);
    }
}
