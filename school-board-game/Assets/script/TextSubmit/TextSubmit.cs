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

    public void HideReactangle()
    {
        if (submitFormStatus == 1)
        {
            StartCoroutine(HideReactangleCoroutine());
            playerName = "";
            submitFormStatus = 0;
        }
    }

    public void SubmitForm()
    {
        if (submitFormStatus == 1)
        {
            StartCoroutine(CheckTheWordInDictionary("https://api.dictionaryapi.dev/api/v2/entries/en/" + inputField.text, OnDictionaryCheckCompleted));
        }
    }

    private void OnDictionaryCheckCompleted(DictionaryEntry[] dictionaryEntry)
    {
        if (dictionaryEntry[0].Equals(null)) return;

        if (dictionaryEntry[0].word != inputField.text)
        {
            Debug.Log("Word not found");
            return;
        }
        else
        {
            Debug.Log("Word found");
            HideReactangle();
        }
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

    IEnumerator HideReactangleCoroutine()
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
    }

    IEnumerator CheckTheWordInDictionary(string url, Action<DictionaryEntry[]> callback)
    {
        using (UnityWebRequest response = UnityWebRequest.Get(url))
        {
            yield return response.SendWebRequest();

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

}
