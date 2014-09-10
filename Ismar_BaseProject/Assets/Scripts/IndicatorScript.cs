using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndicatorScript : MonoBehaviour {

    public Animator indicatorAnimator;




	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void relativeSpeed(float distance)
    {
        indicatorAnimator.speed = 1F / (distance / 20F);
    }
}
