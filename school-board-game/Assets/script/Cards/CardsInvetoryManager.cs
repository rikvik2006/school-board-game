using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsInvetoryManager : MonoBehaviour
{
    public GameObject[] cards;
    public GameObject inventory;
    public WordDatabase wordDatabase;

    void Start()
    {
        inventory.SetActive(false);
        foreach (GameObject card in cards)
        {
            card.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCardForPlayerOne()
    {
        if (inventory.activeSelf == false)
        {
            inventory.SetActive(true);
            List<string> letters = wordDatabase.GetLettersForPlayer("Player1");

            int i = 0;
            foreach (GameObject card in cards)
            {
                card.SetActive(true);
                card.GetComponentInChildren<TextMeshProUGUI>().text = letters[i];
                Debug.Log("Letter: " + letters[i] + " i: " + i);
                i++;
                break;
            }

            // For each letter in the list, add a card to the player 1 inventory and update the database
            foreach (string letter in letters)
            {
                foreach (GameObject card in cards)
                {
                    if (card.activeSelf == false)
                    {
                        card.SetActive(true);
                        card.GetComponentInChildren<TextMeshProUGUI>().text = letter;
                        break;
                    }
                }
            }
        }
        else
        {
            inventory.SetActive(false);
            foreach (GameObject card in cards)
            {
                card.SetActive(false);
            }
        }
    }
}
