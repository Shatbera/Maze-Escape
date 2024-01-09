using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float m_Speed = 5.0f;
    [SerializeField] private Joystick m_Joystick;
    [SerializeField] private CharacterController m_CharacterController;
    [SerializeField] private Player m_Player;
    private void Awake()
    {
        m_Speed = m_Player.Stats.MoveSpeed;
    }
    private void Update()
    {
        Vector3 direction = new Vector3(m_Joystick.Horizontal, 0, m_Joystick.Vertical).normalized;

        Vector3 velocity = direction * m_Speed;

        m_CharacterController.Move(velocity * Time.deltaTime);

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }

    public void EnableMovements(bool enable)
    {
        m_CharacterController.enabled = enable;
        m_Joystick.gameObject.SetActive(enable);
    }
}
