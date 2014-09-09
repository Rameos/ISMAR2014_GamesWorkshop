using UnityEngine;
using System.Collections;

public class GameButtonscript : MonoBehaviour {
	public string gameNr;
	// Use this for initialization
	void Start () {
		if (
			PlayerPrefs.GetInt (gameNr) == 1)
						renderer.material.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
