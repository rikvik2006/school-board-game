using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CineMachineCameraTrasition : MonoBehaviour
{
    public CinemachineBrain brain;
    public CinemachineVirtualCamera camera1;
    public CinemachineVirtualCamera camera2;
    public CinemachineVirtualCamera camera3;
    public CinemachineVirtualCamera camera4;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsTransitionComplete())
        {
            ChangeCamera();
        }
    }

    public void ChangeCamera()
    {
        camera1.Priority = 103;
        camera2.Priority = 102;
        camera3.Priority = 101;
        camera4.Priority = 100;



        // camera1.Priority = 100;
        // camera2.Priority = 101;
        // camera3.Priority = 102;
        // camera4.Priority = 103;
    }

    // Check if the cinemachine trasition is complete
    public bool IsTransitionComplete()
    {
        return brain.IsBlending == false;
    }
}
