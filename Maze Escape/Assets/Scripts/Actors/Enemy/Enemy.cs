using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyStats Stats;

    [SerializeField] private SphereCollider m_Collider;
    [SerializeField] private NavMeshAgent m_Agent;

    private void Awake()
    {
        m_Collider.radius = Stats.VisionRadius;
        m_Agent.speed = Stats.MoveSpeed;
    }
}
