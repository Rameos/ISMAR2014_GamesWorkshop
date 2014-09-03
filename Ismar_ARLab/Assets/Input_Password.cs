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
    }
	
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if (inputInLine == password)
			FadeManager.FadeOut();
			else
			{
				inputInLine = "Password incorrect!";
			}
        }
    }
}
