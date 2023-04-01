using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class TextSubmit : MonoBehaviour
{
    public RectTransform submitForm;
    public TextMeshProUGUI playerNameText;
    public TMP_InputField inputField;
    public PopupWindow popupWindow;
    [Space]
    [SerializeField]
    private PlayerMoveDatabase playerMoveDatabase;
    [SerializeField]
    private GameObject inventory;

    // BUG: This is not working
    [HideInInspector] public string playerName;
    private float submitFormStatus = 0;


    public void ShowReactangle()
    {
        if (submitFormStatus == 0)
        {
            submitForm.gameObject.SetActive(true);
            StartCoroutine(ShowReactangleCoroutine());
            playerName = playerNameText.text;
            submitFormStatus = 1;
        }
    }

    public void HideReactangle(string state)
    {
        if (submitFormStatus == 1)
        {
            StartCoroutine(HideReactangleCoroutine(state));
            playerName = "";
            submitFormStatus = 0;
        }
    }

    public void SubmitForm()
    {
        Debug.Log("Submit form status: " + submitFormStatus);
        if (submitFormStatus == 1)
        {
            Debug.Log("In the submit form if statement");
            StartCoroutine(CheckTheWordInDictionary("https://api.dictionaryapi.dev/api/v2/entries/en/" + inputField.text, OnDictionaryCheckCompleted));
            HideReactangle("submit");
            // StartCoroutine(DisableInventory());
            // CloseInvetory.CloseInventory();
            // popupWindow.AddToQueue("Word submitted");
        }
    }

    private void OnDictionaryCheckCompleted(DictionaryEntry[] dictionaryEntry)
    {
        Debug.Log("After dictionary check. Before Frist return");
        if (dictionaryEntry[0].Equals(null)) return;
        Debug.Log("After dictionary check. After Frist return");

        // Debug.Log("Word from api: " + dictionaryEntry[0].word);
        if (dictionaryEntry[0].word != inputField.text.ToLower())
        {
            Debug.Log("Word not found");
            return;
        }
        else
        {
            Debug.Log("After dictionary check. After second return");
            // Getting the meaning            
            int randomMeaningObj = UnityEngine.Random.Range(0, dictionaryEntry[0].meanings.Count);
            int randomMeaningDefinitionsObj = UnityEngine.Random.Range(0, dictionaryEntry[0].meanings[randomMeaningObj].definitions.Count);

            Debug.Log("Added word for player: " + playerNameText.text + " with " + inputField.text.Length + " tiles");
            playerMoveDatabase.AddPlayerMoveTiles(playerNameText.text, inputField.text.Length, inputField.text, dictionaryEntry[0].meanings[randomMeaningObj].definitions[randomMeaningDefinitionsObj].definition);
        }
        inputField.text = "";
        Debug.Log("Diciontry check Compleated");
    }

    IEnumerator ShowReactangleCoroutine()
    {
        float time = 0;
        Vector2 startPosition = submitForm.anchoredPosition;
        Vector2 finalPosition = submitForm.anchoredPosition + Vector2.up * 350;

        while (time < 1)
        {
            time += Time.deltaTime * 2;
            submitForm.anchoredPosition = Vector2.Lerp(startPosition, finalPosition, time);
            yield return null;
        }
    }

    IEnumerator HideReactangleCoroutine(string state)
    {
        float time = 0;
        Vector2 startPosition = submitForm.anchoredPosition;
        Vector2 finalPosition = submitForm.anchoredPosition + Vector2.down * 350;

        while (time < 1)
        {
            time += Time.deltaTime * 2;
            submitForm.anchoredPosition = Vector2.Lerp(startPosition, finalPosition, time);
            yield return null;
        }

        if (state == "submit")
        {
            inventory.gameObject.SetActive(false);
        }
    }

    IEnumerator CheckTheWordInDictionary(string url, Action<DictionaryEntry[]> callback)
    {
        using (UnityWebRequest response = UnityWebRequest.Get(url))
        {
            Debug.Log("In the coroutine where the word is checked");
            yield return response.SendWebRequest();
            Debug.Log("After the response is sent (word check)");

            if (response.result == UnityWebRequest.Result.ProtocolError || response.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(response.error);
            }

            if (response.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(response.downloadHandler.text);
                DictionaryEntry[] stringfyJson = JsonConvert.DeserializeObject<DictionaryEntry[]>(response.downloadHandler.text);
                callback(stringfyJson);
                yield return stringfyJson;
            }

        }
    }

    IEnumerator DisableInventory()
    {
        yield return new WaitForSeconds(0.5f);
        inventory.SetActive(false);
        yield break;
    }

}
