using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImprevistoZoom : MonoBehaviour
{
    public GameObject imprevistoZoom;

    public void ShowImprevistoZoom()
    {
        imprevistoZoom.SetActive(true);
        gameObject.SetActive(false);
    }
}
