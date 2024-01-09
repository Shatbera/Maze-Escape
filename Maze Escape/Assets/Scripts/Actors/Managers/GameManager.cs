using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Player Player;

    [SerializeField] private PlayerStart m_PlayerStart;
    [SerializeField] private PlayerFinish m_PlayerFinish;
    [SerializeField] private UIManager m_UiManager;
    [SerializeField] private Maze m_Maze;

    public event Action Event_Defeat;
    public event Action Event_Victory;
  

    private void Awake()
    {
        m_PlayerFinish.Event_PlayerEntered += Victory;
        Player.Event_PlayerDied += Defeat;
        m_UiManager.Initialize(this);
    }
    public void StartGame()
    {
        m_Maze.GenerateMaze();
        m_PlayerStart.SpawnPlayer(Player);
    }

    public void Victory()
    {
        Event_Victory?.Invoke();
        Player.gameObject.SetActive(false);
    }
    public void Defeat()
    {
        Event_Defeat?.Invoke();
    }
}
