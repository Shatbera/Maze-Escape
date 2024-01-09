using UnityEngine;

[CreateAssetMenu(fileName = "new EnemyStats", menuName = "ScriptableObjects/Enemy/Stats")]
public class EnemyStats : ScriptableObject
{
    public int Damage = 1;
    public float AttackRange = 2;
    public float AttackSpeed = 10;
    public float MoveSpeed = 3.5f;
    public float VisionRadius = 10;
}
