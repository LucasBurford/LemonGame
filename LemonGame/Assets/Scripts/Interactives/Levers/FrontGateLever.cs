using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FrontGateLever : MonoBehaviour
{
    public PlayableDirector frontGate;
    public PlayableDirector backGate;

    public void OnInteract()
    {
        frontGate.Play();
        backGate.Play();
    }
}
