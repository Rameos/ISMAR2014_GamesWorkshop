using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour
{
    private GameObject targetRotation;
    private int sideShowing;
    private int dirShowing;

    void Start()
    {
        targetRotation = new GameObject();
        targetRotation.transform.rotation = transform.rotation;
    }

    public void SetTargetRotation(GameObject gameObject, SwipeScript.rotation dir)
    {
        switch (dir)
        {
            case SwipeScript.rotation.right:
                targetRotation.transform.Rotate(90, 0, 0, Space.World);
                break;

            case SwipeScript.rotation.left:
                targetRotation.transform.Rotate(-90, 0, 0, Space.World);
                break;

            case SwipeScript.rotation.up:
                targetRotation.transform.Rotate(0, 0, 90, Space.World);
                break;

            case SwipeScript.rotation.down:
                targetRotation.transform.Rotate(0, 0, -90, Space.World);
                break;
        }

        if (targetRotation.transform.up == Vector3.up)
        {
            sideShowing = 0;
        }
        else if (targetRotation.transform.up == -Vector3.up)
        {
            sideShowing = 1;
        }
        else if (targetRotation.transform.up == Vector3.right)
        {
            sideShowing = 2;
        }
        else if (targetRotation.transform.up == -Vector3.right)
        {
            sideShowing = 3;
        }
        else if (targetRotation.transform.up == Vector3.forward)
        {
            sideShowing = 4;
        }
        else if (targetRotation.transform.up == -Vector3.forward)
        {
            sideShowing = 5;
        }

        if (targetRotation.transform.right == Vector3.up)
        {
            dirShowing = 0;
        }
        else if (targetRotation.transform.right == -Vector3.up)
        {
            dirShowing = 1;
        }
        else if (targetRotation.transform.right == Vector3.right)
        {
            dirShowing = 2;
        }
        else if (targetRotation.transform.right == -Vector3.right)
        {
            dirShowing = 3;
        }
        else if (targetRotation.transform.right == Vector3.forward)
        {
            dirShowing = 4;
        }
        else if (targetRotation.transform.right == -Vector3.forward)
        {
            dirShowing = 5;
        }

        Debug.Log(sideShowing + " " + dirShowing);
    }

    void Update()
    {
        if (gameObject.transform.rotation != targetRotation.transform.rotation)
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation.transform.rotation, 0.2f);
    }
}
