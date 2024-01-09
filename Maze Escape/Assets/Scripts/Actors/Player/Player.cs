using System;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    public PlayerStats Stats;

    public event Action Event_PlayerDied;
    public PlayerController PlayerController;

    public ObservedValue<int> CurrentHealth = new();
    public void Respawn(Transform spawnPoint)
    {
        transform.SetPositionAndRotation(spawnPoint.position, spawnPoint.rotation);
        gameObject.SetActive(true);
        CurrentHealth.Value = Stats.Health;
    }
    public bool GetDamage(int damage)
    {
        damage = Mathf.Clamp(damage, 0, CurrentHealth.Value);
        CurrentHealth.Value -= damage;
        if(CurrentHealth.Value <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    private void Die()
    {
        gameObject.SetActive(false);
        Event_PlayerDied?.Invoke();
    }
}
