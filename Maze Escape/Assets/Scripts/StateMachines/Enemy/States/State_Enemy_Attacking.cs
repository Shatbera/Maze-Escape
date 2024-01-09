using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyAttacking", menuName = "ScriptableObjects/FSM/States/EnemyAttacking")]
public class State_Enemy_Attacking : BaseState
{
    public State_Enemy_Patrolling State_Patrolling;
    public State_Enemy_Chasing State_Chasing;
    public override void EnterState(BaseStateMachine stateMachine)
    {
        Sensor sensor = stateMachine.GetCachedComponent<Sensor>();
        EnemyStats stats = stateMachine.GetCachedComponent<Enemy>().Stats;
        stateMachine.StartCoroutine(AttackCoroutine(stateMachine, stats, sensor));
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        Player target = stateMachine.GetCachedComponent<Sensor>().Target;
        stateMachine.transform.LookAt(target.transform.position);
    }

    private IEnumerator AttackCoroutine(BaseStateMachine stateMachine, EnemyStats stats, Sensor sensor)
    {
        WaitForSeconds delay = new WaitForSeconds(10 / stats.AttackSpeed);
        bool playerDied = false;
        while (sensor.IsPlayerInAttackRange(stats.AttackRange))
        {
            yield return delay;
            if (sensor.Target.GetDamage(stats.Damage))
            {
                playerDied = true;
                break;
            }
        }
        stateMachine.SwitchState(playerDied ? State_Patrolling : State_Chasing);
    }
}
