using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RotateCube : MonoBehaviour
{
    public int currentField1;
    public int currentField2;
    public int sideShowing;
    public int dirShowing;
    public bool aligned;
    public bool victoryTriggered;
    public GameObject location2;

    private SwipeScript swiper;
    private Vector3 posWork;
    private Vector3 posEdit;
    private Vector3 targetLocation;

    private MeshRenderer targetCube;
    private GameObject targetRotation;

    void Start()
    {
        targetRotation = new GameObject();
        targetRotation.transform.rotation = transform.rotation;

        posWork = transform.position;
        posEdit = location2.transform.position;
        targetLocation = posWork;

        targetCube = GetComponentInChildren<MeshRenderer>();
    }

    public void SetTargetRotation(GameObject gameObject, SwipeScript.rotation dir)
    {
		int rotated = 0;
		float cameraZ = Camera.main.gameObject.transform.rotation.eulerAngles.z;

		if ((cameraZ <= 45 && cameraZ >= 0) || (cameraZ <= 360 && cameraZ >= 315))
		    rotated = 0;
		if ((cameraZ >= 45 && cameraZ <= 135))
			rotated = 1;
		if ((cameraZ >= 135 && cameraZ <= 225))
			rotated = 2;
		if ((cameraZ >= 225 && cameraZ <= 315) || (cameraZ < 360 && cameraZ > 315))
			rotated = 3;

		//Text text = GameObject.Find("Current").GetComponent<Text>();
		//text.text = "" + rotated;

		if (rotated == 2) 
		{
						switch (dir) {
						case SwipeScript.rotation.right:
								targetRotation.transform.Rotate (0, 0, -90, Space.World);
								break;

						case SwipeScript.rotation.left:
								targetRotation.transform.Rotate (0, 0, 90, Space.World);
								break;

						case SwipeScript.rotation.up:
								targetRotation.transform.Rotate (90, 0, 0, Space.World);
								break;

						case SwipeScript.rotation.down:
								targetRotation.transform.Rotate (-90, 0, 0, Space.World);
								break;
						}
				}

		if (rotated == 1) 
		{
			switch (dir) 
			{
			case SwipeScript.rotation.right:
				targetRotation.transform.Rotate (-90, 0, 0, Space.World);
				break;
				
			case SwipeScript.rotation.left:
				targetRotation.transform.Rotate (90, 0, 0, Space.World);
				break;
				
			case SwipeScript.rotation.up:
				targetRotation.transform.Rotate (0, 0, -90, Space.World);
				break;
				
			case SwipeScript.rotation.down:
				targetRotation.transform.Rotate (0, 0, 90, Space.World);
				break;
			}
		}
		if (rotated == 0) 
		{
			switch (dir) 
			{
			case SwipeScript.rotation.right:
				targetRotation.transform.Rotate (0, 0, 90, Space.World);
				break;
				
			case SwipeScript.rotation.left:
				targetRotation.transform.Rotate (0, 0, -90, Space.World);
				break;
				
			case SwipeScript.rotation.up:
				targetRotation.transform.Rotate (-90, 0, 0, Space.World);
				break;
				
			case SwipeScript.rotation.down:
				targetRotation.transform.Rotate (90, 0, 0, Space.World);
				break;
			}
		}
		if (rotated == 3) 
		{
			switch (dir) 
			{
			case SwipeScript.rotation.right:
				targetRotation.transform.Rotate (90, 0, 0, Space.World);
				break;
				
			case SwipeScript.rotation.left:
				targetRotation.transform.Rotate (-90, 0, 0, Space.World);
				break;
				
			case SwipeScript.rotation.up:
				targetRotation.transform.Rotate (0, 0, 90, Space.World);
				break;
				
			case SwipeScript.rotation.down:
				targetRotation.transform.Rotate (0, 0, -90, Space.World);
				break;
			}
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
    }

    public void ChangeLocation()
    {
        if (posWork == targetLocation)
        {
            targetLocation = posEdit;
            SwipeScript.moveable = false;
        }
        else
        {
            targetLocation = posWork;
            SwipeScript.moveable = true;
        }
    }

    void Update()
    {
        if (victoryTriggered)
        {
            targetCube.material.color = new Color(targetCube.material.color.r,
                targetCube.material.color.g, targetCube.material.color.b,
                targetCube.material.color.a - (1f * Time.deltaTime));

            if (targetCube.material.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }

        if (Vector3.Distance(transform.position, posEdit) < 0.1)
        {
            aligned = true;
        }
        else
        {
            aligned = false;
        }

        if (!victoryTriggered)
        {
            if (gameObject.transform.rotation != targetRotation.transform.rotation)
                gameObject.transform.rotation = Quaternion.Lerp(gameObject.transform.rotation, targetRotation.transform.rotation, 0.2f);

            transform.position = Vector3.Lerp(transform.position, targetLocation, 0.3f);
        }
    }
}