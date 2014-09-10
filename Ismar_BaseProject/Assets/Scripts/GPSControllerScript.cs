﻿using UnityEngine;
using System.Collections;

public class GPSControllerScript : MonoBehaviour {


    //GPS Points
    private float lati1 = 48.26253F;
    private float longi1 = 11.66639F;
    private float lati2 = 48.26274F;
    private float longi2 = 11.66639F;
    private float lati3 = 48.26274F;
    private float longi3 = 11.66623F;
    private float closeLat;
    private float closeLong;

    public GPSTextScript GPSTextScript;
    public IndicatorScript indicatorScript;
    public Rotation rotationScript;

    private float distance1, distance2, distance3;
    public bool GPSOn;
    private string log;
    private int closestKey;

    


    void Start()
    {
        Input.compass.enabled = true;
        GPSOn = false;
        StartGPS();
    }
	
	// Update is called once per frame
	void Update () {
        float closestDistance = -1;
        if (GPSOn)
        {
            GetDistances();
            closestDistance = getClosest(distance1, distance2, distance3);            
            indicatorScript.relativeSpeed(closestDistance);


            rotationScript.RotateTorus(GetBearingTo(Input.location.lastData.latitude, Input.location.lastData.longitude, closeLat, closeLong) + Input.compass.trueHeading);
        }
        log = "closestkey: " + GetBearingTo(Input.location.lastData.latitude, Input.location.lastData.longitude, closeLat, closeLong);
        //GPSTextScript.changeText(Input.location.lastData.latitude, Input.location.lastData.longitude, log, closestDistance, closestKey);
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
        if (d1 == -1)
        {
            d1 = 1000000000;
        }
        if (d2 == -1)
        {
            d2 = 1000000000;
        }
        if (d3 == -1)
        {
            d3 = 1000000000;
        }
        float currentSmallest = d1;

        closeLat = lati1;
        closeLong = longi1;
        closestKey = 1;
        if (d2 < currentSmallest)
        {
            closeLat = lati2;
            closeLong = longi2;
            closestKey = 2;
            currentSmallest = d2;
        }

        if (d3 < currentSmallest)
        {
            closestKey = 3;
            closeLat = lati3;
            closeLong = longi3;
            currentSmallest = d3;
        }

        if (currentSmallest == 1000000000)
        {
            currentSmallest = -1;
        }

        return currentSmallest;
    }

    private void checkVictory()
    {
        if(distance1 == -1 && distance2 == -1 && distance3 == -1){
            log = "victory!!";
        }
    }

    private float GetBearingTo(float lat_a, float lng_a, float lat_b, float lng_b)
    {
        float lat1 = ToRadians(lat_a);
        float lat2 = ToRadians(lat_b);
        float dLon = ToRadians(lng_a-lng_b);

        float y = Mathf.Sin(dLon) * Mathf.Cos(lat2);
        float x = Mathf.Cos(lat1) * Mathf.Sin(lat2) - Mathf.Sin(lat1) * Mathf.Cos(lat2) * Mathf.Cos(dLon);
        float brng = Mathf.Atan2(y, x);
  
        return (ToDegrees(brng)+360) % 360;
    }

    private float ToRadians(float angle)
    {
        return (angle * Mathf.PI) / 180f;
    }

    private float ToDegrees(float rad)
    {
        return (rad * 180f) / Mathf.PI;
    }
}
