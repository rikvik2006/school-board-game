using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordDatabase : MonoBehaviour
{

    [SerializeField]
    public WordAssigner[] wordsAssingers;

    // Add a new letter in the wordsAssiger array (add a letter in the database)
    public void AddLetter(string word, string player)
    {
        WordAssigner wordAssigner = new WordAssigner();
        wordAssigner.letter = word;
        wordAssigner.forPlayer = player;
        wordsAssingers.Append(wordAssigner);
    }

    // Get all the letters for a player
    public string[] GetLettersForPlayer(string player)
    {
        string[] letters = { };
        foreach (WordAssigner wordAssigner in wordsAssingers)
        {
            if (wordAssigner.forPlayer == player)
            {
                letters.Append(wordAssigner.letter);
            }
        }

        return letters;
    }

    // Delete all letters
    public void DeleteAllLetters()
    {
        wordsAssingers = new WordAssigner[] { };
    }

    // Delete all letters for a player
    public void DeleteLettersForPlayer(string player)
    {
        foreach (WordAssigner wordAssigner in wordsAssingers)
        {
            if (wordAssigner.forPlayer == player)
            {
                wordsAssingers = wordsAssingers.Where(val => val != wordAssigner).ToArray();
            }
        }
    }
}
