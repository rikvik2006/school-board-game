using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistiMovimentController : MonoBehaviour
{
    private GameObject player1, player2, player3, player4;
    private int player1StartWaypoint = 0;
    private int player2StartWaypoint = 0;
    private int player3StartWaypoint = 0;
    private int player4StartWaypoint = 0;
    private int tilesTargetPlayer1 = 0;
    private int tilesTargetPlayer2 = 0;
    private int tilesTargetPlayer3 = 0;
    private int tilesTargetPlayer4 = 0;
    private GameControl gameControl;

    private void Awake()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");

        gameControl = gameObject.GetComponent<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameControl.imprevistiPhase)
        {
            if (player1.GetComponent<FollowThePaht>().waypointIndex > player1StartWaypoint + tilesTargetPlayer1)
            {
                player1.GetComponent<FollowThePaht>().moveallowed = false;
                // Eguegliamo la variabile player1StartWaypoint al waypointIndex incrementato del player 1
                player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;

                // Aggiorniamo in GameControl il valore di player1StartWaypoint che serve per il movimento del player1
                GameControl.player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;
                Debug.Log("waypointIndex: " + player1.GetComponent<FollowThePaht>().waypointIndex + "| player1StartWaypoint: " + player1StartWaypoint);
            }

            if (player2.GetComponent<FollowThePaht>().waypointIndex > player2StartWaypoint + tilesTargetPlayer2)
            {
                player2.GetComponent<FollowThePaht>().moveallowed = false;
                // Eguegliamo la variabile player2StartWaypoint al waypointIndex incrementato del player 2
                player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;

                // Aggiorniamo in GameControl il valore di player2StartWaypoint che serve per il movimento del player2
                GameControl.player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;
            }

            if (player3.GetComponent<FollowThePaht>().waypointIndex > player3StartWaypoint + tilesTargetPlayer3)
            {
                player3.GetComponent<FollowThePaht>().moveallowed = false;
                // Eguegliamo la variabile player3StartWaypoint al waypointIndex incrementato del player 3
                player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;

                // Aggiorniamo in GameControl il valore di player3StartWaypoint che serve per il movimento del player3
                GameControl.player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;
            }

            if (player4.GetComponent<FollowThePaht>().waypointIndex > player4StartWaypoint + tilesTargetPlayer4)
            {
                player4.GetComponent<FollowThePaht>().moveallowed = false;
                // Eguegliamo la variabile player4StartWaypoint al waypointIndex incrementato del player 4
                player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;

                // Aggiorniamo in GameControl il valore di player4StartWaypoint che serve per il movimento del player4
                GameControl.player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;
            }
        }

        if (gameControl.isGoingBackwards)
        {
            Debug.LogFormat("player1StartWaypoint: {0} | tilesTargetPlayer1: {1} | waypointIndex: {2}", player1StartWaypoint, tilesTargetPlayer1, player1.GetComponent<FollowThePaht>().waypointIndex);
            // if (player1.GetComponent<FollowThePaht>().waypointIndex < player1StartWaypoint - Mathf.Abs(tilesTargetPlayer1))
            if (player1.GetComponent<FollowThePaht>().waypointIndex < player1StartWaypoint && player1StartWaypoint - player1.GetComponent<FollowThePaht>().waypointIndex > tilesTargetPlayer1)
            {
                player1.GetComponent<FollowThePaht>().goBackwards = false;
                gameControl.isGoingBackwards = false;

                player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;

                GameControl.player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;
                Debug.LogFormat("Player1StartWaypoint: {0}", player1StartWaypoint);
            }

            Debug.LogFormat("player1StartWaypoint: {0} | tilesTargetPlayer1: {1} | waypointIndex: {2}", player2StartWaypoint, tilesTargetPlayer2, player2.GetComponent<FollowThePaht>().waypointIndex);
            if (player2.GetComponent<FollowThePaht>().waypointIndex < player2StartWaypoint - Mathf.Abs(tilesTargetPlayer2))
            {
                player2.GetComponent<FollowThePaht>().goBackwards = false;
                gameControl.isGoingBackwards = false;

                player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;

                GameControl.player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;
            }

            Debug.LogFormat("player1StartWaypoint: {0} | tilesTargetPlayer1: {1} | waypointIndex: {2}", player3StartWaypoint, tilesTargetPlayer3, player3.GetComponent<FollowThePaht>().waypointIndex);
            if (player3.GetComponent<FollowThePaht>().waypointIndex < player3StartWaypoint - Mathf.Abs(tilesTargetPlayer3))
            {
                player3.GetComponent<FollowThePaht>().goBackwards = false;
                gameControl.isGoingBackwards = false;

                player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;

                GameControl.player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;
            }

            Debug.LogFormat("player1StartWaypoint: {0} | tilesTargetPlayer1: {1} | waypointIndex: {2}", player4StartWaypoint, tilesTargetPlayer4, player4.GetComponent<FollowThePaht>().waypointIndex);
            if (player4.GetComponent<FollowThePaht>().waypointIndex < player4StartWaypoint - Mathf.Abs(tilesTargetPlayer4))
            {
                player4.GetComponent<FollowThePaht>().goBackwards = false;
                gameControl.isGoingBackwards = false;

                player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;

                GameControl.player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;
            }
        }
    }

    public void MovePlayer1(int tilesTarget)
    {
        player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer1 = tilesTarget - 1;
        player1.GetComponent<FollowThePaht>().moveallowed = true;
    }

    public void MovePlayer2(int tilesTarget)
    {
        player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer2 = tilesTarget - 1;
        player2.GetComponent<FollowThePaht>().moveallowed = true;
    }

    public void MovePlayer3(int tilesTarget)
    {
        player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer3 = tilesTarget - 1;
        player3.GetComponent<FollowThePaht>().moveallowed = true;
    }

    public void MovePlayer4(int tilesTarget)
    {
        player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer4 = tilesTarget - 1;
        player4.GetComponent<FollowThePaht>().moveallowed = true;
    }

    // Move backwards start function
    public void MovePlayer1Backwards(int tilesTarget)
    {
        player1StartWaypoint = player1.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer1 = tilesTarget;
        gameControl.isGoingBackwards = true;
        player1.GetComponent<FollowThePaht>().goBackwards = true;
    }

    public void MovePlayer2Backwards(int tilesTarget)
    {
        player2StartWaypoint = player2.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer2 = tilesTarget;
        gameControl.isGoingBackwards = true;
        player2.GetComponent<FollowThePaht>().goBackwards = true;
    }

    public void MovePlayer3Backwards(int tilesTarget)
    {
        player3StartWaypoint = player3.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer3 = tilesTarget;
        gameControl.isGoingBackwards = true;
        player3.GetComponent<FollowThePaht>().goBackwards = true;
    }

    public void MovePlayer4Backwards(int tilesTarget)
    {
        player4StartWaypoint = player4.GetComponent<FollowThePaht>().waypointIndex;
        this.tilesTargetPlayer4 = tilesTarget;
        gameControl.isGoingBackwards = true;
        player4.GetComponent<FollowThePaht>().goBackwards = true;
    }
}