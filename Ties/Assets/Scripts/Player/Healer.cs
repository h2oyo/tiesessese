using UnityEngine;
using System.Collections;

public class Healer : MonoBehaviour
{
    public bool healerMenu;
  
    Transform player;
    public PlayerClass playerc;
    // Use this for initialization

    private float Distance()
    { return Vector3.Distance(player.position, gameObject.transform.position); }
    void OnMouseOver()
    {
        
        if (Input.GetMouseButtonDown(0) && Distance() < 3 )
        healerMenu = true;
    }
    void Start () {
        healerMenu = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        playerc = player.GetComponent<PlayerClass>();
    }
	
	// Update is called once per frame
	void Update () {

        
        

    }

   
    void OnGUI()
    {

        if (healerMenu == true)
        {
            Time.timeScale = 0;
            if (GUI.Button(new Rect(450, 200, 200, 50), "Heal Me!" ))
            { playerc.damageTaken = 0; }

            if (GUI.Button(new Rect(450, 250, 200, 50), "Shop!"))
            { }

            if (GUI.Button(new Rect(450, 300, 200, 50), "Goodbye!"))
            { healerMenu = false; }
        }
        else
        {
            Time.timeScale = 1;
        }



    }

}
