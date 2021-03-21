using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    GamePieceManager _gamePieceManager;

    private void Start()
    {
        var _gameManager = GameManager.Instance;
        _gamePieceManager = _gameManager.GetComponent<GamePieceManager>();
    }

    public void OutlineBoardSpaceOnEnter(GameObject gameObject)
    {
        if (_gamePieceManager.GetSelectedGamePieces().Count != 0)
        {
            var outline = gameObject.GetComponent<Outline>() != null ? gameObject.GetComponent<Outline>() : gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;
        }
    }

    public void OutlineBoardSpaceOnExit(GameObject gameObject)
    {
        var outline = gameObject.GetComponent<Outline>() != null ? gameObject.GetComponent<Outline>() : gameObject.AddComponent<Outline>();

        outline.OutlineMode = Outline.Mode.OutlineHidden;
    }
}
