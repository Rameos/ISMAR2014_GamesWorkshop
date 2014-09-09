using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ForceGameInstructions : MonoBehaviour
{

    [SerializeField]
    Texture tutorialTexture;

    public float widthX;
    public float heightX;
    //[SerializeField]
    //string headLine = @"The Forcegame";

    //[SerializeField]
    //string instructionText = @"You should move the blue ball to the end of the maze by creating force fields. Avoid walls. Use swipe motions to determine the direction of the force fields. Tap screen to start.";

    //[SerializeField]
    //GUIStyle styleHeadline;

    //[SerializeField]
    //GUIStyle standardFont;


	void Update()
	{
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Application.LoadLevel("ForceGame");
            }

            ++i;
        }

        if(Input.GetMouseButtonDown(0))
            Application.LoadLevel("ForceGame");
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 8f, Screen.height / 95f, Screen.width*0.67f, Screen.height), tutorialTexture);

        //GUI.Label(new Rect(Screen.width / 8f, Screen.height / 95f, (Screen.width * 6f) / 8f, (Screen.height * 6f)),headLine,styleHeadline);
        //GUI.skin.box.wordWrap = true;
        //GUI.skin.box.fontSize = Screen.height / 20;
        //GUI.Box(new Rect(Screen.width / 8f, Screen.height / 6f, (Screen.width * 6f) / 8f, (Screen.height * 6f) / 8f), instructionText);
    }
}