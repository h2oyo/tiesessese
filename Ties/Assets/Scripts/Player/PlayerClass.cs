using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerClass : MonoBehaviour {


	private static List<Item> _inventory = new List<Item>();
	public static List<Item> Inventory
	{
		get { return _inventory; }
	}
	private static Item _equipedWeapon;
	public static Item EquipedWeapon
	{
		get { return _equipedWeapon; }
		set { _equipedWeapon = value; }
	}
	private static Item _equipedChest;
	public static Item EquipedChest
	{
		get { return _equipedChest; }
		set { _equipedChest = value; }
	}
  
    public int str, dex, vit, mag;
    public int HealthPoints, ManaPoints, MaxHealth;
    public int basedamage;
    public int damageReduction;
    public int WeaponDamage;
    public int weapon;
    public bool StatsMenu = false;
    public int damageTaken;
    public int statpoints;
    public int healthpots, manapots;
    float sw;
    float sh;
    public int maxhealthpots, maxmanapots;
    public bool isActive;
    float temptime;
    public int manaSpent;
    public int gold;
    CoinPickup coin;
    public bool sharpenActive;
    public bool bashActive;
    public bool casted;
    public bool casted1;
    public int tempDam;


    public bool SkillMenu;

    public int skillpoints;
    public int bashLevel;
    public int sharpenLevel;
    public bool OffenseMenu;
    public bool DefenseMenu;
    public int DefAuraLevel;
    public bool DefAuraActive;
    public int baseTempDam;
    public int tempDef;

    public bool FireMenu;
    public bool IceMenu;

    [SerializeField]
    public static bool MageSelected;
    [SerializeField]
    public static bool WarriorSelected;




    public bool fireballActive;
    public bool IceBallActive;
    public int IceBallLevel;
    public int IceBallDam;
    public int fireBallLevel;
    public int FireBallDam;
    // Use this for initialization
    void Start ()
    {
        fireBallLevel = 1;
        if (MageSelected == true)
        {
            
        

            str = 20;
            dex = 5;
            vit = 7;
            mag = 14;
            StatsMenu = false;
            SkillMenu = false;
			WeaponDamage = EquipedWeapon.MaxDamage;
            damageReduction = 0;

            fireballActive = false;
            IceBallActive = false;


            fireBallLevel = 1;
            IceMenu = false;
            FireMenu = false;
}

        if (WarriorSelected == true)
        {
          
            

            str = 12;
            dex = 8;
            vit = 10;
            mag = 4;
            StatsMenu = false;
            healthpots = 5;
            gold = 50;
            WeaponDamage = 6;  //hard value for testing only, this should come from the weapon tables.


            casted = false;
            casted1 = false;
            bashActive = false;
            tempDam = WeaponDamage;
            DefAuraActive = false;
            SkillMenu = false;
            OffenseMenu = false;
            DefenseMenu = false;
            bashLevel = 0;
            sharpenLevel = 0;
            DefAuraLevel = 0;

            tempDef = damageReduction;
            manaSpent = 0;

        }
        statpoints = 0;
        skillpoints = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {

		if(EquipedChest != null)
		{
			damageReduction = EquipedChest.Defence;
		}

		if (EquipedWeapon != null)
		{
			WeaponDamage = EquipedWeapon.MaxDamage;
		}
		else
		{
			WeaponDamage = 0;
		}
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
        if (HealthPoints > MaxHealth)
        {
            HealthPoints = MaxHealth;
        }
        ManaPoints = (mag * 5) - manaSpent;

        basedamage = str / 2;

        baseTempDam = basedamage;
        if (WarriorSelected == true)
        {
            sharpen();
        }
        if (damageTaken < 0)
        {
            damageTaken = 0;
        }
        if (Input.GetButtonUp("Toggle Character Window"))
        {
            Messenger.Broadcast("ToggleCharacterWindow");
        }
        if (Input.GetButtonUp("ToggleInventory"))
        {
            Messenger.Broadcast("ToggleInventory");
        }

    }

    //-------------------------------------------WARRIOR CLAsS STUFF---------------------------------------------------------------
    public void sharpen()
    {
        temptime += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && sharpenActive == true)
        {
            temptime = 0;
            manaSpent += 5;
            if (casted == false && sharpenLevel == 1) { casted = true; WeaponDamage += 2; }
            if (casted == false && sharpenLevel == 2) { casted = true; WeaponDamage += 4; }
            if (casted == false && sharpenLevel == 3) { casted = true; WeaponDamage += 8; }
        }
        if (temptime >= 30) { WeaponDamage = tempDam; casted = false; temptime = 0; }

    }
    public void bash()
    {

        if (bashLevel == 1)
        {
            basedamage = basedamage * 2;
            manaSpent = manaSpent + 3;
        }
        if (bashLevel == 2)
        {
            basedamage = basedamage * 3;
            manaSpent = manaSpent + 7;
        }

    }

    public void defAura()
    {
        if (DefAuraActive == true)
        {

            if (casted1 == false) { casted1 = true; damageReduction = damageReduction + 2;  }


        }
      
    }
    //----------------------------------------------------------------------------------------------------------------------------------------------

    //----------------------------------------------------Mage SKILLS----------------------------------------------------------------------------------

    public void fireBall()
    {
        if (fireBallLevel == 1)
        {
            FireBallDam = 15;
            manaSpent += 5;
        }
        if (fireBallLevel == 2)
        {
            FireBallDam = 25;
            manaSpent += 10;
        }
        if (fireBallLevel == 3)
        {
            FireBallDam = 30;
            manaSpent += 11;
        }
        if (fireBallLevel == 4)
        {
            FireBallDam = 35;
            manaSpent += 12;
        }
        if (fireBallLevel == 5)
        {
            FireBallDam = 50;
            manaSpent += 13;
        }
        Debug.Log("I CASTED THE BALLS OF FIRE");
    }
    public void IceBall()
    {
        if (IceBallLevel == 1)
        {
            IceBallDam = 10;
            manaSpent += 5;
        }
        if (IceBallLevel == 2)
        {
            IceBallDam = 15;
            manaSpent += 10;
        }
        if (IceBallLevel == 3)
        {
            IceBallDam = 22;
            manaSpent += 11;
        }
        if (IceBallLevel == 4)
        {
            IceBallDam = 30;
            manaSpent += 12;
        }
        if (IceBallLevel == 5)
        {
            IceBallDam = 44;
            manaSpent += 13;
        }
        Debug.Log("I CASTED THE BALLS OF ICE");
    }



    void OnGUI()
    {
        GUI.Button(new Rect(0, 455, 150, 50), "GOLD:" + gold);
        if (GUI.Button(new Rect(450, 600, 200, 50), "HpPots:" + healthpots))
        {
            if (healthpots > 0 && damageTaken > 0)
            {
                healthpots = healthpots - 1;
                damageTaken = damageTaken - 10;
            }

        }
        GUI.Button(new Rect(0, 575, 150, 50), "Health:" + HealthPoints);
        GUI.Button(new Rect(1000, 575, 100, 50), "Mana:" + ManaPoints);


        //on top right side have a button to show main menu toggle 
        if (GUI.Button(new Rect(1060, 0, 40, 40), "S:" + statpoints))
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
                if (statpoints > 0)
                {
                    statpoints = statpoints - 1;
                    str = str + 1;
                }

            }
            //Exit to Menu button
            if (GUI.Button(new Rect(450, 260, 200, 50), "Dex:" + dex))
            {
                if (statpoints > 0)
                {
                    statpoints = statpoints - 1;
                    dex = dex + 1;
                }
            }
            //Quit button
            if (GUI.Button(new Rect(450, 320, 200, 50), "Vit:" + vit))
            {
                if (statpoints > 0)
                {
                    statpoints = statpoints - 1;
                    vit = vit + 1;
                }
            }
            if (GUI.Button(new Rect(450, 380, 200, 50), "Mag:" + mag))
            {
                if (statpoints > 0)
                {
                    statpoints = statpoints - 1;
                    mag = mag + 1;
                }
            }

        }
        if (GUI.Button(new Rect(1000, 0, 40, 40), "Skills:" + skillpoints))
        {
            if (!SkillMenu)
            {
                SkillMenu = true;
                Time.timeScale = 0;
            }
            else
            {
                SkillMenu = false;
                Time.timeScale = 1;
            }
        }
        if (SkillMenu)
        {
            if (MageSelected == true)
            {
                if (GUI.Button(new Rect(450, 200, 200, 50), "Fire:"))
                {
                    if (!FireMenu)
                    { FireMenu = true; SkillMenu = false; }
                    else { FireMenu = false; }
                }

                if (GUI.Button(new Rect(450, 260, 200, 50), "Ice:"))
                {
                    if (!IceMenu)
                    { IceMenu = true; SkillMenu = false; }
                    else { IceMenu = false; }
                }
            }
            if (WarriorSelected == true)
            {
                if (GUI.Button(new Rect(450, 200, 200, 50), "Offense:"))
                {
                    if (!OffenseMenu)
                    { OffenseMenu = true; SkillMenu = false; }
                    else { OffenseMenu = false; }
                }
                if (GUI.Button(new Rect(450, 260, 200, 50), "Defense:"))
                {
                    if (!DefenseMenu)
                    { DefenseMenu = true; SkillMenu = false; }
                    else { DefenseMenu = false; }
                }
            }
        }

        if (OffenseMenu)
        {
            SkillMenu = false;
            if (GUI.Button(new Rect(450, 200, 200, 50), "Bash:" + bashLevel))
            {
                if (bashLevel >= 1)
                {
                    bashActive = true;
                    sharpenActive = false;
                }
                if (skillpoints > 0)
                {
                    skillpoints = skillpoints - 1;
                    bashLevel = bashLevel + 1;
                }
            }
            if (GUI.Button(new Rect(450, 260, 200, 50), "Sharpen:" + sharpenLevel))
            {
                if (sharpenLevel >= 1)
                {
                    sharpenActive = true;
                    bashActive = false;
                }
                if (skillpoints > 0)
                {
                    skillpoints = skillpoints - 1;
                    sharpenLevel = sharpenLevel + 1;
                }
            }
            if (GUI.Button(new Rect(450, 320, 200, 50), "Close"))
            { OffenseMenu = false; }
        }
        if (DefenseMenu)
        {
            SkillMenu = false;
            if (GUI.Button(new Rect(450, 200, 200, 50), "Defensive Aura:" + DefAuraLevel))
            {
                if (DefAuraLevel >= 1)
                {
                    DefAuraActive = true;
                    bashActive = false;
                    sharpenActive = false;
                }
                if (skillpoints > 0)
                {
                    skillpoints = skillpoints - 1;
                    DefAuraLevel = DefAuraLevel + 1;
                }
            }
            if (GUI.Button(new Rect(450, 320, 200, 50), "Close"))
            { DefenseMenu = false; }
        }

        if (FireMenu)
        {
            SkillMenu = false;
            if (GUI.Button(new Rect(450, 200, 200, 50), "FireBall:" + fireBallLevel))
            {
                if (fireBallLevel >= 1)
                {
                    fireballActive = true;
                    IceBallActive = false;
                }
                if (skillpoints > 0)
                {
                    skillpoints = skillpoints - 1;
                    fireBallLevel = fireBallLevel + 1;
                }
            }
            if (GUI.Button(new Rect(450, 320, 200, 50), "Close"))
            { FireMenu = false; }
        }

        if (IceMenu)
        {
            SkillMenu = false;
            if (GUI.Button(new Rect(450, 200, 200, 50), "IceBall:" + IceBallLevel))
            {
                if (IceBallLevel >= 1)
                {
                    fireballActive = false;
                    IceBallActive = true;
                }
                if (skillpoints > 0)
                {
                    skillpoints = skillpoints - 1;
                    IceBallLevel = IceBallLevel + 1;
                }
            }
            if (GUI.Button(new Rect(450, 320, 200, 50), "Close"))
            { IceMenu = false; }
        }

    }
}
