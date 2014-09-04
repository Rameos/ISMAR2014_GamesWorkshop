using UnityEngine;
using System.Collections;

public class FirstPersonSwordScript : MonoBehaviour {
	


	public GameObject explosion;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//	gameObject.transform.RotateAround (pivot.transform.position, Vector3.forward, Input.GetAxis ("Horizontal") * rotationSpeed*-1f);
		
		
		
	}
	
	void OnTriggerEnter(Collider barrel)
	{
		if (barrel.tag == "Barrel") 
		{
			//Debug.Log ("Barrel hit the sword");
			if (barrel.gameObject.GetComponent<FirstPersonBarrelScript>().isExplosive)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().lives--;
				GameObject e = (GameObject)Instantiate(explosion);
				e.transform.position = barrel.gameObject.transform.position;
			}

			else
			{
			GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().score++;
			FirstPersonBarrelScript.speed += 0.01f;
			}

			Destroy (barrel.gameObject);
		}
	}
}
