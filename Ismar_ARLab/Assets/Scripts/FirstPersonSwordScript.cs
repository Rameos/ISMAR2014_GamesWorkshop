using UnityEngine;
using System.Collections;

public class FirstPersonSwordScript : MonoBehaviour {
	


	public GameObject explosion;
	public bool isUmbrella;


	// Use this for initialization
	void Start () {
		isUmbrella = true;
	}
	
	// Update is called once per frame
	void Update () {
		//	gameObject.transform.RotateAround (pivot.transform.position, Vector3.forward, Input.GetAxis ("Horizontal") * rotationSpeed*-1f);
		
		
		
	}
	
	void OnTriggerEnter(Collider barrel)
	{
		if (barrel.GetComponent<FirstPersonBarrelScript>() != null) 
		{	if (barrel.GetComponent<FirstPersonBarrelScript>().tetris)
			{

				{if (isUmbrella)
					GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().lives--;
					else
						GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().score++;
				}
			}

			else {
			if (barrel.gameObject.GetComponent<FirstPersonBarrelScript>().isExplosive)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().lives--;
				GameObject e = (GameObject)Instantiate(explosion);
				e.transform.position = barrel.gameObject.transform.position;
			}

			else
			{if (isUmbrella)
			GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().score++;
				else
					GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().lives--;
				}}

			Destroy (barrel.gameObject);
		}
	}
}
