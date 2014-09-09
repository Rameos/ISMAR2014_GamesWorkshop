using UnityEngine;
using System.Collections;

public class BluePrints : MonoBehaviour {

	public int CluesFound = 0;
	public int CollisionBarrier = 0;
	public int OptionList = 0;
	public int Answer = 0;

	public string AnswerText1;
	public string AnswerText2;
	public string AnswerText3;
	public string AnswerText4;

	GameObject myCamera; 
	RaycastHit hitter;
	float previousPositionY;	
	string TheRay;

	// Use this for initialization
	void Start () {

		previousPositionY = Input.mousePosition.y;			
		myCamera = GameObject.Find("ARCamera");	
	}
	
	// Update is called once per frame
	void Update () {
	
		GameObject.Find("Option1").renderer.enabled = false;
		GameObject.Find("Option2").renderer.enabled = false;
		GameObject.Find("Option3").renderer.enabled = false;
		GameObject.Find("Option4").renderer.enabled = false;
		GameObject.Find("Option5").renderer.enabled = false;
		GameObject.Find("Option6").renderer.enabled = false;
		GameObject.Find("Option7").renderer.enabled = false;
		GameObject.Find("Option8").renderer.enabled = false;
		GameObject.Find("Option9").renderer.enabled = false;
		GameObject.Find("Option10").renderer.enabled = false;

		AnswerText1 = GameObject.Find ("AnswerText1").GetComponent<TextMesh>().text;
		AnswerText2 = GameObject.Find ("AnswerText2").GetComponent<TextMesh>().text;;
		AnswerText3 = GameObject.Find ("AnswerText3").GetComponent<TextMesh>().text;;
		AnswerText4 = GameObject.Find ("AnswerText4").GetComponent<TextMesh>().text;;


		GameObject.Find ("AnswerMenu").collider.enabled = false;

		CluesFound = GameObject.Find("ARCamera").GetComponent<Raycasting>().WordCount;

		Ray ray = camera.ScreenPointToRay(Input.mousePosition);				// Raycasting. Basically allows the button interaction
		
		Physics.Raycast(myCamera.transform.position, ray.direction, out hitter);
		
		Debug.DrawRay(myCamera.transform.position, ray.direction);


		if(AnswerText1 == "CapturePrincess();" && AnswerText2 == "ClimbLadder();" && AnswerText3 == "GetAngry();" && AnswerText4 == "ThrowBarrel();" )
		{

			print("WINNER");

		}




		if (CluesFound == 10) 
		{
			CollisionBarrier = 1;
		}

		switch(CollisionBarrier)
		{
			case 0:

			GameObject.Find("Answer1").collider.enabled = false;
			GameObject.Find("Answer1").renderer.enabled = false;
			GameObject.Find("Answer2").collider.enabled = false;
			GameObject.Find("Answer2").renderer.enabled = false;
			GameObject.Find("Answer3").collider.enabled = false;
			GameObject.Find("Answer3").renderer.enabled = false;
			GameObject.Find("Answer4").collider.enabled = false;
			GameObject.Find("Answer4").renderer.enabled = false;


			break;

			case 1:

			GameObject.Find("Answer1").collider.enabled = true;
			GameObject.Find("Answer2").collider.enabled = true;
			GameObject.Find("Answer3").collider.enabled = true;
			GameObject.Find("Answer4").collider.enabled = true;

			break;


		}


		switch(OptionList)
		{
			case 0:
			StartCoroutine(OptionsOff());
			break;

			case 1:
			StartCoroutine(OptionsOn());
			break;

		}

		switch(Answer)
		{
			case 0:

			break;

			case 1:
			
			break;

		}

		if (hitter.collider != null && hitter.collider.name == "Answer1") 
		{		
			OptionList = 1;
			Answer = 1;
		}

		if (hitter.collider != null && hitter.collider.name == "Answer2") 
		{		
			OptionList = 1;
			Answer = 2;
		}

		if (hitter.collider != null && hitter.collider.name == "Answer3") 
		{		
			OptionList = 1;
			Answer = 3;
		}

		if (hitter.collider != null && hitter.collider.name == "Answer4") 
		{		
			OptionList = 1;
			Answer = 4;
		}
			

		if (hitter.collider != null && hitter.collider.name == "Option1") 
		{	
			switch(Answer)
			{
				case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "ClimbLadder();";
				break;

				case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "ClimbLadder();";
				break;

				case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "ClimbLadder();";
				break;

				case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "ClimbLadder();";
				break;
			}

		}

		if (hitter.collider != null && hitter.collider.name == "Option2") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "ThrowBarrel();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "ThrowBarrel();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "ThrowBarrel();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "ThrowBarrel();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option3") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "GetAngry();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "GetAngry();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "GetAngry();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "GetAngry();";
				break;
			}
			
		}


		if (hitter.collider != null && hitter.collider.name == "Option4") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "CapturePrincess();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "CapturePrincess();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "CapturePrincess();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "CapturePrincess();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option5") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "GainRupee();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "GainRupee();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "GainRupee();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "GainRupee();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option6") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "DestroyBlock();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "DestroyBlock();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "DestroyBlock();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "DestroyBlock();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option7") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "EatMushroom();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "EatMushroom();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "EatMushroom();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "EatMushroom();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option8") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "CrushEnemy();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "CrushEnemy();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "CrushEnemy();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "CrushEnemy();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option9") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "GainTriForcePiece();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "GainTriForcePiece();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "GainTriForcePiece();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "GainTriForcePiece();";
				break;
			}
			
		}

		if (hitter.collider != null && hitter.collider.name == "Option10") 
		{	
			switch(Answer)
			{
			case 1:
				GameObject.Find("AnswerText1").GetComponent<TextMesh>().text = "DrinkPotion();";
				break;
				
			case 2:
				GameObject.Find("AnswerText2").GetComponent<TextMesh>().text = "DrinkPotion();";
				break;
				
			case 3:
				GameObject.Find("AnswerText3").GetComponent<TextMesh>().text = "DrinkPotion();";
				break;
				
			case 4:
				GameObject.Find("AnswerText4").GetComponent<TextMesh>().text = "DrinkPotion();";
				break;
			}
			
		}


		if (hitter.collider != null && hitter.collider.name == "SourceCode") 
		{		
			//OptionList = 0;			
		}


	}



	public IEnumerator OptionsOn()
	{
		GameObject.Find ("OText1").renderer.enabled = true;
		GameObject.Find ("OText2").renderer.enabled = true;
		GameObject.Find ("OText3").renderer.enabled = true;
		GameObject.Find ("OText4").renderer.enabled = true;
		GameObject.Find ("OText5").renderer.enabled = true;
		GameObject.Find ("OText6").renderer.enabled = true;
		GameObject.Find ("OText7").renderer.enabled = true;
		GameObject.Find ("OText8").renderer.enabled = true;
		GameObject.Find ("OText9").renderer.enabled = true;
		GameObject.Find ("OText10").renderer.enabled = true;

		GameObject.Find ("Option1").collider.enabled = true;
		GameObject.Find ("Option2").collider.enabled = true;
		GameObject.Find ("Option3").collider.enabled = true;
		GameObject.Find ("Option4").collider.enabled = true;
		GameObject.Find ("Option5").collider.enabled = true;
		GameObject.Find ("Option6").collider.enabled = true;
		GameObject.Find ("Option7").collider.enabled = true;
		GameObject.Find ("Option8").collider.enabled = true;
		GameObject.Find ("Option9").collider.enabled = true;
		GameObject.Find ("Option10").collider.enabled = true;

		GameObject.Find ("AnswerMenu").renderer.enabled = true;
		GameObject.Find ("AnswerMenu").collider.enabled = true;

		yield return new WaitForSeconds(1);
	}

	public IEnumerator OptionsOff()
	{
		GameObject.Find ("OText1").renderer.enabled = false;
		GameObject.Find ("OText2").renderer.enabled = false;
		GameObject.Find ("OText3").renderer.enabled = false;
		GameObject.Find ("OText4").renderer.enabled = false;
		GameObject.Find ("OText5").renderer.enabled = false;
		GameObject.Find ("OText6").renderer.enabled = false;
		GameObject.Find ("OText7").renderer.enabled = false;
		GameObject.Find ("OText8").renderer.enabled = false;
		GameObject.Find ("OText9").renderer.enabled = false;
		GameObject.Find ("OText10").renderer.enabled = false;
		
		GameObject.Find ("Option1").collider.enabled = false;
		GameObject.Find ("Option2").collider.enabled = false;
		GameObject.Find ("Option3").collider.enabled = false;
		GameObject.Find ("Option4").collider.enabled = false;
		GameObject.Find ("Option5").collider.enabled = false;
		GameObject.Find ("Option6").collider.enabled = false;
		GameObject.Find ("Option7").collider.enabled = false;
		GameObject.Find ("Option8").collider.enabled = false;
		GameObject.Find ("Option9").collider.enabled = false;
		GameObject.Find ("Option10").collider.enabled = false;

		GameObject.Find ("AnswerMenu").renderer.enabled = false;
		GameObject.Find ("AnswerMenu").collider.enabled = false;

		yield return new WaitForSeconds(1);
	}


}
