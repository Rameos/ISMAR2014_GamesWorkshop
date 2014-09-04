using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour 
{
    public float speed = 1;
    public Vector3 initialPosition;

	void Start()
    {
        rigidbody.velocity = Vector3.right * speed;
	}
	
	void Update()
    {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Exit"))
        {
            Debug.Log("You succesfully get the key out of the maze.");
        }
        else if (other.name.Equals("ForceField"))
        {
            rigidbody.velocity = other.transform.right;
        }
        else if (other.name.Equals("Wall"))
        {
            Debug.Log("You failed.");
            transform.position = initialPosition;
        }
    }
}
