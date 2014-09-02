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
		gameObject.transform.RotateAround (pivot.transform.position, Vector3.forward, Input.GetAxis ("Horizontal") * rotationSpeed*-1f);
	


	}
}
