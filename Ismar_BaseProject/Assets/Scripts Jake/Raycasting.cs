using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	GameObject myCamera; 
	RaycastHit hitter;
	float previousPositionY;	
	string TheRay;

	public int WordVisable = 0;
	public int WordCount = 0;
	public int LastScreen = 0;

	public bool Word1 = false;
	public bool Word2 = false;
	public bool Word3 = false;
	public bool Word4 = false;
	public bool Word5 = false;
	public bool Word6 = false;
	public bool Word7 = false;
	public bool Word8 = false;
	public bool Word9 = false;
	public bool Word10 = false;

    bool completed = false;

	// Use this for initialization
	void Start()
    {
		previousPositionY = Input.mousePosition.y;			
		myCamera = GameObject.Find("ARCamera");	
	}

    void OnGUI()
    {
        GUI.skin.box.fontSize = Screen.height / 25;
        GUI.skin.button.fontSize = Screen.height / 25;

        GUI.Box(new Rect(Screen.width / 2, 0, Screen.width / 2, Screen.height / 8), "CLUES FOUND: " + WordCount + "/4");

        if (GUI.Button(new Rect(0, 0, Screen.width / 4, Screen.height / 8), "MAIN MENU"))
        {
            QCARRenderer.Instance.DrawVideoBackground = true;

            Application.LoadLevel("GameSelector");
        }

        if (completed)
        {
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "CONGRATULATIONS!\nYou succesfully finished the game. Tap on MAIN MENU for other mini-games.");
            //Solve the Game;
            GlobalData.Instance.gameSolved(MiniGame.MagnifyingLense);
        }
    }
	
	// Update is called once per frame
	void Update () {

		GameObject.Find ("Word1").renderer.enabled = false;
		GameObject.Find ("Word2").renderer.enabled = false;
		GameObject.Find ("Word3").renderer.enabled = false;
		GameObject.Find ("Word4").renderer.enabled = false;


		//GameObject.Find ("Counter2").GetComponent<TextMesh> ().text = WordCount.ToString ();

		Ray ray = camera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));				// Raycasting. Basically allows the button interaction
		
		Physics.Raycast(myCamera.transform.position, ray.direction, out hitter);
		
		Debug.DrawRay(myCamera.transform.position, ray.direction);

        //switch(LastScreen)
        //{
        //    case 0:
        //    GameObject.Find("LastBackground").renderer.enabled = false;
        //    GameObject.Find("SourceCode").renderer.enabled = false;
        //    GameObject.Find("LastBackground").collider.enabled = false;
        //    GameObject.Find("SourceCode").collider.enabled = false;
        //    break;

        //    case 1:
        //    GameObject.Find("LastBackground").renderer.enabled = true;
        //    GameObject.Find("SourceCode").renderer.enabled = true;
        //    GameObject.Find("LastBackground").collider.enabled = true;
        //    GameObject.Find("SourceCode").collider.enabled = true;
        //    break;


        //}


		if (WordCount == 4)
        {
            completed = true;

            GlobalData.Instance.gameSolved(MiniGame.MagnifyingLense);

			//StartCoroutine(GetBluePrints());
			//StartCoroutine(TurnOffColliders());
			//StartCoroutine(TurnAllOff());
			//GameObject.Find("Counter").renderer.enabled = false;
			//GameObject.Find("Counter2").renderer.enabled = false;
			
            //LastScreen = 1;
		}

		if (hitter.collider != null && hitter.collider.name == "Word1") {		
			
			
			WordVisable = 1;
			if(Word1 == false)
			{
				WordCount += 1;
				Word1 = true;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Word2") {		


			WordVisable = 2;
			if(Word2 == false)
			{
				WordCount += 1;
				Word2 = true;
			}
		}

		if (hitter.collider != null && hitter.collider.name == "Word3") {		

			WordVisable = 3;
			if(Word3 == false)
			{
				WordCount += 1;
				Word3 = true;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Word4") {		

			WordVisable = 4;
			if(Word4 == false)
			{
				WordCount += 1;
				Word4 = true;
			}
			
		}

        //if (hitter.collider != null && hitter.collider.name == "Word5") {		
			
			
        //    WordVisable = 5;
        //    if(Word5 == false)
        //    {
        //        WordCount += 1;
        //        Word5 = true;
        //    }
			
        //}



        //if (hitter.collider != null && hitter.collider.name == "Word6") {		
			
			
        //    WordVisable = 6;
        //    if(Word6 == false)
        //    {
        //        WordCount += 1;
        //        Word6 = true;
        //    }
        //}

        //if (hitter.collider != null && hitter.collider.name == "Word7") {		
			
			
        //    WordVisable = 7;
        //    if(Word7 == false)
        //    {
        //        WordCount += 1;
        //        Word7 = true;
        //    }
        //}


        //if (hitter.collider != null && hitter.collider.name == "Word8") {		
			
			
        //    WordVisable = 8;
        //    if(Word8 == false)
        //    {
        //        WordCount += 1;
        //        Word8 = true;
        //    }
        //}


        //if (hitter.collider != null && hitter.collider.name == "Word9") {		
			
			
        //    WordVisable = 9;
        //    if(Word9 == false)
        //    {
        //        WordCount += 1;
        //        Word9 = true;
        //    }
        //}

        //if (hitter.collider != null && hitter.collider.name == "Word10") {		
			
			
        //    WordVisable = 10;
        //    if(Word10 == false)
        //    {
        //        WordCount += 1;
        //        Word10 = true;
        //    }
        //}

		switch (WordVisable) 
		{
		case 0:

			StartCoroutine(TurnAllOff());
			break;

		case 1:

			StartCoroutine(TurnAllOff());
			GameObject.Find("Text1").renderer.enabled = true;
			break;
		case 2:

			StartCoroutine(TurnAllOff());
			GameObject.Find("Text2").renderer.enabled = true;
			break;
		case 3:

			StartCoroutine(TurnAllOff());
			GameObject.Find("Text3").renderer.enabled = true;

			break;
		case 4:
			
			StartCoroutine(TurnAllOff());
			GameObject.Find("Text4").renderer.enabled = true;
			
			break;

        //case 5:
			
        //    StartCoroutine(TurnAllOff());
        //    GameObject.Find("Text5").renderer.enabled = true;
			
        //    break;
		
        //case 6:
			
        //    StartCoroutine(TurnAllOff());
        //    GameObject.Find("Text6").renderer.enabled = true;
			
        //    break;

        //case 7:
			
        //    StartCoroutine(TurnAllOff());
        //    GameObject.Find("Text7").renderer.enabled = true;
			
        //    break;

        //case 8:
			
        //    StartCoroutine(TurnAllOff());
        //    GameObject.Find("Text8").renderer.enabled = true;
			
        //    break;

        //case 9:
			
        //    StartCoroutine(TurnAllOff());
        //    GameObject.Find("Text9").renderer.enabled = true;
			
        //    break;

        //case 10:
			
        //    StartCoroutine(TurnAllOff());
        //    GameObject.Find("Text10").renderer.enabled = true;
			
        //    break;
		}
	}

    //public IEnumerator GetBluePrints()
    //{
    //    GameObject.Find ("FinishedText").GetComponent<TextMesh>().text = "Blueprints Found";
    //    yield return new WaitForSeconds (1);
    //}

	IEnumerator TurnOffColliders()
	{
		GameObject.Find("Word1").collider.enabled = false;
		GameObject.Find("Word2").collider.enabled = false;
		GameObject.Find("Word3").collider.enabled = false;
		GameObject.Find("Word4").collider.enabled = false;
        //GameObject.Find("Word5").collider.enabled = false;
        //GameObject.Find("Word6").collider.enabled = false;
        //GameObject.Find("Word7").collider.enabled = false;
        //GameObject.Find("Word8").collider.enabled = false;
        //GameObject.Find("Word9").collider.enabled = false;
        //GameObject.Find("Word10").collider.enabled = false;
		
		yield return new WaitForSeconds(0.5f);

	}



	IEnumerator TurnAllOff()
	{
		GameObject.Find("Text1").renderer.enabled = false;
		GameObject.Find("Text2").renderer.enabled = false;
		GameObject.Find("Text3").renderer.enabled = false;
		GameObject.Find("Text4").renderer.enabled = false;
        //GameObject.Find("Text5").renderer.enabled = false;
        //GameObject.Find("Text6").renderer.enabled = false;
        //GameObject.Find("Text7").renderer.enabled = false;
        //GameObject.Find("Text8").renderer.enabled = false;
        //GameObject.Find("Text9").renderer.enabled = false;
        //GameObject.Find("Text10").renderer.enabled = false;

		yield return new WaitForSeconds(0.5f);
	}
}
