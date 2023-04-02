using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckImprevistoTiles : MonoBehaviour
// Assegnato ad ongi player, controlla se il player è sopra una casella imprevisto, se si, assegna un imprevisto al player.
{
    [HideInInspector]
    public List<int> imporevistiTiles = new List<int> { 4, 6, 9, 10, 13, 15, 18, 19, 22, 24, 27, 28, 30, 31 };
    public ImprevistiDatabase imprevistiDatabase;
    public ImprevistoManager imprevistoManager;
    private FollowThePaht followThePathScript;
    public GameControl gameControl;

    void Start()
    {
        followThePathScript = gameObject.GetComponent<FollowThePaht>();
    }

    // Update is called once per frame

    void Update()
    {
        if (gameControl.movePhase == true)
        {
            return;
        }

        // Debug.Log("Waypoint Index: " + followThePathScript.waypointIndex + " For player: " + gameObject.name);
        if (imporevistiTiles.Exists((tile) => tile == followThePathScript.waypointIndex - 1))
        {
            // TODO: Controlla se il player ha un imprevisto assegnato, se si, esci
            ImprevistoDatabaseDocument imprevistoAssegnato = imprevistiDatabase.imporevistiAssegnati.Find((imprevisto) => imprevisto.forPlayer == gameObject.name);
            if (imprevistoAssegnato != null)
            {
                return;
            }

            // TODO: Prendi la lista di Imprevisti dal file ImporevistoManager
            // Imprevisto imprevisto = imprevistoManager.GetRandomImporevisto();
            Imprevisto imprevisto = imprevistoManager.GetImprevisto(13);
            Debug.Log("Imprevisto: " + imprevisto.name + ", For Player: " + gameObject.name);
            imprevistiDatabase.AddImprevistoAssegnato(imprevisto, gameObject.name);
        }
    }
}
