using UnityEngine;
using System.Collections;

public class GUITextureOnCamera : MonoBehaviour {
	public GUITexture m_guiTexture;
	public RenderTexture m_renderTexture;
	public bool m_flipVertical;
	public bool m_flipHorizontal;
	// Use this for initialization
	private int m_screenWidth;
	private int m_screenHeight;
	private float m_textureInsetWidth;
	private float m_textureInsetHeight;
	private float m_textureInsetX;
	private float m_textureInsetY;
	private int m_texWidth;
	private int m_texHeight;
	void Start () {
		this.m_screenHeight = Screen.height;
		this.m_screenWidth = Screen.width;
		m_texWidth = m_renderTexture.width;
		m_texHeight = m_renderTexture.height;
		
		
		
		m_textureInsetWidth = ((float)m_screenWidth) / m_texWidth * m_texWidth;
		m_textureInsetHeight = ((float)m_screenHeight) / m_texHeight * m_texHeight;
		m_textureInsetX = 0;
		m_textureInsetY = 0;		
		
		if(m_flipVertical){
			m_textureInsetHeight = -m_textureInsetHeight;
			m_textureInsetY = m_screenHeight;
		}
		
		if(m_flipHorizontal){
			m_textureInsetWidth = -m_textureInsetWidth;
			m_textureInsetX = m_screenWidth;
		}

		m_guiTexture.color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
		m_guiTexture.pixelInset = new Rect(m_textureInsetX, m_textureInsetY, m_textureInsetWidth, m_textureInsetHeight);
		m_guiTexture.texture = m_renderTexture;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
