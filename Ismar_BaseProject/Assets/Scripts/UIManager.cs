using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    string textBuffer;
    public static Button buttonHide;
    public static Button buttonShow;
    public static Text text;

    public Button buttonHide1;
    public Button buttonShow1;
    public Text text1;

    void Start()
    {
        buttonHide = buttonHide1;
        buttonShow = buttonShow1;
        text = text1;
    }

    public static void ShowCancelDialog()
    {
        buttonHide.gameObject.SetActive(false);
        buttonShow.gameObject.SetActive(true);
        text.gameObject.SetActive(true);
    }

    public static void HideCancelDialog()
    {
        buttonHide.gameObject.SetActive(true);
        buttonShow.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }

    public void TriggerCancelPuzzle()
    {
        Application.LoadLevel(0);            
    }

}
