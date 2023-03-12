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

    // Custom moviment
    [HideInInspector] public Vector3 destination;
    [HideInInspector] public int currentTiles;
    [HideInInspector] public int destinationTiles;
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
            Vector3 wayPointPosition = waypoints[waypointIndex].transform.position;
            wayPointPosition.Set(wayPointPosition.x, transform.position.y, wayPointPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPosition, moveSpeed * Time.deltaTime);

            if (transform.position.x == waypoints[waypointIndex].transform.position.x && transform.position.z == waypoints[waypointIndex].transform.position.z)
            {
                waypointIndex += 1;
            }
        }
        else
        {
            Debug.Log($"{gameObject.name} Won");
        }
    }

    // private void Move()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);

    //     if (transform.position == destination)
    //     {
    //         moveallowed = false;
    //         currentTiles = destinationTiles;
    //     }
    // }


}
