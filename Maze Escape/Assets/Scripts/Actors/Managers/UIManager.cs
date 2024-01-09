using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameOverPanel m_GameOverPanel;
    [SerializeField] private HealthBar m_HealthBar;
    public void Initialize(GameManager gameManager)
    {
        m_GameOverPanel.Initialize(gameManager);
        m_HealthBar.Initialize(gameManager.Player);
    }
}
