using UnityEngine;
using System.Collections;

public class GPSControllerScript : MonoBehaviour {

    public float lati2, lati3;
    public float longi2, longi3;

    public float lati1 = 48.26253F;
    public float longi1 = 11.66639F;

    public GPSTextScript GPSTextScript;
    public IndicatorScript indicatorScript;

    private float distance1, distance2, distance3;

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

        float lastLongi = Input.location.lastData.longitude;
        float lastLati = Input.location.lastData.latitude;

        distance1 = calculateDistance(lati1, longi1, lastLati, lastLongi);
        distance2 = calculateDistance(lati2, longi2, lastLati, lastLongi);
        distance3 = calculateDistance(lati3, longi3, lastLati, lastLongi);

        float closest = getClosest(distance1, distance2, distance3);



        GPSTextScript.changeText(Input.location.lastData.latitude, Input.location.lastData.longitude, log, closest);
        indicatorScript.relativeSpeed(closest);
    }

    private float calculateDistance(float lat_a, float lng_a, float lat_b, float lng_b)
    {
        float dx = 71.5F * (lng_a - lng_b);
        float dy = 111.3F * (lat_a - lat_b);

        return Mathf.Sqrt((dx * dx) + (dy * dy))*1000F;
    }

    private float getClosest(float d1, float d2, float d3)
    {
        float currentSmallest = d1;
        if (d2 < currentSmallest)
        {
            currentSmallest = d2;
        }

        if (d3 < currentSmallest)
        {
            currentSmallest = d3;
        }

        return currentSmallest;
    }


}
