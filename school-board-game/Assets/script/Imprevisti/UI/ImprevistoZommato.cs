using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoZommato : MonoBehaviour
{
    public GameObject imprevistoCard;

    // Start is called before the first frame update
    void Start()
    {
        transform.parent.gameObject.SetActive(false);
    }

    public void AcceptedImprevisto()
    {
        // TODO: Implementare la logica per accettare l'imprevisto, e per eseguire l'imprevisto
        imprevistoCard.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
