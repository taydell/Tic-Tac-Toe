using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    static SpawnManager _spawnManager;
    bool _gameOver = false;
    bool _isDraw;
    PlayerEnum _winner;

    void Awake()
    {
        if (Instance != null) //this depend how you want to handle multiple managers (like when switching/adding scenes) but this way should cover common use cases
            Destroy(Instance);
        Instance = this;
    }
    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GetComponent<SpawnManager>();
        _spawnManager.SpawnGame();
    }

    public void SetIsDraw(bool isDraw)
    {
        _isDraw = isDraw;
    }
    public void EndGame(PlayerEnum player)
    {
        _gameOver = true;
        if (!_isDraw)
        {
            _winner = player;
            Debug.Log(player + " wins!");
            //win logic
        }
        else
        {
            Debug.Log("Its A Draw!!");
            //draw logic
        }
            
    }
}
