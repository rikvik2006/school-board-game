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
    [SerializeField]
    private GameObject imprevistoCard;
    private ImprevistoDisplay imprevistoDisplay;
    [SerializeField]
    // ImprevistiDatabase è una clasese che serve per contenere gli imprerivsti assegnati hai giocatori quando vanno sopra a una casella imprevisto.
    private ImprevistiDatabase imprevistiDatabase;
    public string Nameplayer { get; set; }

    void Start()
    {
        imprevistoCard.SetActive(false);
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

        if (gameControl.gameIsStarted != true)
        {
            popupWindow.AddToQueue("Game isn't started yet");
            return;
        }

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

        ShowImprevistoCard(namePlayer);

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

    private void ShowImprevistoCard(string namePlayer)
    {
        Nameplayer = namePlayer;
        ImprevistiEventsMaster.Nameplayer = namePlayer;
        if (imprevistoCard.activeSelf == false)
        {
            imprevistoCard.SetActive(true);
            imprevistoDisplay = imprevistoCard.GetComponent<ImprevistoDisplay>();
            ImprevistoDatabaseDocument imprevistoAssegnato = imprevistiDatabase.imporevistiAssegnati.Find((imprevisto) => imprevisto.forPlayer == namePlayer);

            // Controlliamo se il giocatore non ha imprevisti assegnati, in tal caso settiamo un imprevisto di default
            if (imprevistoAssegnato == null)
            {
                Imprevisto noImprevisto = ScriptableObject.CreateInstance<Imprevisto>();
                noImprevisto.name = "All is fine";
                noImprevisto.description = "There are no chances, everything is quiet.";

                imprevistoDisplay.SetImprevisto(noImprevisto);
                return;
            }

            // Prediamo solo i dati che ci interessano, in modo tale da convertire il type ImprevistoDatabaseDocument in Imprevisto
            Imprevisto imprevisto = ScriptableObject.CreateInstance<Imprevisto>();
            imprevisto.name = imprevistoAssegnato.name;
            imprevisto.description = imprevistoAssegnato.description;

            imprevistoDisplay.SetImprevisto(imprevisto);
        }
        else
        {
            imprevistoCard.SetActive(false);
            Debug.Log("Card imprevisto disattivata");
        }
    }

    IEnumerator DisableInventory()
    {
        yield return new WaitForSeconds(3);

        if (gameControl.movePhase == true)
        {
            inventory.SetActive(false);
            foreach (GameObject card in cards)
            {
                card.SetActive(false);
            }
        }
    }
}