using UnityEngine;
using System.Collections;

public class GameSelector : MonoBehaviour
{
    bool isMarkerLocated = false;
    string gameName = "";

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
            Debug.Log("Starting the Magnifying Glass Game");
            gameName = "MagnifyingGlassGame";
            Invoke("LoadGame", 1);
        }
        else if (name == "maze3" || name == "MazeTarget2")
        {
            Debug.Log("Starting the Force Game");
            gameName = "ForceGame";
            Invoke("LoadGame", 1);
        }
    }

    void OnGUI()
    {
        if (isMarkerLocated)
        {
            GUI.skin.box.wordWrap = true;
            GUI.skin.box.fontSize = Screen.height / 20;
            GUI.Box(new Rect(Screen.width / 8f, Screen.height / 8f, (Screen.width * 6f) / 8f, (Screen.height * 6f) / 8f), "Starting the " + gameName);
        }
    }

    void LoadGame()
    {
        Application.LoadLevel(gameName);
    }
}