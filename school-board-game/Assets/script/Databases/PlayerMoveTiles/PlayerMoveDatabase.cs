using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDatabase : MonoBehaviour
{
    [SerializeField]
    public List<PlayerMoveTiles> playerMoveTilesList = new List<PlayerMoveTiles>();

    private void Start()
    {
        AddPlayerMoveTiles("null", 5, "epic", "Somtihgt that is rare");
    }

    public void AddPlayerMoveTiles(string playerName, int tilesToMove, string currentWord, string definition)
    {
        PlayerMoveTiles playerMoveTiles = new PlayerMoveTiles();
        playerMoveTiles.playerName = playerName;
        playerMoveTiles.tilesToMove = tilesToMove;
        playerMoveTiles.currentWord = currentWord;
        playerMoveTiles.definition = definition;
        this.playerMoveTilesList.Add(playerMoveTiles);
    }

    public void ClearPlayerMoveTilesList()
    {
        this.playerMoveTilesList.Clear();
        AddPlayerMoveTiles("null", 5, "epic", "Somtihgt that is rare");
    }
}
