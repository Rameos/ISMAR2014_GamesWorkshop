using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour
{


    private float fingerStartTime = 0.0f;
    private Vector2 fingerStartPos = Vector2.zero;

    private bool isSwipe = false;
    private float minSwipeDist = 50.0f;
    private float maxSwipeTime = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount != 0)
        {

            Touch touch = Input.touches[0];

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                Debug.Log(hit.transform.gameObject.name);
                MeshRenderer render = hit.transform.gameObject.GetComponent<MeshRenderer>();
                render.material.color = Color.red;
            }
        }
    }
}