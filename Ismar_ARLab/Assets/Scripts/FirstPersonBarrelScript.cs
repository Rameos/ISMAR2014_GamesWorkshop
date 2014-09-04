using UnityEngine;
using System.Collections;

public class FirstPersonBarrelScript : MonoBehaviour {

	public float right, left, top, bottom, z;
	public static	float speed = 0.08f;
	private Vector3 target;
	public bool isExplosive;
	private float rotationSpeedX, rotationSpeedY, rotationSpeedZ;


	// Use this for initialization
	void Start () {
		right = 0.2930751f;
		bottom = 0.7610543f;
		left = 3.77922f;
		top = 2.822616f;
		z = 2.1f;
		target = new Vector3 
			(Random.Range(left, right),Random.Range(bottom, top),z  );
	int r = Random.Range (0, 5); if (r >= 4) {
						isExplosive = true;
						gameObject.renderer.material.color = Color.red;
		} else
						//isExplosive = false;
		transform.rotation = Random.rotation;
		rotationSpeedX = Random.Range (0.1f,0.5f);
		rotationSpeedY = Random.Range (0.1f,0.5f);
		rotationSpeedZ = Random.Range (0.1f,0.5f);

	}


	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, Vector3.right, rotationSpeedX);
		transform.RotateAround (transform.position, Vector3.up, rotationSpeedY);
		transform.RotateAround (transform.position, Vector3.forward, rotationSpeedZ);
		Vector3 translationVector = target - transform.position;translationVector.Normalize ();
		translationVector = new Vector3 (translationVector.x * speed, translationVector.y * speed, translationVector.z * speed);
		transform.position += translationVector;
		if (transform.position.z >= 2f) 
		{	
			if (gameObject.GetComponent<FirstPersonBarrelScript>().isExplosive == false)
			{
				GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonPlayerStatsScript>().lives--;
			}
			
			Destroy (gameObject);
		}
	}
}
