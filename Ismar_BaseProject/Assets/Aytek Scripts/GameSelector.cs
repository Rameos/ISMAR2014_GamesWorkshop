using UnityEngine;
using System.Collections;

public class GameSelector : MonoBehaviour
{
    bool isMarkerLocated = false;
    string sceneName = "";
    string notification = "";

    bool isMapActive = false;

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

        if (name == "Lens3")
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
        GUI.skin.box.fontSize = Screen.height / 20;
        GUI.skin.button.fontSize = Screen.height / 20;

        if (!isMapActive)
        {
            if (GUI.Button(new Rect(10, 10, 400, 80), "OPEN MAP"))
            {
                isMapActive = true;
            }
        }
        else
        {
            if (GUI.Button(new Rect(10, 10, 400, 80), "CLOSE MAP"))
            {
                isMapActive = false;
            }
        }

        if (isMarkerLocated)
        {
            GUI.skin.box.wordWrap = true;
            GUI.skin.box.fontSize = Screen.height / 20;
            GUI.Box(new Rect(Screen.width / 8f, Screen.height / 8f, (Screen.width * 6f) / 8f, (Screen.height * 6f) / 8f), notification);
        }
    }

    void LoadGame()
    {
        Debug.Log("Loading new level");
        Application.LoadLevel(sceneName);
    }
}