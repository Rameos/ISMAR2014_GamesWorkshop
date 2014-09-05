using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	GameObject myCamera; 
	RaycastHit hitter;
	float previousPositionY;	
	string TheRay;

	public int WordVisable = 0;
	public int WordCount = 0;
	public bool Word1 = false;
	public bool Word2 = false;
	public bool Word3 = false;
	public bool Word4 = false;


	// Use this for initialization
	void Start () {
	
		previousPositionY = Input.mousePosition.y;			
		myCamera = GameObject.Find("ARCamera");	



	}


	
	// Update is called once per frame
	void Update () {

		GameObject.Find ("Word1").renderer.enabled = false;
		GameObject.Find ("Word2").renderer.enabled = false;
		GameObject.Find ("Word3").renderer.enabled = false;
		GameObject.Find ("Word4").renderer.enabled = false;


        Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));			// Raycasting. Basically allows the button interaction
		
		Physics.Raycast(myCamera.transform.position, ray.direction, out hitter);
		
		Debug.DrawRay(myCamera.transform.position, ray.direction);

		if (WordCount == 4) {

			StartCoroutine(GetBluePrints());
		}

		if (hitter.collider != null && hitter.collider.name == "Word1") {		
			
			
			WordVisable = 4;
			if(Word1 == false)
			{
				WordCount += 1;
				Word1 = true;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Word2") {		


			WordVisable = 1;
			if(Word2 == false)
			{
				WordCount += 1;
				Word2 = true;
			}
		}

		if (hitter.collider != null && hitter.collider.name == "Word3") {		

			WordVisable = 2;
			if(Word3 == false)
			{
				WordCount += 1;
				Word3 = true;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Word4") {		

			WordVisable = 3;
			if(Word4 == false)
			{
				WordCount += 1;
				Word4 = true;
			}
			
		}

		switch (WordVisable) 
		{
		case 0:

			StartCoroutine(TurnAllOff());
			break;

		case 1:

			StartCoroutine(TurnAllOff());
			GameObject.Find("Text2").renderer.enabled = true;
			break;
		case 2:

			StartCoroutine(TurnAllOff());
			GameObject.Find("Text3").renderer.enabled = true;
			break;
		case 3:

			StartCoroutine(TurnAllOff());
			GameObject.Find("Text4").renderer.enabled = true;

			break;
		case 4:
			
			StartCoroutine(TurnAllOff());
			GameObject.Find("Text1").renderer.enabled = true;
			
			break;

		case 5:
			
			StartCoroutine(TurnAllOff());
			GameObject.Find("Text5").renderer.enabled = true;
			
			break;



		}
	
	}

	IEnumerator GetBluePrints()
	{
		GameObject.Find ("FinishedText").GetComponent<TextMesh>().text = "Blueprints Found";
		yield return new WaitForSeconds (1);
	}


	IEnumerator TurnAllOff()
	{
		GameObject.Find("Text1").renderer.enabled = false;
		GameObject.Find("Text2").renderer.enabled = false;
		GameObject.Find("Text3").renderer.enabled = false;
		GameObject.Find("Text4").renderer.enabled = false;

		yield return new WaitForSeconds(0.5f);
	}
}
