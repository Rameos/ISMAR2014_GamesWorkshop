using UnityEngine;
using System.Collections;

public class TetrisGuy_SelectColor : MonoBehaviour {

    [SerializeField]
    private Material[] colors;


	// Use this for initialization
	void Start () {
        int randomCol = Random.Range(0, colors.Length - 1);
        renderer.material = colors[randomCol];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
