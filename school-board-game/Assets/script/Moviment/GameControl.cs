using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public static PlayerMoveDatabase playerMoveDatabase;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        playerMoveDatabase = gameObject.GetComponent<PlayerMoveDatabase>();

        player1.GetComponent<FollowThePaht>().moveallowed = false;
        player2.GetComponent<FollowThePaht>().moveallowed = false;
        player3.GetComponent<FollowThePaht>().moveallowed = false;
        player4.GetComponent<FollowThePaht>().moveallowed = false;

    }

    // Update is called once per frame
    void Update()
    {
        // IMPORTANT: Player 1 script
        int player1TilesToMove = playerMoveDatabase.playerMoveTiles.Find((x) => x.playerName == "Player1").tilesToMove;
        if (player1.GetComponent<FollowThePaht>().waypointIndex > player1StartWaypoint + player1TilesToMove)
        {
            player1.GetComponent<FollowThePaht>().moveallowed = false;
            // player1MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(true);
            player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex - 1;

            // Start the next player
            player2.GetComponent<FollowThePaht>().moveallowed = true;
        }

        if (player1.GetComponent<FollowThePaht>().waypointIndex == player1.GetComponent<FollowThePaht>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            // player1MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 1 Wins!";
            gameOver = true;
        }

        // IMPORTANT: Player 2 script
        int player2TilesToMove = playerMoveDatabase.playerMoveTiles.Find((x) => x.playerName == "Player2").tilesToMove;
        if (player2.GetComponent<FollowThePaht>().waypointIndex > player2StartWaypoint + player2TilesToMove)
        {
            player2.GetComponent<FollowThePaht>().moveallowed = false;
            // player2MoveText.gameObject.SetActive(false);
            // player2MoveText.gameObject.SetActive(true);
            player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex - 1;

            // Start the next player
            player3.GetComponent<FollowThePaht>().moveallowed = true;
        }

        if (player2.GetComponent<FollowThePaht>().waypointIndex == player2.GetComponent<FollowThePaht>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            // player2MoveText.gameObject.SetActive(false);
            // player3MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 2 Wins!";
            gameOver = true;
        }

        // IMPORTANT: Player 3 script
        int player3TilesToMove = playerMoveDatabase.playerMoveTiles.Find((x) => x.playerName == "Player3").tilesToMove;
        if (player3.GetComponent<FollowThePaht>().waypointIndex > player3StartWaypoint + player3TilesToMove)
        {
            player3.GetComponent<FollowThePaht>().moveallowed = false;
            // player3MoveText.gameObject.SetActive(false);
            // player3MoveText.gameObject.SetActive(true);
            player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex - 1;

            // Start the next player
            player4.GetComponent<FollowThePaht>().moveallowed = true;
        }

        if (player3.GetComponent<FollowThePaht>().waypointIndex == player3.GetComponent<FollowThePaht>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            // player3MoveText.gameObject.SetActive(false);
            // player3MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 3 Wins!";
            gameOver = true;
        }

        // IMPORTANT: Player 4 script
        int player4TilesToMove = playerMoveDatabase.playerMoveTiles.Find((x) => x.playerName == "Player4").tilesToMove;
        if (player4.GetComponent<FollowThePaht>().waypointIndex > player4StartWaypoint + player4TilesToMove)
        {
            player4.GetComponent<FollowThePaht>().moveallowed = false;
            // player4MoveText.gameObject.SetActive(false);
            // player4MoveText.gameObject.SetActive(true);
            player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex - 1;

            // This player is the last one to move, so we can start the next round
        }

        if (player4.GetComponent<FollowThePaht>().waypointIndex == player4.GetComponent<FollowThePaht>().waypoints.Length)
        {
            whoWinsText.gameObject.SetActive(true);
            // player4MoveText.gameObject.SetActive(false);
            // player4MoveText.gameObject.SetActive(false);
            whoWinsText.GetComponent<Text>().text = "Player 4 Wins!";
            gameOver = true;
        }

        // TODO: Start to move the palyer if the list have 4 elements (this means that all player have aswered the qeustion) or the timer is over
        if (playerMoveDatabase.playerMoveTiles.Count == 4)
        {
            MovePlayer();
        }
    }

    public static void MovePlayer()
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

        List<PlayerMoveTiles> palyerMOveTilesCopy = playerMoveDatabase.playerMoveTiles;
        playerMoveDatabase.playerMoveTiles.Clear();


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
