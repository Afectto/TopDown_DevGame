using System;
using UnityEngine;
using UnityEngine.UI;

public interface ILisener
{
    void AddAllListeners();
    void RemoveAllListeners();
}

public class Health : MonoBehaviour, ILisener
{
    [SerializeField] private Image fillHealthBar;
    private float _currentHealth;
    private bool _isAlreadyDie;
    private float _maxHealth = 10;
    private GameObject _owner;

    public Action OnDead;

    public void Start()
    {
        _owner = GetComponentInParent<Enemy>().gameObject;
        _currentHealth = _maxHealth;
        _isAlreadyDie = false;
        AddAllListeners();
    }

    public void SetMaxHeath(float value)
    {
        _maxHealth = value;
    }

    public void AddAllListeners()
    {
        EventManager.Instance.OnDamageTaken += OnDamageTaken;
    }

    public void RemoveAllListeners()
    {
        // ReSharper disable once DelegateSubtraction
        EventManager.Instance.OnDamageTaken -= OnDamageTaken;
    }

    private void OnDamageTaken(GameObject thisOwner, float damage)
    {
        if (_owner == thisOwner)
        {
            Damage(damage);
        }
    }

    private void Damage(float damage)
    {
        if(damage <= 0 ) return;
        
        _currentHealth -= damage;

        if (!_isAlreadyDie && _currentHealth <= 0)
        {
            _isAlreadyDie = true;
            _currentHealth = 0;
            OnDead?.Invoke();
        }

        UpdateHealthLine();
    }
    
    private void UpdateHealthLine()
    {
        fillHealthBar.fillAmount = _currentHealth / _maxHealth;
    }

    public void OnDestroy()
    {
        RemoveAllListeners();
    }
}
