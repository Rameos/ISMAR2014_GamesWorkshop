using UnityEngine;
using System.Collections;

public class DonkeyScript : MonoBehaviour {
	public GameObject left, right, top, bottom;
	public float moveSpeed, heightMultiplier, fMultiplier;
	private int directionX;

	private float xSin;


	public float cooldownTime;
	public GameObject barrelPrefab;
	private bool barrelReady;
	// Use this for initialization
	void Start () {
		directionX = 1;
		xSin = 0;


		barrelReady = false;
		StartCoroutine (barrelCD());
	}
	
	// Update is called once per frame
	void Update () {

		xSin += Time.deltaTime*fMultiplier;
		transform.position = new Vector3 (transform.position.x + moveSpeed*directionX, transform.position.y+ (Mathf.Sin(xSin)*heightMultiplier), transform.position.z);
		if (transform.position.x < right.transform.position.x)
						directionX = 1;
		if (transform.position.x > left.transform.position.x) {
			directionX = -1; 
				}

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
