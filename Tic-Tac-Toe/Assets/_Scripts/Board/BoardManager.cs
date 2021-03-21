using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    GamePieceManager _gamePieceManager;
    GamePiece[,] _gameBoard = new GamePiece[3,3];

    private void Start()
    {
        var _gameManager = GameManager.Instance;
        _gamePieceManager = _gameManager.GetComponent<GamePieceManager>();
    }

    public void OutlineBoardSpaceOnEnter(GameObject selectedSpace, int row, int column)
    {
        if (_gamePieceManager.GetSelectedGamePieces().Count != 0)
        {
            var gamePieceOnBoard = GetGamePieceAtSpecificBoardSpace(row, column);
            if(CanGamePieceBePlaced(gamePieceOnBoard, _gamePieceManager.GetSelectedGamePieces()[0]))
            {
                var outline = selectedSpace.GetComponent<Outline>() != null ? selectedSpace.GetComponent<Outline>() : selectedSpace.AddComponent<Outline>();

                outline.OutlineMode = Outline.Mode.OutlineAll;
                outline.OutlineColor = Color.yellow;
                outline.OutlineWidth = 5f;
            }
        }
    }

    public void OutlineBoardSpaceOnExit(GameObject gameObject)
    {
        var outline = gameObject.GetComponent<Outline>() != null ? gameObject.GetComponent<Outline>() : gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineHidden;
    }

    public void AddGamePieceToGameBoard(int row, int column, GamePiece gamePiece)
    {
        _gameBoard[row,column] = gamePiece;
    }

    public GamePiece GetGamePieceAtSpecificBoardSpace(int row, int column)
    {
        return _gameBoard[row,column];
    }

    private bool CanGamePieceBePlaced(GamePiece gamePieceOnBoard, GameObject selectedGamePiece)
    {
        return (gamePieceOnBoard == null) || (gamePieceOnBoard.GetSize() < selectedGamePiece.GetComponent<GamePiece>().GetSize());
    }
}
