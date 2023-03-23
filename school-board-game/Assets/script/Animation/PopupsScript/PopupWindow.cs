using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupWindow : MonoBehaviour
{
    public TMP_Text popupText;
    private GameObject canvas;
    [SerializeField]
    private Animator popupAnimator;
    private Queue<string> popupQueue; // Queue is a data structure that works like a line, first in first out (FIFO)
    private bool isActive;
    private Coroutine queueChecker;

    private void Start()
    {
        canvas = transform.GetChild(0).gameObject;
        // popupAnimator = canvas.GetComponent<Animator>();
        canvas.SetActive(false);
        popupQueue = new Queue<string>();
    }

    public void AddToQueue(string text)
    {
        popupQueue.Enqueue(text);
        if (queueChecker == null)
        {
            queueChecker = StartCoroutine(CheckQueue());
        }
    }

    public void ShowPopup(string text)
    {
        isActive = true;
        canvas.SetActive(true);
        popupText.text = text;
        popupAnimator.Play("PopupAnimation");
    }

    private IEnumerator CheckQueue()
    {
        do
        {
            ShowPopup(popupQueue.Dequeue());
            do
            {
                yield return null;
            } while (!popupAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"));
        } while (popupQueue.Count > 0);
        canvas.SetActive(false);
        queueChecker = null;
    }
}
