using UnityEngine;

public class TargetCollision : MonoBehaviour
{
    // Center of the target
    private Vector3 targetCenter = new Vector3(1f, 3.29f, 11.55f);

    private scoremanager scoreManager;

    void Start()
    {
        // Find the scoremanager in the scene
        scoreManager = FindObjectOfType<scoremanager>();
        if (scoreManager == null)
        {
            Debug.LogError("Score Manager is not found in the scene!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (scoreManager == null) return;

        // Get the collision point
        ContactPoint contact = collision.contacts[0];
        Vector3 collisionPoint = contact.point;

        // Compare the collision point with the target center
        float xDiff = collisionPoint.x - targetCenter.x;
        float yDiff = collisionPoint.y - targetCenter.y;

        // Provide feedback based on collision point
        string feedback = "";
        if (Mathf.Abs(yDiff) > Mathf.Abs(xDiff))
        {
            if (yDiff > 0){
                Debug.Log("Aim a little lower.");
                feedback = "Aim a little lower.";}
            else{
                
                Debug.Log("Aim a little higher.");
                feedback = "Aim a little higher.";}
        }
        else
        {
            if (xDiff > 0){
                
                Debug.Log("Aim a little left.");
                feedback = "Aim a little left.";}
            else{
                
                Debug.Log("Aim a little right.");
                feedback = "Aim a little right.";}
        }

        // Send feedback to scoremanager
        scoreManager.UpdateHint(feedback);
    }
}
