using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoZoom : MonoBehaviour
{
    public GameObject imprevistoZoom;
    [SerializeField]
    private GameControl gameControl;
    [SerializeField]
    private PopupWindow popupWindow;
    [SerializeField]
    private ImprevistoExecuted imprevistoExecuted;


    public void ShowImprevistoZoom()
    {
        if (gameControl.imprevistiPhase != true)
        {
            popupWindow.AddToQueue("You can't do this in this pahse");
            return;
        }

        ImprevistoDatabaseDocument imprevistoDocument = imprevistoExecuted.imprevistiUsati.Find(imprevisto => imprevisto.name == ImprevistiEventsMaster.Nameplayer);
        Debug.Log("NamePlayer from ImprevistoZoom: " + ImprevistiEventsMaster.Nameplayer);

        // if (imprevistoDocument == null)
        // {
        //     popupWindow.AddToQueue("You have arledy executed this unexpected event");
        //     return;
        // }
        imprevistoZoom.SetActive(true);
        gameObject.SetActive(false);
    }
}
