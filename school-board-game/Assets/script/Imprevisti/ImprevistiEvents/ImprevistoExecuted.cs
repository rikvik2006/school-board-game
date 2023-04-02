using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoExecuted : MonoBehaviour
// Questa classe server per salvare gli imprevisti che sono stati usati dall untente, solo per evitare che l'utente possa rieseguire l'ho stesso imprevisti nella stessa fase.
{
    public List<ImprevistoDatabaseDocument> imprevistiUsati = new List<ImprevistoDatabaseDocument>();

    private void Start()
    {
        Imprevisto imprevisto = ScriptableObject.CreateInstance<Imprevisto>();
        imprevisto.name = "null";
        imprevisto.description = "null";
        AddImprevistoUsato(imprevisto, "null");
    }

    public void AddImprevistoUsato(Imprevisto imprevisto, string forPlayer)
    {
        ImprevistoDatabaseDocument imprevistoDatabaseDocument = new ImprevistoDatabaseDocument();
        imprevistoDatabaseDocument.name = imprevisto.name;
        imprevistoDatabaseDocument.description = imprevisto.description;
        imprevistoDatabaseDocument.forPlayer = forPlayer;
        this.imprevistiUsati.Add(imprevistoDatabaseDocument);
    }

    public void ClearImprevistoUsato()
    {
        this.imprevistiUsati.Clear();
        Imprevisto imprevisto = ScriptableObject.CreateInstance<Imprevisto>();
        imprevisto.name = "null";
        imprevisto.description = "null";
        AddImprevistoUsato(imprevisto, "null");
    }
}