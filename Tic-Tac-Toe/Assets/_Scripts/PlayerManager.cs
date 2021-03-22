using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerEnum _playersTurn = PlayerEnum.Player1;

    public PlayerEnum GetCurrentPlayer()
    {
        return _playersTurn;
    }

    public void ChangeTurns()
    {
        _playersTurn = _playersTurn == PlayerEnum.Player1 ? PlayerEnum.Player2 : PlayerEnum.Player1;
    }
}
