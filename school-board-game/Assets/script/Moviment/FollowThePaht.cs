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
    public bool goBackwards = false;
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
        else if (goBackwards)
        {
            GoBackwards();
        }
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Length - 1)
        {
            // Getting the position of the waypoint
            Vector3 wayPointPosition = waypoints[waypointIndex].transform.position;
            // Getting only the x and z position of the waypoint, keeping the y position of the player
            wayPointPosition.Set(wayPointPosition.x, transform.position.y, wayPointPosition.z);
            // Moving the player to the waypoint
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

    public void GoBackwards()
    {
        if (waypointIndex > 0)
        {
            Vector3 wayPointPosition = waypoints[waypointIndex - 1].transform.position;

            wayPointPosition.Set(wayPointPosition.x, transform.position.y, wayPointPosition.z);
            // Moving the player to the waypoint
            transform.position = Vector3.MoveTowards(transform.position, wayPointPosition, moveSpeed * Time.deltaTime);

            if (transform.position.x == waypoints[waypointIndex - 1].transform.position.x && transform.position.z == waypoints[waypointIndex - 1].transform.position.z)
            {
                waypointIndex -= 1;
            }
        }
    }
}
