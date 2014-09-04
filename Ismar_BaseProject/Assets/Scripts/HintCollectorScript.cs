using UnityEngine;
using System.Collections;

public class HintCollectorScript : MonoBehaviour {

    public GameObject [] sprites;

    void Start()
    {
        startVisibilities();
    }


    public void found(int key)
    {
        switch (key)
        {
            case 1:
                PlayerPrefsX.SetBool("GPS_key1", true);
                sprites[0].SetActive(true);
                sprites[1].SetActive(true);
                sprites[2].SetActive(true);
                break;
            case 2:
                PlayerPrefsX.SetBool("GPS_key2", true);
                sprites[3].SetActive(true);
                sprites[4].SetActive(true);
                sprites[5].SetActive(true);
                
                break;
            case 3:
                PlayerPrefsX.SetBool("GPS_key3", true);
                sprites[6].SetActive(true);
                sprites[7].SetActive(true);
                sprites[8].SetActive(true);                
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
