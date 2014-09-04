using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandleTarget : MonoBehaviour
{

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public Text text;

    public void ShowTarget()
    {
        GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

        foreach (GameObject cube in cubeObjects)
        {
            cube.GetComponent<RotateCube>().ChangeLocation();
        }

        if (PlayerPrefsX.GetBool("GPS_key2", false))
            target1.SetActive(!target1.activeSelf);
        if (PlayerPrefsX.GetBool("GPS_key1", false))
            target2.SetActive(!target2.activeSelf);
        if (PlayerPrefsX.GetBool("GPS_key3", false))
            target3.SetActive(!target3.activeSelf);

        if (target1.activeSelf || target2.activeSelf || target3.activeSelf)
            text.text = "Hide Target";
        else
            text.text = "Show Target";
    }
}
