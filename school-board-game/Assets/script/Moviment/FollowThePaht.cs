using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePaht : MonoBehaviour
{
    public Transform[] waypoints;
    [SerializeField]
    private float moveSpeed = 1f;
    [HideInInspector]
    public int waypointIndex = 0;
    public bool moveallowed = false;
    // Start is called before the first frame update
    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, waypoints[waypointIndex].transform.position.z);
    }

    // Update is called once per frame
    private void Update()
    {
        if (moveallowed)
        {
            Move();
        }
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == waypoints[waypointIndex].transform.position)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} Won");
        }
    }
}
