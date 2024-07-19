using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTransform;
    private float _speed = 1;

    private void Awake()
    {
        var player = FindFirstObjectByType<Player>();
        if (player)
        {
            _playerTransform = player.transform;
        }
    }

    void Update()
    {
        if(!_playerTransform) return;
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, Time.deltaTime * _speed);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
