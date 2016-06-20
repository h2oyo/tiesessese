using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {





   // [SerializeField]
   // private float range = 10.0f;

    private Transform t;
    private Transform player;

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        //if (player)
        //    print(player.name + " is " + Distance().ToString() + " units from " + t.name);

        //else
        //    print("Player not found!");
    }

    private float Distance()
    {
        return Vector3.Distance(t.position, player.position);
    }


    void OnMouseDown()
    {
        if (Distance() < 3)
        {
            Destroy(this.gameObject);
        }
    }
}
