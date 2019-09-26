using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }
    public void LoadFirstLevel()
    {
        Debug.Log("START BUTTON IS PRESSED");
        SceneManager.LoadScene("EscapeRoomAaronScene", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Debug.Log("Quit button is pressed");
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
