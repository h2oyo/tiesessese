using UnityEngine;
using System.Collections;

public class EnemeyTesting : MonoBehaviour {

    
    
    int ArmorValue;
   public int hp;

    Transform target; // target is the player on this script
    Transform mytransform;  // this is the enemy's transform
   
    public LevelSystem playerLevel;
    public PlayerClass player;

	Transform Chest;

    // Use this for initialization
    void Start ()
    {
        hp = 75;
        ArmorValue = 1;
        mytransform = transform;
        target = GameObject.FindGameObjectWithTag("Player").transform;
		Chest = Resources.Load<Transform> ("Chest");
	}


    // Update is called once per frame
    void Update()
    {

        HpAdjust();
         Debug.Log(hp);
        if (hp <= 0)
        {
            playerLevel.exp = playerLevel.exp + 25;
            // golddrop();
			Itemdrop();
            Destroy(this.gameObject);



        }
    }


	void Itemdrop()
	{
		Instantiate (Chest, transform.position, Quaternion.identity);
	}
    void HpAdjust()
    {
        if(playerLevel.lvlupCalled == true)
        {
            if (playerLevel.level == 1) { hp = 75; }
            if (playerLevel.level == 2) { hp = 110; }
            if (playerLevel.level == 3) { hp = 150; }
            if (playerLevel.level == 4) { hp = 200; }
            if (playerLevel.level == 5) { hp = 240; }
            if (playerLevel.level == 6) { hp = 300; }
        }
    }
    private float Distance()
    {
        return Vector3.Distance(mytransform.position, target.position);
    }

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(1) && player.bashActive == true)
        {
            player.bash();
            if (Distance() < 3)
            {
                //  click.moveSpeed = 0;
                hp = hp - Mathf.Abs(ArmorValue - (player.basedamage + player.WeaponDamage));
            }

        
        }
    }
    void OnMouseDown()
    {
        if (Distance() < 3)
        {
            //  click.moveSpeed = 0;
            hp = hp - Mathf.Abs(ArmorValue - (player.basedamage + player.WeaponDamage));
          
        }

      

    }

   }
