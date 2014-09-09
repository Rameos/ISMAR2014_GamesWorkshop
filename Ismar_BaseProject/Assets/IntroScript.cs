using UnityEngine;
using System.Collections;

public class IntroScript : MonoBehaviour
{
    string instructionText = @"Use the magnifying glass to scan different Ismar posters and find the hidden game functions. Once all functions are discovered you must put them in the blank spots on the blueprints to obtain the clue. Tap your screen to start.";
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
        GUI.skin.box.fontSize = Screen.height / 20;
        GUI.Box(new Rect(Screen.width / 8f, Screen.height / 8f, (Screen.width * 6f) / 8f, (Screen.height * 6f) / 8f), instructionText);
    }
}
