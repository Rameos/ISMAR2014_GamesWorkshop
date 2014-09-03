using UnityEngine;
using System.Collections;

public class BarrelSpawnerScript : MonoBehaviour {

	public GameObject barrelPrefab;

	public float speedMin, speedMax;

	public float cooldownTime;

<<<<<<< HEAD
=======
	public GameObject left, right, top, bottom;


>>>>>>> cb1f8312bb5e92d1958ee83450fbdb69cea5eda0
	private bool barrelReady;

	// Use this for initialization
	void Start () {
		barrelReady = false;
		StartCoroutine (barrelCD());

	}
	
	// Update is called once per frame
	void Update () {
		if (barrelReady) 
<<<<<<< HEAD
		{
			GameObject barrelInstance = (GameObject)Instantiate(barrelPrefab);
			barrelInstance.transform.position = gameObject.transform.position;
=======
		{	

			float x = Random.Range(left.transform.position.x, right.transform.position.x);
			float y = Random.Range(bottom.transform.position.y, top.transform.position.y);
			Vector3 target = new Vector3(x, y, -3f);

			GameObject spawnedBarrel = (GameObject)Instantiate(barrelPrefab);
			spawnedBarrel.transform.position = gameObject.transform.position;
			spawnedBarrel.GetComponent<BarrelScript>().target = target;
			spawnedBarrel.GetComponent<BarrelScript>().speed = Random.Range(speedMin, speedMax);
>>>>>>> cb1f8312bb5e92d1958ee83450fbdb69cea5eda0
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
