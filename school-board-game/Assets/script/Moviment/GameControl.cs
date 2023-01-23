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

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        player1.GetComponent<FollowThePaht>().moveallowed = false;
        player2.GetComponent<FollowThePaht>().moveallowed = false;
        player3.GetComponent<FollowThePaht>().moveallowed = false;
        player4.GetComponent<FollowThePaht>().moveallowed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void MMovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePaht>().moveallowed = true;
                break;
            case 2:
                player2.GetComponent<FollowThePaht>().moveallowed = true;
                break;
            case 3:
                player3.GetComponent<FollowThePaht>().moveallowed = true;
                break;
            case 4:
                player4.GetComponent<FollowThePaht>().moveallowed = true;
                break;
        }
    }
}
