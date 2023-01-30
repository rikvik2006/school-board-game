using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordDatabase : MonoBehaviour
{

    [SerializeField]
    public List<WordAssigner> wordsAssingers;

    // Add a new letter in the wordsAssiger array (add a letter in the database)
    public void AddLetter(string word, string player)
    {

        WordAssigner wordAssigner = new WordAssigner();
        wordAssigner.letter = word;
        wordAssigner.forPlayer = player;
        // Debug.Log($"Letter: {wordAssigner.letter} for player: {wordAssigner.forPlayer}");


        // Add the new letter to the array
        wordsAssingers.Add(wordAssigner);
        // Debug.Log($"wordsAssingers: {wordsAssingers.Count}");
    }

    // Get all the letters for a player
    public List<string> GetLettersForPlayer(string player)
    {
        List<string> letters = new List<string>();
        foreach (WordAssigner wordAssigner in wordsAssingers)
        {
            if (wordAssigner.forPlayer == player)
            {
                letters.Add(wordAssigner.letter);
            }
        }

        return letters;
    }

    // Delete all letters
    public void DeleteAllLetters()
    {
        wordsAssingers = new List<WordAssigner>();
    }

    // Delete all letters for a player
    public void DeleteLettersForPlayer(string player)
    {
        foreach (WordAssigner wordAssigner in wordsAssingers)
        {
            // If the letter is for the player, delete it
            if (wordAssigner.forPlayer == player)
            {
                wordsAssingers.Remove(wordAssigner);
            }
        }
    }
}
