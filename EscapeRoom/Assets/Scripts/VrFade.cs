using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VrFade : MonoBehaviour
{
    public float fadeDuration;
    public bool fadedOut;
    public bool fadedIn;
    bool fadingOut, fadingIn;
    float x;
    RawImage fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<RawImage>();
        fadeImage.color = new Color(255, 255, 255, 0);
    }
    public void FadeOut()
    {

    }
    public void FadeIn()
    {
        if(!fadedIn)
        {
            fadeImage.color = new Color(0, 0, 0, 0);
            fadedIn = true;
        }

            x = x + -0.025f * Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, x);

        
    }
    // Update is called once per frame
    void Update()
    {
        if(!fadingIn)
        {
            x =x+ 0.025f* Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, x);
           
        }
    }
}
