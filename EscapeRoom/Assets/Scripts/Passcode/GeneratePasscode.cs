using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePasscode : MonoBehaviour
{
    public int[] Numbers = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        Randomize();
    }

    // Will randomize unless already set
    void Randomize()
    {     
        for (int i = 0; i < 4; i++)
        {
            Numbers[i] = Random.Range(0, 9);
        }
    }

}
