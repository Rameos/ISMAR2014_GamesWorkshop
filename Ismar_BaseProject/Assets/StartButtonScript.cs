using UnityEngine;
using System.Collections;

public class StartButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator clickedyclick()
	{yield return new WaitForSeconds(1f); Application.LoadLevel (1);}
}
