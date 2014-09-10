using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
    float smooth = 10f;
    public float headingAccuracy = 2f;
    float lastValue;
    Quaternion target = Quaternion.Euler(90, 0, 0);



	// Use this for initialization
	void Start () {
        
        lastValue = Input.compass.trueHeading;
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(lastValue - Input.compass.trueHeading) > headingAccuracy)
        {
            lastValue = Input.compass.trueHeading;
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }        
	}

    public void RotateTorus(float zDeg)
    {
        target = Quaternion.Euler(90, 0, zDeg);
    }
}
