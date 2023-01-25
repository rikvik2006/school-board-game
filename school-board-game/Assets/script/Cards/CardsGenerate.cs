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

    private string[] letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
    private int[] letterCount = new int[26];
    private int generateCards = 0;

    //Card spacing
    public Vector3 cardSpacing;
    private Vector3 currentPosition;

    void Start()
    {
        currentPosition = cardPosition;
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

            GameObject card = Instantiate(cardPrefab, currentPosition, Quaternion.identity);

            card.transform.LookAt(center);
            currentPosition += cardSpacing;

            Quaternion rotation = Quaternion.LookRotation(center - card.transform.position, Vector3.up);
            card.transform.rotation = rotation;
            card.transform.Rotate(Vector3.up, 90f);

            Debug.Log(letter);
            cardLetter.text = letter;
            generateCards++;
        }
    }
}
