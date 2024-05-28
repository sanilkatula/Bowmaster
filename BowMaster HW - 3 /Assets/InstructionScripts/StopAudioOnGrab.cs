using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StopAudioOnGrab : MonoBehaviour
{
    public AudioSource instructionAudioSource; // Old audio
    public AudioSource newAudioSource; // New audio

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        // Ensure the instruction audio source is playing at the start
        if (instructionAudioSource != null)
        {
            instructionAudioSource.Play();
            Debug.Log("Instruction audio started playing.");
        }

        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the select entered event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the select entered event
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }

    // This method will be called when the bow is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        if (instructionAudioSource != null && instructionAudioSource.isPlaying)
        {
            instructionAudioSource.Stop();
            Debug.Log("Instruction audio stopped because bow was grabbed.");
        }

        if (newAudioSource != null)
        {
            newAudioSource.Play();
            Debug.Log("New audio started playing.");
        }
    }
}
