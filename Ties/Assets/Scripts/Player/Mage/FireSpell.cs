using UnityEngine;
using System.Collections;

public class FireSpell : MonoBehaviour
{
    public float castTime;
    Rigidbody rb;
    Transform playerT;
    public PlayerClass player;
    GameObject prefab;

    float spawnDistance = 0.8f;

    float speed = 20.0f;


    // Use this for initialization
    void Start()
    {
        prefab = Resources.Load("Spell") as GameObject;
        rb = GetComponent<Rigidbody>();
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        player = playerT.GetComponent<PlayerClass>();
    }

    // Update is called once per frame
    void Update()
    {
        castTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && castTime >= .5f && player.fireballActive == true)
        {
            player.fireBall();
            firespell();
            castTime = 0;
        }
        if (Input.GetMouseButtonDown(1) && castTime >= .35f && player.IceBallActive == true)
        {
            player.IceBall();
            firespell();
            castTime = 0;
        }
    }

    void firespell()
    {
        GameObject fireball = GameObject.Instantiate(prefab, transform.position + spawnDistance
                                  * transform.forward, transform.rotation) as GameObject;

        Rigidbody fireRigidbody = fireball.GetComponent<Rigidbody>();

        fireRigidbody.AddForce((transform.forward * speed), ForceMode.Impulse);
    }

}