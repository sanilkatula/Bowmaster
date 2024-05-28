using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandleStringGrab : MonoBehaviour
{
    public AudioSource audioToStop; // Audio 2
    public AudioSource audioToPlayOnGrab; // Audio 3
    public int maxPlayCount = 2; // Maximum number of times to play the audio

    private XRGrabInteractable grabInteractable;
    public bool playAudio3 = true; // Counter for the number of times the string has been grabbed

    void Start()
    {
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Subscribe to the select entered and exited events
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(OnGrabString);
            grabInteractable.selectExited.AddListener(OnReleaseString);
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from the select entered and exited events
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(OnGrabString);
            grabInteractable.selectExited.RemoveListener(OnReleaseString);
        }
    }

    // This method will be called when the string is grabbed
    private void OnGrabString(SelectEnterEventArgs args)
    {

        if (audioToStop != null && audioToStop.isPlaying)
        {   audioToStop.Pause();
            Debug.Log("Audio 2 paused because string was grabbed.");
        }

        if (playAudio3 == true)
        {

            if (audioToPlayOnGrab != null)
            {
                audioToPlayOnGrab.Play();
                Debug.Log("Audio 3 started playing because string was grabbed.");
                playAudio3 = false;

            }

        }
        else
        {
            Debug.Log("Max play count reached. Audio will not play.");
        }
    }

    // This method will be called when the string is released
    private void OnReleaseString(SelectExitEventArgs args)
    {
        if (audioToPlayOnGrab != null && audioToPlayOnGrab.isPlaying)
        {
            audioToPlayOnGrab.Stop();
            Debug.Log("Audio 3 stopped because string was released.");
        }
    }
}
