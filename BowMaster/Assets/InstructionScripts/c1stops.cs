using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class c1stops : MonoBehaviour
{
    public AudioSource instructionAudioSource;

    private bool isGrabbed = false;

    void Start()
    {
        // Ensure the audio source is playing at the start
        if (instructionAudioSource != null)
        {
            instructionAudioSource.Play();
            Debug.Log("Audio started playing.");
        }
    }

    void Update()
    {
        if (isGrabbed && instructionAudioSource.isPlaying)
        {
            instructionAudioSource.Stop();
            Debug.Log("Audio stopped.");
        }
    }

    // This method will be called when a collision is detected
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bow"))
        {
            isGrabbed = true;
            Debug.Log("Bow grabbed.");
        }
    }
}
