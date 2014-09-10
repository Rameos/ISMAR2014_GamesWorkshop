using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour
{
    string instructionText = @"Use the magnifying glass to scan the poster and find the hidden game functions. Tap your screen to start.";

    void Start()
    {

    }

    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Application.LoadLevel("MagnifyingGlassGame");
            }

            ++i;
        }

        if (Input.GetMouseButtonDown(0))
            Application.LoadLevel("MagnifyingGlassGame");
    }

    void OnGUI()
    {
        GUI.skin.box.wordWrap = true;
        GUI.skin.box.fontSize = Screen.height / 25;
        GUI.skin.button.fontSize = Screen.height / 25;
        GUI.Box(new Rect(Screen.width / 4f, Screen.height / 4f, Screen.width / 2f, Screen.height / 2f), instructionText);
    }
}
