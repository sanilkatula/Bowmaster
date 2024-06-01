using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedbackAim : MonoBehaviour
{
    public AudioClip aimLower;
    public AudioClip aimHigher;
    public AudioClip aimRight;
    public AudioClip aimLeft;

    private AudioSource audioSource;

    void Start()
    {
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
            case "lower":
                if (aimHigher != null)
                {
                    audioSource.PlayOneShot(aimHigher);
                }
                break;

            case "upper":
                if (aimLower != null)
                {
                    audioSource.PlayOneShot(aimLower);
                }
                break;

            case "right":
                if (aimRight != null)
                {
                    audioSource.PlayOneShot(aimRight);
                }
                break;

            case "left":
                if (aimLeft != null)
                {
                    audioSource.PlayOneShot(aimLeft);
                }
                break;
                
            default:
                Debug.LogWarning("Unhandled tag: " + gameObject.tag);
                break;
        }
    }
}
