using UnityEngine;
using System.Collections;

public class BarrelSpawnerScript : MonoBehaviour {

	public GameObject barrelPrefab;

	public float speedMin, speedMax;

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
			GameObject barrelInstance = (GameObject)Instantiate(barrelPrefab);
			barrelInstance.transform.position = gameObject.transform.position;
			barrelReady = false;
			StartCoroutine (barrelCD());

		}
	}

	IEnumerator barrelCD()
	{
		yield return new WaitForSeconds (cooldownTime);
		barrelReady = true;
	}
}
