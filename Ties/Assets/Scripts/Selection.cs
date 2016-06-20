using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour {

    public Button back;
    public Button soul;
    public Button heart;
    public PlayerClass players;
 
    
	// Use this for initialization
	void Start ()
    {
        back = back.GetComponent<Button>();
        soul = soul.GetComponent<Button>();
        heart = heart.GetComponent<Button>();

	}
	
    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void mageButton()
    {
        //some how load game with mage settings
        PlayerClass.MageSelected = true;
        SceneManager.LoadScene("thingsthesecond");
    }

    public void warriorButton()
    {
        //some how load game with warrior settings
        PlayerClass.WarriorSelected = true;
        SceneManager.LoadScene("thingsthesecond");
    }
}
