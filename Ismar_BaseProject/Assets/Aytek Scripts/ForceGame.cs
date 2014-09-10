using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ForceGame : MonoBehaviour
{
    public enum GameState
    {
        Idle,
        Intro,
        Running,
        Prompting,
        Win
    }

    public GameObject forceFieldPrefab;

    List<GameObject> forceFields = new List<GameObject>();

    Key key;
    Camera arCamera;

    List<GameObject> walls;

    Bounds bounds;

    public GameState gameState;

    public bool snapToGrid = false;

    float introTimer = 0;
    float gameTimer = 0;
    Vector3 lastWorldPosition = Vector3.zero;

    ForceGameTrackableEventHandler trackable = null;

    void InitObjectCache()
    {
        foreach (Transform t in trackable.children)
            t.gameObject.SetActive(true);

        arCamera = GameObject.Find("ARCamera").camera;
        key = GameObject.Find("Key").GetComponent<Key>();
        walls = new List<GameObject>(GameObject.FindGameObjectsWithTag("Wall"));
        bounds = GameObject.Find("Bounds").collider.bounds;
    }

    void SetGameState(GameState gameState)
    {
        if (gameState == GameState.Idle)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].transform.localScale = Vector3.zero;
            }
        }
        else if (gameState == GameState.Intro)
        {
            for (int i = 0; i < forceFields.Count; i++)
            {
                Destroy(forceFields[i]);
            }

            foreach (GameObject wall in walls)
            {
                wall.collider.enabled = false;
            }

            introTimer = 0;
            key.transform.position = Vector3.zero;
            key.velocity = Vector3.zero;
        }
        else if (gameState == GameState.Running)
        {
            gameTimer = 0;

            key.velocity = Vector3.left;
        }
        else if (gameState == GameState.Prompting)
        {
        }
        else if (gameState == GameState.Win)
        {
        }

        this.gameState = gameState;
    }

    void Awake()
    {
	}

    void Update()
    {
        if (gameState == GameState.Intro)
        {
            Intro();
        }
        else if (gameState == GameState.Running)
        {
            gameTimer += Time.deltaTime;
            
            CreateForceFieldUsingSwipeMotion();
        }
    }

    bool trackingInitialized = false;
    string trackableName = "";

    public void OnTrackableFound(string name, ForceGameTrackableEventHandler sender)
    {
        if (!trackingInitialized)
        {
            trackableName = name;
            trackable = sender;

            InitObjectCache();

            SetGameState(GameState.Idle);
            SetGameState(GameState.Intro);
        }

        if(sender.mTrackableBehaviour.TrackableName == trackableName)
            Time.timeScale = 1;

        trackingInitialized = true;
    }

    public void OnTrackableLost(string name, ForceGameTrackableEventHandler sender)
    {
        Time.timeScale = 0;
    }

    void OnGUI()
    {
        GUI.skin.box.fontSize = Screen.height / 25;
        GUI.skin.button.fontSize = Screen.height / 25;

        if (GUI.Button(new Rect(0, 0, Screen.width / 4, Screen.height / 8), "MAIN MENU"))
        {
            Application.LoadLevel("GameSelector");
        }

        if (GUI.Button(new Rect(Screen.width / 4, 0, Screen.width / 4, Screen.height / 8), "RESTART"))
        {
            SetGameState(GameState.Intro);
        }

        if (gameState == GameState.Win)
        {
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "CONGRATULATIONS!\nYou succesfully finished the game. Tap on MAIN MENU for other mini-games." );
        }

        if (gameState == GameState.Prompting)
        {
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "YOU HIT THE WALL");
        }
    }

    void Intro()
    {
        introTimer += Time.deltaTime;

        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].transform.localScale = new Vector3(introTimer, introTimer, introTimer);
        }

        if (introTimer > 1)
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].collider.enabled = true;
            }

            key.GetComponent<Key>().velocity = Vector3.left;

            SetGameState(GameState.Running);
        }
    }

    void CreateForceFieldUsingSwipeMotion()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = arCamera.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                lastWorldPosition = hit.point;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = arCamera.camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 rotation = Vector3.zero;
                Vector3 direction = hit.point - lastWorldPosition;

                if (direction.magnitude < 0.5)
                    return;

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x > 0)
                        rotation.z = 0;
                    else
                        rotation.z = 180;
                }
                else
                {
                    if (direction.y > 0)
                        rotation.z = 90;
                    else
                        rotation.z = 270;
                }

                if (snapToGrid)
                {
                    lastWorldPosition.x = Mathf.RoundToInt(lastWorldPosition.x);
                    lastWorldPosition.y = Mathf.RoundToInt(lastWorldPosition.y);
                }

                if(bounds.Contains(lastWorldPosition))
                    forceFields.Add(Instantiate(forceFieldPrefab, lastWorldPosition, Quaternion.Euler(rotation)) as GameObject);
            }
        }

        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector2 touchPosition = Input.GetTouch(i).position;
                Ray ray = arCamera.camera.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    lastWorldPosition = hit.point;
                }
            }

            ++i;
        }

        i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Ended)
            {
                Vector2 touchPosition = Input.GetTouch(i).position;
                Ray ray = arCamera.camera.ScreenPointToRay(touchPosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 rotation = Vector3.zero;
                    Vector3 direction = hit.point - lastWorldPosition;

                    if (direction.magnitude < 0.5)
                        return;

                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        if (direction.x > 0)
                            rotation.z = 0;
                        else
                            rotation.z = 180;
                    }
                    else
                    {
                        if (direction.y > 0)
                            rotation.z = 90;
                        else
                            rotation.z = 270;
                    }

                    if (snapToGrid)
                    {
                        lastWorldPosition.x = Mathf.RoundToInt(lastWorldPosition.x);
                        lastWorldPosition.y = Mathf.RoundToInt(lastWorldPosition.y);
                    }


                    forceFields.Add(Instantiate(forceFieldPrefab, lastWorldPosition, Quaternion.Euler(rotation)) as GameObject);
                }
            }

            ++i;
        }
    }
	
    void Reset()
    {

    }

    #region MESSAGES

    void HitTheWall()
    {
        gameState = GameState.Prompting;

        Reset();
    }

    void WonTheGame()
    {
        Debug.Log(trackableName);

        key.velocity = Vector3.zero;

        gameState = GameState.Win;

        if (trackableName == "maze3" || trackableName == "MazeTarget2")
        {
            GlobalData.Instance.gameSolved(MiniGame.EnergyMaze);
        }
    }

    #endregion
}
