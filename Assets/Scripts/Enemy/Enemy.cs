using UnityEngine;

public class Enemy : MonoBehaviour, ILisener
{
    [SerializeField]private SpriteRenderer _skin;
    private Health _health;
    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _health = GetComponentInChildren<Health>();
        _enemyMovement = GetComponent<EnemyMovement>();

    }

    public void Initialize(EnemyStats stats)
    {
        _health.SetMaxHeath(stats.Health);
        _enemyMovement.SetSpeed(stats.Speed);
        _skin.color = stats.Skin.color;
    }

    private void OnEnable()
    {
        AddAllListeners();
    }

    private void OnDead()
    {
        Destroy(gameObject);
    }
    
    public void AddAllListeners()
    {
        _health.OnDead += OnDead;
    }

    public void RemoveAllListeners()
    {
        _health.OnDead -= OnDead;
    }
    private void OnDisable()
    {
        RemoveAllListeners();
    }
}