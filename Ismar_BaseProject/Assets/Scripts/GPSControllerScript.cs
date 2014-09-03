using UnityEngine;
using System.Collections;

public class GPSControllerScript : MonoBehaviour {

    public static float lati2, lati3, lati4;
    public static float longi2, longi3, longi4;

    public static float lati1 = 48.26253F;
    public static float longi1 = 11.66639F;

    public GPSTextScript GPSTextScript;
    public IndicatorScript indicatorScript;
    private string log;


    void Start()
    {
        log = "Starting...";

        if (Input.location.isEnabledByUser)
        {
            Input.location.Start(2F,3F);
        }
        else
        {
            log =  "Location not enabled by user!";
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.location.status == LocationServiceStatus.Initializing)
        {
            log = "waiting for initialize..";
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            log = "Unable to determine device location";

        }

        float distance = calculateDistance(lati1, longi1, Input.location.lastData.latitude, Input.location.lastData.longitude);
        GPSTextScript.changeText(Input.location.lastData.latitude, Input.location.lastData.longitude, log, distance);
        indicatorScript.relativeSpeed(distance);
    }

    private float calculateDistance(float lat_a, float lng_a, float lat_b, float lng_b)
    {
        float dx = 71.5F * (lng_a - lng_b);
        float dy = 111.3F * (lat_a - lat_b);

        return Mathf.Sqrt((dx * dx) + (dy * dy))*1000F;
    }


}
