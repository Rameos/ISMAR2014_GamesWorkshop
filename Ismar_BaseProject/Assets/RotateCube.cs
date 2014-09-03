using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour
{
    private GameObject targetRotation;

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

        Debug.Log(targetRotation.transform.rotation.eulerAngles);
    }

    void Update()
    {
        if (gameObject.transform.rotation != targetRotation.transform.rotation)
            gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation.transform.rotation, 0.2f);
    }
}
