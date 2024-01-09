using UnityEngine;

public class Sensor : MonoBehaviour
{
    [HideInInspector] public Player Target;
    public bool IsPlayerDetected => Target != null && Target.isActiveAndEnabled;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = other.GetComponent<Player>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Target = null;
        }
    }

    public bool IsPlayerInAttackRange(float attackRange)
    {
        if (!IsPlayerDetected)
            return false;
        return Vector3.Distance(transform.position, Target.transform.position) <= attackRange;
    }

    /*
    public Player GetPlayerInRange(float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider col in hitColliders)
        {
            if (col.CompareTag("Player"))
            {
                return col.GetComponent<Player>();
            }
        }

        return null;
    }*/
}
