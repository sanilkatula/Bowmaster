using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scorecollision : MonoBehaviour
{
    public AudioClip audioClip10pt;
    public AudioClip audioClip8pt;
    public AudioClip audioClip6pt;
    public AudioClip audioClip2pt;

    public Transform targetCenter; // Reference to the center of the target
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No AudioSource component found on this GameObject. Please add one.");
        }
        if (targetCenter == null)
        {
            Debug.LogError("No target center set. Please assign the target center Transform in the inspector.");
        }
        else
        {
            Debug.Log($"Target center position: {targetCenter.position}");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision detected with {collision.gameObject.name} on {gameObject.name}");

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing. Please add an AudioSource component to this GameObject.");
            return;
        }
        if (targetCenter == null)
        {
            Debug.LogError("Target center is not assigned.");
            return;
        }

        // Calculate the distance from the collision point to the center of the target in 3D space
        Vector3 collisionPoint = collision.contacts[0].point;
        float distance = Vector3.Distance(collisionPoint, targetCenter.position);

        Debug.Log($"Collision point: {collisionPoint}, Target center: {targetCenter.position}, Distance: {distance}");

        // Assign points based on the distance
        int points = 0;
        AudioClip clipToPlay = null;

        if (distance <= 0.2) // Gold radius
        {
            points = 10;
            clipToPlay = audioClip10pt;
            scoremanager.AddMessage("10 points");
            Debug.Log("Hit in gold zone: 10 points");
        }
        else if (distance <= 0.37f) // Red radius
        {
            points = 8;
            clipToPlay = audioClip8pt;
            scoremanager.AddMessage("8 points");
            Debug.Log("Hit in red zone: 8 points");
        }
        else if (distance <= 0.5994f) // Blue radius
        {
            points = 6;
            clipToPlay = audioClip6pt;
            scoremanager.AddMessage("6 points");
            Debug.Log("Hit in blue zone: 6 points");
        }
        else if (distance <= 0.896f) // Black radius
        {
            points = 2;
            clipToPlay = audioClip2pt;
            scoremanager.AddMessage("2 points");
            Debug.Log("Hit in black zone: 2 points");
        }
        else
        {
            Debug.LogWarning("Collision point is outside the scoring area.");
        }

        // Update the score and play the corresponding audio
        if (points > 0)
        {
            scoremanager.AddScore(points);
            if (clipToPlay != null)
            {
                audioSource.PlayOneShot(clipToPlay);
                Debug.Log($"Playing audio for {points}pt hit.");
            }
        }
    }
}
