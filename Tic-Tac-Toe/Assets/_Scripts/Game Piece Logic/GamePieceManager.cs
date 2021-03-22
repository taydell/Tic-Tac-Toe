using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePieceManager : MonoBehaviour
{
    List<GameObject> _selectedPieces = new List<GameObject>();
    BoardManager _boardManager;
    GameManager _gameManager;
    PlayerManager _playerManager;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _boardManager = _gameManager.GetComponent<BoardManager>();
        _playerManager = _gameManager.GetComponent<PlayerManager>();
    }

    public void OutlinePiece(GameObject gameObject)
    {
        var isDeselectingPiece = false;
        if (_selectedPieces.Count != 0)
        {
            var oldSelection = _selectedPieces[0];
            var oldSelectionsOutline = oldSelection.GetComponent<Outline>();
            var oldSelectionsGamePiece = oldSelection.GetComponent<GamePiece>();

            oldSelectionsOutline.OutlineMode = Outline.Mode.OutlineHidden;

            var gamePiece = gameObject.GetComponent<GamePiece>();
            isDeselectingPiece = gamePiece.GetId().Equals(oldSelectionsGamePiece.GetId());
            _selectedPieces.Clear();
        }

        if (!isDeselectingPiece)
        {
            var outline = gameObject.GetComponent<Outline>() != null ? gameObject.GetComponent<Outline>() : gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;

            _selectedPieces.Add(gameObject);
        }
    }

    public void MovePiece(GameObject boardSpace)
    {
        if (_selectedPieces.Count != 0)
        {
            var gamePieceToMove = _selectedPieces[0];
            var boardSpacePosition = boardSpace.transform.position;
            var boardSpaceRow = boardSpace.GetComponent<BoardSpaces>().GetBoardSpaceRow();
            var boardSpaceColumn = boardSpace.GetComponent<BoardSpaces>().GetBoardSpaceColumn();
            var gamePiece = gamePieceToMove.GetComponent<GamePiece>();
            var gamePieceAtSpecificBoardSpace = _boardManager.GetGamePieceAtSpecificBoardSpace(boardSpaceRow, boardSpaceColumn);

            if (gamePieceAtSpecificBoardSpace == null ||(gamePiece.GetSize() > _boardManager.GetGamePieceAtSpecificBoardSpace(boardSpaceRow, boardSpaceColumn).GetSize()))
            {
                gamePiece.SetIsInPlay(true);
                gamePieceToMove.transform.position = new Vector3(boardSpacePosition.x, boardSpacePosition.y + .5f, boardSpacePosition.z);
                OutlinePiece(_selectedPieces[0]);

                _boardManager.AddGamePieceToGameBoard(boardSpaceRow, boardSpaceColumn, gamePiece);
                if(_boardManager.IsGameOver(gamePiece.GetPlayer()))
                {
                    _gameManager.EndGame(gamePiece.GetPlayer());
                }

                _boardManager.OutlineBoardSpaceOnExit(boardSpace);
                _playerManager.ChangeTurns();
            }
        }
    }

    public List<GameObject> GetSelectedGamePieces()
    {
        return _selectedPieces;
    }

    public bool CheckIfPieceIsPlayersPiece(GameObject GamePiece, PlayerEnum currentPlayer)
    {
        var gamePiecesPlayer = GamePiece.GetComponent<GamePiece>().GetPlayer();
        return currentPlayer == gamePiecesPlayer;
    }
}
