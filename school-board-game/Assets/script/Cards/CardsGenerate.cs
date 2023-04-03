using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardsGenerate : MonoBehaviour
{
    public GameObject cardPrefab;
    public Vector3 cardPosition;
    public Vector3 center;
    public TextMeshProUGUI cardLetter;
    public WordDatabase wordDatabase;
    public float extraRotation;
    public static bool needNewCards = false;

    private string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int[] letterCount = new int[26];
    private int generateCards = 0;

    //Card spacing
    public Vector3 cardSpacing;
    private Vector3 currentPosition;

    void Start()
    {
        currentPosition = cardPosition;
    }

    private void Update()
    {
        if (needNewCards)
        {
            GenerateCards();
            needNewCards = false;
        }

    }

    public void GenerateCards()
    {
        generateCards = 0;
        currentPosition = cardPosition;
        while (generateCards < 10)
        {
            int letterIndex = Random.Range(0, letters.Length);
            string letter = letters[letterIndex];

            if (letterCount[letterIndex] >= 2)
            {
                continue;
            }

            letterCount[letterIndex]++;

            // Save the letter in the word database
            // Debug.Log("Letter: " + letter + " GameObject: " + gameObject.name);
            wordDatabase.AddLetter(letter, gameObject.name);

            GameObject card = Instantiate(cardPrefab, currentPosition, Quaternion.identity);

            card.transform.LookAt(center);
            currentPosition += cardSpacing;

            Quaternion rotation = Quaternion.LookRotation(center - card.transform.position, Vector3.up);
            card.transform.rotation = rotation;
            card.transform.Rotate(Vector3.up, 90f);
            card.transform.rotation = Quaternion.Euler(0, extraRotation, 0);

            cardLetter.text = letter;
            generateCards++;
        }
    }
}
