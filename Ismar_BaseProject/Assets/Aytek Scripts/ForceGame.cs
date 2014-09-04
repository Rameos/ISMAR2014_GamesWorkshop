﻿using UnityEngine;
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
                    forceFields.Add(Instantiate(forceFieldPrefab, hit.point, transform.rotation) as GameObject);
                }
            }

            ++i;
        }	
	}
}
