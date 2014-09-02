using UnityEngine;
using System.Collections;

public class BarrelScript : MonoBehaviour {

	public Vector3 target;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

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
	}
}
