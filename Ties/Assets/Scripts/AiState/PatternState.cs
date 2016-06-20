using UnityEngine;
using System.Collections;
public class PatternState : MonoBehaviour
{

  

    public PlayerClass player;


    public float sightRange = 20f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);




    [HideInInspector]  public Transform chaseTarget;
    public EnemyState currentState;
    [HideInInspector]  public ChaseState chaseState;
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public AttackState attackState;
    [HideInInspector] public PatrolState patrolstate;
    [HideInInspector] public NavMeshAgent navMeshAgent;


    public void Awake()
    {

        chaseState = new ChaseState(this);
        idleState = new IdleState(this);
        // patrolstate = new PatrolState(this);
        attackState = new AttackState(this);

        navMeshAgent = GetComponent<NavMeshAgent>();

    }


    // Use this for initialization
    void Start()
    {

        currentState = idleState;



    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        // Debug.Log(currentState);
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

}
