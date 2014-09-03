using UnityEngine;
using System.Collections;

public class SwordScript : MonoBehaviour {

	public GameObject pivot;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//	gameObject.transform.RotateAround (pivot.transform.position, Vector3.forward, Input.GetAxis ("Horizontal") * rotationSpeed*-1f);
	


	}

<<<<<<< HEAD
	void OnTriggerEnter(Collider barrel)
	{
		if (barrel.tag == "Barrel") 
				{
						//Debug.Log ("Barrel hit the sword");
						Destroy (barrel.gameObject);
						GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatsScript>().score++;
				}
=======
	void OnTriggerEnter(Collider other)
	{
		
		Destroy(other.gameObject);Debug.Log ("hit");
		
>>>>>>> cb1f8312bb5e92d1958ee83450fbdb69cea5eda0
	}
}
