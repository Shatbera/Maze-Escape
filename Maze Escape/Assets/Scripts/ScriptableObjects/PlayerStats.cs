using UnityEngine;

[CreateAssetMenu(fileName = "new PlayerStats", menuName = "ScriptableObjects/Player/Stats")]
public class PlayerStats : ScriptableObject
{
    public int Health = 5;
    public int MoveSpeed = 5;
}
