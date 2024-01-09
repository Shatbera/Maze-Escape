
using UnityEngine;
public abstract class BaseState : ScriptableObject
{
    public abstract void EnterState(BaseStateMachine stateMachine);
    public abstract void UpdateState(BaseStateMachine stateMachine);
    public abstract void ExitState(BaseStateMachine stateMachine);

}
