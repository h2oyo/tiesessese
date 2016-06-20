using UnityEngine;
using System.Collections;

public class Barrels : MonoBehaviour
{

    public LevelSystem playerLevel;


    public Transform t;
    private Transform player;
    float BarHit;
    int hp;
    int gold;
    int dongers;
    int ArmorValue;
   public WarriorClass warrior;
    Transform weapons1;
   

   
    

    void Awake()
    {
        ArmorValue = 5;
        hp = 1;
        BarHit = 3;
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        weapons1 = Resources.Load<Transform>("Coin");
    
    
    }

    private void Update()
    {
        

    }
    private float Distance()
    {
        return Vector3.Distance(t.position, player.position);
    }
    void golddrop()
    {
        {
            Instantiate(weapons1, transform.position, Quaternion.identity);

        }
       
    }
   
    void OnMouseDown()
    {
        if (Distance() < 3)
        {
            //  click.moveSpeed = 0;
            hp = hp - Mathf.Abs(ArmorValue - (warrior.basedamage + warrior.WeaponDamage));
        }

        if (hp <= 0)
        {
            int randomTemp = Random.Range(1, 100);
            if(randomTemp > 1)
            {

    
            } 
            
            
            Destroy(this.gameObject);


        }


    }
}

