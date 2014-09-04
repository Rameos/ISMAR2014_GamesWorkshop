using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceGame : MonoBehaviour 
{
    List<GameObject> forceFields = new List<GameObject>();
    public GameObject forceFieldPrefab;
    GameObject arCamera;
    void Start()
    {
        arCamera = GameObject.Find("ARCamera");
	}
	
	void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Vector2 touchPosition =  Input.GetTouch(i).position;
                Ray ray = arCamera.camera.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 rotation = Vector3.zero;

                    Vector2 toTarget = hit.point - arCamera.transform.position;
                    if (Mathf.Abs(toTarget.x) > Mathf.Abs(toTarget.y))
                    {
                        if (toTarget.x > 0)
                            rotation.z = 0;
                        else
                            rotation.z = 180;
                    }
                    else
                    {
                        if (toTarget.y > 0)
                            rotation.z = 90;
                        else
                            rotation.z = 270;
                    }


                    forceFields.Add(Instantiate(forceFieldPrefab, hit.point, Quaternion.Euler(rotation)) as GameObject);
                }
            }

            ++i;
        }	
	}
}
