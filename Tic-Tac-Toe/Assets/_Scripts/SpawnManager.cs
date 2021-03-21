using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Serialized Objects
    [LabelOverride("Board Spawn Area")]
    [SerializeField]
    GameObject _boardSpawnObject;
    [LabelOverride("Player 1 Spawn Area")]
    [SerializeField]
    GameObject _player1SpawnArea;
    [LabelOverride("Player 2 Spawn Area")]
    [SerializeField]
    GameObject _player2SpawnArea;

    [SerializeField]
    GameObject _board;
    [LabelOverride("Player 1 Piece")]
    [SerializeField]
    GameObject _player1piece;
    [LabelOverride("Player 2 Piece")]
    [SerializeField]
    GameObject _player2piece;
    #endregion

    public void SpawnGame()
    {
        var board = Instantiate(_board, _boardSpawnObject.transform.position, Quaternion.identity);
        board.transform.SetParent(_boardSpawnObject.transform);
        SpawnGamePieces();
    }

    private void SpawnGamePieces()
    {
        for(int creationIndex = 0; creationIndex < 6; creationIndex++)
        {
            SpawnGamePiece(_player1piece, _player1SpawnArea, creationIndex, PlayerEnum.Player1, "Player1-" + creationIndex);
            SpawnGamePiece(_player2piece, _player2SpawnArea, creationIndex, PlayerEnum.Player2, "Player2-" + creationIndex);
        }
    }

    private void SpawnGamePiece(GameObject gamePiece, GameObject playerSpawnArea, int creationIndex, PlayerEnum player, string id)
    {
        var piece = Instantiate(gamePiece, GetSpawnLocation(creationIndex, playerSpawnArea), Quaternion.identity);
        scaleGamePiece(creationIndex, piece);
        if(creationIndex == 0)
            piece.transform.position = new Vector3(piece.transform.position.x - .2f, piece.transform.position.y, piece.transform.position.z);
        piece.transform.SetParent(playerSpawnArea.transform);
        var gamePieceInfo = piece.GetComponent<GamePiece>();
        
        gamePieceInfo.SetSize(6 - creationIndex);
        gamePieceInfo.SetIsPlayer1(player);
        gamePieceInfo.SetId(id);
    }

    private void scaleGamePiece(int creationIndex, GameObject gamePiece)
    {
        var localScale = gamePiece.transform.localScale;
        var scaledVector = creationIndex != 0 ? new Vector3(localScale.x - (creationIndex * .1f), localScale.y - (creationIndex * .1f), localScale.z - (creationIndex * .1f)) : localScale;
        gamePiece.transform.localScale = scaledVector;
    }

    private Vector3 GetSpawnLocation(int creationIndex, GameObject gamePiece)
    {
        var xPosition = gamePiece.transform.position.x + creationIndex;
        var yPosition = gamePiece.transform.position.y;
        var zPosition = gamePiece.transform.position.z;
        return new Vector3(xPosition, yPosition, zPosition);
    }
}
