using System.IO;
using UnityEngine;

public class CharacterPng : MonoBehaviour
{
    public GameObject GameObject;

    public void Capture()
    {
        var rectTransform = GameObject.GetComponent<RectTransform>();
        var delta = rectTransform.sizeDelta;
        var position = rectTransform.position;

        var offset = new RectOffset((int)(delta.x / 2), (int)(delta.x / 2), (int)(delta.y / 2), (int)(delta.y / 2));
        var rect = new Rect(position, Vector2.zero);
        var add = offset.Add(rect);

        var tex = new Texture2D((int)add.width, (int)add.height);
        tex.ReadPixels(add, 0, 0);

        var encodeToPNG = tex.EncodeToPNG();

        File.WriteAllBytes("card.png", encodeToPNG);

        DestroyImmediate(tex);
    }
}