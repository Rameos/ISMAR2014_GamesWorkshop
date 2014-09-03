using UnityEngine;
using System.Collections;

public class FirstPersonPlayerStatsScript : MonoBehaviour {
	
	
	public int lives, score;
	
	// Use this for initialization
	void Start () {
		lives = 10;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	
	void OnGUI ()
	{
		GUI.TextArea (new Rect(0f,0f, 100f, 25f), "Lives: "+lives);
		GUI.TextArea (new Rect(0f,25f, 100f, 25f), "Score: "+score);
	}
}
