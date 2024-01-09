using System;
using UnityEngine;

public class PlayerFinish : MonoBehaviour
{
    public event Action Event_PlayerEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Event_PlayerEntered?.Invoke();
        }
    }
}
