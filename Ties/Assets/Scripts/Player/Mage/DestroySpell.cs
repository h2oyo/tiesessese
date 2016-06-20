using UnityEngine;
using System.Collections;

public class DestroySpell : MonoBehaviour
{
    Transform map;
    Transform enemyT;
    Transform playerT;
    public PlayerClass player;
    public EnemeyTesting enemy;
    float lifetime;
    float SlowTimer;

    // Use this for initialization
    void Start()
    {
        enemyT = GameObject.FindGameObjectWithTag("enemy").transform;
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        map = GameObject.FindGameObjectWithTag("GAMEMAP").transform;
        player = playerT.GetComponent<PlayerClass>();
        enemy = enemyT.GetComponent<EnemeyTesting>();
        lifetime = 2.0f;
    }

    void OnCollisionEnter(Collision col)
    {
        EnemeyTesting enemy = col.collider.GetComponent<EnemeyTesting>();

        if (enemy != null)
        {
            if (player.fireballActive == true)
            {
                enemy.hp = enemy.hp - player.FireBallDam;
            }
            if (player.IceBallActive == true)
            {
                enemy.hp = enemy.hp - player.IceBallDam;
                //enemy.
            }
            Destroy(gameObject);
        }

      //  if(map != null)
        //{ Destroy(gameObject); }
        Barrels barrel = col.collider.GetComponent<Barrels>();

        if (barrel != null)
        {
            Destroy(gameObject);
        }

        Chest chest = col.collider.GetComponent<Chest>();

        if (chest != null)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SlowTimer += Time.deltaTime;
        lifetime -= 1.0f * Time.deltaTime;

        if (lifetime <= 0)
        {
            Destroy(gameObject, lifetime);
        }
    }
}