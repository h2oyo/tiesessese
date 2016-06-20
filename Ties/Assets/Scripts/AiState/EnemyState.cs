using UnityEngine;
using System.Collections;

public interface EnemyState
{


    void UpdateState();

    void toPatrol();

    void toIdle();

    void toChase();

    void toAttack();

    void OnTriggerEnter(Collider other);








}
