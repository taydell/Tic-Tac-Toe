using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    private string _id { get; set; }
    private int _size { get;set; }
    private PlayerEnum _player { get; set; }
    private bool _isInPlay { get; set; } = false;
    GameManager _gameManager;
    GamePieceManager _gamePieceManager;
    PlayerManager _playerManager;

    public void SetId(string id)
    {
        _id = id;
    }

    public void SetSize(int size) 
    {
        _size = size;
    }

    public void SetIsPlayer1(PlayerEnum player)
    {
        _player = player;
    }

    public void SetIsInPlay(bool isInPlay)
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

    public PlayerEnum GetPlayer()
    {
        return _player;
    }

    public bool GetIsInPlay()
    {
        return _isInPlay;
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _gamePieceManager = _gameManager.GetComponent<GamePieceManager>();
        _playerManager = _gameManager.GetComponent<PlayerManager>();
    }

    private void OnMouseDown()
    {
        var currentPlayer = _playerManager.GetCurrentPlayer();

        if (_gamePieceManager.CheckIfPieceIsPlayersPiece(gameObject,currentPlayer))
        {
            if (!_isInPlay && !_gameManager.IsGameOver())
                {
                    Debug.Log("Is In Play: " + _isInPlay);
                    Debug.Log("Size: " + _size);
                    Debug.Log("Player: " + GetPlayer());

                    _gamePieceManager.OutlinePiece(gameObject);
                }
        }
        
    }
}
