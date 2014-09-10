using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GameSelector : MonoBehaviour
{
    bool isMarkerLocated = false;
    string sceneName = "";
    string notification = "";

    bool showStory = false;
    bool showInstructions = false;
    bool showMap = false;
    bool showProgress = true;

    [SerializeField]
    GUIStyle buttonsMainManu;

    [SerializeField]
    GUIStyle miniGameName;

    [SerializeField]
    GUIStyle statusButton;

    [SerializeField]
    Texture storyBackground;
    [SerializeField]
    Texture mapBackground;
    [SerializeField]
    Texture instructionBackground;

    [SerializeField]
    Texture doneQuestButton;
    [SerializeField]
    Texture openQuestButton;


    public Texture passwordTexture;
    public Texture mapTexture;

    private Vector2 anchorLayout;
    private Vector2 anchorText; 
   

	void Start()
	{
        //PlayerPrefs.DeleteAll();
	}
	
	void Update()
	{
	
	}

    public void OnTrackableFound(string name)
    {
        if (isMarkerLocated)
            return;

        isMarkerLocated = true;

        if (name == "Lens3")
        {
            if (!GlobalData.Instance.isGameSolved(MiniGame.MagnifyingLense))
            {
            notification = "Starting the Magnifying Glass game";
            sceneName = "MagnifyIntro";
            LoadGame();
            }
        }
        else if ((name == "maze3" || name == "MazeTarget2"))
        {
            if (!GlobalData.Instance.isGameSolved(MiniGame.EnergyMaze))
            {
                notification = "Starting the Energymaze game";
                sceneName = "ForceGameInstructions";
                LoadGame();
            }
        }
        else if (name == "BackCover")
        {
            if(!GlobalData.Instance.isGameSolved(MiniGame.Library))
            {
                notification = "Starting the Light game";
                sceneName = "LibraryInfo";
                LoadGame();
            }
        }
        else if (name == "PrincessMarker")
        {
            if(!GlobalData.Instance.isGameSolved(MiniGame.GPSGame))
            {
                notification = "Starting the GPS game";
                sceneName = "GPSscene";
                LoadGame();
            }
        }
    }

    bool IsReadyForLabGame()
    {
        GlobalData instance = GlobalData.Instance;

        return instance.isGameSolved(MiniGame.EnergyMaze) &&
            instance.isGameSolved(MiniGame.MagnifyingLense) && 
            instance.isGameSolved(MiniGame.GPSGame) && 
            instance.isGameSolved(MiniGame.Library);
    }

    void OnGUI()
    {
        GUI.skin.box.fontSize = Screen.height / 25;
        GUI.skin.button.fontSize = Screen.height / 25;

        GUI.skin.box.wordWrap = true;

        if (IsReadyForLabGame())
        {
            GUI.DrawTexture(new Rect(Screen.width / 4f, Screen.height / 4f, Screen.width / 2, Screen.width / 8f), passwordTexture);

            return;
        }

        if (GUI.Button(new Rect(0, 0, Screen.width / 4, Screen.height / 8), "STORY",buttonsMainManu))
        {
            showStory = true;
            showInstructions = false;
            showMap = false;
            showProgress = false;
        }

        if (GUI.Button(new Rect(Screen.width / 4, 0, Screen.width / 4, Screen.height / 8), "INSTRUCTIONS", buttonsMainManu))
        {
            showStory = false;
            showInstructions = true;
            showMap = false;
            showProgress = false;
        }

        if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 4, Screen.height / 8), "MAP", buttonsMainManu))
        {
            showStory = false;
            showInstructions = false;
            showMap = true;     
            showProgress = false;
        }

        if (GUI.Button(new Rect((Screen.width * 3f) / 4f, 0, Screen.width / 4, Screen.height / 8), "STATUS", buttonsMainManu))
        {
            showStory = false;
            showInstructions = false;    
            showMap = false;
            showProgress = true;
        }



        if (isMarkerLocated && notification != "")
        {
            showProgress = false;

            GUI.Box(new Rect(Screen.width / 4f, Screen.height / 4f, Screen.width / 2, Screen.height / 2), notification);

            return;
        }

        if (showStory)
        {
            GUI.DrawTexture(new Rect(Screen.width * 0.05f, Screen.height / 4f, Screen.width * 0.85f, Screen.width / 2.85f), storyBackground);
        }

        if (showProgress)
        {
            // Init Points
            anchorLayout = new Vector2(Screen.width * 0.7f, Screen.height * 0.3f);
            anchorText = new Vector2(Screen.width * 0.25f, Screen.height * 0.3f);
            miniGameName.fontSize = (int)(Screen.height * 0.05f);
            
            //GPS Game
            GUI.Label(new Rect(anchorText.x, anchorText.y, Screen.width * 0.48f, Screen.width * 0.05f), "The melodic safe", miniGameName);
            GUI.DrawTexture(new Rect(anchorLayout.x, anchorLayout.y, Screen.width * 0.05f, Screen.width * 0.05f), drawStatusOfGame(MiniGame.GPSGame));
            
            //EnergyGame
            GUI.Label(new Rect(anchorText.x, anchorText.y+Screen.height*0.15f, Screen.width * 0.48f, Screen.width * 0.05f), "EnergyGame", miniGameName);
            GUI.DrawTexture(new Rect(anchorLayout.x, anchorLayout.y + Screen.height * 0.15f, Screen.width * 0.05f, Screen.width * 0.05f), drawStatusOfGame(MiniGame.EnergyMaze));

            //Magnifying Glass
            GUI.Label(new Rect(anchorText.x, anchorText.y + Screen.height * 0.3f, Screen.width * 0.48f, Screen.width * 0.05f), "The lost source", miniGameName);
            GUI.DrawTexture(new Rect(anchorLayout.x, anchorLayout.y + Screen.height * 0.3f, Screen.width * 0.05f, Screen.width * 0.05f), drawStatusOfGame(MiniGame.MagnifyingLense));

            //EnergyGame
            GUI.Label(new Rect(anchorText.x, anchorText.y + Screen.height * 0.45f, Screen.width * 0.48f, Screen.width * 0.05f), "The missing candle", miniGameName);
            GUI.DrawTexture(new Rect(anchorLayout.x, anchorLayout.y + Screen.height * 0.45f, Screen.width * 0.05f, Screen.width * 0.05f), drawStatusOfGame(MiniGame.Library));

            
           
        }

        if (showInstructions)
        {
            GUI.DrawTexture(new Rect(Screen.width * 0.05f, Screen.height / 4f, Screen.width * 0.85f, Screen.width / 2.85f), instructionBackground);
        }

        if (showMap)
        {
            GUI.DrawTexture(new Rect(Screen.width * 0.05f, Screen.height / 4f, Screen.width * 0.85f, Screen.width / 2.85f), mapBackground);
        }
    }

    private Texture drawStatusOfGame(MiniGame type)
    {
        if(GlobalData.Instance.isGameSolved(type))
        {
            return doneQuestButton;

        }

        return openQuestButton;
    }

    void LoadGame()
    {
        Debug.Log("Loading new level");
        Application.LoadLevel(sceneName);
    }
}