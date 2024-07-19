using UnityEngine;

public class Player : MonoBehaviour
{
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
        _playerMovement.AddMultiplier(speed);
    }
    
    public void DecreaseSpeed(float speed)
    {
        _playerMovement.RemoveMultiplier(speed);
    }

    public void ChangeInvulnerability(bool value)
    {
        _isInvulnerability = value;
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
