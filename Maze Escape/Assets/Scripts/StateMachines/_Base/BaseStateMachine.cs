using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseStateMachine : MonoBehaviour
{
    private readonly Dictionary<Type, Component> m_CachedComponents = new();
    [SerializeField] private BaseState InitialState;
    private BaseState m_CurrentState;

    private void Awake()
    {
        m_CurrentState= InitialState;
    }
    private void Update()
    {
        m_CurrentState.UpdateState(this);
    }

    public void SwitchState(BaseState newState)
    {
        m_CurrentState.ExitState(this);
        m_CurrentState = newState;
        m_CurrentState.EnterState(this);
    }
    public T GetCachedComponent<T>() where T : Component
    {
        if (m_CachedComponents.ContainsKey(typeof(T)))
            return m_CachedComponents[typeof(T)] as T;

        var component = GetComponent<T>();
        if (component != null)
        {
            m_CachedComponents.Add(typeof(T), component);
        }
        return component;
    }
}
