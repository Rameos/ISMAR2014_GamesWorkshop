using UnityEngine;
using System.Collections;

public class MagnifyingGlassGame : MonoBehaviour
{
    Camera arCamera;
    Texture2D webcamTexture;

    GameObject background;
    GameObject glass;

    bool done = false;
    public float scale = 5;

	void Start()
	{
        arCamera = GameObject.Find("ARCamera").camera;
        background = GameObject.Find("Background");
        glass = GameObject.Find("Glass");

        webcamTexture = new Texture2D(0, 0, TextureFormat.RGB565, false);
        webcamTexture.filterMode = FilterMode.Bilinear;
        webcamTexture.wrapMode = TextureWrapMode.Clamp;

        QCARRenderer.Instance.DrawVideoBackground = false;

        QCARRenderer.Instance.SetVideoBackgroundTexture(webcamTexture);
        
        glass.renderer.material.mainTexture = webcamTexture;
        background.renderer.material.mainTexture = webcamTexture;

        AdjustBackgroundPlane();
	}
	
	void Update()
	{
        if (!done && QCARRenderer.Instance.IsVideoBackgroundInfoAvailable())
        {
            float aspect = arCamera.camera.aspect;

            Vector2[] uvs = background.GetComponent<MeshFilter>().mesh.uv;
            QCARRenderer.VideoTextureInfo info = QCARRenderer.Instance.GetVideoTextureInfo();
            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i].x *= (float)info.imageSize.x / (float)info.textureSize.x;
                uvs[i].y *= (float)info.imageSize.y / (float)info.textureSize.y;
            }
            background.GetComponent<MeshFilter>().mesh.uv = uvs;

            uvs = glass.GetComponent<MeshFilter>().mesh.uv;
            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i].x *= (float)info.imageSize.x / (float)info.textureSize.x;
                uvs[i].y *= (float)info.imageSize.y / (float)info.textureSize.y;
            }

            Vector2 center = new Vector2((float)info.imageSize.x / (float)info.textureSize.x, (float)info.imageSize.y / (float)info.textureSize.y) / 2;

            for (int i = 0; i < uvs.Length; i++)
            {
                uvs[i].x = (uvs[i].x - center.x) * scale + center.x;
                uvs[i].y = (uvs[i].y - center.y) * scale * aspect + center.y;
            }

            glass.GetComponent<MeshFilter>().mesh.uv = uvs;

            done = true;
        }
	}

    void AdjustBackgroundPlane()
    {
        float fov = arCamera.fieldOfView;
        float aspect = arCamera.aspect;

        //float yScale = transform.position.z * Mathf.Tan((fov / 2) * Mathf.Deg2Rad);
        //float xScale = yScale * aspect;

        background.transform.localScale = new Vector3(-aspect * 10, 10, 10);
    }
}