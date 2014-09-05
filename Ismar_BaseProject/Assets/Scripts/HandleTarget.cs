using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HandleTarget : MonoBehaviour
{

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;
    public GameObject safe;
    public Text text;

    public static bool victoryTriggered;
    private bool victory;

    void Update()
    {
        if (victory)
        {
            GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cube");

            foreach (GameObject cube in cubeObjects)
            {
                if (!cube.GetComponent<RotateCube>().aligned)
                {
                    return;
                }
            }
            foreach (GameObject cube in cubeObjects)
            {
                cube.GetComponent<RotateCube>().victoryTriggered = true;
            }

            Destroy(target1);
            Destroy(target2);
            Destroy(target3);

            safe.animation.Play("ArmatureAction");
            victoryTriggered = true;
            victory = false;
        }

    }

    public void ShowTarget()
    {
        if (victoryTriggered)
            return;

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

    public void Victory()
    {
        victory = true;
    }
}
