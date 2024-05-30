using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorecollision : MonoBehaviour
{
    public AudioClip audioClip10pt;
    public AudioClip audioClip8pt;
    public AudioClip audioClip6pt;
    public AudioClip audioClip2pt;
    public static string x = "";

    private AudioSource audioSource;
    public AudioSource audioSourceStop;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject. Please add one.");
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
            case "10pt":
                // scoremanager.AddScore(10 - 8);
                scoremanager.AddScore(10);

                scoremanager.AddMessage("10 points");
                
                // Debug.Log("Score updated for 10pt hit.");
                if (audioClip10pt != null)
                {
                    audioSource.PlayOneShot(audioClip10pt);
                    Debug.Log("Playing audio for 10pt hit.");
                    audioSourceStop = gameObject.AddComponent<AudioSource>();
                    audioSourceStop.Stop();

                }
                // else
                // {
                //     Debug.LogError("Audio clip for 10pt is not assigned.");
                // }
                break;
            case "8pt":
                // scoremanager.AddScore(8 - 6);
                scoremanager.AddScore(8);
                scoremanager.AddMessage("8 points");
                Debug.Log("Score updated for 8pt hit.");
                if (audioClip8pt != null)
                {
                    audioSource.PlayOneShot(audioClip8pt);
                    Debug.Log("Playing audio for 8pt hit.");
                    audioSourceStop = gameObject.AddComponent<AudioSource>();
                    audioSourceStop.Stop();

                }
                // else
                // {
                //     Debug.LogError("Audio clip for 8pt is not assigned.");
                // }
                break;
            case "6pt":
                // scoremanager.AddScore(6 - 2);
                scoremanager.AddScore(6);
                scoremanager.AddMessage("6 points");

                // Debug.Log("Score updated for 6pt hit.");
                if (audioClip6pt != null)
                {
                    audioSource.PlayOneShot(audioClip6pt);
                    Debug.Log("Playing audio for 6pt hit.");
                    audioSourceStop = gameObject.AddComponent<AudioSource>();
                    audioSourceStop.Stop();
                }
                // else
                // {
                //     Debug.LogError("Audio clip for 6pt is not assigned.");
                // }
                break;

            case "2pt":
                scoremanager.AddScore(2);
                scoremanager.AddMessage("2 points");

                // Debug.Log("Score updated for 2pt hit.");
                if (audioClip2pt != null)
                {
                    audioSource.PlayOneShot(audioClip2pt);
                    Debug.Log("Playing audio for 2pt hit.");
                }
                // else
                // {
                //     Debug.LogError("Audio clip for 2pt is not assigned.");
                // }
                break;
            default:
                Debug.LogWarning("Unhandled tag: " + gameObject.tag);
                break;
        }
    }
}