using UnityEngine;
using System.Collections;

public class PlaneScript : MonoBehaviour {

	public static int lives;

	// Use this for initialization
	void Start () {
		lives = 3;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other)
	{

		Destroy(other.gameObject);lives--;
				
	}

	void OnGUI()
	{
		GUI.TextArea (new Rect (0f, 0f, 50f, 25f), "" + lives);
	}
}
