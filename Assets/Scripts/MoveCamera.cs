using UnityEngine;

public class MoveCamera : MonoBehaviour
{    
    private Transform _player;
    private Vector2 _maxLimits;
    private Vector2 _minLimits;
    private const float Smoothness = 0.5f;

    private Vector3 _offset;

    void Start()
    {
        _maxLimits = new Vector2(3.68f, 7.32f);
        _minLimits = new Vector2( -3.68f, -7.32f);
        _player = FindFirstObjectByType<Player>().transform;
        _offset = transform.position - _player.position;
    }

    void LateUpdate()
    {
        Vector3 targetPos = _player.position + _offset;
        targetPos.x = Mathf.Clamp(targetPos.x, _minLimits.x, _maxLimits.x);
        targetPos.y = Mathf.Clamp(targetPos.y, _minLimits.y, _maxLimits.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, Smoothness);
    }
}
