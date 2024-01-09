using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    [SerializeField] private Transform m_SpawnPoint;

    public void SpawnPlayer(Player player)
    {
        player.Respawn(m_SpawnPoint);      
    }
}
