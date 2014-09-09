using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static Button buttonHide;
    public static Button buttonShow;
    public static GameObject lostObject;
    public static GameObject loader;

    public GameObject lostObject1;
    public Button buttonHide1;
    public Button buttonShow1;
    public GameObject loader1;

    void Start()
    {
        buttonHide = buttonHide1;
        buttonShow = buttonShow1;
        lostObject = lostObject1;
        loader = loader1;
    }

    public static void ShowCancelDialog()
    {
        buttonHide.gameObject.SetActive(false);
        buttonShow.gameObject.SetActive(true);
        lostObject.SetActive(true);
    }

    public static void HideCancelDialog()
    {
        buttonHide.gameObject.SetActive(true);
        buttonShow.gameObject.SetActive(false);
        lostObject.SetActive(false);
    }

    public static void ShowLoadingScreen()
    {
        loader.SetActive(true);
    }

    public void TriggerCancelPuzzle()
    {
        ShowLoadingScreen();
        Application.LoadLevelAsync(0);            
    }
}
