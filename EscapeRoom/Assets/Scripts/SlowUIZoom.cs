using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlowUIZoom : MonoBehaviour
{
    public float zoomSpeed;
    public float fadeTime;
    float timeX;
    RectTransform rectTransform;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    void FadeOut()
    {
        Text t = GetComponent<Text>();
        GetComponent<Text>().color = new Color(t.color.r, t.color.g, t.color.b, t.color.a - (1.15f * Time.deltaTime));
    }
    private void Update()
    {
        if(timeX<fadeTime)
        {
            timeX = timeX + Time.deltaTime;
        }
        else
        {
            FadeOut();
        }
    }
    void LateUpdate()
    {
        rectTransform.localScale += new Vector3(zoomSpeed * Time.deltaTime, zoomSpeed * Time.deltaTime, zoomSpeed * Time.deltaTime);
    }
}
