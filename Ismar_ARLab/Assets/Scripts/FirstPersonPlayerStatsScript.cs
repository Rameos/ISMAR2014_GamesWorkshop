using UnityEngine;
using System.Collections;

public class FirstPersonPlayerStatsScript : MonoBehaviour {
	
	
	public int lives, score, targetScore;
	
	// Use this for initialization
	void Start () {
		lives = 5;
		score = 0;
		targetScore = 15;




	}
	
	// Update is called once per frame
	void Update () {
		if (score >= targetScore)
						Debug.Log ("win");//Application.LoadLevel (3); 
		else if (lives <= 0)
			Debug.Log ("lose");//Application.LoadLevel (2);
	}

	
	void OnGUI ()
	{
		GUI.TextArea (new Rect(0f,0f, 100f, 25f), "Lives: "+lives);
		GUI.TextArea (new Rect(0f,25f, 100f, 25f), "Score: "+score);
	}
}
