using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManagerGPS : MonoBehaviour {

    public static GameObject loader;
    public GameObject loader1;

    public Toggle toggler1;
    public Toggle toggler2;
    public Toggle toggler3;

    public static Toggle toggle1;
    public static Toggle toggle2;
    public static Toggle toggle3;



	void Start () {
        toggle1 = toggler1;
        toggle2 = toggler2;
        toggle3 = toggler3;
        loader = loader1;
        toggle1.isOn = false;
        toggle2.isOn = false;
        toggle3.isOn = false;
        toggle1.interactable = false;
        toggle2.interactable = false;
        toggle3.interactable = false;
        
        
	}

    public static void ShowLoadingScreen()
    {
        loader.SetActive(true);
    }


    public static void Toggle1()
    {
        toggle1.isOn = true;
    }

    public static void Toggle2()
    {
        toggle2.isOn = true;
    }

    public static void Toggle3()
    {
        toggle3.isOn = true;
    }
}
