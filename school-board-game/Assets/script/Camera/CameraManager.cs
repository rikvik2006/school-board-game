using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraManager : MonoBehaviour
{
    public PlayableDirector playableDirector;

    public bool IsPlaing()
    {
        return playableDirector.state == PlayState.Playing;
    }
}
