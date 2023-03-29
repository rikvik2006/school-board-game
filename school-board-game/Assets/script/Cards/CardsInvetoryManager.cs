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
    public TMP_Text namePlayerText;  // Correct type for TextMeshProUGUI is TMP_Text, i think is a general type for all textmeshpro
    public GameObject noCardInInventory;
    [SerializeField]
    private PlayerMoveDatabase playerMoveDatabase;
    [SerializeField]
    private PopupWindow popupWindow;

    [SerializeField]
    private GameControl gameControl;

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

    public void AddCardForPlayer(string namePlayer)
    {
        PlayerMoveTiles playerMoveTiles = playerMoveDatabase.playerMoveTilesList.Find(x => x.playerName == namePlayer);

        if (gameControl.movePhase == true)
        {
            popupWindow.AddToQueue("You can't send a word in move phase");
            return;
        }

        if (playerMoveTiles != null)
        {
            Debug.Log("Arledy sented a word");
            popupWindow.AddToQueue("You have already sented a word");
            return;
        }

        if (inventory.activeSelf == false)
        {
            inventory.SetActive(true);
            List<string> letters = wordDatabase.GetLettersForPlayer(namePlayer);

            if (letters.Count <= 0)
            {
                noCardInInventory.SetActive(true);
                return;
            }

            noCardInInventory.SetActive(false);
            namePlayerText.text = namePlayer;

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
