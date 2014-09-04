using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour 
{
    public float speed = 1;
    public Vector3 initialPosition;
    public Vector3 velocity;

	void Start()
    {
        velocity = Vector3.left * speed;
	}
	
	void Update()
    {
        transform.position += velocity * Time.deltaTime;
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.LogError("!");

        if (other.name.Equals("Exit"))
        {
            Debug.Log("You succesfully get the key out of the maze.");
        }
        else if (other.name.Equals("ForceField"))
        {
            Debug.Log("!");
            velocity = other.transform.right;
        }
        else if (other.name.Equals("Wall"))
        {
            Debug.Log("You failed. Try Again");
            transform.position = initialPosition;
            velocity = Vector3.left * speed;
        }
    }
}
