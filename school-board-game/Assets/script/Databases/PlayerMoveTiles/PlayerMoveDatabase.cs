using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveDatabase : MonoBehaviour
{
    public List<PlayerMoveTiles> playerMoveTiles = new List<PlayerMoveTiles>(4);

    public void AddPlayerMoveTiles(string playerName, int tilesToMove, string currentWord, string definition)
    {
        PlayerMoveTiles playerMoveTiles = new PlayerMoveTiles();
        playerMoveTiles.playerName = playerName;
        playerMoveTiles.tilesToMove = tilesToMove;
        playerMoveTiles.currentWord = currentWord;
        playerMoveTiles.definition = definition;
        this.playerMoveTiles.Add(playerMoveTiles);
    }
}
