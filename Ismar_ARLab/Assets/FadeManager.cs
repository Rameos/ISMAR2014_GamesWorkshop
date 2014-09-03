using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUITexture))]
public class FadeManager : MonoBehaviour
{
    public Color fadeColor;
    public static float fadeSpeed = 1f;

    private static bool isFadeInActive = false;
    private static bool isFadeOutActive = true;

    private float screenHeight;
    private float screenWidth;

    public static void FadeOut()
    {
        isFadeOutActive = true;
        isFadeInActive = false;
    }

    public static void FadeIn()
    {
        isFadeOutActive = false;
        isFadeInActive = true;
    }


    void Awake()
    {
        isFadeInActive = true;
        gameObject.guiTexture.color = fadeColor;
    }

    void Update()
    {
        gameObject.guiTexture.pixelInset = new Rect(Screen.width * 0.5f, 0, Screen.width, Screen.height);

        if (isFadeInActive)
        {
            StartScene();
        }

        if (isFadeOutActive)
        {
            EndScene();
        }
    }


    void StartScene()
    {
        guiTexture.color = Color.Lerp(guiTexture.color, Color.clear, fadeSpeed * Time.deltaTime);

        if (guiTexture.color.a <= 0.005f)
        {
            guiTexture.color = Color.clear;
            guiTexture.enabled = false;
            isFadeInActive = false;
        }
    }

    void EndScene()
    {

        guiTexture.enabled = true;
        guiTexture.color = Color.Lerp(guiTexture.color, fadeColor, fadeSpeed * Time.deltaTime);

        if (guiTexture.color.a >= 0.95f)
        {
            isFadeOutActive = false;
        }

    }

}