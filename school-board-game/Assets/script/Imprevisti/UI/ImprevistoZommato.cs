using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoZommato : MonoBehaviour
{
    public GameObject imprevistoCard;
    [SerializeField]
    private ImprevistiEventsMaster imprevistiEventsMaster;
    private Imprevisto imprevisto;

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

        imprevistoCard.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
