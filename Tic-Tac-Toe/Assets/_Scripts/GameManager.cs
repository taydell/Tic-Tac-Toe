using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    SpawnManager _spawnManager;
    List<GameObject> _selectedPieces = new List<GameObject>();

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

    // Update is called once per frame
    void Update()
    {
        
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

    public void OutlineBoardSpaceOnEnter(GameObject gameObject)
    {
        if(_selectedPieces.Count != 0)
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

    public void MovePiece(GameObject boardSpace)
    {
        if (_selectedPieces.Count != 0)
        {
            var gamePieceToMove = _selectedPieces[0];
            var boardSpacePosition = boardSpace.transform.position;
            gamePieceToMove.transform.position = new Vector3(boardSpacePosition.x, boardSpacePosition.y + .5f, boardSpacePosition.z);
            OutlinePiece(_selectedPieces[0]);
            OutlineBoardSpaceOnExit(boardSpace);
        }
    }
}
