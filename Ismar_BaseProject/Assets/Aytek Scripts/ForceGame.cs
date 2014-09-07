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
    Vector3 lastWorldPosition = Vector3.zero;

    void InitObjectCache()
    {
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

            introTimer = 0;
            key.transform.position = Vector3.zero;
            key.velocity = Vector3.zero;
        }
        else if (gameState == GameState.Running)
        {
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
        InitObjectCache();

        SetGameState(GameState.Idle);
	}

    void Update()
    {
        if (gameState == GameState.Intro)
        {
            Intro();
        }
        else if (gameState == GameState.Running)
        {
            CreateForceFieldUsingSweepMotion();
        }
    }

    public void OnTrackableDetected()
    {
        SetGameState(GameState.Intro);
    }

    void OnGUI()
    {
        if (gameState == GameState.Running)
        {
            if (GUI.Button(new Rect(10, 10, 400, 80), "RESTART"))
            {
                SetGameState(GameState.Intro);
            }
        }
        else if (gameState == GameState.Prompting)
        {
            if (GUI.Button(new Rect(10, 10, 400, 80), "TRY AGAIN"))
            {
                SetGameState(GameState.Intro);
            }
        }
        else if (gameState == GameState.Win)
        {
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 40, 400, 80), "YOU FINISHED THE GAME");

            if (GUI.Button(new Rect(10, 10, 400, 80), "RESTART"))
            {
                SetGameState(GameState.Intro);
            }
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

            gameState = GameState.Running;
        }
    }

    void CreateForceFieldUsingSweepMotion()
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
        key.velocity = Vector3.zero;

        gameState = GameState.Win;
    }

    #endregion
}
