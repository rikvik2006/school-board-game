using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ImprevistoDisplay : MonoBehaviour
{
    public Imprevisto imprevisto;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    // Start is called before the first frame update
    void Start()
    {
        Imprevisto imprevistoNull = ScriptableObject.CreateInstance<Imprevisto>();
        imprevistoNull.name = "All is fine";
        // Traducimi in inglse questo: Non ci sono imprevisti, tutto è traquillo.
        imprevistoNull.description = "There are no chances, everything is quiet.";
        this.imprevisto = imprevistoNull;
    }

    public void SetImprevisto(Imprevisto imprevisto)
    {
        this.imprevisto = imprevisto;
    }

    private void Update()
    {
        titleText.text = imprevisto.name;
        descriptionText.text = imprevisto.description;
    }
}
