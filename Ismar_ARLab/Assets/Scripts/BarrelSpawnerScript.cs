using UnityEngine;
using System.Collections;

public class BarrelSpawnerScript : MonoBehaviour {

	public GameObject barrelPrefab;
	public float cooldownTime;



	private bool barrelReady;

	// Use this for initialization
	void Start () {
		barrelReady = false;
		StartCoroutine (barrelCD());

	}
	
	// Update is called once per frame
	void Update () {
		if (barrelReady) 
		{
			GameObject spawnedBarrel = (GameObject)Instantiate(barrelPrefab);
			spawnedBarrel.transform.position = gameObject.transform.position;
			spawnedBarrel.rigidbody.AddForce(new Vector3(Random.Range(-200f, 200f),Random.Range(100f, 200f) , -350f));
			barrelReady = false;
			StartCoroutine(barrelCD());

		}
	}

	IEnumerator barrelCD()
	{
		yield return new WaitForSeconds (cooldownTime);
		barrelReady = true;
	}
}
