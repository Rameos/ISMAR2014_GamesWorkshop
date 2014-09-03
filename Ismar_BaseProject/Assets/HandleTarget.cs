﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandleTarget : MonoBehaviour {

    public GameObject target;
    public Text text;

    public void ShowTarget()
    {
        GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

        foreach(GameObject cube in cubeObjects)
        {
            cube.GetComponent<RotateCube>().ChangeLocation();
        }

        target.SetActive(!target.activeSelf);

        if (target.activeSelf)
            text.text = "Hide Target";
        else
            text.text = "Show Target";
    }
}
