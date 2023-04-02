using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using TMPro;

public class CardsManager : MonoBehaviour
{
    public CameraManager cameraManager;
    public GameObject countDownGB;
    public GameObject checkYourCardsText;
    public TextMeshProUGUI countDownText;

    private GameControl gameControl;
    private CardsGenerate cardsGeneratorPlayer1, cardsGeneratorPlayer2, cardsGeneratorPlayer3, cardsGeneratorPlayer4;
    private int countDown = 3;
    private int countDownToCheckCardsSeconds = 0;
    private int countDownToCheckCardsMinute = 2;

    private void Start()
    {
        gameControl = gameObject.GetComponent<GameControl>();
        countDownGB.SetActive(false);
        checkYourCardsText.SetActive(false);
        cardsGeneratorPlayer1 = GameObject.Find("Player1").GetComponent<CardsGenerate>();
        cardsGeneratorPlayer2 = GameObject.Find("Player2").GetComponent<CardsGenerate>();
        cardsGeneratorPlayer3 = GameObject.Find("Player3").GetComponent<CardsGenerate>();
        cardsGeneratorPlayer4 = GameObject.Find("Player4").GetComponent<CardsGenerate>();
        StartGame();
    }

    public void StartGame()
    {
        StartCoroutine(CountDownToStart());
    }

    private void Update()
    {
        // if (!cameraManager.IsPlaing())
        // {
        //     cardsGeneratorPlayer1.GenerateCards();
        //     cardsGeneratorPlayer2.GenerateCards();
        //     cardsGeneratorPlayer3.GenerateCards();
        //     cardsGeneratorPlayer4.GenerateCards();
        // }
    }

    public void GenerateCards()
    {
        cardsGeneratorPlayer1.GenerateCards();
        cardsGeneratorPlayer2.GenerateCards();
        cardsGeneratorPlayer3.GenerateCards();
        cardsGeneratorPlayer4.GenerateCards();

        CheckCards();
        StartCoroutine(CountDownToCheckCards());
    }

    private void CheckCards()
    {
        checkYourCardsText.SetActive(true);
    }

    IEnumerator CountDownToStart()
    {
        while (cameraManager.IsPlaing())
        {
            yield return null;
        }
        countDownGB.SetActive(true);
        while (countDown > 0)
        {
            countDownGB.GetComponent<TextMeshProUGUI>().text = countDown.ToString();
            yield return new WaitForSeconds(1f);
            countDown--;
        }

        countDownGB.GetComponent<TextMeshProUGUI>().text = "The game has started!";
        GenerateCards();
        gameControl.gameIsStarted = true;
        yield return new WaitForSeconds(1f);
        countDownGB.SetActive(false);
    }

    IEnumerator CountDownToCheckCards()
    {
        while (countDownToCheckCardsMinute > 0 && countDownToCheckCardsSeconds >= 0)
        {
            // Debug.Log("In the while loop");

            if (countDownToCheckCardsSeconds <= 0 && countDownToCheckCardsMinute > 0)
            {
                countDownToCheckCardsMinute--;
                countDownToCheckCardsSeconds = 59;
            }
            if (countDownToCheckCardsMinute <= 0 && countDownToCheckCardsSeconds <= 0)
            {
                // Exit from the loop and the corutine
                yield break;
            }

            // Debug.Log($"{countDownToCheckCardsMinute.ToString()}:{countDownToCheckCardsSeconds.ToString()}");
            countDownText.text = $"{countDownToCheckCardsMinute.ToString()}:{countDownToCheckCardsSeconds.ToString()}";
            yield return new WaitForSeconds(1f);
            countDownToCheckCardsSeconds--;
        }

        yield return null;
    }
}
