using UnityEngine;
using UnityEngine.AI;

public class PatrolPath : MonoBehaviour
{
    [SerializeField] private Transform[] m_WayPoints;
    [SerializeField] private NavMeshAgent m_Agent;

    private int m_CurrentPointIndx = 0;
    public void FollowPath()
    {
        Transform currentWaypoint = m_WayPoints[m_CurrentPointIndx];

        m_Agent.SetDestination(currentWaypoint.transform.position);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f + m_Agent.stoppingDistance)
        {
            m_CurrentPointIndx = (m_CurrentPointIndx + 1) % m_WayPoints.Length;
        }
    }
}
