using UnityEngine;
using System.Collections;

public class MageClass : MonoBehaviour
{

    public int exp, level;
    public int str, dex, vit, mag;
   
    public int baseDamage;
    public int damageReduction;
    public int WeaponDamage;

    public bool StatsMenu = false;

    public int statPoints;

    float sw;
    float sh;

    public int HealthPoints, ManaPoints, MaxHealth;











    public int damageTaken;







    // Use this for initialization
    void Start()
    {
        level = 1;
        exp = 0;

        str = 4;
        dex = 5;
        vit = 7;
        mag = 14;
        StatsMenu = false;

        WeaponDamage = 6;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (!StatsMenu)
            {
                StatsMenu = true;
            }
            else
            {
                StatsMenu = false;
                Time.timeScale = 1;
            }
        }


        MaxHealth = (vit * 5);
        HealthPoints = MaxHealth - damageTaken;
      
        ManaPoints = mag * 5;
        baseDamage = mag / 2;

    }

    void OnGUI()
    {
        GUI.Button(new Rect(0, 575, 150, 50), "Health:" + HealthPoints);
        GUI.Button(new Rect(1000, 575, 100, 50), "Mana:" + ManaPoints);
        //on top right side have a button to show main menu toggle 
        if (GUI.Button(new Rect(1060, 0, 40, 40), "S:" + statPoints))
        {
            if (!StatsMenu)
            {
                StatsMenu = true;
                Time.timeScale = 0;
            }
            else
            {
                StatsMenu = false;
                Time.timeScale = 1;
            }
        }

        if (StatsMenu)
        {
            //resume button
            if (GUI.Button(new Rect(450, 200, 200, 50), "Stregth:" + str))
            {
                if (statPoints > 0)
                {
                    statPoints = statPoints - 1;
                    str = str + 1;
                }
            }
            //Exit to Menu button
            if (GUI.Button(new Rect(450, 260, 200, 50), "Dex:" + dex))
            {
                if (statPoints > 0)
                {
                    statPoints = statPoints - 1;
                    dex = dex + 1;
                }
            }
            //Quit button
            if (GUI.Button(new Rect(450, 320, 200, 50), "Vit:" + vit))
            {
                if (statPoints > 0)
                {
                    statPoints = statPoints - 1;
                    vit = vit + 1;
                }
            }
            if (GUI.Button(new Rect(450, 380, 200, 50), "Mag" + mag))
            {
                if (statPoints > 0)
                {
                    statPoints = statPoints - 1;
                    mag = mag + 1;
                }
            }
        }
    }



}