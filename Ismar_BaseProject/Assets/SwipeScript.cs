﻿using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour
{
    private GameObject selectedObject;
    private GameObject gObject;

    private int[,] finalMatrix1 = new int[3, 3] { { 2, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    private int[,] finalMatrix2 = new int[3, 3] { { 1, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };

    private int[,] currentMatrix1 = new int[3, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
    private int[,] currentMatrix2 = new int[3, 3] { { 2, 2, 2 }, { 2, 2, 2 }, { 2, 2, 2 } };

    public enum rotation
    {
        none, left, right, up, down
    }

    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 10.0f;
    private float maxSwipeTime = 1f;


    void Update()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        Touch touch = Input.touches[0];

        switch (touch.phase)
        {
            case TouchPhase.Began:
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 10000f))
                {
                    selectedObject = hit.transform.gameObject;
                    isSwipe = true;
                    fingerStartTime = Time.time;
                    fingerStartPos = touch.position;
                }
                break;

            case TouchPhase.Canceled:
                selectedObject = null;
                isSwipe = false;
                break;

            case TouchPhase.Ended:
                float gestureTime = Time.time - fingerStartTime;
                float gestureDist = (touch.position - fingerStartPos).magnitude;

                if (selectedObject == null)
                    break;

                if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist)
                {
                    gObject = selectedObject;

                    Vector2 direction = touch.position - fingerStartPos;
                    Vector2 swipeType = Vector2.zero;

                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        swipeType = Vector2.right * Mathf.Sign(direction.x);
                    }
                    else
                    {
                        swipeType = Vector2.up * Mathf.Sign(direction.y);
                    }

                    if (swipeType.x != 0.0f)
                    {

                        if (swipeType.x > 0.0f)
                        {
                            Rotate(gObject, rotation.right);
                        }
                        else
                        {
                            Rotate(gObject, rotation.left);
                        }
                    }

                    if (swipeType.y != 0.0f)
                    {
                        if (swipeType.y > 0.0f)
                        {
                            Rotate(gObject, rotation.up);
                        }
                        else
                        {
                            Rotate(gObject, rotation.down);
                        }
                    }
                }
                break;
        }
    }

    private void Rotate(GameObject gameObject, rotation rotation)
    {
        RotateCube rotator = gameObject.GetComponent<RotateCube>();
        rotator.SetTargetRotation(gameObject, rotation);

        currentMatrix1[rotator.currentField1, rotator.currentField2] = rotator.sideShowing;
        currentMatrix2[rotator.currentField1, rotator.currentField2] = rotator.dirShowing;

        Debug.Log("Final " + finalMatrix1[rotator.currentField1, rotator.currentField2] + " " +
            finalMatrix2[rotator.currentField1, rotator.currentField2]);

        checkVictory();
    }

    private void checkVictory()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int t = 0; t < 3; t++)
            {
                if (finalMatrix1[i, t] != currentMatrix1[i, t])
                    return;
                if (finalMatrix2[i, t] != currentMatrix2[i, t])
                    return;
            }
        }
        Debug.Log("Victory");
    }
}