using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistiEventsMaster : MonoBehaviour
{
    public ImprevistoExecuted imprevistoExecuted;
    public static string Nameplayer { get; set; }
    [SerializeField]
    private ImprevistiDatabase imprevistiDatabase;
    [SerializeField]
    private PlayerMoveDatabase playerMoveDatabase;
    private GameObject player1, player2, player3, player4;
    public ImprevistiMovimentController imprevistiMovimentController;

    private void Awake()
    {
        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");
        player3 = GameObject.Find("Player3");
        player4 = GameObject.Find("Player4");
    }


    // Nome dell imprevisto, deve essere scritto uguale a quello che vine stampato a shermo
    public void StartImprevisto(string nameImprevisto)
    {
        ImprevistoDatabaseDocument imprevistoAssegnato = imprevistiDatabase.GetImprevistoAssegnato(Nameplayer);

        Imprevisto imprevisto = ScriptableObject.CreateInstance<Imprevisto>();

        if (imprevistoAssegnato == null)
        {
            Debug.Log("All is fine for player: " + Nameplayer);

            imprevisto.name = "All is fine";
            imprevisto.description = "There are no chances, everything is quiet.";

            imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
            return;
        }

        // Cnast from ImprevistoDatabaseDocument to Imprevisto
        imprevisto.name = imprevistoAssegnato.name;
        imprevisto.description = imprevistoAssegnato.description;

        Debug.Log("Imprevisto " + imprevisto.name + " for player: " + Nameplayer + " | Name parameter " + nameImprevisto);

        switch (imprevisto.name)
        {
            case "You are die":
                Debug.Log("Dalla classe ImprevistiEventMaster: Imprevisto You are die per player: " + Nameplayer);
                playerMoveDatabase.AddPlayerMoveTiles(Nameplayer, 0, "null", "null");
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            case "Professional Kidnapper":
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            case "Go to jail":
                playerMoveDatabase.AddPlayerMoveTiles(Nameplayer, 0, "null", "null");
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            case "Wrong Choices":
                Debug.Log("Questo imprevisto va eseguito, manualmente, cosa intedo, che non c'è una versione digitale, ma semplicemnte i palyer non potrenno utilizzare la carta scelta per il prossimo turno");
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            case "AI Power":
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            case "Challenge the Fate":
                // if you are in the lead move forward of 1 step, otherwise the one in the lead moves forward of 1

                int player1WayPoint = player1.GetComponent<FollowThePaht>().waypointIndex;
                int player2WayPoint = player2.GetComponent<FollowThePaht>().waypointIndex;
                int player3WayPoint = player3.GetComponent<FollowThePaht>().waypointIndex;
                int player4WayPoint = player4.GetComponent<FollowThePaht>().waypointIndex;

                Debug.LogFormat("Player1: {0} | Player2: {1} | Player3: {2} | Player4: {3}", player1WayPoint, player2WayPoint, player3WayPoint, player4WayPoint);

                int maxWayPoint = player1WayPoint;

                if (player2WayPoint > maxWayPoint)
                {
                    maxWayPoint = player2WayPoint;
                }

                if (player3WayPoint > maxWayPoint)
                {
                    maxWayPoint = player3WayPoint;
                }

                if (player4WayPoint > maxWayPoint)
                {
                    maxWayPoint = player4WayPoint;
                }

                Debug.LogFormat("MaxWayPoint: {0}", maxWayPoint);

                if (player1WayPoint == maxWayPoint)
                {
                    imprevistiMovimentController.MovePlayer1(1);
                }
                else if (player2WayPoint == maxWayPoint)
                {
                    imprevistiMovimentController.MovePlayer2(1);
                }
                else if (player3WayPoint == maxWayPoint)
                {
                    imprevistiMovimentController.MovePlayer3(1);
                }
                else if (player4WayPoint == maxWayPoint)
                {
                    imprevistiMovimentController.MovePlayer4(1);
                }

                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            // case "See God":


            //     imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
            //     break;
            case "Meet Paky":
                switch (Nameplayer)
                {
                    case "Player1":
                        imprevistiMovimentController.MovePlayer1(2);
                        break;
                    case "Player2":
                        imprevistiMovimentController.MovePlayer2(2);
                        break;
                    case "Player3":
                        imprevistiMovimentController.MovePlayer3(2);
                        break;
                    case "Player4":
                        imprevistiMovimentController.MovePlayer4(2);
                        break;
                }

                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
            case "it's 79 A.D.":
                StartCoroutine(MovePlayerBackworksForVesuvio(imprevisto));
                break;
        }

        // TODO: Chiudere l'inventario

    }

    IEnumerator MovePlayerBackworksForVesuvio(Imprevisto imprevisto)
    {
        imprevistiMovimentController.MovePlayer1Backwards(1);
        imprevistiMovimentController.MovePlayer2Backwards(1);
        imprevistiMovimentController.MovePlayer3Backwards(1);
        imprevistiMovimentController.MovePlayer4Backwards(1);

        imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
        yield return null;
    }
}
