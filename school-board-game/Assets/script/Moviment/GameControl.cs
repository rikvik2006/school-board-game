using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;

public class GameControl : MonoBehaviour
{
    private static GameObject whoWinsText, player1MoveText, player2MoveText, player3MoveText, player4MoveText;
    private static GameObject player1, player2, player3, player4;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int player3StartWaypoint = 0;
    public static int player4StartWaypoint = 0;

    public static bool gameOver = false;

    // Moviment database
    public PlayerMoveDatabase playerMoveDatabase;

    private int player1TilesToMove = 0;
    private int player2TilesToMove = 0;
    private int player3TilesToMove = 0;
    private int player4TilesToMove = 0;

    public List<PlayerMoveTiles> palyerMoveTilesCopy = new List<PlayerMoveTiles>();

    // Tiles to move for player: 
    private PlayerMoveTiles player1MoveTiles;
    private PlayerMoveTiles player2MoveTiles;
    private PlayerMoveTiles player3MoveTiles;
    private PlayerMoveTiles player4MoveTiles;
    public bool movePhase = false;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
        // playerMoveDatabase = gameObject.GetComponent<PlayerMoveDatabase>();

        player1.GetComponent<FollowThePaht>().moveallowed = false;
        player2.GetComponent<FollowThePaht>().moveallowed = false;
        player3.GetComponent<FollowThePaht>().moveallowed = false;
        player4.GetComponent<FollowThePaht>().moveallowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMoveDatabase.playerMoveTilesList.Count >= 5)
        {
            // TODO: Start to move the palyer if the list have 5 elements (this means that all player have aswered the qeustion) or the timer is over
            MovePlayer();
            movePhase = true;
            // TODO: Start moving the camera
        }

        // IMPORTANT: Player 1 script
        player1MoveTiles = palyerMoveTilesCopy.Find((x) => x.playerName == "Player1");
        if (player1MoveTiles != null)
        {
            player1TilesToMove = player1MoveTiles.tilesToMove;
            Debug.Log("Tiles to move: " + player1TilesToMove);
            // player1.GetComponent<FollowThePaht>().waypointIndex = player1TilesToMove;
        }

        Debug.Log("CALCOLI PER L'AVVIO: " + player1.GetComponent<FollowThePaht>().waypointIndex + " " + player1StartWaypoint + " " + player1TilesToMove + " " + (player1StartWaypoint + player1TilesToMove));
        if (player1.GetComponent<FollowThePaht>().waypointIndex > player1StartWaypoint + player1TilesToMove)
        {
            player1.GetComponent<FollowThePaht>().moveallowed = false;
            // player1MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;

            // Start the next player
            Debug.Log("STARTING THE NEXT PLAYER");
            player2.GetComponent<FollowThePaht>().moveallowed = true;
        }

        if (player1.GetComponent<FollowThePaht>().waypointIndex == player1.GetComponent<FollowThePaht>().waypoints.Length)
        {
            // whoWinsText.gameObject.SetActive(true);
            // player1MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 1 Wins!";
            gameOver = true;
        }

        // IMPORTANT: Player 2 script
        player2MoveTiles = palyerMoveTilesCopy.Find((x) => x.playerName == "Player2");
        if (player2MoveTiles != null)
        {
            player2TilesToMove = player2MoveTiles.tilesToMove;
            // player2.GetComponent<FollowThePaht>().waypointIndex = player2TilesToMove;
        }

        if (player2.GetComponent<FollowThePaht>().waypointIndex > player2StartWaypoint + player2TilesToMove)
        {
            player2.GetComponent<FollowThePaht>().moveallowed = false;
            // player2MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;

            // Start the next player
            player3.GetComponent<FollowThePaht>().moveallowed = true;
        }

        if (player2.GetComponent<FollowThePaht>().waypointIndex == player2.GetComponent<FollowThePaht>().waypoints.Length)
        {
            // whoWinsText.gameObject.SetActive(true);
            // player2MoveText.gameObject.SetActive(false);
            // player3MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 2 Wins!";
            gameOver = true;
        }

        // IMPORTANT: Player 3 script
        player3MoveTiles = palyerMoveTilesCopy.Find((x) => x.playerName == "Player3");
        if (player3MoveTiles != null)
        {
            player3TilesToMove = player3MoveTiles.tilesToMove;
            // player3.GetComponent<FollowThePaht>().waypointIndex = player3TilesToMove;
        }

        if (player3.GetComponent<FollowThePaht>().waypointIndex > player3StartWaypoint + player3TilesToMove)
        {
            player3.GetComponent<FollowThePaht>().moveallowed = false;
            // player3MoveText.gameObject.SetActive(false);
            // player3MoveText.gameObject.SetActive(true);
            player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;

            // Start the next player
            player4.GetComponent<FollowThePaht>().moveallowed = true;
        }

        if (player3.GetComponent<FollowThePaht>().waypointIndex == player3.GetComponent<FollowThePaht>().waypoints.Length)
        {
            // whoWinsText.gameObject.SetActive(true);
            // player3MoveText.gameObject.SetActive(false);
            // player3MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 3 Wins!";
            gameOver = true;
        }

        // IMPORTANT: Player 4 script
        player4MoveTiles = palyerMoveTilesCopy.Find((x) => x.playerName == "Player4");
        if (player4MoveTiles != null)
        {
            player4TilesToMove = player4MoveTiles.tilesToMove;
            // player4.GetComponent<FollowThePaht>().waypointIndex = player4TilesToMove;
        }

        if (player4.GetComponent<FollowThePaht>().waypointIndex > player4StartWaypoint + player4TilesToMove)
        {
            player4.GetComponent<FollowThePaht>().moveallowed = false;
            // player4MoveText.gameObject.SetActive(false);
            // player4MoveText.gameObject.SetActive(true);
            player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;

            // This player is the last one to move, so we can start the next round
            // Stop the movePhase
            movePhase = false;
        }

        if (player4.GetComponent<FollowThePaht>().waypointIndex == player4.GetComponent<FollowThePaht>().waypoints.Length)
        {
            // whoWinsText.gameObject.SetActive(true);
            // player4MoveText.gameObject.SetActive(false);
            // player4MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 4 Wins!";
            gameOver = true;
        }
    }

    public void MovePlayer()
    {
        // switch (playerToMove)
        // {
        //     case 1:
        //         player1.GetComponent<FollowThePaht>().moveallowed = true;
        //         break;
        //     case 2:
        //         player2.GetComponent<FollowThePaht>().moveallowed = true;
        //         break;
        //     case 3:
        //         player3.GetComponent<FollowThePaht>().moveallowed = true;
        //         break;
        //     case 4:
        //         player4.GetComponent<FollowThePaht>().moveallowed = true;
        //         break;
        // }

        palyerMoveTilesCopy = new List<PlayerMoveTiles>();

        foreach (PlayerMoveTiles tiles in playerMoveDatabase.playerMoveTilesList)
        {
            Debug.Log(tiles.playerName + ": " + tiles.tilesToMove);
            palyerMoveTilesCopy.Add(tiles);
        }

        playerMoveDatabase.ClearPlayerMoveTilesList();  // Clear the list and add an element for initialisation

        string listMovesJson = JsonUtility.ToJson(palyerMoveTilesCopy);

        Debug.Log(listMovesJson);

        player1.GetComponent<FollowThePaht>().moveallowed = true;

        // player2.GetComponent<FollowThePaht>().moveallowed = true;
        // player3.GetComponent<FollowThePaht>().moveallowed = true;
        // player4.GetComponent<FollowThePaht>().moveallowed = true;
    }

    // public void MovePlayer(int numberTilesToMove)
    // {
    //     // When this function will be called 
    //     player1.GetComponent<FollowThePaht>().destinationTiles = (player1.GetComponent<FollowThePaht>().currentTiles + numberTilesToMove) % player1.GetComponent<FollowThePaht>().waypoints.Length;

    //     player2.GetComponent<FollowThePaht>().destinationTiles = (player2.GetComponent<FollowThePaht>().currentTiles + numberTilesToMove) % player2.GetComponent<FollowThePaht>().waypoints.Length;

    //     player3.GetComponent<FollowThePaht>().destinationTiles = (player3.GetComponent<FollowThePaht>().currentTiles + numberTilesToMove) % player3.GetComponent<FollowThePaht>().waypoints.Length;

    //     player4.GetComponent<FollowThePaht>().destinationTiles = (player4.GetComponent<FollowThePaht>().currentTiles + numberTilesToMove) % player4.GetComponent<FollowThePaht>().waypoints.Length;
    // }
}
