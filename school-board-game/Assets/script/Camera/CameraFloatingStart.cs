using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFloatingStart : MonoBehaviour
{
    public float radius = 5.0f;
    public float speed = 1.0f;
    public float startAngle = 0.0f;
    public float lookAtY = 0.0f;

    private float currentAngle = 0.0f;
    private Vector3 startPos;
    private Vector3 endPos;

    void Start()
    {
        startPos = new Vector3(Mathf.Cos(startAngle) * radius, 20f, Mathf.Sin(startAngle) * radius);

        transform.position = startPos;
        currentAngle = startAngle;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle += Time.deltaTime * speed;
        endPos = new Vector3(Mathf.Cos(currentAngle) * radius, 20f, Mathf.Sin(currentAngle) * radius);
        transform.position = Vector3.Lerp(transform.position, endPos, Time.deltaTime);

        transform.LookAt(new Vector3(0, lookAtY, 0));
    }
}
