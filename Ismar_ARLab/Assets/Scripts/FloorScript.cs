using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {
	
	public static int lives;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{	
		if (other.gameObject.GetComponent<FirstPersonBarrelScript> () != null && !other.gameObject.GetComponent<FirstPersonBarrelScript> ().tetris) {
						lives--;
						Destroy (other.gameObject);
				}




		
	}
	

}
