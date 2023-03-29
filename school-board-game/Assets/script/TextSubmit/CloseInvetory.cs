using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloseInvetory : MonoBehaviour
{

    public static bool closeInventory = false;
    public static GameObject invetory;

    private void Update()
    {
        if (closeInventory == true)
        {
            CloseInventory();
        }
    }
    public static void CloseInventory()
    {
        invetory.SetActive(false);
        closeInventory = false;
    }
}
