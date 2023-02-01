using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSubmit : MonoBehaviour
{
    public RectTransform submitForm;
    public TextMeshProUGUI playerNameText;
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

}
