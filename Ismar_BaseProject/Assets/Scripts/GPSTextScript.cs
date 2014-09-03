using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GPSTextScript : MonoBehaviour {

    private string coordinates;
    Text GPStext;
    

	// Use this for initialization
	void Start () {
        GPStext = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void changeText(float lat, float longi, string log, float distance)
    {
        GPStext.text = "Latitude: " + lat + " Longitude: " + longi + "Log: " + log + "Distance: " + distance; 
    }
}
