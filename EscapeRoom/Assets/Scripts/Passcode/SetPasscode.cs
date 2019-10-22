using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPasscode : MonoBehaviour
{
    public GeneratePasscode generatedCode;
    public TextMesh Text;
<<<<<<< HEAD
    public string combinedNumbers;
    public int Current;
    int Number;
    string Format;
    
    void Update()
    {
        Number = generatedCode.Numbers[Current];
        
=======
    public int Current;
    int Number;
    string Format;
    // Start is called before the first frame update
    void Start()
    {
        Number = generatedCode.Numbers[Current];
>>>>>>> master
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
<<<<<<< HEAD
        Debug.Log(GenerateCombinedNumber());
    }

    public string GenerateCombinedNumber()
    {
      
            combinedNumbers = generatedCode.Numbers[0].ToString() + generatedCode.Numbers[1].ToString()+generatedCode.Numbers[2].ToString() + generatedCode.Numbers[3].ToString();
        return combinedNumbers;
=======
>>>>>>> master
    }
}
