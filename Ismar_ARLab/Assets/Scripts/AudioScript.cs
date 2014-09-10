using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(transform.gameObject);
	}
	

	// Update is called once per frame
	void Update () {
		switch (Application.loadedLevel) {
		case 2: gameObject.audio.pitch = 0.80f; break;
		case 3: gameObject.audio.pitch = 1.10f; break;
			case 0: 
			case 1: 
			default: gameObject.audio.pitch = 1f; break;}
	}
}
