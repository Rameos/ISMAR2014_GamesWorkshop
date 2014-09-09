using UnityEngine;
using System.Collections;

public class FirstPersonBarrelScript : MonoBehaviour {

	public static	float speed = 0.005f;
//	private Vector3 target;
	public bool isExplosive;
	private float rotationSpeedX, rotationSpeedY, rotationSpeedZ;

	public bool tetris;
	

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(new Vector3(0,0.01f,tetris?Random.Range(-0.01f,-0.35f):Random.Range(0.01f,0.35f)));
	
	//	target = GameObject.FindGameObjectWithTag("Player").transform.position;

		transform.rotation = Random.rotation;
		rotationSpeedX = Random.Range (0.1f,0.5f);
		rotationSpeedY = Random.Range (0.1f,0.5f);
		rotationSpeedZ = Random.Range (0.1f,0.5f);

	}


	void Update () {
		transform.RotateAround (transform.position, Vector3.right, rotationSpeedX);
		transform.RotateAround (transform.position, Vector3.up, rotationSpeedY);
		transform.RotateAround (transform.position, Vector3.forward, rotationSpeedZ);
	//	Vector3 translationVector = transform.position - target ;	translationVector.Normalize ();
	//	translationVector = new Vector3 (translationVector.x * speed, translationVector.y * speed, translationVector.z * speed);
	//	transform.position += translationVector;

	}
}
