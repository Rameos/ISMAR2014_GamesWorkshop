using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Input_Password : MonoBehaviour {

    [SerializeField]
    string password ;
    string inputInLine = "";



    float posXInputField;
    float posYInputField;

    [SerializeField]
    float xPosScale;
    [SerializeField]
    float yPosScale; 


    void OnGUI()
    {
        posXInputField = Screen.width*xPosScale;
        posYInputField = Screen.height * yPosScale;

        inputInLine = GUI.TextField(new Rect(posXInputField, posYInputField, 150, 25), inputInLine);

		if(GUI.Button(new Rect(posXInputField+160, posYInputField, 50, 25), "Login")) {
			if (inputInLine == password){
				Debug.Log ("good ");
				FadeManager.FadeOut();
			}
			else
			{
				Debug.Log ("bad ");
				inputInLine = "Password incorrect!";
			}
		}
    }
	
    void Update()
    {

    }
}
