using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {
    public int coins;
    WarriorClass war;
    private Transform t;
    private Transform player;
 
    // Use this for initialization
    void Start () {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        war = player.GetComponent<WarriorClass>();
        coins = Random.Range(1, 5);

    }
	
	// Update is called once per frame
	void Update () {
       
    }
    
    public float Distance()
    {
        return Vector3.Distance(t.position, player.position);
    }
    void OnMouseDown()
    {
        if (Distance() < 3)
        {
            
            war.gold = war.gold + coins;
           Destroy(this.gameObject);
        }

    
    }
    void OnGUI()
    {
       
    }
}
