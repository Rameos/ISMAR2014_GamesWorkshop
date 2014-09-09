using UnityEngine;
using System.Collections;

public class ForceField : MonoBehaviour
{
    Vector3 lastPosition = Vector3.zero;
    float lastDistance = float.MaxValue;
    bool active = false;

    Key key;

	void Start()
	{
        key = GameObject.Find("Key").GetComponent<Key>();
	}
	
	void Update()
	{
	    
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Key"))
        {
            float distance = Vector3.Distance(transform.position, key.transform.position);

            if (distance > lastDistance)
            {
                key.velocity = transform.right * 3;
            }

            lastDistance = distance;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag.Equals("Key"))
        {
            lastDistance = float.MaxValue;
        }
    }
}