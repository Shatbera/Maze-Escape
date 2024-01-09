using UnityEngine.AI;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyChasing", menuName = "ScriptableObjects/FSM/States/EnemyChasing")]
public class State_Enemy_Chasing : BaseState
{
    public State_Enemy_Patrolling State_Patrolling;
    public State_Enemy_Attacking State_Attacking;
    public override void EnterState(BaseStateMachine stateMachine)
    {
        
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        NavMeshAgent agent = stateMachine.GetCachedComponent<NavMeshAgent>();
        Sensor sensor = stateMachine.GetCachedComponent<Sensor>();
        EnemyStats stats = stateMachine.GetCachedComponent<Enemy>().Stats;
        if (sensor.IsPlayerDetected)
        {
            agent.SetDestination(sensor.Target.transform.position);
            if (sensor.IsPlayerInAttackRange(stats.AttackRange))
            {
                stateMachine.SwitchState(State_Attacking);
            }
        }
        else
        {
            stateMachine.SwitchState(State_Patrolling);
        }
    }
}
