using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionHandler : MonoBehaviour
{
    public GameObject target;
    public Vector3 farPosition; // Set this in the Inspector for cube_far
    public Vector3 closePosition; // Set this in the Inspector for cube_close

    private void OnCollisionEnter(Collision collision)
    {


        Debug.Log("Collision detected with: " + collision.gameObject.name);


        switch (gameObject.tag){
            case "far":
            MoveTarget(farPosition);

         Debug.Log("  farPosition done with " + collision.gameObject.name);

            break;

            case "close":
            MoveTarget(closePosition);
                     Debug.Log("  closePosition done with " + collision.gameObject.name);

            break;


        }
    }

    private void MoveTarget(Vector3 newPosition)
    {
        if (target != null)
        {
            Debug.Log("Moving target to: " + newPosition);
            target.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Target not set in the inspector!");
        }
    }

}



