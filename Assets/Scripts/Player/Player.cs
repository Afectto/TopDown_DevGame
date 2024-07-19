using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private SpriteRenderer skin;
    private PlayerMovement _playerMovement;
    private bool _isInvulnerability;
    
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _isInvulnerability = false;
        EventManager.Instance.OnEnterDeadZone += Dead;
    }

    public void IncreaseSpeed(float speed)
    {
        skin.color = Color.yellow;
        _playerMovement.AddMultiplier(speed);
    }
    
    public void DecreaseSpeed(float speed)
    {
        skin.color = Color.white;
        _playerMovement.RemoveMultiplier(speed);
    }

    public void ChangeInvulnerability(bool value)
    {
        _isInvulnerability = value;
        skin.color = value ? Color.green : Color.white;
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {        
        if (other.CompareTag("Enemy") && !_isInvulnerability)
        {
            Dead();
        }
    }

    private void Dead()
    {
        EventManager.Instance.OnDeadPlayer?.Invoke();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnEnterDeadZone -= Dead;
    }
}
