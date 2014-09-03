using UnityEngine;
using System.Collections;

public class PlayerStatsScript : MonoBehaviour {


	public int lives, score;

	// Use this for initialization
	void Start () {
		lives = 5;
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {


	}
	
	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Barrel") 
		{
			//Debug.Log ("Barrel hit the player");
			Destroy (collision.gameObject);
			lives--;
		}
	}

	void OnGUI ()
	{
		GUI.TextArea (new Rect(0f,0f, 100f, 25f), "Lives: "+lives);
		GUI.TextArea (new Rect(0f,25f, 100f, 25f), "Score: "+score);
	}
}
