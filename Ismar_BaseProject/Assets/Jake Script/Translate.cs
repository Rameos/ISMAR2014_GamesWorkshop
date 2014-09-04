using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

	public int ExploreButton = 0;
	public int CandleRender = 0;
	public int OkButton = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		switch (CandleRender) 
		{
		case 0:

			GameObject.Find("Candle3").renderer.enabled = false;
			GameObject.Find("Candle6").renderer.enabled = false;
			GameObject.Find("CandleLight3").light.enabled = false;
			GameObject.Find("CandleLight6").light.enabled = false;
			break;

		case 1:
			GameObject.Find("Candle3").renderer.enabled = true;
			GameObject.Find("CandleLight3").light.enabled = true;
			break;

		case 2:
			GameObject.Find("Candle6").renderer.enabled = true;
			GameObject.Find("CandleLight6").light.enabled = true;
			break;
			
		
		}


	
	}


	void OnCollisionEnter (Collision Col)
	{
		if (Col.gameObject.tag != "Collision") 
		{
			ExploreButton = 0;
			
		}

		if (Col.gameObject.name == "BookCase3") 
		{
			ExploreButton = 1;



		}

		if (Col.gameObject.name == "Book5") 
		{
			ExploreButton = 2;
			
		}


	}


	void OnGUI()
	{
				if (GUI.RepeatButton (new Rect (260, 20, 230, 150), "Up")) {
						//GameObject.Find("Player").transform.position += new Vector3 (0.05f,0f,0f);
						GameObject.Find ("Player").transform.position += new Vector3 (0f, 0f, 0.05f);
				}

				if (GUI.RepeatButton (new Rect (260, 320, 230, 150), "Down")) {
						//GameObject.Find("Player").transform.position -= new Vector3 (0.05f,0f,0f);
						GameObject.Find ("Player").transform.position -= new Vector3 (0f, 0f, 0.05f);
				}

				if (GUI.RepeatButton (new Rect (20, 180, 230, 150), "Left")) {
						GameObject.Find ("Player").transform.position -= new Vector3 (0.05f, 0f, 0);
				}

				if (GUI.RepeatButton (new Rect (500, 180, 230, 150), "Right")) {
						GameObject.Find ("Player").transform.position += new Vector3 (0.05f, 0f, 0f);
				}


		switch(OkButton)
		{
		case 0:
			break;
			
		case 1:
			
			if(GUI.Button(new Rect (20,400, 230, 150), "Ok"))
			{
				GameObject.Find("InfoText").renderer.enabled = false;
				OkButton = 0;
			}
			
			break;
			
		}
	

		switch(ExploreButton)
		{
		case 0:
			break;

		case 1:

			if(GUI.Button(new Rect (20,400,200, 150), "Search"))
			{
				CandleRender = 1;
				GameObject.Find("InfoText").GetComponent<TextMesh>().text = "Candle stick found";
				GameObject.Find("InfoText").renderer.enabled = true;
				OkButton = 1;
				ExploreButton = 0;
			}

			break;

		case 2:

			if(GUI.Button(new Rect (20,400, 200, 150), "Search"))
			{
				CandleRender = 2;
				GameObject.Find("InfoText").GetComponent<TextMesh>().text = "Candle stick found";
				GameObject.Find("InfoText").renderer.enabled = true;
				OkButton = 1;
				ExploreButton = 0;
			}

			break;

		}


	}

}
