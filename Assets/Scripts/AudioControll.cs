using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControll : MonoBehaviour
{
    public AudioSource audioS;

    public void PlayAudio()
    {
        if (!audioS.isPlaying)
        {
            audioS.Play();
        }
    }
}
