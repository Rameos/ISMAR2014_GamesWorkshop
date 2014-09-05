using UnityEngine;
using System.Collections;

public class UIManagerGPS : MonoBehaviour {

    public static GameObject loader;
    public GameObject loader1;

	void Start () {
        loader = loader1;
	}

    public static void ShowLoadingScreen()
    {
        loader.SetActive(true);
    }
}
