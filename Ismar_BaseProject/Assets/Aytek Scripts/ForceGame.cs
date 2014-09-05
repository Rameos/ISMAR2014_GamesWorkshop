using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceGame : MonoBehaviour 
{
    List<GameObject> forceFields = new List<GameObject>();
    public GameObject forceFieldPrefab;
    GameObject arCamera;

    public Texture crosshairTexture;
    public float crossHairRadius = 20;
    public bool snapToGrid = false;

    public enum GameState 
    {
        Running,
        Prompting,
        Win
    }

    void Awake()
    {
        arCamera = GameObject.Find("ARCamera");
	}

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2 - crossHairRadius, Screen.height / 2 - crossHairRadius, crossHairRadius * 2, crossHairRadius * 2);

        //GUI.DrawTexture(rect, crosshairTexture);
    }

    void CreateForceFieldUsingAngle()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Vector2 touchPosition = Input.GetTouch(i).position;
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

    Vector3 lastWorldPosition = Vector3.zero;

    void CreateForceFieldUsingSweepMotion()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                lastWorldPosition = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = arCamera.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 rotation = Vector3.zero;
                Vector3 direction = hit.point - lastWorldPosition;

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x > 0)
                        rotation.z = 0;
                    else
                        rotation.z = 180;
                }
                else
                {
                    if (direction.y > 0)
                        rotation.z = 90;
                    else
                        rotation.z = 270;
                }

                if (snapToGrid)
                {
                    lastWorldPosition.x = Mathf.RoundToInt(lastWorldPosition.x);
                    lastWorldPosition.y = Mathf.RoundToInt(lastWorldPosition.y);
                }


                forceFields.Add(Instantiate(forceFieldPrefab, lastWorldPosition, Quaternion.Euler(rotation)) as GameObject);
            }
        }



        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Input.GetTouch(i).position;
                Ray ray = arCamera.camera.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    lastWorldPosition = hit.point;
                }
            }

            ++i;
        }

        i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Vector2 touchPosition = Input.GetTouch(i).position;
                Ray ray = arCamera.camera.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 rotation = Vector3.zero;
                    Vector3 direction = hit.point - lastWorldPosition;

                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        if (direction.x > 0)
                            rotation.z = 0;
                        else
                            rotation.z = 180;
                    }
                    else
                    {
                        if (direction.y > 0)
                            rotation.z = 90;
                        else
                            rotation.z = 270;
                    }

                    if (snapToGrid)
                    {
                        lastWorldPosition.x = Mathf.RoundToInt(lastWorldPosition.x);
                        lastWorldPosition.y = Mathf.RoundToInt(lastWorldPosition.y);
                    }


                    forceFields.Add(Instantiate(forceFieldPrefab, lastWorldPosition, Quaternion.Euler(rotation)) as GameObject);
                }
            }

            ++i;
        }
    }
	
	void Update()
    {
        CreateForceFieldUsingSweepMotion();
        //CreateForceFieldUsingAngle();
	}

    void Reset()
    {
        for (int i = 0; i < forceFields.Count; i++)
        {
            Destroy(forceFields[i]);
        }
    }

    void HitTheWall()
    {
        Reset();
    }
}
