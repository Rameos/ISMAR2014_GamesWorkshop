using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

    public static void VictoryExecution()
    {
        GlobalData.Instance.gameSolved(MiniGame.GPSGame);
        Application.LoadLevel("GameSelector");
    }
}
