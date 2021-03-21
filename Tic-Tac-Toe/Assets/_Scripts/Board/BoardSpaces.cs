using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpaces : MonoBehaviour
{
    [SerializeField]
    int x, y;

    private void OnMouseOver()
    {
        var gameManager = GameManager.Instance;
        gameManager.OutlineBoardSpaceOnEnter(gameObject);
    }
    private void OnMouseExit()
    {
        var gameManager = GameManager.Instance;
        gameManager.OutlineBoardSpaceOnExit(gameObject);
    }

    private void OnMouseDown()
    {
        var gameManager = GameManager.Instance;
        gameManager.MovePiece(gameObject);
    }
}
