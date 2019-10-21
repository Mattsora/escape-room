using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPasscode : MonoBehaviour
{
    public GeneratePasscode generatedCode;
    public TextMesh Text;
    public int Current;
    int Number;
    string Format;
    // Start is called before the first frame update
    void Start()
    {
        Number = generatedCode.Numbers[Current];
        if (Current == 0)
        {
            Format = string.Format("{0} - - -", Number);
        }
        else if (Current == 1)
        {
            Format = string.Format("- {0} - -", Number);
        }
        else if (Current == 2)
        {
            Format = string.Format("- - {0} -", Number);
        }
        else if (Current == 3)
        {
            Format = string.Format("- - - {0}", Number);
        }
        else
        {
            Format = null;
        }
        Text.text = Format;
    }
}
