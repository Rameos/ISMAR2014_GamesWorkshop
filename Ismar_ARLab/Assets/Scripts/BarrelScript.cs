using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

<<<<<<< HEAD
	private Transform playerPosition;
	public float speed;

=======
	public Vector3 target;
	public float speed;
>>>>>>> cb1f8312bb5e92d1958ee83450fbdb69cea5eda0
	// Use this for initialization
	void Start () {
		playerPosition = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		Vector3 translationVector = playerPosition.position - transform.position;
		translationVector = new Vector3 (translationVector.x * speed, translationVector.y * speed, translationVector.z * speed);
		transform.position += translationVector;
=======

		//if(Vector3.Distance(target, gameObject.transform.position) < 3)
		//	Destroy(gameObject);
		//else
		//{
			Vector3 velocity = target - gameObject.transform.position;
			velocity.Normalize();

			velocity = new Vector3 (velocity.x*speed, velocity.y*speed, velocity.z*speed);

			transform.position += velocity;
		//}
		//transform.Translate (new Vector3 ((target.x - transform.position.x)*speed,(target.y - transform.position.y)*speed ,(target.z - transform.position.z)*speed ));
>>>>>>> cb1f8312bb5e92d1958ee83450fbdb69cea5eda0
	}
}
