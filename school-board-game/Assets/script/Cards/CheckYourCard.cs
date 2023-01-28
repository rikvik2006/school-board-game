using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckYourCard : MonoBehaviour
{

    public WordDatabase wordDatabase;
    public GameObject inventory;
    public GameObject card;



    void Start()
    {
        // Get all the letters for the player
        List<string> letters = wordDatabase.GetLettersForPlayer("player1");
        // Get the inventory
        // Inventory inventoryScript = inventory.GetComponent<Inventory>();
        // Check if the player has all the letters
        bool hasAllLetters = true;
        foreach (string letter in letters)
        {
            // 
        }
        // If the player has all the letters, he can go to the next level
        if (hasAllLetters)
        {
            Debug.Log("You can go to the next level");
        }
        else
        {
            Debug.Log("You don't have all the letters");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
