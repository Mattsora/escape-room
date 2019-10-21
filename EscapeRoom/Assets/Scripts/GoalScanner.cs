using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScanner : MonoBehaviour
{
    public Transform targetToWin;
    DoorGoal doorGoal;
    // Start is called before the first frame update
    void Start()
    {
        doorGoal = FindObjectOfType<DoorGoal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == targetToWin.name)
        {
            doorGoal.playerHasWon = true;
        }
    }
}
