using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Input_Password : MonoBehaviour {

    [SerializeField]
    string password = "Tetris";
    string inputInLine = "*****";



    float posXInputField;
    float posYInputField;

    [SerializeField]
    float xPosScale;
    [SerializeField]
    float yPosScale; 


    void OnGUI()
    {
		Debug.Log ("Test!");
        posXInputField = Screen.width*xPosScale;
        posYInputField = Screen.height * yPosScale;

        inputInLine = GUI.TextArea(new Rect(posXInputField, posYInputField, 150, 25), inputInLine);
    }
	
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            FadeManager.FadeOut();
        }
    }
}
