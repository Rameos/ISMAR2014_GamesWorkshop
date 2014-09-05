using UnityEngine;
using System.Collections;

public class HintCollectorScript : MonoBehaviour {

    public GameObject [] sprites;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        startVisibilities();
    }


    public void found(int key)
    {
        switch (key)
        {
            case 1:
                PlayerPrefsX.SetBool("GPS_key1", true);
                for (int i = 0; i < 10; i++)
                {
                    sprites[i].SetActive(true);
                }
                break;
            case 2:
                PlayerPrefsX.SetBool("GPS_key2", true);
                for (int i = 10; i < 20; i++)
                {
                    sprites[i].SetActive(true);
                }
                
                break;
            case 3:
                PlayerPrefsX.SetBool("GPS_key3", true);
                for (int i = 20; i < 30; i++)
                {
                    sprites[i].SetActive(true);
                }  
                break;
            default:
                Debug.Log("that key does not exist!");
                break;
        }
    }

    void startVisibilities()
    {
        if (PlayerPrefsX.GetBool("GPS_key1", false))
        {
            found(1);
        }
        if (PlayerPrefsX.GetBool("GPS_key2", false))
        {
            found(2);
        }
        if (PlayerPrefsX.GetBool("GPS_key3", false))
        {
            found(3);
        }
    }
}
