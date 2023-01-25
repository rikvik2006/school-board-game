using UnityEngine;
using System.Collections;

public class ScreanShootTaker : MonoBehaviour
{
    public GameObject targetObject;
    public Camera captureCamera;
    public string savePath;

    void Start()
    {
        savePath = Application.persistentDataPath + "/Screenshot.png";
        Debug.Log(savePath);
        StartCoroutine(CaptureScreenshot());
    }

    IEnumerator CaptureScreenshot()
    {
        // Attiva la camera di cattura e disattiva tutte le altre
        captureCamera.gameObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);

        // Sposta la camera di cattura sulla posizione dell'oggetto target
        captureCamera.transform.position = targetObject.transform.position;
        captureCamera.transform.rotation = targetObject.transform.rotation;

        // Aspetta il prossimo frame per essere sicuro che la scena sia stata renderizzata
        yield return new WaitForEndOfFrame();

        // Cattura l'immagine dalla camera di cattura
        Texture2D texture = new Texture2D(captureCamera.pixelWidth, captureCamera.pixelHeight, TextureFormat.RGB24, false);
        captureCamera.Render();
        RenderTexture.active = captureCamera.targetTexture;
        texture.ReadPixels(new Rect(0, 0, captureCamera.pixelWidth, captureCamera.pixelHeight), 0, 0);
        texture.Apply();

        // Salva l'immagine su disco
        System.IO.File.WriteAllBytes(savePath, texture.EncodeToPNG());

        // Ripristina la configurazione originale della scena
        Camera.main.gameObject.SetActive(true);
        captureCamera.gameObject.SetActive(false);
    }
}