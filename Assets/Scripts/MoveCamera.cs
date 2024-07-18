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
        float cameraHeight = Constants.GetCameraHeight();
        float cameraWidth = Constants.GetCameraWight();
        
        _maxLimits = Constants.MaxLimitsArena - new Vector2(cameraWidth, cameraHeight);
        _minLimits =  Constants.MinLimitsArena + new Vector2(cameraWidth, cameraHeight);
        
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
