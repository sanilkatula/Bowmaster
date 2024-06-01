using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenFeedbackAim : MonoBehaviour
{
    public AudioClip aimLower;
    public AudioClip aimHigher;
    public AudioClip aimRight;
    public AudioClip aimLeft;

    private AudioSource audioSource;
    public float delay = 5.0f;  // Delay in seconds

    private void Start()
    {
        // Ensure there is an AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing. Please add an AudioSource component to this GameObject.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with {collision.gameObject.name} on {gameObject.name} with tag: {gameObject.tag}");

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing. Please add an AudioSource component to this GameObject.");
            return;
        }

        switch (gameObject.tag)
        {
            case "little_up":
                if (aimHigher != null)
                {
                    StartCoroutine(PlayAudioAfterDelay(aimHigher));
                }
                break;

            case "little_down":
                if (aimLower != null)
                {
                    StartCoroutine(PlayAudioAfterDelay(aimLower));
                }
                break;

            case "little_right":
                if (aimRight != null)
                {
                    StartCoroutine(PlayAudioAfterDelay(aimRight));
                }
                break;

            case "little_left":
                if (aimLeft != null)
                {
                    StartCoroutine(PlayAudioAfterDelay(aimLeft));
                }
                break;

            default:
                Debug.LogWarning("Unhandled tag: " + gameObject.tag);
                break;
        }
    }

    private IEnumerator PlayAudioAfterDelay(AudioClip clip)
    {
        yield return new WaitForSeconds(delay);
        audioSource.PlayOneShot(clip);
    }
}
