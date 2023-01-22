using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectorRoteating : MonoBehaviour
{
    public float startAngle = 180f;
    public float roteatingVelocity = 0.5f;
    public float rotationPerSecond = 90f;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, startAngle, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationPerSecond * Time.deltaTime, 0);
    }
}
