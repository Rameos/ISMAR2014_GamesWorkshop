using UnityEngine;
using System.Collections;

public class GPSControllerScript : MonoBehaviour {


    //GPS Points
    private float lati1 = 48.26257F;
    private float longi1 = 11.66627F;
    private float lati2 = 48.26256F;
    private float longi2 = 11.66878F;
    private float lati3 = 48.2633F;
    private float longi3 = 11.66897F;

    public GPSTextScript GPSTextScript;
    public IndicatorScript indicatorScript;

    private float distance1, distance2, distance3;
    public bool GPSOn;
    private string log;
    private int closestKey;


    void Start()
    {
        GPSOn = false;        
    }
	
	// Update is called once per frame
	void Update () {
        float closest = -1;
        if (GPSOn)
        {
            GetDistances();
            closest = getClosest(distance1, distance2, distance3);            
            indicatorScript.relativeSpeed(closest);            
        }
        GPSTextScript.changeText(Input.location.lastData.latitude, Input.location.lastData.longitude, log, closest, closestKey);
        checkVictory();
    }

    public void StartGPS()
    {
        GPSOn = true;
        log = "Starting...";

        if (Input.location.isEnabledByUser)
        {
            Input.location.Start(1F, 2F);
        }
        else
        {
            log = "Location not enabled by user!";
        }
    }

    private float[] GetDistances()
    {
        float[] output = new float[3];

        if (Input.location.status == LocationServiceStatus.Initializing)
        {
            log = "waiting for initialize..";
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            log = "Unable to determine device location";
        }

        float lastLati = Input.location.lastData.latitude;
        float lastLongi = Input.location.lastData.longitude;

        if (!PlayerPrefsX.GetBool("GPS_key1", false))
        {
            distance1 = calculateDistance(lati1, longi1, lastLati, lastLongi);
        }
        else
        {
            distance1 = -1;
        }

        if (!PlayerPrefsX.GetBool("GPS_key2", false))
        {
            distance2 = calculateDistance(lati2, longi2, lastLati, lastLongi);
        }
        else
        {
            distance2 = -1;
        }

        if (!PlayerPrefsX.GetBool("GPS_key3", false))
        {
            distance3 = calculateDistance(lati3, longi3, lastLati, lastLongi);
        }
        else
        {
            distance3 = -1;
        }

        return output;        
    }

    public void StopGPS()
    {
        GPSOn = false;
        log = "end of GPS";
        Input.location.Stop();
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
        closestKey = 1;
        if (d2 < currentSmallest)
        {
            closestKey = 2;
            currentSmallest = d2;
        }

        if (d3 < currentSmallest)
        {
            closestKey = 3;
            currentSmallest = d3;
        }

        return currentSmallest;
    }

    private void checkVictory()
    {
        if(distance1 == -1 && distance2 == -1 && distance3 == -1){
            log = "victory!!";
        }
    }
}
