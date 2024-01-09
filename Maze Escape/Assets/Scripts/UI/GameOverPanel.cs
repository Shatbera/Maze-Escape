using TMPro;
using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_GameOverTxt;

    private GameManager m_GameManager;
    public void Initialize(GameManager gameManager)
    {
        m_GameManager = gameManager;
        gameManager.Event_Victory += () => DisplayGameOver(true);
        gameManager.Event_Defeat += () => DisplayGameOver(false);
    }

    public void RestartBtn()
    {
        m_GameManager.StartGame();
        Hide();
    }
    private void DisplayGameOver(bool victory)
    {
        m_GameOverTxt.text = victory ? "Victory" : "Defeat";
        Show();
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
