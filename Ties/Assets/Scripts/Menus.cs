using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Menus : MonoBehaviour {

    public Canvas quitMenu;
    public Button newGame;
    public Button loadGame;
    public Button toExit;

	// Use this for initialization
	void Start ()
    {
        quitMenu.enabled = false;
        quitMenu = quitMenu.GetComponent<Canvas>();
        newGame = newGame.GetComponent<Button>();
        loadGame = loadGame.GetComponent<Button>();
        toExit = toExit.GetComponent<Button>();
    }
    
    public void StartNewGame ()
    {
        SceneManager.LoadScene("SelectScreen");
    }
	
    public void StartLoadGame()
    {
        //load a saved game file
        //this is placeholder
        SceneManager.LoadScene("things");
    }

	public void QuitPanal()
    {
        quitMenu.enabled = true;
        newGame.enabled = false;
        loadGame.enabled = false;
        toExit.enabled = false;
    }

    public void clickNo()
    {
        quitMenu.enabled = false;
        newGame.enabled = true;
        loadGame.enabled = true;
        toExit.enabled = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
