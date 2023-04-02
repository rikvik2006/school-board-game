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

        if (imprevistoAssegnato == null)
        {
            return;
        }

        // Cnast from ImprevistoDatabaseDocument to Imprevisto
        Imprevisto imprevisto = ScriptableObject.CreateInstance<Imprevisto>();
        imprevisto.name = imprevistoAssegnato.name;
        imprevisto.description = imprevistoAssegnato.description;

        Debug.Log("Imprevisto " + imprevisto.name + " for player: " + Nameplayer + " | Name parameter " + nameImprevisto);

        switch (imprevisto.name)
        {
            case "All is fine":
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
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
    }
}
