using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Input_Password : MonoBehaviour {

    [SerializeField]
    string password ;
    string inputInLine = "";

	public AudioSource right, wrong;
	public GameObject instr, headl;
	private bool i = false;

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
		if (!i) {
			if (GUI.Button (new Rect (posXInputField + 160 + 60, posYInputField,80, 25), "Instructions")) {
				instr.SetActive (true);
				headl.SetActive (false);
				i = true;
			}
				} 
		else {
			if (GUI.Button (new Rect (posXInputField + 160 + 60, posYInputField, 120, 25), "Close Instructions")) {
				instr.SetActive (false);
				headl.SetActive (true);
				i = false;}
				}

		if(GUI.Button(new Rect(posXInputField+160, posYInputField, 50, 25), "Login")) {
			if (inputInLine == password){
				right.Play();
				FadeManager.FadeOut();
			}
			else
			{
				wrong.Play();
				inputInLine = "Password incorrect!";
			}
		}
    }
	
    void Update()
    {

    }
}
