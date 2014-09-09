using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {
	

	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{	Debug.Log ("meow");
		if (other.gameObject.GetComponent<FirstPersonBarrelScript> () != null && !other.gameObject.GetComponent<FirstPersonBarrelScript> ().isExplosive) {
			GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().lives--;
						Destroy (other.gameObject);
				}




		
	}
	

}
