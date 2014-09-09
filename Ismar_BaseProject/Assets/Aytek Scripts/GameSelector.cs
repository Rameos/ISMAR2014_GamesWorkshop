using UnityEngine;
using System.Collections;

public class GameSelector : MonoBehaviour
{
    bool isMarkerLocated = false;
    string sceneName = "";
    string notification = "";

	void Start()
	{
	
	}
	
	void Update()
	{
	
	}

    public void OnTrackableFound(string name)
    {
        if (isMarkerLocated)
            return;

        isMarkerLocated = true;

        if (name == "Lens1" || name == "Lens2" || name == "Lens3")
        {
            notification = "Starting the Magnifying Glass game";
            sceneName = "MagnifyIntro";
            Invoke("LoadGame", 1);
        }
        else if (name == "maze3" || name == "MazeTarget2")
        {
            notification = "Starting the Energymaze game";
            sceneName = "ForceGameInstructions";
            Invoke("LoadGame", 1);
        }
        else if (name == "BackCover")
        {
            notification = "Starting the Light game";
            sceneName = "LibraryInfo";
            Invoke("LoadGame", 1);
        }
        else if (name == "PrincessMarker")
        {
            notification = "Starting the GPS game";
            sceneName = "GPSscene";
            Invoke("LoadGame", 1);
        }
    }

    void OnGUI()
    {
        if (isMarkerLocated)
        {
            GUI.skin.box.wordWrap = true;
            GUI.skin.box.fontSize = Screen.height / 20;
            GUI.Box(new Rect(Screen.width / 8f, Screen.height / 8f, (Screen.width * 6f) / 8f, (Screen.height * 6f) / 8f), notification);
        }
    }

    void LoadGame()
    {
        Application.LoadLevel(sceneName);
    }
}