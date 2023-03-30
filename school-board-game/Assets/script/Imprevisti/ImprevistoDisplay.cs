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
        titleText.text = imprevisto.name;
        descriptionText.text = imprevisto.description;
    }
}
