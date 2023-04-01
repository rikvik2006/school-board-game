using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayZommedImprevisto : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI cardTitle;
    [SerializeField]
    private TextMeshProUGUI cardDescription;
    [SerializeField]
    private ImprevistoDisplay imprevistoDisplay;
    private Imprevisto imprevisto;

    void Start()
    {
        imprevisto = imprevistoDisplay.imprevisto;
    }

    // Update is called once per frame
    void Update()
    {
        imprevisto = imprevistoDisplay.imprevisto;
        cardTitle.text = imprevisto.name;
        cardDescription.text = imprevisto.description;
    }
}
