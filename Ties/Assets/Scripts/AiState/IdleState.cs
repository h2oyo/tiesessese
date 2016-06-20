using UnityEngine;
using System.Collections;

public class IdleState : EnemyState
{
    private readonly PatternState enemy;


    public IdleState(PatternState patternStateEnemy)
    {
        enemy = patternStateEnemy;

    }


    public void UpdateState()
    {
        
        Search();
    }

    public void toPatrol()
    {

    }

    public void toIdle()
    {
   

    }

    public void toChase()
    {
        enemy.currentState = enemy.chaseState;

    }

    public void toAttack()
    {



    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        { toChase(); }
    }

    private void Search()
    {
        enemy.chaseTarget = GameObject.FindWithTag("Player").transform;
        RaycastHit hit;
        if (Physics.Raycast(enemy.eyes.transform.position, enemy.eyes.transform.forward, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;
            toChase();
        }

    }

}
