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

    void OnTriggerStay(Collider other)
    {
        Debug.LogError("!");

        if (other.name.Equals("Exit"))
        {
            Debug.Log("You succesfully get the key out of the maze.");
        }
        else if (other.tag.Equals("ForceField"))
        {
            Debug.Log("!");
            velocity = other.transform.right;
        }
        else if (other.tag.Equals("Wall"))
        {
            Debug.Log("You failed. Try Again");

            SendMessageUpwards("HitTheWall");

            transform.position = initialPosition;
            velocity = Vector3.left * speed;
        }
    }


}
