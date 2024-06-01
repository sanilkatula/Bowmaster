using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HandleStringInteraction : MonoBehaviour
{
    public AudioSource audioToPause; // Audio 2
    public AudioSource audioToPlay; // Audio 3
    public ActionBasedController leftController; // The left controller interacting with the string
    public ActionBasedController rightController; // The right controller interacting with the string

    private bool isTriggerPressed = false;

    void Update()
    {
        // Check if the trigger button is pressed on either controller
        bool leftTriggerValue = leftController.selectAction.action.ReadValue<float>() > 0.1f;
        bool rightTriggerValue = rightController.selectAction.action.ReadValue<float>() > 0.1f;

        if (leftTriggerValue || rightTriggerValue)
        {
            if (!isTriggerPressed)
            {
                isTriggerPressed = true;
                OnTriggerPressed();
            }
        }
        else
        {
            if (isTriggerPressed)
            {
                isTriggerPressed = false;
                OnTriggerReleased();
            }
        }
    }

    private void OnTriggerPressed()
    {
        if (audioToPause != null && audioToPause.isPlaying)
        {
            audioToPause.Pause();
            Debug.Log("Audio 2 paused because string was grabbed with trigger button.");
        }

        if (audioToPlay != null)
        {
            audioToPlay.Play();
            Debug.Log("Audio 3 started playing because string was grabbed with trigger button.");
        }
    }

    private void OnTriggerReleased()
    {
        if (audioToPlay != null && audioToPlay.isPlaying)
        {
            audioToPlay.Stop();
            Debug.Log("Audio 3 stopped because trigger button was released.");
        }
    }
}
