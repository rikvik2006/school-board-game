using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsGenerate : MonoBehaviour
{
    public GameObject cardPrefab;
    public Vector3 cardPosition;
    public TextMesh cardLetter;

    private string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int[] letterCount = new int[26];
    private int generateCards = 0;

    void Start()
    {
        GenerateCards();
    }

    private void GenerateCards()
    {
        while (generateCards < 10)
        {
            int letterIndex = Random.Range(0, letters.Length);
            string letter = letters[letterIndex];

            if (letterCount[letterIndex] >= 2)
            {
                continue;
            }

            letterCount[letterIndex]++;

            GameObject card = Instantiate(cardPrefab, cardPosition, Quaternion.Euler(0, 90, 0));

            cardLetter.text = letter;

            if (cardPosition.x == 0)
            {
                cardPosition += new Vector3(3.6f, 0, 0);
                Debug.Log(cardPosition + new Vector3(3.6f, 0, 0));
            }
            else if (cardPosition.z == 0)
            {
                cardPosition += new Vector3(0, 0, 3.6f);
            }
            generateCards++;
        }
    }
}
