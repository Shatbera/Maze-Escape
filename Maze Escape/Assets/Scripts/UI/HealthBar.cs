using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image m_FillImg;
    private ObservedValue<int> m_PlayerHealth;
    private int m_MaxHealth;
    public void Initialize(Player player)
    {
        m_PlayerHealth = player.CurrentHealth;
        m_MaxHealth = player.Stats.Health;
        m_PlayerHealth.ValueChanged += UpdateFill;
        UpdateFill();
    }

    private void UpdateFill()
    {
        m_FillImg.fillAmount = (float)m_PlayerHealth.Value / m_MaxHealth;
    }
}
