using UnityEngine;
using System.Collections;

public class GameSelector : MonoBehaviour
{
    bool isMarkerLocated = false;
    string sceneName = "";
    string notification = "";

    bool showStory = true;
    bool showInstructions = false;
    bool showMap = false;
    bool showProgress = false;

    string instructionsText = "Try to locate to posters to launch the games. You can use the MAP for help. Once you located the poster, scan it with your camera to launch the game. You can check the status of the game using STATUS button.";
    string storyText = "Princess Lineblock is captured ... ";

    public Texture passwordTexture;
    public Texture mapTexture;

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
            notification = "Starting the Magnifying Glass game";
            sceneName = "MagnifyIntro";
            LoadGame();
        }
        else if ((name == "maze3" || name == "MazeTarget2"))
        {
            notification = "Starting the Energymaze game";
            sceneName = "ForceGameInstructions";
            LoadGame();
        }
        else if (name == "BackCover")
        {
            notification = "Starting the Light game";
            sceneName = "LibraryInfo";
            LoadGame();
        }
        else if (name == "PrincessMarker")
        {
            notification = "Starting the GPS game";
            sceneName = "GPSscene";
            LoadGame();
        }
    }

    bool IsReadyForLabGame()
    {
        GlobalData instance = GlobalData.Instance;

        return instance.isGameSolved(MiniGame.EnergyMaze) &&
            instance.isGameSolved(MiniGame.MagnifyingLense);
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

        if (GUI.Button(new Rect(0, 0, Screen.width / 4, Screen.height / 8), "STORY"))
        {
            showStory = true;
            showInstructions = false;
            showMap = false;
            showProgress = false;
        }

        if (GUI.Button(new Rect(Screen.width / 4, 0, Screen.width / 4, Screen.height / 8), "INSTRUCTIONS"))
        {
            showStory = false;
            showInstructions = true;
            showMap = false;
            showProgress = false;
        }

        if (GUI.Button(new Rect(Screen.width / 2, 0, Screen.width / 4, Screen.height / 8), "MAP"))
        {
            showStory = false;
            showInstructions = false;
            showMap = true;     
            showProgress = false;
        }

        if (GUI.Button(new Rect((Screen.width  * 3f) / 4f, 0, Screen.width / 4, Screen.height / 8), "STATUS"))
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
            GUI.Box(new Rect(Screen.width / 4f, Screen.height / 4f, Screen.width / 2f, Screen.height / 2f), storyText);
        }

        if (showProgress)
        {
            string progressText = "";

            string gpsGameStatus = GlobalData.Instance.isGameSolved(MiniGame.GPSGame) ? "<color=green>COMPLETE</color>" : "<color=red>INCOMPLETE</color>";
            string energyMazeGameStatus = GlobalData.Instance.isGameSolved(MiniGame.EnergyMaze) ? "<color=green>COMPLETE</color>" : "<color=red>INCOMPLETE</color>";
            string magnifyingLenseGameStatus = GlobalData.Instance.isGameSolved(MiniGame.MagnifyingLense) ? "<color=green>COMPLETE</color>" : "<color=red>INCOMPLETE</color>";
            string libraryGameStatus = GlobalData.Instance.isGameSolved(MiniGame.Library) ? "<color=green>COMPLETE</color>" : "<color=red>INCOMPLETE</color>";

            progressText += "GPS GAME: " + gpsGameStatus + "\n";
            progressText += "ENERGY MAZE: " + energyMazeGameStatus + "\n";
            progressText += "MAGNIFYING GLASS: " + magnifyingLenseGameStatus + "\n";
            progressText += "LIBRARY GAME: " + libraryGameStatus + "\n";

            GUI.Box(new Rect(Screen.width / 4f, Screen.height / 4f, Screen.width / 2f, Screen.height / 2f), progressText);
        }

        if (showInstructions)
        {
            GUI.Box(new Rect(Screen.width / 4f, Screen.height / 4f, Screen.width / 2f, Screen.height / 2f), instructionsText);
        }

        if (showMap)
        {
            GUI.DrawTexture(new Rect(0, Screen.height / 4f, Screen.width, Screen.width / 4), mapTexture);
        }
    }

    void LoadGame()
    {
        Debug.Log("Loading new level");
        Application.LoadLevel(sceneName);
    }
}