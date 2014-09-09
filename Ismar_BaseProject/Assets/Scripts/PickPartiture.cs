using UnityEngine;
using System.Collections;

public class PickPartiture : MonoBehaviour
{
    public GameObject targetLocation;
    private Transform currentLocation;
    private bool done;

    void Start()
    {
        currentLocation = transform;
        done = false;
    }

    void Update()
    {
        if (!HandleTarget.victoryTriggered)
        {
            return;
        }

        transform.position = Vector3.Lerp(transform.position, currentLocation.position, 0.05f);

        if (Input.touchCount <= 0)
        {
            return;
        }

        Touch touch = Input.touches[0];

        switch (touch.phase)
        {
            case TouchPhase.Began:
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 10000f))
                {
                    if (hit.transform.gameObject == gameObject)
                    {
                        currentLocation = targetLocation.transform;

                        if (!done)
                        {
                            GetComponent<AudioSource>().Play();
                        }
                    }
                }
                break;
        }
    }
}
