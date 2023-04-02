using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistiEventsMaster : MonoBehaviour
{
    public CardsInvetoryManager cardsInvetoryManager;
    public ImprevistoExecuted imprevistoExecuted;
    public static string Nameplayer { get; set; }
    [SerializeField]
    private ImprevistiDatabase imprevistiDatabase;


    public void StartImprevisto(string name)
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

        switch (name)
        {
            case "All is fine":
                imprevistoExecuted.AddImprevistoUsato(imprevisto, Nameplayer);
                break;
        }
    }
}
