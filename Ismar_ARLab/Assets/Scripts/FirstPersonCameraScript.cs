using UnityEngine;
using System.Collections;

public class FirstPersonCameraScript : MonoBehaviour {
	public GameObject player;
	public Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = player.transform.position - gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = player.transform.position-offset;
	}
}
