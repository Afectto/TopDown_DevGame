using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTransform;
    private float _speed = 1;

    private void Awake()
    {
        _playerTransform = FindFirstObjectByType<Player>().transform;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, Time.deltaTime * _speed);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}
