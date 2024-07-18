using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]private float speed = 5f;
    private float _baseSpeed;
    private Vector2 _maxLimits;
    private Vector2 _minLimits;
    
    public float rotationSpeed = 180f;

    private void Awake()
    {
        _baseSpeed = speed;
        _maxLimits = Utils.MaxLimitsArena;
        _minLimits = Utils.MinLimitsArena;
    }

    private void Start()
    {
        EventManager.Instance.OnEnterSlowZone += Slow;
        EventManager.Instance.OnExitSlowZone += Normal;
    }

    private void Normal()
    {
        speed = _baseSpeed;
    }

    private void Slow(float value)
    {
        speed *= value;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * speed * Time.deltaTime;
        Vector3 newPos = transform.position + movement;

        newPos.x = Mathf.Clamp(newPos.x, _minLimits.x, _maxLimits.x);
        newPos.y = Mathf.Clamp(newPos.y, _minLimits.y, _maxLimits.y);

        transform.position = newPos;
        if (Input.GetMouseButton(0))
        {
            Rotation();
        }
    }

    private void Rotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        EventManager.Instance.OnEnterSlowZone -= Slow;
        EventManager.Instance.OnExitSlowZone -= Normal;
    }
}
