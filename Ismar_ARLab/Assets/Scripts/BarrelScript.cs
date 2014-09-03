using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

	private Transform playerPosition;
	public float speed;

	// Use this for initialization
	void Start () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 translationVector = playerPosition.position - transform.position;
		translationVector = new Vector3 (translationVector.x * speed, translationVector.y * speed, translationVector.z * speed);
		transform.position += translationVector;
	}
}
