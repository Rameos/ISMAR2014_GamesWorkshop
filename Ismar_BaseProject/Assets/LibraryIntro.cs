using UnityEngine;
using System.Collections;

public class LibraryIntro : MonoBehaviour {


    [SerializeField]
    Texture tutorialTexture;

    public float widthX;
    public float heightX;


    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width / 8f, Screen.height / 95f, Screen.width * 0.67f, Screen.height), tutorialTexture);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Fire1")) {

			Application.LoadLevel("Library");

		}
	
	}
}
