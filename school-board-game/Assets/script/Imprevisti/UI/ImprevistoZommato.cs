using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoZommato : MonoBehaviour
{
    public GameObject imprevistoCard;
    private ImprevistiEventsMaster imprevistiEventsMaster;
    private Imprevisto imprevisto;
    [SerializeField]
    private TextSubmit textSubmit;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.gameObject.SetActive(false);
        imprevistiEventsMaster = gameObject.GetComponent<ImprevistiEventsMaster>();
        imprevisto = imprevistoCard.GetComponent<ImprevistoDisplay>().imprevisto;
    }

    private void Update()
    {
        imprevisto = imprevistoCard.GetComponent<ImprevistoDisplay>().imprevisto;
    }

    public void AcceptedImprevisto()
    {
        // TODO: Implementare la logica per accettare l'imprevisto, e per eseguire l'imprevisto

        Debug.Log("Imprevisto name: " + imprevisto.name);
        imprevistiEventsMaster.StartImprevisto(imprevisto.name);
        Debug.Log("DOPO IL METODO START IMPREVISTO");
        Debug.Log("Lunghezza della lista di imrevisti usati: " + imprevistiEventsMaster.imprevistoExecuted.imprevistiUsati.Count);

        textSubmit.HideInventory();

        // imprevistoCard.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
