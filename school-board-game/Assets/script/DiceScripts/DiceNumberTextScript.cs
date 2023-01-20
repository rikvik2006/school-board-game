using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNumberTextScript : MonoBehaviour
{

    TextMesh text;
    public static int diceNumber;

    private void Start()
    {
        text = GetComponent<TextMesh>();
    }

    private void Update()
    {
        text.text = diceNumber.ToString();
    }
}
