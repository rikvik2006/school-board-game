using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInputChecker : MonoBehaviour
{
    public WordDatabase wordDatabase;
    public TextSubmit textSubmit;
    private TMP_InputField inputField;
    // public TextMeshProUGUI playerNameText;
    private string playerName;
    [SerializeField]
    private List<string> letters = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        // inputField.onValueChanged.AddListener(delegate { CheckInput(); });
        inputField.onValueChanged.AddListener(CheckInput);
    }

    // Update is called once per frame
    void Update()
    {
        if (textSubmit != null)
        {
            playerName = textSubmit.playerNameText.text;
        }
    }

    private void CheckInput(string newValue)
    {
        if (inputField.text.Length > 0)
        {
            letters = wordDatabase.GetLettersForPlayer(playerName);
            // Debug.Log("Player name: " + playerName);
            // Debug.Log("New Value: " + newValue);

            if (letters == null || letters.Count <= 0)
            {
                return;
            }

            foreach (char letter in newValue)
            {
                string upperCaseLetter = letter.ToString().ToUpper();
                if (!letters.Exists((x) => x == upperCaseLetter))
                {
                    // Sostituisci la lettera con una stringa vuota

                    string replace = inputField.text.Replace(letter.ToString(), "");
                    inputField.text = replace;

                    // string replace = inputField.text.Replace(letter.ToString(), "");
                    // Debug.Log("Replace: " + replace);
                    // inputField.text = replace;
                }
            }
        }
    }
}
