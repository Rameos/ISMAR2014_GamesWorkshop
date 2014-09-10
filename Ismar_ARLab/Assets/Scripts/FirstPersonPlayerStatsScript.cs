using UnityEngine;
using System.Collections;

public class FirstPersonPlayerStatsScript : MonoBehaviour {
	
	
	public int lives, score, targetScore;
	public AudioSource exp, normal;
	// Use this for initialization
	void Start () {
		lives = 5;
		score = 0;
		targetScore = 15;
		GameObject.FindGameObjectWithTag("Donkey").GetComponent<Animator>().SetBool(Animator.StringToHash("hit"), false);
	


	}
	
	// Update is called once per frame
	void Update () {
		if (score >= targetScore) {
						GameObject.Find ("Ubitrack").GetComponent<SimpleFacade> ().stopUbiTrack ();
						Application.LoadLevel (3);
				} else if (lives <= 0) 
		{GameObject.Find ("Ubitrack").GetComponent<SimpleFacade> ().stopUbiTrack ();
			Application.LoadLevel (2);
				}
	}

	
	void OnGUI ()
	{
		GUI.TextArea (new Rect(0f,0f, 100f, 25f), "Lives: "+lives);
		GUI.TextArea (new Rect(0f,25f, 100f, 25f), "Score: "+score);
	}

	void OnTriggerEnter (Collider other)
	{	
		if (other.GetComponent<FirstPersonBarrelScript> () == null)
						return;
		if (other.gameObject.GetComponent<FirstPersonBarrelScript>().tetris == false)
			{
				lives--;
			GameObject.FindGameObjectWithTag("Donkey").GetComponent<Animator>().SetBool(Animator.StringToHash("hit"), true);
			StartCoroutine(AnimationRoutine());
			if (other.gameObject.GetComponent<FirstPersonBarrelScript>().isExplosive)
				exp.Play();
			else
				normal.Play();
			}

			
			Destroy (other.gameObject);

	}

	IEnumerator AnimationRoutine()
	{
		yield return new WaitForSeconds (2f);
		GameObject.FindGameObjectWithTag("Donkey").GetComponent<Animator>().SetBool(Animator.StringToHash("hit"), false);
	}
}
