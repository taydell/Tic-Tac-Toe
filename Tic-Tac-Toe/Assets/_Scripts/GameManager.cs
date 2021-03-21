using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    static SpawnManager     _spawnManager;

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
}
