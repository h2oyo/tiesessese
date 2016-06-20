using UnityEngine;
using System.Collections;

public class Escmenu : MonoBehaviour
{
    public WarriorClass warrior;
    //menu option to on or off
    public bool pauseMenu = false;

    //calculate screen size
    float sw;
    float sh;

    void Start()
    {
        //getting screen size
        sw = Screen.width;
        sh = Screen.height;

        //pause set back to false
        pauseMenu = false;

    }

    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pauseMenu)
            {
                pauseMenu = true;
                //set frame rate to 0 so game will pause objects will be still.
                Time.timeScale = 0;
            }
            else
            {
                pauseMenu = false;
                Time.timeScale = 1;
            }
        }
    }

    void OnGUI()
    {
        //on top right side have a button to show main menu toggle 

        //if pause
        if (pauseMenu)
        {
            //resume button
            if (GUI.Button(new Rect(sw / 2 - 100, 200, 200, 50), "Resume"))
            {
                pauseMenu = false;
                Time.timeScale = 1;
            }
            //Exit to Menu button
            if (GUI.Button(new Rect(sw / 2 - 100, 260, 200, 50), "Main Menu"))
            {
                Application.LoadLevel(0);
            }
            //Quit button
            if (GUI.Button(new Rect(sw / 2 - 100, 320, 200, 50), "Quit"))
            {
                Application.Quit();
            }
        }

    }

}

