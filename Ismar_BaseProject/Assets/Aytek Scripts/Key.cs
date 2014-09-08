using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour 
{
    public float speed = 1;
    public Vector3 initialPosition;
    public Vector3 velocity;

	void Start()
    {
        velocity = Vector3.zero;
	}
	
	void Update()
    {
        velocity = Vector3.Lerp(velocity, velocity.normalized, Time.deltaTime * 2);

        transform.position += velocity * Time.deltaTime;
	}

    void OnTriggerStay(Collider other)
    {
        //Debug.LogError("!");

        if (other.name.Equals("Exit"))
        {
            SendMessageUpwards("WonTheGame");

            //Debug.Log("You succesfully get the key out of the maze.");
        }
        else if (other.tag.Equals("ForceField"))
        {
            //Debug.Log("!");
            //velocity = other.transform.right * 3;
        }
        else if (other.tag.Equals("Wall"))
        {
            //Debug.Log("You failed. Try Again");
            velocity = Vector3.zero;

            SendMessageUpwards("HitTheWall");

            //transform.position = initialPosition;
            //velocity = Vector3.left * speed;
        }
    }


}
