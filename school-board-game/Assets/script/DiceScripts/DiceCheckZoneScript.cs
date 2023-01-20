using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    Vector3 diceVelocity;

    void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelocity;
    }

    private void OnTriggerStay(Collider collider)
    {
        if (diceVelocity.x == 0f && diceVelocity.y == 0f && diceVelocity.z == 0f)
        {
            switch (collider.gameObject.name)
            {
                case "Face1":
                    DiceNumberTextScript.diceNumber = 6;
                    break;
                case "Face2":
                    DiceNumberTextScript.diceNumber = 5;
                    break;
                case "Face3":
                    DiceNumberTextScript.diceNumber = 4;
                    break;
                case "Face4":
                    DiceNumberTextScript.diceNumber = 3;
                    break;
                case "Face5":
                    DiceNumberTextScript.diceNumber = 2;
                    break;
                case "Face6":
                    DiceNumberTextScript.diceNumber = 1;
                    break;
            }
        }
    }
}
