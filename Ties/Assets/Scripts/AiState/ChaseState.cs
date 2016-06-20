using UnityEngine;
using System.Collections;

public class ChaseState : EnemyState
{


    private readonly PatternState enemy;


    public ChaseState(PatternState patternStateEnemy)
    {

        enemy = patternStateEnemy;

    }


    public void OnTriggerEnter(Collider other)
    {

    }

    public void UpdateState()
    {
        Search();
        Chase();

    }

    public void toPatrol()
    {
        enemy.currentState = enemy.patrolstate;
    }

    public void toIdle()
    {

        enemy.currentState = enemy.idleState;

    }


    public void toAttack()
    {

        enemy.currentState = enemy.attackState;

    }

    public void toChase()
    {

    }

    private void Search()
    {
        enemy.chaseTarget = GameObject.FindWithTag("Player").transform;
        RaycastHit hit;
        Vector3 enemyToTarget = (enemy.chaseTarget.position + enemy.offset) - enemy.eyes.transform.position;
        if (Physics.Raycast(enemy.eyes.transform.position, enemyToTarget, out hit, enemy.sightRange) && hit.collider.CompareTag("Player"))
        {
            enemy.chaseTarget = hit.transform;

        }
        //  else
        // {
        //     toIdle();
        // }

    }

    private void Chase()
    {
        enemy.navMeshAgent.destination = enemy.chaseTarget.position;
        enemy.navMeshAgent.Resume();
        if (Vector3.Distance(enemy.navMeshAgent.destination, enemy.chaseTarget.position) < 4)
        {
            toAttack();
        }

    }



}
