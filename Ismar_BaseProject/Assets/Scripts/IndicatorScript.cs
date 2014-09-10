using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorScript : MonoBehaviour {

    public Animator indicatorAnimator;




	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("" + (PlayerPrefsX.GetBool("GPS_key1", false) && PlayerPrefsX.GetBool("GPS_key2", false) && PlayerPrefsX.GetBool("GPS_key3", false)));
        if ((PlayerPrefsX.GetBool("GPS_key1", false) && PlayerPrefsX.GetBool("GPS_key2", false) && PlayerPrefsX.GetBool("GPS_key3", false)))
        {
            Debug.Log("show finished");
            UIManagerGPS.FinishedGPS();
        }
	}

    public void relativeSpeed(float distance)
    {
        indicatorAnimator.speed = 1F / (distance / 20F);
    }
}
