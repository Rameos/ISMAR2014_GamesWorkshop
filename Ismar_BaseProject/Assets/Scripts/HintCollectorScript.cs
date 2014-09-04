using UnityEngine;
using System.Collections;

public class HintCollectorScript : MonoBehaviour {

    public GameObject [] sprites;


    public void found(int key)
    {
        switch (key)
        {
            case 1:
                sprites[0].SetActive(true);
                sprites[1].SetActive(true);
                sprites[2].SetActive(true);
                break;
            case 2:
                sprites[3].SetActive(true);
                sprites[4].SetActive(true);
                sprites[5].SetActive(true);
                
                break;
            case 3:
                sprites[6].SetActive(true);
                sprites[7].SetActive(true);
                sprites[8].SetActive(true);                
                break;
            default:
                Debug.Log("that key does not exist!");
                break;
        }
    }
}
