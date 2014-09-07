using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

	public int ExploreButton = 0;
	public int CandleRender = 0;
	public int OkButton = 1;
	public int Win = 0;
	public bool Search1 = true;
	public bool Search2 = true;
	public bool TetrisBook = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*
		GameObject.Find("Wall1").renderer.enabled = false;
		GameObject.Find("Wall2").renderer.enabled = false;
		GameObject.Find("Wall3").renderer.enabled = false;
		GameObject.Find("Wall4").renderer.enabled = false;
		*/
		GameObject.Find("TetrisBook").renderer.enabled = TetrisBook;
		GameObject.Find("TetrisBook").collider.enabled = TetrisBook;

		if (Win == 2) 
		{
			GameObject.Find("BookCase10").renderer.enabled = false;
			TetrisBook = true;
			OkButton = 0;
		}

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
		case 3:

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

		if(Col.gameObject.tag == "Nope")
		{
			ExploreButton = 3; 
		}


		if (Col.gameObject.name == "Book5") 
		{
			ExploreButton = 2;
			
		}

		if (Col.gameObject.name == "TetrisBook") 
		{
			GameObject.Find("InfoText").GetComponent<TextMesh>().text = "Clue Found";
			GameObject.Find("InfoText").renderer.enabled = true;
		}


	}


	void OnGUI()
	{
				if (GUI.RepeatButton (new Rect (260, 20, 230, 150), "Up")) {
						//GameObject.Find("Player").transform.position += new Vector3 (0.05f,0f,0f);
			GameObject.Find ("Player").transform.position -= new Vector3 (0.05f, 0f, 0f);
				}

				if (GUI.RepeatButton (new Rect (260, 320, 230, 150), "Down")) {
						//GameObject.Find("Player").transform.position -= new Vector3 (0.05f,0f,0f);
			GameObject.Find ("Player").transform.position += new Vector3 (0.05f, 0f, 0f);
				}

				if (GUI.RepeatButton (new Rect (20, 180, 230, 150), "Left")) {
			GameObject.Find ("Player").transform.position -= new Vector3 (0f, 0f, 0.05f);
		}

				if (GUI.RepeatButton (new Rect (500, 180, 230, 150), "Right")) {
			GameObject.Find ("Player").transform.position += new Vector3 (0f, 0f, 0.05f);
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
				//OkButton = 1;
				StartCoroutine(CandleFound());
				ExploreButton = 0;
				if(Search1 == true)
				{
					StartCoroutine(AddWin());
					Search1 = false;
				}
			}

			break;

		case 2:

			if(GUI.Button(new Rect (20,400, 200, 150), "Search"))
			{
				CandleRender = 2;
				GameObject.Find("InfoText").GetComponent<TextMesh>().text = "Candle stick found";
				GameObject.Find("InfoText").renderer.enabled = true;
				//OkButton = 1;
				StartCoroutine(CandleFound());
				ExploreButton = 0;
				if(Search2 == true)
				{
					StartCoroutine(AddWin());
					Search2 = false;
				}
			}

			break;

		case 3:
			if(GUI.Button(new Rect (20,400, 200, 150), "Search"))
			{
				GameObject.Find("InfoText").GetComponent<TextMesh>().text = "Nothing Found";
				GameObject.Find("InfoText").renderer.enabled = true;
				ExploreButton = 0;
				StartCoroutine(TimeText());

			}
			break;

		}


	}

	public IEnumerator CandleFound()
	{
		GameObject.Find ("InfoText").GetComponent<TextMesh> ().text = "Candle stick found!";
		yield return new WaitForSeconds(3);
		GameObject.Find ("InfoText").GetComponent<TextMesh> ().text = "";

	}

	public IEnumerator TimeText()
	{
		OkButton = 0;

		yield return new WaitForSeconds (3);
		GameObject.Find("InfoText").GetComponent<TextMesh>().text = "";
	}

	public IEnumerator AddWin ()
	{
		Win += 1;
		yield return new WaitForSeconds(0.5f);
	}

}
