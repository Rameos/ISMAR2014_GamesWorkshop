using UnityEngine;
using System.Collections;

public class GPSControllerScript : MonoBehaviour {

    public static float lati1, lati2, lati3, lati4;
    public static float longi1, longi2, longi3, longi4;


    IEnumerator Start()
    {
        if (!Input.location.isEnabledByUser)


        Input.location.Start();
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        if (maxWait < 1)
        {
            print("Timed out");

        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");

        }
        else
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);
        Input.location.Stop();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private double calculateDistance(float lat_a, float lng_a, float lat_b, float lng_b)
    {
        float pk = (float)(180 / 3.14169);

        float a1 = lat_a / pk;
        float a2 = lng_a / pk;
        float b1 = lat_b / pk;
        float b2 = lng_b / pk;

        float t1 = Mathf.Cos(a1) * Mathf.Cos(a2) * Mathf.Cos(b1) * Mathf.Cos(b2);
        float t2 = Mathf.Cos(a1) * Mathf.Sin(a2) * Mathf.Cos(b1) * Mathf.Sin(b2);
        float t3 = Mathf.Sin(a1) * Mathf.Sin(b1);
        double tt = Mathf.Acos(t1 + t2 + t3);

        

        return 6366000 * tt;
    }


}
