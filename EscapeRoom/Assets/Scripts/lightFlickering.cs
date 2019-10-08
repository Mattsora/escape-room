using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFlickering : MonoBehaviour
{
    public Light Light;
    public bool IsFlickering;
    public int Frequency = 60;

    float timeUntilFlicker;
    Random rng = new Random();

    // Start is called before the first frame update
    void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilFlicker = Random.Range(0, Frequency);
        if(timeUntilFlicker == 0)
        {
            Light.enabled = true;
        }
        else
        {        
            Light.enabled = false;

        }
    }
}
