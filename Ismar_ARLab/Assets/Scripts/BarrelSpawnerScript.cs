using UnityEngine;
using System.Collections;

public class BarrelSpawnerScript : MonoBehaviour {

	public GameObject barrelPrefab;

	public float speedMin, speedMax;

	public float cooldownTime;

	public GameObject left, right, top, bottom;


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

			float x = Random.Range(left.transform.position.x, right.transform.position.x);
			float y = Random.Range(bottom.transform.position.y, top.transform.position.y);
			Vector3 target = new Vector3(x, y, -3f);

			GameObject spawnedBarrel = (GameObject)Instantiate(barrelPrefab);
			spawnedBarrel.transform.position = gameObject.transform.position;
			spawnedBarrel.GetComponent<BarrelScript>().target = target;
			spawnedBarrel.GetComponent<BarrelScript>().speed = Random.Range(speedMin, speedMax);
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
