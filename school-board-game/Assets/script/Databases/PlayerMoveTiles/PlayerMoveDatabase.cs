using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDatabase : MonoBehaviour
{
    [SerializeField]
    public List<PlayerMoveTiles> playerMoveTilesList = new List<PlayerMoveTiles>();

    public void AddPlayerMoveTiles(string playerName, int tilesToMove, string currentWord, string definition)
    {
        PlayerMoveTiles playerMoveTiles = new PlayerMoveTiles();
        playerMoveTiles.playerName = playerName;
        playerMoveTiles.tilesToMove = tilesToMove;
        playerMoveTiles.currentWord = currentWord;
        playerMoveTiles.definition = definition;
        this.playerMoveTilesList.Add(playerMoveTiles);
    }
}
