using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditions : MonoBehaviour
{
    BoardManager _boardManager;

    private void Start()
    {
        var _gameManager = GameManager.Instance;
        _boardManager = _gameManager.GetComponent<BoardManager>();
    }
    #region Horizontal Wins
    public bool WinConditionForTopRow(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(0, 0) == player 
            && _boardManager.GetPlayerFromGameBoardPosition(0, 0) == _boardManager.GetPlayerFromGameBoardPosition(0, 1) 
            && _boardManager.GetPlayerFromGameBoardPosition(0, 0) == _boardManager.GetPlayerFromGameBoardPosition(0, 2);
    }

    public bool WinConditionForMiddleRow(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(1, 0) == player
            && _boardManager.GetPlayerFromGameBoardPosition(1, 0) == _boardManager.GetPlayerFromGameBoardPosition(1, 1)
            && _boardManager.GetPlayerFromGameBoardPosition(1, 0) == _boardManager.GetPlayerFromGameBoardPosition(1, 2);
    }

    public bool WinConditionForBottomRow(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(2, 0) == player
            && _boardManager.GetPlayerFromGameBoardPosition(2, 0) == _boardManager.GetPlayerFromGameBoardPosition(2, 1)
            && _boardManager.GetPlayerFromGameBoardPosition(2, 0) == _boardManager.GetPlayerFromGameBoardPosition(2, 2);
    }
    #endregion
    #region Vertical Wins
    public bool WinConditionForLeftColumn(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(0, 0) == player
            && _boardManager.GetPlayerFromGameBoardPosition(0, 0) == _boardManager.GetPlayerFromGameBoardPosition(1, 0)
            && _boardManager.GetPlayerFromGameBoardPosition(0, 0) == _boardManager.GetPlayerFromGameBoardPosition(2, 0);
    }

    public bool WinConditionForMiddleColumn(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(0, 1) == player
            && _boardManager.GetPlayerFromGameBoardPosition(0, 1) == _boardManager.GetPlayerFromGameBoardPosition(1, 1)
            && _boardManager.GetPlayerFromGameBoardPosition(0, 1) == _boardManager.GetPlayerFromGameBoardPosition(2, 1);
    }

    public bool WinConditionForRightColumn(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(0, 2) == player
            && _boardManager.GetPlayerFromGameBoardPosition(0, 2) == _boardManager.GetPlayerFromGameBoardPosition(1, 2)
            && _boardManager.GetPlayerFromGameBoardPosition(0, 2) == _boardManager.GetPlayerFromGameBoardPosition(2, 2);
    }
    #endregion
    #region Diagonal wins
    public bool WinConditionForTopLeftToBottomRightDiagonal(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(0, 0) == player
            && _boardManager.GetPlayerFromGameBoardPosition(0, 0) == _boardManager.GetPlayerFromGameBoardPosition(1, 1)
            && _boardManager.GetPlayerFromGameBoardPosition(0, 0) == _boardManager.GetPlayerFromGameBoardPosition(2, 2);
    }

    public bool WinConditionForTopRightToBottomLeftDiagonal(PlayerEnum player)
    {
        return _boardManager.GetPlayerFromGameBoardPosition(0, 2) == player
            && _boardManager.GetPlayerFromGameBoardPosition(0, 2) == _boardManager.GetPlayerFromGameBoardPosition(1, 1)
            && _boardManager.GetPlayerFromGameBoardPosition(0, 2) == _boardManager.GetPlayerFromGameBoardPosition(2, 0);
    }
    #endregion

    #region Draw Condition
    public bool DrawCondition()
    {
        return _boardManager.GetGamePieceAtSpecificBoardSpace(0, 0) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(0, 1) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(0, 2) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(1, 0) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(1, 1) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(1, 2) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(2, 0) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(2, 1) != null
             && _boardManager.GetGamePieceAtSpecificBoardSpace(2, 2) != null;
    }
    #endregion
}
