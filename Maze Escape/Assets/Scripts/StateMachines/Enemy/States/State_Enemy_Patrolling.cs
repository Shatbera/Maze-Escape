using UnityEngine;

[CreateAssetMenu(fileName = "EnemyPatrolling", menuName = "ScriptableObjects/FSM/States/EnemyPatrolling")]
public class State_Enemy_Patrolling : BaseState
{
    public State_Enemy_Chasing State_Chasing;
    public override void EnterState(BaseStateMachine stateMachine)
    {
        
    }

    public override void ExitState(BaseStateMachine stateMachine)
    {
        
    }

    public override void UpdateState(BaseStateMachine stateMachine)
    {
        stateMachine.GetCachedComponent<PatrolPath>().FollowPath();
        Sensor sensor = stateMachine.GetCachedComponent<Sensor>();
        if(sensor.IsPlayerDetected)
        {
            stateMachine.SwitchState(State_Chasing);
        }
    }
}
