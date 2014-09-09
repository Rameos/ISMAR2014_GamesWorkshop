using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void clickedyclick()
	{StartCoroutine (menuLoad ());}

	IEnumerator menuLoad()
	{
		yield return new WaitForSeconds (2f); Application.LoadLevel (1);
	}


}
