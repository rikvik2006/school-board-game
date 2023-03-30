using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistiDatabase : MonoBehaviour
// Questa classe serve per contrllare se un utente ha già un imporevisto assegnato, E NON serve come database di imporevisti generale per il gioco.
{
    public List<ImprevistoDatabaseDocument> imporevistiAssegnati = new List<ImprevistoDatabaseDocument>();

    // Start is called before the first frame update
    void Start()
    {
        Imprevisto imprevisto = new Imprevisto();
        imprevisto.name = "null";
        imprevisto.description = "null";
        AddImprevistoAssegnato(imprevisto, "null");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddImprevistoAssegnato(Imprevisto imprevisto, string forPlayer)
    {
        ImprevistoDatabaseDocument imprevistoDatabaseDocument = new ImprevistoDatabaseDocument();
        imprevistoDatabaseDocument.name = imprevisto.name;
        imprevistoDatabaseDocument.description = imprevisto.description;
        imprevistoDatabaseDocument.forPlayer = forPlayer;
        this.imporevistiAssegnati.Add(imprevistoDatabaseDocument);
    }

    public void ClearImprevistoAsegnato()
    {
        this.imporevistiAssegnati.Clear();
        Imprevisto imprevisto = new Imprevisto();
        imprevisto.name = "null";
        imprevisto.description = "null";
        AddImprevistoAssegnato(imprevisto, "null");
    }
}


public class ImprevistoDatabaseDocument
{
    public string name;
    public string description;
    public string forPlayer;

}