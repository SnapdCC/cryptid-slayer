using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    //The image to fade in the Inspector
    public Image m_Image;

    void Start()
    {
        m_Image.canvasRenderer.SetAlpha(-4.0f);
    }
    void Update()
    {
        m_Image.CrossFadeAlpha(1.0f, 3.0f, true);
    }

    
}
