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
                // Il player non deve poter scrivere una parola il prossimo turno
                // switch (Nameplayer)
                // {
                //     case "Player1":

                //         break;
                //     case "Player2":

                //         break;
                //     case "Player3":

                //         break;
                //     case "Player4":

                //         break;
                // }

                Debug.Log("Dalla classe ImprevistiEventMaster: Imprevisto You are die per player: " + Nameplayer);
                playerMoveDatabase.AddPlayerMoveTiles(Nameplayer, 0, "null", "null");
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
        }

        // TODO: Chiudere l'inventario

    }
}
